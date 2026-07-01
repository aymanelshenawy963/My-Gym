using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GymManagement.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedIdentityTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Members_MemberId",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassEnrollments_GymClasses_ClassId",
                table: "ClassEnrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassEnrollments_Members_MemberId",
                table: "ClassEnrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_GymClasses_Trainers_TrainerId",
                table: "GymClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_Members_AspNetUsers_UserId",
                table: "Members");

            migrationBuilder.DropForeignKey(
                name: "FK_MemberSubscriptions_Members_MemberId",
                table: "MemberSubscriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_MemberSubscriptions_MembershipPlans_PlanId",
                table: "MemberSubscriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainers_AspNetUsers_UserId",
                table: "Trainers");

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "AspNetRoles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AspNetRoles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "IsDefault", "IsDeleted", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0197cf4a-ac5d-7eef-a708-093bf42c7564", "0197cf4a-ac5d-7eef-a708-093cfad648ba", false, false, "Admin", "ADMIN" },
                    { "0197cf4a-ac5d-7eef-a708-093d426d0794", "0197cf4a-ac5d-7eef-a708-093e31470a2b", true, false, "Customer", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsDisabled", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0197cf4a-ac5c-76c1-aa23-e65baf669280", 0, "0197cf4a-ac5d-7eef-a708-093a94835448", "admin@gym.com", true, "Ayman", false, "Elshenawy", false, null, "ADMIN@GYM.COM", "ADMIN", "AQAAAAIAAYagAAAAEFnVAVxyzPFqpVnW/e91bWX5vgyL779eXkPr0XILoma/3pK8p+5mdbDm9TlaCBiy/Q==", null, false, "10FEEAC918104B68A8F1F626F8C14E37", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0197cf4a-ac5d-7eef-a708-093bf42c7564", "0197cf4a-ac5c-76c1-aa23-e65baf669280" });

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Members_MemberId",
                table: "Attendances",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassEnrollments_GymClasses_ClassId",
                table: "ClassEnrollments",
                column: "ClassId",
                principalTable: "GymClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassEnrollments_Members_MemberId",
                table: "ClassEnrollments",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GymClasses_Trainers_TrainerId",
                table: "GymClasses",
                column: "TrainerId",
                principalTable: "Trainers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Members_AspNetUsers_UserId",
                table: "Members",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MemberSubscriptions_Members_MemberId",
                table: "MemberSubscriptions",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MemberSubscriptions_MembershipPlans_PlanId",
                table: "MemberSubscriptions",
                column: "PlanId",
                principalTable: "MembershipPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainers_AspNetUsers_UserId",
                table: "Trainers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Members_MemberId",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassEnrollments_GymClasses_ClassId",
                table: "ClassEnrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassEnrollments_Members_MemberId",
                table: "ClassEnrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_GymClasses_Trainers_TrainerId",
                table: "GymClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_Members_AspNetUsers_UserId",
                table: "Members");

            migrationBuilder.DropForeignKey(
                name: "FK_MemberSubscriptions_Members_MemberId",
                table: "MemberSubscriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_MemberSubscriptions_MembershipPlans_PlanId",
                table: "MemberSubscriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainers_AspNetUsers_UserId",
                table: "Trainers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0197cf4a-ac5d-7eef-a708-093d426d0794");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0197cf4a-ac5d-7eef-a708-093bf42c7564", "0197cf4a-ac5c-76c1-aa23-e65baf669280" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0197cf4a-ac5d-7eef-a708-093bf42c7564");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0197cf4a-ac5c-76c1-aa23-e65baf669280");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AspNetRoles");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Members_MemberId",
                table: "Attendances",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassEnrollments_GymClasses_ClassId",
                table: "ClassEnrollments",
                column: "ClassId",
                principalTable: "GymClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassEnrollments_Members_MemberId",
                table: "ClassEnrollments",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GymClasses_Trainers_TrainerId",
                table: "GymClasses",
                column: "TrainerId",
                principalTable: "Trainers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Members_AspNetUsers_UserId",
                table: "Members",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MemberSubscriptions_Members_MemberId",
                table: "MemberSubscriptions",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MemberSubscriptions_MembershipPlans_PlanId",
                table: "MemberSubscriptions",
                column: "PlanId",
                principalTable: "MembershipPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainers_AspNetUsers_UserId",
                table: "Trainers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
