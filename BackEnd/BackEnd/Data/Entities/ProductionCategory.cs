using Data.Interfaces;

namespace Data.Entities
{
    public class ProductionCategory : IAuditVariables, ISoftDelete
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
