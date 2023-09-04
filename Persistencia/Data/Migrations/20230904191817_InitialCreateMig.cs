using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "genero",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 3, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreGenero = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genero", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "pais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 3, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombrePais = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pais", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "salon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 3, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreSalon = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Capacidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_salon", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tipopersona",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 3, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DescripcionTipoPersona = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipopersona", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "departamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 3, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreDep = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdPaisFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_departamento_pais_IdPaisFk",
                        column: x => x.IdPaisFk,
                        principalTable: "pais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ciudad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 3, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreCiudad = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdepFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ciudad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ciudad_departamento_IdepFk",
                        column: x => x.IdepFk,
                        principalTable: "departamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "persona",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 3, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombrePersona = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ApellidoPersona = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdGeneroFk = table.Column<int>(type: "int", nullable: false),
                    IdCiudadFk = table.Column<int>(type: "int", nullable: false),
                    IdTipoPerFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_persona", x => x.Id);
                    table.ForeignKey(
                        name: "FK_persona_ciudad_IdCiudadFk",
                        column: x => x.IdCiudadFk,
                        principalTable: "ciudad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_persona_genero_IdGeneroFk",
                        column: x => x.IdGeneroFk,
                        principalTable: "genero",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_persona_tipopersona_IdTipoPerFk",
                        column: x => x.IdTipoPerFk,
                        principalTable: "tipopersona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "matricula",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 3, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdPersonaFk = table.Column<int>(type: "int", nullable: false),
                    PersonaId = table.Column<int>(type: "int", nullable: true),
                    IdSalonFk = table.Column<int>(type: "int", nullable: false),
                    SalonId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_matricula", x => x.Id);
                    table.ForeignKey(
                        name: "FK_matricula_persona_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "persona",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_matricula_salon_SalonId",
                        column: x => x.SalonId,
                        principalTable: "salon",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "trainersalon",
                columns: table => new
                {
                    IdPersonaTrainerFk = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    IdSalonFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trainersalon", x => new { x.IdSalonFk, x.IdPersonaTrainerFk });
                    table.ForeignKey(
                        name: "FK_trainersalon_persona_IdPersonaTrainerFk",
                        column: x => x.IdPersonaTrainerFk,
                        principalTable: "persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_trainersalon_salon_IdSalonFk",
                        column: x => x.IdSalonFk,
                        principalTable: "salon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ciudad_IdepFk",
                table: "ciudad",
                column: "IdepFk");

            migrationBuilder.CreateIndex(
                name: "IX_departamento_IdPaisFk",
                table: "departamento",
                column: "IdPaisFk");

            migrationBuilder.CreateIndex(
                name: "IX_matricula_PersonaId",
                table: "matricula",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_matricula_SalonId",
                table: "matricula",
                column: "SalonId");

            migrationBuilder.CreateIndex(
                name: "IX_persona_IdCiudadFk",
                table: "persona",
                column: "IdCiudadFk");

            migrationBuilder.CreateIndex(
                name: "IX_persona_IdGeneroFk",
                table: "persona",
                column: "IdGeneroFk");

            migrationBuilder.CreateIndex(
                name: "IX_persona_IdTipoPerFk",
                table: "persona",
                column: "IdTipoPerFk");

            migrationBuilder.CreateIndex(
                name: "IX_trainersalon_IdPersonaTrainerFk",
                table: "trainersalon",
                column: "IdPersonaTrainerFk");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "matricula");

            migrationBuilder.DropTable(
                name: "trainersalon");

            migrationBuilder.DropTable(
                name: "persona");

            migrationBuilder.DropTable(
                name: "salon");

            migrationBuilder.DropTable(
                name: "ciudad");

            migrationBuilder.DropTable(
                name: "genero");

            migrationBuilder.DropTable(
                name: "tipopersona");

            migrationBuilder.DropTable(
                name: "departamento");

            migrationBuilder.DropTable(
                name: "pais");
        }
    }
}
