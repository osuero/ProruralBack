namespace Data.Geographical
{
    public class Region
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Province> Provinces { get; set; }
    }

    public class Province
    {
        public int Id { get; set; }
        public int RegionId { get; set; }
       
        public string Name { get; set; }
        public List<Municipality> Municipalities { get; set; }
    }

    public class Municipality
    {
        public int Id { get; set; }
        public int ProvinceId { get; set; }
       
        public string Name { get; set; }
        public List<Section> Sections { get; set; }
    }

    public class Section
    {
        public int Id { get; set; }
        public int MunicipalityId { get; set; }
       
        public string Name { get; set; }
       public List<Place> Places { get; set; }
    }

    public class Place
    {
        public int Id { get; set; }
        public int SectionId { get; set; }
        
        public string Name { get; set; }
    }
}
