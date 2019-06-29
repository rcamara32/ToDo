using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using ToDoList.Domain.Entities;

namespace ToDoList.Repository.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {

        public UserMap() : base()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Table & Column Mappings
            this.ToTable("User");
            this.Property(t => t.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(t => t.Name).HasColumnName("Name").HasMaxLength(255).IsRequired();
            this.Property(t => t.UserName).HasColumnName("UserName").HasMaxLength(20).IsRequired();
            this.Property(t => t.Password).HasColumnName("Password").HasMaxLength(20).IsRequired();

        }

    }
}
