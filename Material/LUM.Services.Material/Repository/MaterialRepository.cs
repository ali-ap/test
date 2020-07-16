using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using LUM.Services.Material.Common.Persistence;
using LUM.Services.Material.Model.Query;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;

namespace LUM.Services.Material.Repository
{
    public class MaterialRepository : RavenRepository<Domain.Material>
    {
        public MaterialRepository(IDocumentStore store, IMapper mapper) : base(store, mapper)
        {
        }

        public async Task<(List<Domain.Material> data, QueryStatistics statistics)> SearchByNameAsync(SearchMaterialByNameQueryModel query)
        {
            return (await SessionAsync.Advanced.AsyncDocumentQuery<Domain.Material>(nameof(MaterialSearchByNameIndex))
                .WaitForNonStaleResults()
                .WhereEquals(x => x.Name, query.Name)
                .Statistics(out QueryStatistics stats)
                .Skip(query.Page * query.Results)
                .Take(query.Results)
                .OrderByDescending(query.OrderBy)
                .ToListAsync(), stats);
        }
    }
}