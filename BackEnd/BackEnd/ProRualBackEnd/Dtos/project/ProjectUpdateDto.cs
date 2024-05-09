using ProRualBackEnd.Dtos.Fund;

namespace ProRualBackEnd.Dtos.project
{
    public class ProjectUpdateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? ImplementationStatus { get; set; }
        public bool ApprovedFirstDisbursement { get; set; }
        public decimal ProruralFunds { get; set; }
        public decimal OrganizationFunds { get; set; }
        public decimal CreditFunds { get; set; }
        public decimal GobermentFunds { get; set; }
        public decimal FinancingGroup { get; set; }
    }
}
