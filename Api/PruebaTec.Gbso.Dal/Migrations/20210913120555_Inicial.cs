using Microsoft.EntityFrameworkCore.Migrations;

namespace PruebaTec.Gbso.Dal.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoIdentificacionModel",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoIdentificacionModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoIdentificacionId = table.Column<short>(type: "smallint", nullable: false),
                    Contrasenia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_TipoIdentificacionModel_TipoIdentificacionId",
                        column: x => x.TipoIdentificacionId,
                        principalTable: "TipoIdentificacionModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TipoIdentificacionModel",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { (short)1, "CC" },
                    { (short)2, "RC" },
                    { (short)3, "TI" },
                    { (short)4, "CE" },
                    { (short)5, "PA" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_TipoIdentificacionId",
                table: "Usuarios",
                column: "TipoIdentificacionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "TipoIdentificacionModel");
        }
    }
}
