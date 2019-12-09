namespace Propostas.Infra.Data.Seeds
{
    public class SeedInitializer
    {
        // Não remova ou edite a linha abaixo. Utilizado para gerar código automático
        // AddNewInitializerVariable //
        private TagInitializer tagInitializer;
        private SecaoArquivoTagInitializer secaoarquivotagInitializer;
        private PropostaTagInitializer propostatagInitializer;
        private UsuarioInitializer usuarioInitializer;
        private PropostaInitializer propostaInitializer;
        private TemplateSecaoInitializer templatesecaoInitializer;
        private TemplateInitializer templateInitializer;
        private SecaoInitializer secaoInitializer;
        private StatusPropostaInitializer statuspropostaInitializer;
        private TiposContatoInitializer tiposcontatoInitializer;
        private PerfilUsuarioInitializer perfilusuarioInitializer;
        private ContatoInitializer contatoInitializer;
        private RecursoInitializer recursoInitializer;
        private TipoSecaoInitializer tiposecaoInitializer;
        private LinguagemInitializer linguagemInitializer;
        private TipoTemplateInitializer tipotemplateInitializer;
        private PublicoAlvoInitializer publicoalvoInitializer;
        private MoedaInitializer moedaInitializer;
        private ClienteInitializer clienteInitializer;
        private ProdutoInitializer produtoInitializer;
        private UnidadeMedidaInitializer unidademedidaInitializer;
        private PaisInitializer paisInitializer;
        private EstadoInitializer estadoInitializer;
        private CidadeInitializer cidadeInitializer;

        public SeedInitializer(// AddNewInitializerIoC //
            TagInitializer tagInitializer,
            SecaoArquivoTagInitializer secaoarquivotagInitializer,
            PropostaTagInitializer propostatagInitializer,
            UsuarioInitializer usuarioInitializer,
            PropostaInitializer propostaInitializer,
            TemplateSecaoInitializer templatesecaoInitializer,
            TemplateInitializer templateInitializer,
            SecaoInitializer secaoInitializer,
            StatusPropostaInitializer statuspropostaInitializer,
            TiposContatoInitializer tiposcontatoInitializer,
            PerfilUsuarioInitializer perfilusuarioInitializer,
            ContatoInitializer contatoInitializer,
            RecursoInitializer recursoInitializer,
            TipoSecaoInitializer tiposecaoInitializer,
            LinguagemInitializer linguagemInitializer,
            TipoTemplateInitializer tipotemplateInitializer,
            PublicoAlvoInitializer publicoalvoInitializer,
            MoedaInitializer moedaInitializer,
            ClienteInitializer clienteInitializer,
            ProdutoInitializer produtoInitializer,
            UnidadeMedidaInitializer unidademedidaInitializer,
            PaisInitializer paisInitializer,
            EstadoInitializer estadoInitializer,
            CidadeInitializer cidadeInitializer)
        {
            // AddNewInitializerSetter //
            this.tagInitializer = tagInitializer;
            this.secaoarquivotagInitializer = secaoarquivotagInitializer;
            this.propostatagInitializer = propostatagInitializer;
            this.usuarioInitializer = usuarioInitializer;
            this.propostaInitializer = propostaInitializer;
            this.templatesecaoInitializer = templatesecaoInitializer;
            this.templateInitializer = templateInitializer;
            this.secaoInitializer = secaoInitializer;
            this.statuspropostaInitializer = statuspropostaInitializer;
            this.tiposcontatoInitializer = tiposcontatoInitializer;
            this.perfilusuarioInitializer = perfilusuarioInitializer;
            this.contatoInitializer = contatoInitializer;
            this.recursoInitializer = recursoInitializer;
            this.tiposecaoInitializer = tiposecaoInitializer;
            this.linguagemInitializer = linguagemInitializer;
            this.tipotemplateInitializer = tipotemplateInitializer;
            this.publicoalvoInitializer = publicoalvoInitializer;
            this.moedaInitializer = moedaInitializer;
            this.clienteInitializer = clienteInitializer;
            this.produtoInitializer = produtoInitializer;
            this.unidademedidaInitializer = unidademedidaInitializer;
            this.paisInitializer = paisInitializer;
            this.estadoInitializer = estadoInitializer;
            this.cidadeInitializer = cidadeInitializer;
        }

        public void Seed()
        {
            // AddNewInitializerSeedWait //
            this.tagInitializer.Seed().Wait();
            this.secaoarquivotagInitializer.Seed().Wait();
            this.propostatagInitializer.Seed().Wait();
            this.usuarioInitializer.Seed().Wait();
            this.propostaInitializer.Seed().Wait();
            this.templatesecaoInitializer.Seed().Wait();
            this.templateInitializer.Seed().Wait();
            this.secaoInitializer.Seed().Wait();
            this.statuspropostaInitializer.Seed().Wait();
            this.tiposcontatoInitializer.Seed().Wait();
            this.perfilusuarioInitializer.Seed().Wait();
            this.contatoInitializer.Seed().Wait();
            this.recursoInitializer.Seed().Wait();
            this.tiposecaoInitializer.Seed().Wait();
            this.linguagemInitializer.Seed().Wait();
            this.tipotemplateInitializer.Seed().Wait();
            this.publicoalvoInitializer.Seed().Wait();
            this.moedaInitializer.Seed().Wait();
            this.clienteInitializer.Seed().Wait();
            this.produtoInitializer.Seed().Wait();
            this.unidademedidaInitializer.Seed().Wait();
            this.paisInitializer.Seed().Wait();
            this.estadoInitializer.Seed().Wait();
            this.cidadeInitializer.Seed().Wait();
        }
    }
}
