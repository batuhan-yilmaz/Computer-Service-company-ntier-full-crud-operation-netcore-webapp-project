using Microsoft.EntityFrameworkCore.Migrations;

namespace General.DataAccess.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ControlCenters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ControlcenterKey = table.Column<string>(nullable: true),
                    mainsliderimage = table.Column<string>(nullable: true),
                    mainsliderimage2 = table.Column<string>(nullable: true),
                    mainsliderimage3 = table.Column<string>(nullable: true),
                    mainsliderimage4 = table.Column<string>(nullable: true),
                    parallax1 = table.Column<string>(nullable: true),
                    parallax2 = table.Column<string>(nullable: true),
                    parallax3 = table.Column<string>(nullable: true),
                    Adress = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    webadress = table.Column<string>(nullable: true),
                    Logo = table.Column<string>(nullable: true),
                    contract1tr = table.Column<string>(nullable: true),
                    contract2tr = table.Column<string>(nullable: true),
                    contract3tr = table.Column<string>(nullable: true),
                    contract4tr = table.Column<string>(nullable: true),
                    socialnetwork1 = table.Column<string>(nullable: true),
                    socialnetwork2 = table.Column<string>(nullable: true),
                    socialnetwork3 = table.Column<string>(nullable: true),
                    socialnetwork4 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlCenters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyService",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    longexplanation = table.Column<string>(nullable: true),
                    shortexplanation = table.Column<string>(nullable: true),
                    icon = table.Column<string>(nullable: true),
                    image = table.Column<string>(nullable: true),
                    ControlCenterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyService", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyService_ControlCenters_ControlCenterId",
                        column: x => x.ControlCenterId,
                        principalTable: "ControlCenters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyService_ControlCenterId",
                table: "CompanyService",
                column: "ControlCenterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyService");

            migrationBuilder.DropTable(
                name: "ControlCenters");
        }
    }
}
