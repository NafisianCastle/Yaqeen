using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Yaqeen.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rewards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    PointCost = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rewards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaskSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskSchedules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    GoogleId = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    FullName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CurrentLevel = table.Column<string>(type: "text", nullable: false),
                    PointsBalance = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    ContentType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ContentReference = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    TaskScheduleId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTasks_TaskSchedules_TaskScheduleId",
                        column: x => x.TaskScheduleId,
                        principalTable: "TaskSchedules",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CustomUserTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    IsCompleted = table.Column<bool>(type: "boolean", nullable: false),
                    DueDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomUserTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomUserTasks_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRewardRedemptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    RewardId = table.Column<int>(type: "integer", nullable: false),
                    RedemptionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    ShippingAddress = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRewardRedemptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRewardRedemptions_Rewards_RewardId",
                        column: x => x.RewardId,
                        principalTable: "Rewards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRewardRedemptions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskLevels",
                columns: table => new
                {
                    TaskId = table.Column<int>(type: "integer", nullable: false),
                    Level = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskLevels", x => new { x.TaskId, x.Level });
                    table.ForeignKey(
                        name: "FK_TaskLevels_UserTasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "UserTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProgresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    TaskId = table.Column<int>(type: "integer", nullable: false),
                    CompletionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PointsAwarded = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProgresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProgresses_UserTasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "UserTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProgresses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Rewards",
                columns: new[] { "Id", "Description", "IsActive", "Name", "PointCost", "Type" },
                values: new object[,]
                {
                    { 1, "Badge for completing beginner level", true, "Beginner Badge", 100, "Virtual" },
                    { 2, "Digital tasbeeh counter", true, "Tasbeeh Counter", 200, "Physical" },
                    { 3, "Unlock Intermediate Level", true, "Intermediate Access", 100, "Virtual" },
                    { 4, "Unlock Advanced Level", true, "Advanced Access", 250, "Virtual" }
                });

            migrationBuilder.InsertData(
                table: "TaskSchedules",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Every day after any prayer", "Daily" },
                    { 2, "Tasks to do after Fajr", "After Fajr" },
                    { 3, "Tasks to do after Maghrib", "After Maghrib" },
                    { 4, "Once every week", "Weekly" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CurrentLevel", "Email", "FullName", "GoogleId", "PointsBalance" },
                values: new object[,]
                {
                    { 1, "Beginner", "beginner@example.com", "Beginner User", "g_beg_1", 20 },
                    { 2, "Intermediate", "intermediate@example.com", "Intermediate User", "g_int_1", 120 },
                    { 3, "Advanced", "advanced@example.com", "Advanced User", "g_adv_1", 280 }
                });

            migrationBuilder.InsertData(
                table: "CustomUserTasks",
                columns: new[] { "Id", "DueDate", "IsCompleted", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 7, 16, 0, 0, 0, 0, DateTimeKind.Utc), false, "Read Islamic book 10 mins", 2 },
                    { 2, new DateTime(2025, 7, 16, 0, 0, 0, 0, DateTimeKind.Utc), false, "Volunteer at mosque", 3 }
                });

            migrationBuilder.InsertData(
                table: "UserTasks",
                columns: new[] { "Id", "ContentReference", "ContentType", "Description", "TaskScheduleId", "Title" },
                values: new object[,]
                {
                    { 1, null, "Checklist", "Complete all 5 daily prayers", 1, "Pray 5 Times Salah" },
                    { 2, "DuaFajr1", "Dua", "Daily Masnun dua after Fajr", 2, "Recite Dua After Fajr" },
                    { 3, "DuaMaghrib1", "Dua", "Daily Masnun dua after Maghrib", 3, "Recite Dua After Maghrib" },
                    { 4, "Yasin", "Surah", "Weekly Surah Yasin recitation", 4, "Recite Surah Yasin" },
                    { 5, "Mulk", "Surah", "Night recitation of Surah Mulk", 3, "Recite Surah Mulk" },
                    { 6, "Ikhlas,Falaq,Nas", "Surah", "Morning and evening protection", 1, "Recite 3 Quls" }
                });

            migrationBuilder.InsertData(
                table: "TaskLevels",
                columns: new[] { "Level", "TaskId" },
                values: new object[,]
                {
                    { "Beginner", 1 },
                    { "Beginner", 2 },
                    { "Beginner", 3 },
                    { "Intermediate", 4 },
                    { "Advanced", 5 },
                    { "Intermediate", 6 }
                });

            migrationBuilder.InsertData(
                table: "UserProgresses",
                columns: new[] { "Id", "CompletionDate", "PointsAwarded", "TaskId", "UserId" },
                values: new object[] { 1, new DateTime(2025, 7, 16, 0, 0, 0, 0, DateTimeKind.Utc), 10, 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_CustomUserTasks_UserId",
                table: "CustomUserTasks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProgresses_TaskId",
                table: "UserProgresses",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProgresses_UserId",
                table: "UserProgresses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRewardRedemptions_RewardId",
                table: "UserRewardRedemptions",
                column: "RewardId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRewardRedemptions_UserId",
                table: "UserRewardRedemptions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTasks_TaskScheduleId",
                table: "UserTasks",
                column: "TaskScheduleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomUserTasks");

            migrationBuilder.DropTable(
                name: "TaskLevels");

            migrationBuilder.DropTable(
                name: "UserProgresses");

            migrationBuilder.DropTable(
                name: "UserRewardRedemptions");

            migrationBuilder.DropTable(
                name: "UserTasks");

            migrationBuilder.DropTable(
                name: "Rewards");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "TaskSchedules");
        }
    }
}
