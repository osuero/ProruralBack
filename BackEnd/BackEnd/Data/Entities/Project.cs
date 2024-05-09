using Data.Interfaces;
using Microsoft.VisualBasic;

namespace Data.Entities
{
    public class Project: IAuditVariables, ISoftDelete
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool ApprovedFirstDisbursement { get; set; }
        public bool IsDeleted { get; set; }
        public decimal FundAmount { get; set; }
        public DateTime CreationDate { get; set ; }
        public DateTime UpdatedDate { get; set; }

        public decimal? ProruralFunds { get; set; } = 0;
        public decimal?  OrganizationFunds { get; set; } = 0;
        public decimal? CreditFunds { get; set; } = 0;
        public decimal? GorbermentFunds { get; set; } = 0;
        // Foreign key for Organization
        public Guid? OrganizationId { get; set; }
        // Navigation property for Organization
        public Organization? Organization { get; set; }

        public int? ProjectTypeId { get; set; }
      
        public ProjectType ProjectType { get; set; }

        public int? ProjectStatusId { get; set; } = 1;
        public ProjectStatus ProjectStatus { get; set; }

    }
}
