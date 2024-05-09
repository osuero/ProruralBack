using Data.Interfaces;

namespace Data.Entities
{
    public class Permission: IAuditVariables, ISoftDelete
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        // Relaciones
        public ICollection<RolePermission> RolePermissions { get; set; }
        public bool IsDeleted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime CreationDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime UpdatedDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}