namespace ProRualBackEnd.Dtos.Fund
{
    public class FundCreateDto
    {
        public string InstitutionName { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public Guid ProjectId { get; set;}
    }
}
