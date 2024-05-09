using Data.Entities;
using Data.Geographical;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });
                userRole.HasOne(ur => ur.User)
                        .WithMany(u => u.UserRoles)
                        .HasForeignKey(ur => ur.UserId);
                userRole.HasOne(ur => ur.Role)
                        .WithMany(r => r.UserRoles)
                        .HasForeignKey(ur => ur.RoleId);
            });

            modelBuilder.Entity
                        <Organization>()
                        .HasOne(o => o.President)
                        .WithMany()
                        .HasForeignKey(o => o.PresidentId)
                        .IsRequired(false)
                        .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity
                        <Organization>()
                        .HasOne(o => o.Region)
                        .WithMany()
                        .HasForeignKey(o => o.RegionId)
                        .IsRequired(false)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity
                        <Organization>()
                        .HasOne(o => o.Province)
                        .WithMany()
                        .HasForeignKey(o => o.ProvinceId)
                        .IsRequired(false)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RolePermission>(rolePermission =>
            {
                rolePermission.HasKey(rp => new { rp.RoleId, rp.PermissionId });
                rolePermission.HasOne(rp => rp.Role)
                              .WithMany(r => r.RolePermissions)
                              .HasForeignKey(rp => rp.RoleId);
                rolePermission.HasOne(rp => rp.Permission)
                              .WithMany(p => p.RolePermissions)
                              .HasForeignKey(rp => rp.PermissionId);
            });

            modelBuilder.Entity<Project>()
             .HasOne(p => p.Organization) 
             .WithMany() 
             .HasForeignKey(p => p.OrganizationId) 
             .IsRequired(false) 
             .OnDelete(DeleteBehavior.SetNull);


            modelBuilder.Entity<Project>()
                .HasOne(p => p.ProjectType) // Set up relationship to ProjectType
                .WithMany() // Assuming ProjectType does not have navigation back to Projects
                .HasForeignKey(p => p.ProjectTypeId)
                .IsRequired(true); // Assuming a project must have a type

            modelBuilder.Entity<Project>()
                .HasOne(p => p.ProjectStatus) // Set up relationship to ProjectStatus
                .WithMany() // Assuming ProjectStatus does not have navigation back to Projects
                .HasForeignKey(p => p.ProjectStatusId)
                .IsRequired(true); // Assuming a project must have a status


            modelBuilder.Entity<Beneficiary>()
                .HasOne(p => p.IcvType) // Set up relationship to ProjectStatus
                .WithMany() // Assuming ProjectStatus does not have navigation back to Projects
                .HasForeignKey(p => p.IcvTypeId)
                .IsRequired(true); // Assuming a project must have a status

            //modelBuilder.Entity<Beneficiary>()
            //    .HasOne(p => p.Organization)
            //    .WithMany()
            //    .HasForeignKey(p => p.OrganizationId)
            //    .IsRequired(false)
            //    .OnDelete(DeleteBehavior.SetNull);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(ISoftDelete).IsAssignableFrom(entityType.ClrType))
                {
                    entityType.AddSoftDeleteQueryFilter();
                }
            }

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<Beneficiary> Beneficiaries { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<ProductionCategory> ProductionCategories { get; set; }
        public DbSet<Fund> Funds { get; set; }

        public DbSet<Region> Regions { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Municipality> Municipalities { get; set; }
        public DbSet<Section> Sections { get; set; }
        
        public DbSet<Place> Places { get; set; }

        public DbSet<ProjectStatus> ProjectStatuses { get; set; }
        public DbSet<ProjectType> ProjectType { get; set; }
        public DbSet<IcvTypes> IcvTypes { get; set; }
        public DbSet<FinancingGroup> FinancingGroup { get; set; }
        public override int SaveChanges()
        {
            ApplySoftDelete();
            OnBeforeSaving();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            ApplySoftDelete();
            OnBeforeSaving();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void ApplySoftDelete()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is ISoftDelete && e.State == EntityState.Deleted);

            foreach (var entry in entries)
            {
                ((ISoftDelete)entry.Entity).IsDeleted = true;
                // Marca la entidad como modificada en lugar de eliminada
                entry.State = EntityState.Modified;
            }
        }
        private void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries();
            foreach (var entry in entries)
            {
                if (entry.Entity is IAuditVariables trackable)
                {
                    var now = DateTime.UtcNow; // O utiliza DateTime.Now si estás manejando fechas en zona horaria local.
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            // Actualiza la fecha de actualización
                            trackable.UpdatedDate = now;
                            break;
                        case EntityState.Added:
                            // Establece ambas fechas en la creación
                            trackable.CreationDate = now;
                            trackable.UpdatedDate = now;
                            break;
                    }
                }

                if (entry.Entity is ISoftDelete deletable && entry.State == EntityState.Deleted)
                {
                   
                    deletable.IsDeleted = true;
                    entry.State = EntityState.Modified; 
                }
            }
        }
    }
}
