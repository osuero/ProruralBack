namespace ProRualBackEnd.Dtos.Organization
{
    public class OrganizationCreateDto
    {
        public string Name { get; set; }
        public string? ProductiveActivityId { get; set; }
        public string Rnc { get; set; }
        public string? Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public string? PresidentId { get; set; }
        public string Email { get; set; }
        public string? RegionId { get; set; }
        public string? ProvinceId { get; set; }
        public string? MunicipalityId { get; set; }
        public string? SectionId { get; set; }
        public string? OrganizationNumber { get; set; }
    }
}
