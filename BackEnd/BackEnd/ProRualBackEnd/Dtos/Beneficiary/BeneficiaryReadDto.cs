using ProRural.Data.Enums;

namespace ProRualBackEnd.Dtos.Beneficiary
{
    public class BeneficiaryReadDto
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
        public bool IsDeleted { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsForeign { get; set; }

        public int IcvTypeId { get; set; }
    }
}
