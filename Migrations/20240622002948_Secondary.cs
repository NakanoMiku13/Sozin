using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SozinBackNew.Migrations
{
    /// <inheritdoc />
    public partial class Secondary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaterialsPerIncident_Materials_material_idId",
                table: "MaterialsPerIncident");

            migrationBuilder.RenameColumn(
                name: "material_idId",
                table: "MaterialsPerIncident",
                newName: "MaterialId");

            migrationBuilder.RenameColumn(
                name: "incident_id",
                table: "MaterialsPerIncident",
                newName: "IncidentId");

            migrationBuilder.RenameIndex(
                name: "IX_MaterialsPerIncident_material_idId",
                table: "MaterialsPerIncident",
                newName: "IX_MaterialsPerIncident_MaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialsPerIncident_Materials_MaterialId",
                table: "MaterialsPerIncident",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaterialsPerIncident_Materials_MaterialId",
                table: "MaterialsPerIncident");

            migrationBuilder.RenameColumn(
                name: "MaterialId",
                table: "MaterialsPerIncident",
                newName: "material_idId");

            migrationBuilder.RenameColumn(
                name: "IncidentId",
                table: "MaterialsPerIncident",
                newName: "incident_id");

            migrationBuilder.RenameIndex(
                name: "IX_MaterialsPerIncident_MaterialId",
                table: "MaterialsPerIncident",
                newName: "IX_MaterialsPerIncident_material_idId");

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialsPerIncident_Materials_material_idId",
                table: "MaterialsPerIncident",
                column: "material_idId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
