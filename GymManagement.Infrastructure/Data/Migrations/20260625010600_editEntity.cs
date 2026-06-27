using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymManagement.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class editEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassEnrollments_GymClasses_GymClassId",
                table: "ClassEnrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_MemberSubscriptions_MembershipPlans_MembershipPlanId",
                table: "MemberSubscriptions");

            migrationBuilder.DropIndex(
                name: "IX_MemberSubscriptions_MembershipPlanId",
                table: "MemberSubscriptions");

            migrationBuilder.DropIndex(
                name: "IX_ClassEnrollments_GymClassId",
                table: "ClassEnrollments");

            migrationBuilder.DropColumn(
                name: "MembershipPlanId",
                table: "MemberSubscriptions");

            migrationBuilder.DropColumn(
                name: "GymClassId",
                table: "ClassEnrollments");

            migrationBuilder.CreateIndex(
                name: "IX_MemberSubscriptions_PlanId",
                table: "MemberSubscriptions",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassEnrollments_ClassId",
                table: "ClassEnrollments",
                column: "ClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassEnrollments_GymClasses_ClassId",
                table: "ClassEnrollments",
                column: "ClassId",
                principalTable: "GymClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MemberSubscriptions_MembershipPlans_PlanId",
                table: "MemberSubscriptions",
                column: "PlanId",
                principalTable: "MembershipPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassEnrollments_GymClasses_ClassId",
                table: "ClassEnrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_MemberSubscriptions_MembershipPlans_PlanId",
                table: "MemberSubscriptions");

            migrationBuilder.DropIndex(
                name: "IX_MemberSubscriptions_PlanId",
                table: "MemberSubscriptions");

            migrationBuilder.DropIndex(
                name: "IX_ClassEnrollments_ClassId",
                table: "ClassEnrollments");

            migrationBuilder.AddColumn<int>(
                name: "MembershipPlanId",
                table: "MemberSubscriptions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GymClassId",
                table: "ClassEnrollments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MemberSubscriptions_MembershipPlanId",
                table: "MemberSubscriptions",
                column: "MembershipPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassEnrollments_GymClassId",
                table: "ClassEnrollments",
                column: "GymClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassEnrollments_GymClasses_GymClassId",
                table: "ClassEnrollments",
                column: "GymClassId",
                principalTable: "GymClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_MemberSubscriptions_MembershipPlans_MembershipPlanId",
                table: "MemberSubscriptions",
                column: "MembershipPlanId",
                principalTable: "MembershipPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
