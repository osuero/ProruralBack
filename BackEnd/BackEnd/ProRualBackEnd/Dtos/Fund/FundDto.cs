namespace ProRualBackEnd.Dtos.Fund
{
    public class FundDto
    {
        public string InstitutionName { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
