using Data.Interfaces;

namespace Data.Entities
{
    public class User: IAuditVariables, ISoftDelete
    {

        public User() {
            IsEmailConfirmed = false;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Identification { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }

        public string Email { get; set; }

        public bool IsEmailConfirmed { get; set; }
        // Relaciones
        public bool IsDeleted { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
