using Microsoft.EntityFrameworkCore;

namespace HW13_Notes_MVC.Data
{
    public class NotesMvcDbContext : DbContext
    {
        public NotesMvcDbContext(DbContextOptions<NotesMvcDbContext> options) : base(options)
        {
        }
        public DbSet<Models.Note> Notes { get; set; }
        public DbSet<Models.Contact> Contacts { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Models.Note>().ToTable("Notes");
        //    modelBuilder.Entity<Models.Contact>().ToTable("Contacts");
        //}
    }
}
