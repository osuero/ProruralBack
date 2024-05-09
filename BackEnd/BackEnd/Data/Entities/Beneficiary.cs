using Data.Interfaces;
using ProRural.Data.Enums;

namespace Data.Entities
{
    public class Beneficiary : IAuditVariables, ISoftDelete
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string IdentificationNumber { get; set; }
        public Gender Sex { get; set; }
        public DateTime Birthday { get; set; }
        public string CivilStatus { get; set; }
        public string PhoneNumber { get; set; }
        public string OtherPhoneNumber { get; set; }
        public string Email { get; set; }
        public string Profession { get; set; }
        public string EducationLevel { get; set; }
        public bool CanRead { get; set; }
        public Guid? OrganizationId { get; set; }
        public Organization? Organization { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsForeign { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public int? IcvTypeId { get; set; }
        public IcvTypes IcvType{ get; set; }
    }

}
