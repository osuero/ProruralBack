using Data.Interfaces;

namespace Data.Entities
{
    public class Fund : IAuditVariables, ISoftDelete
    {
        public Guid Id { get; set; }
        public string InstitutionName { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }

        public Guid ProjectId { get; set; }
        public Project Project { get; set; } // Navigation property
    }
}
