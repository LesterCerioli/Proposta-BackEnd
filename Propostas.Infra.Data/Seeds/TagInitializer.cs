namespace Propostas.Infra.Data.Seeds
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Propostas.Domain.Models;
    using Propostas.Infra.Data.Context;

    public class TagInitializer
    {
        private PropostasContext context;
        private ICollection<Tag> tags;

        public TagInitializer(PropostasContext context)
        {
            this.context = context;
        }

        public async Task Seed()
        {
            this.tags = this.Generate();

            /*
            var allTags = this.context.Tags.ToList();
            foreach (var tag in _tags)
            {
                if (!allTags.Any(c => c.Code == country.Code))
                {
                    this.context.Add(tag);
                }
            }

            */

            await this.context.SaveChangesAsync();
        }

        private ICollection<Tag> Generate()
        {
            var tag = new List<Tag>();

            /* Insira seus dados na lista */

            return tag;
        }
    }
}
