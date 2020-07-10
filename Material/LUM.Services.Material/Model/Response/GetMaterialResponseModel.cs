using LUM.Services.Material.Common.Enum;

namespace LUM.Services.Material.Model.Response
{
    public class GetMaterialResponseModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public bool IsVisible { get; set; }
        public Phase Type { get; set; }
        public string Notes { get; set; }
        public int FunctionMaxTemperature { get; set; }
        public int FunctionMinTemperature { get; set; }

    }
}
