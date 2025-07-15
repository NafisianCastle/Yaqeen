using Microsoft.EntityFrameworkCore;
using Yaqeen.API.Models;

/// <summary>
/// Summary description for Class1
/// </summary>
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    public DbSet<User> Users { get; set; }
    public DbSet<UserTask> UserTasks { get; set; }
    public DbSet<TaskSchedule> TaskSchedules { get; set; }
    public DbSet<TaskLevel> TaskLevels { get; set; }
    public DbSet<UserProgress> UserProgresses { get; set; }
    public DbSet<CustomUserTask> CustomUserTasks { get; set; }
    public DbSet<Reward> Rewards { get; set; }
    public DbSet<UserRewardRedemption> UserRewardRedemptions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(u => u.Id);

            entity.Property(u => u.Email)
                  .IsRequired()
                  .HasMaxLength(150);

            entity.Property(u => u.GoogleId)
                  .HasMaxLength(100);

            entity.Property(u => u.FullName)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.Property(u => u.CurrentLevel)
                  .HasConversion<string>()
                  .IsRequired();

            entity.Property(u => u.PointsBalance)
                  .IsRequired();
        });

        // TASK
        modelBuilder.Entity<UserTask>(entity =>
        {
            entity.HasKey(t => t.Id);

            entity.Property(t => t.Title)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.Property(t => t.Description)
                  .HasMaxLength(500);

            entity.Property(t => t.ContentType)
                  .IsRequired()
                  .HasMaxLength(50);

            entity.Property(t => t.ContentReference)
                  .HasMaxLength(200);
        });

        // TASK SCHEDULE
        modelBuilder.Entity<TaskSchedule>(entity =>
        {
            entity.HasKey(ts => ts.Id);

            entity.Property(ts => ts.Name)
                  .IsRequired()
                  .HasMaxLength(50);

            entity.Property(ts => ts.Description)
                  .HasMaxLength(250);
        });

        // TASK LEVEL
        modelBuilder.Entity<TaskLevel>(entity =>
        {
            entity.HasKey(tl => new { tl.TaskId, tl.Level });

            entity.Property(tl => tl.Level)
                  .HasConversion<string>()
                  .IsRequired();
        });

        // USER PROGRESS
        modelBuilder.Entity<UserProgress>(entity =>
        {
            entity.HasKey(up => up.Id);

            entity.Property(up => up.CompletionDate)
                  .IsRequired();

            entity.Property(up => up.PointsAwarded)
                  .IsRequired();
        });

        // CUSTOM USER TASK
        modelBuilder.Entity<CustomUserTask>(entity =>
        {
            entity.HasKey(cut => cut.Id);

            entity.Property(cut => cut.Title)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.Property(cut => cut.IsCompleted)
                  .IsRequired();
        });

        // REWARD
        modelBuilder.Entity<Reward>(entity =>
        {
            entity.HasKey(r => r.Id);

            entity.Property(r => r.Name)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.Property(r => r.Description)
                  .HasMaxLength(300);

            entity.Property(r => r.PointCost)
                  .IsRequired();

            entity.Property(r => r.Type)
                  .HasConversion<string>()
                  .IsRequired();

            entity.Property(r => r.IsActive)
                  .IsRequired();
        });

        // USER REWARD REDEMPTION
        modelBuilder.Entity<UserRewardRedemption>(entity =>
        {
            entity.HasKey(rr => rr.Id);

            entity.Property(rr => rr.RedemptionDate)
                  .IsRequired();

            entity.Property(rr => rr.Status)
                  .HasConversion<string>()
                  .IsRequired();

            entity.Property(rr => rr.ShippingAddress)
                  .HasMaxLength(500); // Adjust if encrypted length is known
        });
        // User
        modelBuilder.Entity<User>()
            .HasKey(u => u.Id);

        modelBuilder.Entity<User>()
            .HasMany(u => u.UserProgresses)
            .WithOne(up => up.User)
            .HasForeignKey(up => up.UserId);

        modelBuilder.Entity<User>()
            .HasMany(u => u.CustomUserTasks)
            .WithOne(cut => cut.User)
            .HasForeignKey(cut => cut.UserId);

        modelBuilder.Entity<User>()
            .HasMany(u => u.RewardRedemptions)
            .WithOne(rr => rr.User)
            .HasForeignKey(rr => rr.UserId);

        // Task
        modelBuilder.Entity<UserTask>()
            .HasKey(t => t.Id);

        modelBuilder.Entity<UserTask>()
            .HasMany(t => t.UserProgresses)
            .WithOne(up => up.Task)
            .HasForeignKey(up => up.TaskId);

        modelBuilder.Entity<UserTask>()
            .HasOne(t => t.TaskSchedule)
            .WithMany(ts => ts.Tasks)
            .HasForeignKey(t => t.TaskScheduleId);

        // TaskSchedule
        modelBuilder.Entity<TaskSchedule>()
            .HasKey(ts => ts.Id);

        // TaskLevel (many-to-many)
        modelBuilder.Entity<TaskLevel>()
            .HasKey(tl => new { tl.TaskId, tl.Level });

        modelBuilder.Entity<TaskLevel>()
            .HasOne(tl => tl.Task)
            .WithMany(t => t.TaskLevels)
            .HasForeignKey(tl => tl.TaskId);

        // UserProgress
        modelBuilder.Entity<UserProgress>()
            .HasKey(up => up.Id);

        // CustomUserTask
        modelBuilder.Entity<CustomUserTask>()
            .HasKey(cut => cut.Id);

        // Reward
        modelBuilder.Entity<Reward>()
            .HasKey(r => r.Id);

        modelBuilder.Entity<Reward>()
            .HasMany(r => r.Redemptions)
            .WithOne(rr => rr.Reward)
            .HasForeignKey(rr => rr.RewardId);

        // UserRewardRedemption
        modelBuilder.Entity<UserRewardRedemption>()
            .HasKey(rr => rr.Id);

        modelBuilder.Entity<User>().HasData(
             new User { Id = 1, Email = "beginner@example.com", GoogleId = "g_beg_1", FullName = "Beginner User", CurrentLevel = Level.Beginner, PointsBalance = 20 },
             new User { Id = 2, Email = "intermediate@example.com", GoogleId = "g_int_1", FullName = "Intermediate User", CurrentLevel = Level.Intermediate, PointsBalance = 120 },
             new User { Id = 3, Email = "advanced@example.com", GoogleId = "g_adv_1", FullName = "Advanced User", CurrentLevel = Level.Advanced, PointsBalance = 280 }
         );

        modelBuilder.Entity<TaskSchedule>().HasData(
            new TaskSchedule { Id = 1, Name = "Daily", Description = "Every day after any prayer" },
            new TaskSchedule { Id = 2, Name = "After Fajr", Description = "Tasks to do after Fajr" },
            new TaskSchedule { Id = 3, Name = "After Maghrib", Description = "Tasks to do after Maghrib" },
            new TaskSchedule { Id = 4, Name = "Weekly", Description = "Once every week" }
        );

        modelBuilder.Entity<UserTask>().HasData(
            new UserTask { Id = 1, Title = "Pray 5 Times Salah", Description = "Complete all 5 daily prayers", ContentType = "Checklist", ContentReference = null, TaskScheduleId = 1 },
            new UserTask { Id = 2, Title = "Recite Dua After Fajr", Description = "Daily Masnun dua after Fajr", ContentType = "Dua", ContentReference = "DuaFajr1", TaskScheduleId = 2 },
            new UserTask { Id = 3, Title = "Recite Dua After Maghrib", Description = "Daily Masnun dua after Maghrib", ContentType = "Dua", ContentReference = "DuaMaghrib1", TaskScheduleId = 3 },
            new UserTask { Id = 4, Title = "Recite Surah Yasin", Description = "Weekly Surah Yasin recitation", ContentType = "Surah", ContentReference = "Yasin", TaskScheduleId = 4 },
            new UserTask { Id = 5, Title = "Recite Surah Mulk", Description = "Night recitation of Surah Mulk", ContentType = "Surah", ContentReference = "Mulk", TaskScheduleId = 3 },
            new UserTask { Id = 6, Title = "Recite 3 Quls", Description = "Morning and evening protection", ContentType = "Surah", ContentReference = "Ikhlas,Falaq,Nas", TaskScheduleId = 1 }
        );

        modelBuilder.Entity<TaskLevel>().HasData(
            new { TaskId = 1, Level = Level.Beginner },
            new { TaskId = 2, Level = Level.Beginner },
            new { TaskId = 3, Level = Level.Beginner },
            new { TaskId = 4, Level = Level.Intermediate },
            new { TaskId = 5, Level = Level.Advanced },
            new { TaskId = 6, Level = Level.Intermediate }
        );

        modelBuilder.Entity<CustomUserTask>().HasData(
            new CustomUserTask { Id = 1, UserId = 2, Title = "Read Islamic book 10 mins", IsCompleted = false, DueDate = DateTime.Today.AddDays(1) },
            new CustomUserTask { Id = 2, UserId = 3, Title = "Volunteer at mosque", IsCompleted = false, DueDate = DateTime.Today.AddDays(3) }
        );

        modelBuilder.Entity<Reward>().HasData(
            new Reward { Id = 1, Name = "Beginner Badge", Description = "Badge for completing beginner level", PointCost = 100, Type = RewardType.Virtual, IsActive = true },
            new Reward { Id = 2, Name = "Tasbeeh Counter", Description = "Digital tasbeeh counter", PointCost = 200, Type = RewardType.Physical, IsActive = true },
            new Reward { Id = 3, Name = "Intermediate Access", Description = "Unlock Intermediate Level", PointCost = 100, Type = RewardType.Virtual, IsActive = true },
            new Reward { Id = 4, Name = "Advanced Access", Description = "Unlock Advanced Level", PointCost = 250, Type = RewardType.Virtual, IsActive = true }
        );


    }


}
