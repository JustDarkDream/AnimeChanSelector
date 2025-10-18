using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DataAccessLayer
{
    public class DataContext : DbContext
    {
        public DbSet<AnimeChanRepo> AnimeChans { get; set; }
        public DbSet<SkillRepo> Skills { get; set; }


        //public DataContext(): base(@"LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Nubik\Documents\IloveGit\Semester3\DataAccessLayer\AnimeChansDB.mdf;Integrated Security = True") { }

        //public EntityProjectRepository(DataContext context)
        //{
        //    _context = context;
        //}

        public DataContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Nubik\Documents\IloveGit\Semester3\DataAccessLayer\AnimeChanDataBase.mdf;Integrated Security = True");
            }

            //    if (!optionsBuilder.IsConfigured)
            //    {
            //        optionsBuilder.UseSqlServer(
            //            @"Server=(localdb)\MSSQLLocalDB;Database=AnimeChanDB;Trusted_Connection=True;TrustServerCertificate=True;");
            //    }
            //}


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnimeChanRepo>()
                .HasMany(a => a.Skills)
                .WithOne(s => s.AnimeChanRepo)
                .HasForeignKey(s => s.AnimeChanRepoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
