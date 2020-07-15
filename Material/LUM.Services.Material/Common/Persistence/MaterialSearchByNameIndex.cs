using System.Linq;
using Raven.Client.Documents.Indexes;

namespace LUM.Services.Material.Common.Persistence
{
    public class MaterialSearchByNameIndex : AbstractIndexCreationTask<Domain.Material>
    {
        public MaterialSearchByNameIndex()
        {
            Map = materials => from material in materials
                select new Domain.Material
                {
                    Name = material.Name
                };
        }
    }
}
