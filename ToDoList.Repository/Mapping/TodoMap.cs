using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using ToDoList.Domain.Entities;

namespace ToDoList.Repository.Mapping
{
    public class TodoMap : EntityTypeConfiguration<Todo>
    {

        public TodoMap() : base()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Table & Column Mappings
            this.ToTable("Todo");
            this.Property(t => t.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(t => t.Description).HasColumnName("Description").HasMaxLength(255).IsRequired();
            this.Property(t => t.ModificationDate).HasColumnName("ModificationDate");
            this.Property(t => t.Done).HasColumnName("Done");

         
            // Relationships
            this.HasRequired(c => c.User)
                .WithMany(t => t.Todos)
                .HasForeignKey(fk => fk.UserId);

        }

    }
}
