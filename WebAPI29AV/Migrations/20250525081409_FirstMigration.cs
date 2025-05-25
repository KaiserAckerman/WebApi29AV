using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebAPI29AV.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    PKRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.PKRol);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    PKUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FKRol = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.PKUser);
                    table.ForeignKey(
                        name: "FK_Users_Roles_FKRol",
                        column: x => x.FKRol,
                        principalTable: "Roles",
                        principalColumn: "PKRol");
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "PKRol", "Name" },
                values: new object[,]
                {
                    { 1, "Alumno" },
                    { 2, "Maestro" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "PKUser", "FKRol", "Name", "Password", "Username" },
                values: new object[,]
                {
                    { 1, 2, "Josafat", "1910", "Joss" },
                    { 2, 1, "Roberto", "1910", "Kaiser" },
                    { 3, 1, "Kaiser", "1910", "Ackerman" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_FKRol",
                table: "Users",
                column: "FKRol");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
