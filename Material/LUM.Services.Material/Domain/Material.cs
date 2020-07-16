using LUM.Services.Material.Common.Enum;
using LUM.Services.Material.Type;

namespace LUM.Services.Material.Domain
{
    public class Material:IIdentifiable
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public bool IsVisible { get; set; }
        public Phase Type { get; set; }
        public string Notes { get; set; }
        public Function Function { get; set; }
    }
}
