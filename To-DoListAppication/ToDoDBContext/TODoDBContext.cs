using Microsoft.EntityFrameworkCore;
using To_DoListAppication.Models;

namespace To_DoListAppication.ToDoDBContext
{
    public class TODoDBContext:DbContext
    {
        public TODoDBContext(DbContextOptions options):base(options) 
        { 

        }
        public DbSet<SignInModel> signInModels { get; set; }
        public DbSet<WorkRecordModel> workRecordModels  { get; set; }
        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            base.OnModelCreating (modelBuilder);
            modelBuilder.Entity<WorkRecordModel>().ToTable("workRecordModels");
            //seed data
            modelBuilder.Entity<WorkRecordModel>().HasData(new WorkRecordModel
            {
                workId=1,workName="tocreate model",workDetails="Add  model folder. add a class",dateOfWork=DateTime.Now,IsCompleted="Yes",userEmail= "ch@gmail.com"
            });

            modelBuilder.Entity<SignInModel>().ToTable("signInModels");
            modelBuilder.Entity<SignInModel>().HasData(new SignInModel
            {
                Id=1,
               name="ramesh",
               email="ch@gmail.com",
               mobile=6574837373,
               password="111",
            });
        }
    }
}
