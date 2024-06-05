using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Polling_Page_Administration_Task.Migrations
{
    /// <inheritdoc />
    public partial class AssignAdminToAllRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into [Security].[UserRoles] (UserId,RoleId) select '4763a8d4-fcf2-4768-9fbc-bb3a4ed1e300',Id from [Security].[Roles]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from [Security].[UserRoles] where UserId='4763a8d4-fcf2-4768-9fbc-bb3a4ed1e300'");
        }
    }
}
