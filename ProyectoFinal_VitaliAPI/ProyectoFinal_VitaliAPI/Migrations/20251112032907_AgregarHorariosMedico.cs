using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinal_VitaliAPI.Migrations
{
    /// <inheritdoc />
    public partial class AgregarHorariosMedico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HorarioConsulta",
                table: "Medicos");

            migrationBuilder.CreateTable(
                name: "HorarioConsulta",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DiaSemana = table.Column<string>(type: "text", nullable: false),
                    Espacio1 = table.Column<string>(type: "text", nullable: false),
                    Espacio2 = table.Column<string>(type: "text", nullable: false),
                    Espacio3 = table.Column<string>(type: "text", nullable: false),
                    Espacio4 = table.Column<string>(type: "text", nullable: false),
                    MedicoId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorarioConsulta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HorarioConsulta_Medicos_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HorarioConsulta_MedicoId",
                table: "HorarioConsulta",
                column: "MedicoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HorarioConsulta");

            migrationBuilder.AddColumn<string>(
                name: "HorarioConsulta",
                table: "Medicos",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
