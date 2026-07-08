using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECOM.Migrations
{
    /// <inheritdoc />
    public partial class CommentID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_COMMENTS",
                table: "COMMENTS");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "COMMENTS"
                );

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "COMMENTS",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity","1,1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_COMMENTS",
                table: "COMMENTS",
                column: "ID"
                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
