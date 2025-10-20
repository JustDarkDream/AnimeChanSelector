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


        public DataContext()
        {
            Database.EnsureCreated();
        }

        ///<summary>Автоматически подключается к БД </summary>
        /// <param name="optionsBuilder">помогает подключиться к БД</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Nubik\Documents\IloveGit\Semester3\DataAccessLayer\AnimeChanDataBase.mdf;Integrated Security = True");
            }
        }

        ///<summary>Настройка связи между таблицами </summary>
        /// <param name="optionsBuilder">объект для настройки структуры моделей (таблицы, ключи и т.д.)</param>
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
