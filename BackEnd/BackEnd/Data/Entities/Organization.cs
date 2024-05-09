using Data.Geographical;
using Data.Interfaces;
using System;

namespace Data.Entities
{
    public class Organization : IAuditVariables, ISoftDelete
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid ProductiveActivityId { get; set; }
        public string Rnc { get; set; }

        public string OrganizationNumber { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string? Address { get; set; }
        // Nullable foreign key properties
        public int? RegionId { get; set; }

        public Region Region { get; set; }


        public int? ProvinceId { get; set; }
        public Province Province { get; set; }

        public int? MunicipalityId { get; set; }

        public int? SectionId { get; set; }
        public Section Section { get; set; }
        
        public int? PlaceId { get; set; }
        public Place Place { get; set; }
        public string Email { get; set; }
        public Guid? CategoryId { get; set; }
        public ProductionCategory Category { get; set; }
        public ICollection<Beneficiary> Beneficiaries { get; set; }

        public Guid? PresidentId { get; set; }
        public Beneficiary? President { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdatedDate { get; set; }
       
    }
}
