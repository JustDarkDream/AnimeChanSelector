using Microsoft.EntityFrameworkCore;

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
                optionsBuilder.UseSqlServer(@"Server=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\SeDMI\OneDrive\Рабочий стол\AnimeChanSelector\DataAccessLayer\AnimeChanDataBase.mdf;Integrated Security = True");
            }
        }

        ///<summary>Настройка связи между таблицами </summary>
        /// <param name="optionsBuilder">объект для настройки структуры моделей (таблицы, ключи и т.д.)</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnimeChanRepo>()
                .HasMany(a => a.Skills)
                .WithMany(s => s.AnimeChansRepo)
                .UsingEntity(j => j.ToTable("SkillChans"));
        }
    }
}
