using Microsoft.EntityFrameworkCore;
using ToDoList.DAL.Models;

namespace ToDoList.DAL.Repositories
{
    public class ToDoListContext : DbContext
    {        public ToDoListContext(DbContextOptions<ToDoListContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<ToDoList.DAL.Models.ToDoList> ToDoLists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDoList.DAL.Models.ToDoList>()
                .HasOne(t => t.User)
                .WithMany(u => u.ToDoLists)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
