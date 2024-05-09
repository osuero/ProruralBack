using Data.Geographical;
using ProRualBackEnd.Dtos.Beneficiary;

namespace ProRualBackEnd.Dtos.Organization
{
    public class OrganizationReadDto
    {
        public Guid Id { get; set; } // Asumiendo que usas GUID como el identificador
        public string Name { get; set; }
        public Guid ProductiveActivityId { get; set; }
        public string Rnc { get; set; }
        public string PresidentName { get; set; }
        public string PresidentPhone { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string AddressId { get; set; }
        public string RegionId { get; set; }
        public string ProvinceId { get; set; }
        public string MunicipalityID { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string OrganizationNumber { get; set; }
        public Region Region { get; set; }
        public Province Province { get; set; }
        public BeneficiaryReadDto? President { get; set; }
        public ICollection<BeneficiaryReadDto> Beneficiaries { get; set; }
    }
}
