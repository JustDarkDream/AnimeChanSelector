using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class DataContext : DbContext
    {
        public DbSet<AnimeChanRepo> AnimeChans { get; set; }
        public DbSet<SkillRepo> Skills { get; set; }


        public DataContext()
        {
            //Database.EnsureCreated();
        }

        ///<summary>Автоматически подключается к БД </summary>
        /// <param name="optionsBuilder">помогает подключиться к БД</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Nubik\Documents\IloveGit\AnimeChanSelector\DataAccessLayer\AnimeChanDataBase.mdf;Integrated Security=True");
            }
        }

        ///<summary>Настройка связи между таблицами </summary>
        /// <param name="optionsBuilder">объект для настройки структуры моделей (таблицы, ключи и т.д.)</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnimeChanRepo>()
                .HasMany(a => a.Skills)
                .WithMany(s => s.AnimeChansRepo)
                .UsingEntity<Dictionary<string, object>>(
                    "SkillChans",
                    j => j
                        .HasOne<SkillRepo>()
                        .WithMany()
                        .HasForeignKey("SkillsId")
                        .OnDelete(DeleteBehavior.Cascade),  // Каскад при удалении навыка
                    j => j
                        .HasOne<AnimeChanRepo>()
                        .WithMany()
                        .HasForeignKey("AnimeChansRepoId")
                        .OnDelete(DeleteBehavior.Cascade)   // Каскад при удалении персонажа
                );
        }
    }
}
