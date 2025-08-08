using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParcelManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddStatusToParcel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_parcels",
                table: "parcels");

            migrationBuilder.RenameTable(
                name: "parcels",
                newName: "Parcels");

            migrationBuilder.AlterColumn<string>(
                name: "SenderName",
                table: "Parcels",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "RecieverName",
                table: "Parcels",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Origin",
                table: "Parcels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Parcels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parcels",
                table: "Parcels",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Parcels",
                table: "Parcels");

            migrationBuilder.DropColumn(
                name: "Origin",
                table: "Parcels");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Parcels");

            migrationBuilder.RenameTable(
                name: "Parcels",
                newName: "parcels");

            migrationBuilder.AlterColumn<string>(
                name: "SenderName",
                table: "parcels",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "RecieverName",
                table: "parcels",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddPrimaryKey(
                name: "PK_parcels",
                table: "parcels",
                column: "Id");
        }
    }
}
