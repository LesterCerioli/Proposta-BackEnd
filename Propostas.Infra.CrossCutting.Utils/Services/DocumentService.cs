namespace Propostas.Infra.CrossCutting.Utils.Services
{
    using DocumentFormat.OpenXml;
    using DocumentFormat.OpenXml.Packaging;
    using DocumentFormat.OpenXml.Wordprocessing;
    using OpenXmlPowerTools;
    using Propostas.Infra.CrossCutting.Utils.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using A = DocumentFormat.OpenXml.Drawing;
    using DW = DocumentFormat.OpenXml.Drawing.Wordprocessing;
    using PIC = DocumentFormat.OpenXml.Drawing.Pictures;
    using SixLabors.ImageSharp.PixelFormats;
    using SixLabors.ImageSharp;
    using Microsoft.Office.Interop.Word;
    using SixLabors.ImageSharp.Processing;
    using RestSharp;
    using System.Text;
    using Newtonsoft.Json;

    public class DocumentService : IDocumentService
    {
        private readonly IAzureBlobService azureBlobService;

        public DocumentService(IAzureBlobService azureBlobService)
        {
            this.azureBlobService = azureBlobService;
        }

        public void MergeFromLocal(ICollection<string> docsLocalPaths, string destinationPath)
        {
            if (File.Exists(destinationPath))
            {
                File.Delete(destinationPath);
            }

            File.Copy(docsLocalPaths.First(), destinationPath);
            docsLocalPaths = docsLocalPaths.Skip(1).ToList();

            using (var wordDocument = WordprocessingDocument.Open(destinationPath, true))
            {
                var mainPart = wordDocument.MainDocumentPart;

                foreach (var secondaryFilePath in docsLocalPaths)
                {
                    using (var secondaryFile = new FileStream(secondaryFilePath, FileMode.OpenOrCreate))
                    {
                        var altChunkId = "AltChunkId" + Guid.NewGuid().ToString();
                        var chunk = mainPart.AddAlternativeFormatImportPart(AlternativeFormatImportPartType.WordprocessingML, altChunkId);
                        chunk.FeedData(secondaryFile);

                        var altChunk = new AltChunk();
                        altChunk.Id = altChunkId;
                        wordDocument.MainDocumentPart.Document.Body.Append(altChunk);
                    }
                }

                mainPart.Document.Save();
            }
        }

        public void MergeFromAzure(ICollection<string> docsAzurePaths, string destinationPath)
        {
            if (docsAzurePaths != null && docsAzurePaths.Any())
            {
                var firstUrl = docsAzurePaths.First();
                docsAzurePaths = docsAzurePaths.Skip(1).ToList();

                if (File.Exists(destinationPath))
                {
                    File.Delete(destinationPath);
                }

                using (var primaryFile = new FileStream(destinationPath, FileMode.OpenOrCreate))
                {
                    this.azureBlobService.Download(primaryFile, firstUrl, false);
                }

                using (var wordDocument = WordprocessingDocument.Open(destinationPath, true))
                {
                    var mainPart = wordDocument.MainDocumentPart;

                    foreach (var url in docsAzurePaths)
                    {
                        var secondaryFilePath = Path.GetTempPath() + Guid.NewGuid().ToString() + ".docx";
                        using (var secondaryFile = new FileStream(secondaryFilePath, FileMode.OpenOrCreate))
                        {
                            this.azureBlobService.Download(secondaryFile, url, true);

                            var altChunkId = "AltChunkId" + Guid.NewGuid().ToString();
                            var chunk = mainPart.AddAlternativeFormatImportPart(AlternativeFormatImportPartType.WordprocessingML, altChunkId);
                            chunk.FeedData(secondaryFile);

                            var altChunk = new AltChunk();
                            altChunk.Id = altChunkId;
                            wordDocument.MainDocumentPart.Document.Body.Append(altChunk);
                        }

                        File.Delete(secondaryFilePath);
                    }

                    mainPart.Document.Save();
                }
            }
        }

        /// <summary>
        /// Encontra todas as tags no documento solicitado
        /// </summary>
        /// <param name="filePath">O path do azure do arquivo.</param>
        public IEnumerable<string> GetTags(string filePath)
        {
            var tags = new List<string>();

            using (var wordDocument = WordprocessingDocument.Open(filePath, true))
            {
                SimplifyMarkupSettings settings = new SimplifyMarkupSettings
                {
                    RemoveComments = true,
                    RemoveContentControls = true,
                    RemoveFieldCodes = false,
                    RemoveLastRenderedPageBreak = true,
                    RemovePermissions = true,
                    RemoveProof = true,
                    RemoveRsidInfo = true,
                    RemoveSmartTags = true,
                    RemoveSoftHyphens = true,
                    ReplaceTabsWithSpaces = true,
                    RemoveBookmarks = true,
                };
                MarkupSimplifier.SimplifyMarkup(wordDocument, settings);

                var mainPart = wordDocument.MainDocumentPart;

                foreach (var para in mainPart.Document.Body.ChildElements)
                {
                    foreach (var run in para.Elements<Run>())
                    {
                        foreach (var text in run.Elements<Text>())
                        {
                            var texto = text.Text.ToLowerCase();

                            // Verficando se o texto não contêm a tag de imagem, ou seja, {{imagem:...}}
                            if (texto.Contains("{{imagem:"))
                            {
                                var matches = Regex.Matches(texto, @"{{imagem:([A-Za-z0-9\-_]+)}}");
                                foreach (Match match in matches)
                                {
                                    var key = match.Value.Replace("{{", string.Empty).Replace("}}", string.Empty);
                                    if (!tags.Any(t => t == key))
                                    {
                                        tags.Add(key);
                                    }
                                }
                            }
                            // Verficando se o texto não contêm a tag de texto, ou seja, {{texto:...}}
                            else if (texto.Contains("{{texto:"))
                            {
                                var matches = Regex.Matches(texto, @"{{texto:([A-Za-z0-9\-_]+)}}");
                                foreach (Match match in matches)
                                {
                                    var key = match.Value.Replace("{{", string.Empty).Replace("}}", string.Empty);
                                    if (!tags.Any(t => t == key))
                                    {
                                        tags.Add(key);
                                    }
                                }
                            }
                        }
                    }
                }

                foreach (var foot in mainPart.FooterParts)
                {
                    foreach (var currentText in foot.RootElement.Descendants<Text>())
                    {
                        var texto = currentText.Text.ToLowerCase();
                        if (texto.Contains("{{texto:", StringComparison.InvariantCultureIgnoreCase))
                        {
                            var matches = Regex.Matches(texto, @"{{texto:([A-Za-z0-9\-_]+)}}");
                            foreach (Match match in matches)
                            {
                                var key = match.Value.Replace("{{", string.Empty).Replace("}}", string.Empty);
                                if (!tags.Any(t => t == key))
                                {
                                    tags.Add(key);
                                }
                            }
                        }
                        // Verficando se o texto não contêm a tag de imagem, ou seja, {{imagem:...}}
                        if (texto.Contains("{{imagem:"))
                        {
                            var matches = Regex.Matches(texto, @"{{imagem:([A-Za-z0-9\-_]+)}}");
                            foreach (Match match in matches)
                            {
                                var key = match.Value.Replace("{{", string.Empty).Replace("}}", string.Empty);
                                if (!tags.Any(t => t == key))
                                {
                                    tags.Add(key);
                                }
                            }
                        }
                    }
                }
            }

            return tags;
        }

        public void ReplaceTags(string filePath, Dictionary<string, string> keyValuePairs)
        {
            using (var wordDocument = WordprocessingDocument.Open(filePath, true))
            {
                SimplifyMarkupSettings settings = new SimplifyMarkupSettings
                {
                    RemoveComments = true,
                    RemoveContentControls = true,
                    RemoveFieldCodes = false,
                    RemoveLastRenderedPageBreak = true,
                    RemovePermissions = true,
                    RemoveProof = true,
                    RemoveRsidInfo = true,
                    RemoveSmartTags = true,
                    RemoveSoftHyphens = true,
                    ReplaceTabsWithSpaces = true,
                    RemoveBookmarks = true,
                };
                MarkupSimplifier.SimplifyMarkup(wordDocument, settings);

                var mainPart = wordDocument.MainDocumentPart;

                foreach (var para in mainPart.Document.Body.ChildElements)
                {
                    foreach (var run in para.Elements<Run>())
                    {
                        foreach (var text in run.Elements<Text>())
                        {
                            var texto = text.Text.ToLowerCase();
                            //// Verficando se o texto não contêm a tag de imagem, ou seja, {{imagem:...}}
                            //if (texto.Contains("{{imagem:", StringComparison.InvariantCultureIgnoreCase))
                            //{
                            //    var match = Regex.Match(texto, @"{{imagem:([A-Za-z0-9\-_]+)}}");
                            //    if (match.Success)
                            //    {
                            //        //var key = match.Value.Replace("{{imagem:", string.Empty).Replace("}}", string.Empty);
                            //        var key = match.Value;
                            //        if (keyValuePairs.ContainsKey(key))
                            //        {
                            //            string imageBase64 = keyValuePairs[key];
                            //            this.AddImage(wordDocument, para, imageBase64);
                            //            text.Text = string.Empty;
                            //        }
                            //    }
                            //}
                            // Verficando se o texto não contêm a tag de texto, ou seja, {{texto:...}}
                            //    else
                            if (texto.Contains("{{texto:", StringComparison.InvariantCultureIgnoreCase))
                            {
                                var matches = Regex.Matches(texto, @"{{texto:([A-Za-z0-9\-_]+)}}");
                                foreach (Match match in matches)
                                {
                                    var key = match.Value;
                                    if (keyValuePairs.ContainsKey(key))
                                    {
                                        string value = keyValuePairs[key];
                                        text.Text = text.Text.Replace(match.Value, value, StringComparison.InvariantCultureIgnoreCase);
                                    }
                                }
                            }
                        }
                    }
                }

                foreach (var keyValuePair in keyValuePairs)
                {
                    // Search for text holder
                    var textPlaceHolders = wordDocument.MainDocumentPart.Document.Body.Descendants<Text>()
                        .Where((x) => x.Text == keyValuePair.Key).ToList();

                    foreach (var textPlaceHolder in textPlaceHolders)
                    {

                        if (textPlaceHolder == null)
                        {
                            Console.WriteLine("Text holder not found!");
                        }
                        else
                        {
                            var parent = textPlaceHolder.Parent;

                            if (!(parent is Run))  // Parent should be a run element.
                            {
                                Console.Out.WriteLine("Parent is not run");
                            }
                            else
                            {
                                if (textPlaceHolder.Text.Contains("{{imagem:", StringComparison.InvariantCultureIgnoreCase))
                                {
                                    var matches = Regex.Matches(textPlaceHolder.Text, @"{{imagem:([A-Za-z0-9\-_]+)}}");
                                    foreach (Match match in matches)
                                    {
                                        var key = match.Value;
                                        if (keyValuePairs.ContainsKey(key))
                                        {
                                            string image = keyValuePairs[key];
                                            var element = this.AddImage(wordDocument, parent, image);
                                            textPlaceHolder.Parent.InsertAfterSelf(new DocumentFormat.OpenXml.Wordprocessing.Paragraph(element));
                                            textPlaceHolder.Remove();
                                        }
                                    }
                                }
                            }
                        }
                    }

                }
                foreach (var foot in mainPart.FooterParts)

                {
                    foreach (var currentText in foot.RootElement.Descendants<Text>())
                    {
                        var texto = currentText.Text.ToLowerCase();

                        if (texto.Contains("{{texto:", StringComparison.InvariantCultureIgnoreCase))
                        {
                            var matches = Regex.Matches(texto, @"{{texto:([A-Za-z0-9\-_]+)}}");

                            foreach (Match match in matches)
                            {
                                var key = match.Value;
                                if (keyValuePairs.ContainsKey(key))
                                {
                                    string value = keyValuePairs[key];
                                    currentText.Text = currentText.Text.Replace(match.Value, value, StringComparison.InvariantCulture);
                                }
                            }
                        }
                    }
                }

                mainPart.Document.Save();
                wordDocument.Close();
            }

        }

        private Run AddImage(WordprocessingDocument wordprocessingDocument, OpenXmlElement refChild, string imageBase64)
        {

            var bytes = Convert.FromBase64String(imageBase64.Split(',')[1]);
            var imagePath = Path.GetTempPath() + Guid.NewGuid().ToString() + ".png";

            try
            {
                MainDocumentPart mainPart = wordprocessingDocument.MainDocumentPart;
                ImagePart imagePart = mainPart.AddImagePart(ImagePartType.Png);

                File.WriteAllBytes(imagePath, bytes);



                // Carregando a imagem em imagePart
                using (FileStream stream = new FileStream(imagePath, FileMode.Open))
                {
                    imagePart.FeedData(stream);
                }
                return AddImageToBody(wordprocessingDocument, refChild, mainPart.GetIdOfPart(imagePart), imagePath);
            }
            finally
            {
                File.Delete(imagePath);
            }
        }

        private Run AddImageToBody(WordprocessingDocument wordDoc, OpenXmlElement refChild, string relationshipId, string imagePath)
        {
            Run element = null;
            // Define the reference of the image.

            using (Image<Rgba32> imagem = Image.Load<Rgba32>(imagePath))
            {

                long imageWidthEMU = (long)((imagem.Width) * 9144);
                long imageHeightEMU = (long)((imagem.Height) * 9144);


                //var widthImage = imagem.Width;
                //var heightImage = imagem.Height;
                imagem.Save(imagePath);

                element = new Run(
                                    new RunProperties(
                                        new NoProof()),
                                    new Drawing(
                                        new DW.Inline(
                                            new DW.Extent() { Cx = 5333333L, Cy = imageHeightEMU },
                                            new DW.EffectExtent() { LeftEdge = 19050L, TopEdge = 0L, RightEdge = 19050L, BottomEdge = 0L },
                                            new DW.DocProperties() { Id = (UInt32Value)1U, Name = "Picture 0", Description = "Forest Flowers.jpg" },
                                            new DW.NonVisualGraphicFrameDrawingProperties(
                                                new A.GraphicFrameLocks() { NoChangeAspect = true }),
                                            new A.Graphic(
                                                new A.GraphicData(
                                                    new PIC.Picture(
                                                        new PIC.NonVisualPictureProperties(
                                                            new PIC.NonVisualDrawingProperties() { Id = (UInt32Value)0U, Name = "Forest Flowers.jpg" },
                                                            new PIC.NonVisualPictureDrawingProperties()),
                                                        new PIC.BlipFill(
                                                            new A.Blip() { Embed = relationshipId, CompressionState = A.BlipCompressionValues.Print },
                                                            new A.Stretch(
                                                                new A.FillRectangle())),
                                                        new PIC.ShapeProperties(
                                                            new A.Transform2D(
                                                                new A.Offset() { X = 0L, Y = 0L },
                                                                new A.Extents() { Cx = imageWidthEMU, Cy = imageHeightEMU }),
                                                            new A.PresetGeometry(
                                                                new A.AdjustValueList()
                                                            )
                                                            { Preset = A.ShapeTypeValues.Rectangle }))
                                                )
                                                { Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture" })
                                        )
                                        { DistanceFromTop = (UInt32Value)0U, DistanceFromBottom = (UInt32Value)0U, DistanceFromLeft = (UInt32Value)0U, DistanceFromRight = (UInt32Value)0U }));
            }
            return element;
            // Append the reference to body, the element should be in a Run.
            //  wordDoc.MainDocumentPart.Document.Body.InsertAfterSelf(new Paragraph(new Run(element)));
        }

        public void ConvertDocxToPdf(string docxPath, string pdfPath)
        {
            if (File.Exists(pdfPath))
            {
                File.Delete(pdfPath);
            }
            var bytes = File.ReadAllBytes(docxPath);

            var base64 = Convert.ToBase64String(bytes);

            var endpoint = "http://191.177.61.112:3000/convert-file";

            var restClient = new RestClient(endpoint);
            var request = new RestRequest(Method.POST);

            var body = new { base64 = base64 };

            request.AddJsonBody(JsonConvert.SerializeObject(body));

            var response = restClient.Post(request);

            var bytesFinal = Convert.FromBase64String(response.Content);

            File.WriteAllBytes(pdfPath, bytesFinal);

        }
    }
}
