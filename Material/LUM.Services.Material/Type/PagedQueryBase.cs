namespace LUM.Services.Material.Type
{
    public abstract class PagedQueryBase
    {
        public int Page { get; set; } = 0;
        public int Results { get; set; } = 10;
        public string OrderBy { get; set; }

    }
}