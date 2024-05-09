using ProRualBackEnd.Dtos.Fund;

namespace ProRualBackEnd.Dtos.project
{
    public class ProjectCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public int ProjectTypeId { get; set; }
        public decimal? ProruralFunds { get; set; }
        public decimal? OrganizationFunds { get; set; }
        public decimal? CreditFunds { get; set; }
        public decimal? FinancingGroup { get; set; }
        public decimal? GobermentGroup { get; set; }
    }
}
