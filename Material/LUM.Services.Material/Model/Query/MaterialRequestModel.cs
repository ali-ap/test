using LUM.Services.Material.Common.Enum;
using LUM.Services.Material.Type;

namespace LUM.Services.Material.Model.Query
{
    public class SearchMaterialByNameQueryModel : PagedQueryBase
    {
        public string Name { get; set; }

    }
}
