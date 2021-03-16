using Microsoft.EntityFrameworkCore.Migrations;

namespace SongerAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SongItems",
                columns: table => new
                {
                    SongId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SongTitle = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    SongArtist = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    SongKey = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    SongBpm = table.Column<string>(type: "nvarchar(3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongItems", x => x.SongId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SongItems");
        }
    }
}
