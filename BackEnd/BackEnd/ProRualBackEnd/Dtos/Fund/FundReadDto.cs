namespace ProRualBackEnd.Dtos.Fund
{
    public class FundReadDto
    {
        public Guid Id { get; set; }
        public string InstitutionName { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public Guid ProjectId { get; set; }


    }
}
