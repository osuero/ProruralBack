using ProRualBackEnd.Dtos.Organization;

namespace ProRualBackEnd.Dtos.project
{
    public class ProjectReadDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? ImplementationStatus { get; set; }
        public bool ApprovedFirstDisbursement { get; set; }
      
        public OrganizationReadDto? Organization { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public decimal ProruralFunds { get; set; }
        public decimal OrganizationFunds { get; set; }
        public decimal CreditFunds { get; set; }
        public decimal GobermentFunds { get; set; }
        public decimal FinancingGroup { get;set; }
    }
}
