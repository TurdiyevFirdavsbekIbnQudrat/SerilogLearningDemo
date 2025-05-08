using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SerilogLearningDemo.Migrations
{
    /// <inheritdoc />
    public partial class addUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Foydalanuvchi ismi"),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false, comment: "Elektron pochta manzili"),
                    Password = table.Column<string>(type: "varchar(43)", nullable: false, comment: "Kirish uchun parol")
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
        }
    }
}
