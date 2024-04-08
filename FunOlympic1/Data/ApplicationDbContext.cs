using FunOlympic1;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FunOlympic1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {


        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<Video> Videos { get; set; }
        public DbSet<News> News { get; set; }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Log> Logs { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());

            // Configure relationship between Comment and IdentityUser
            builder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany() // Assuming IdentityUser doesn't have a navigation property to Comment
                .HasForeignKey(c => c.UserId)
                .IsRequired();
            // Configure relationship between Comment and VideoUpload (as you did before)
            builder.Entity<Comment>()
                .HasOne(c => c.Video)
                .WithMany(v => v.Comments)
                .HasForeignKey(c => c.VideoUploadId)
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete, if needed




        }


    }
}

public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.Property(u => u.Name).HasMaxLength(200);

    }
}