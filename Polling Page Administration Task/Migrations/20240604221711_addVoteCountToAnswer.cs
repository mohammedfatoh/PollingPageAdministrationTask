using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Polling_Page_Administration_Task.Migrations
{
    /// <inheritdoc />
    public partial class addVoteCountToAnswer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VoteCount",
                table: "Answers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VoteCount",
                table: "Answers");
        }
    }
}
