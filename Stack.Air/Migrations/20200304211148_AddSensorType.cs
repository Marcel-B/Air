using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace com.b_velop.Stack.Air.Migrations
{
    public partial class AddSensorType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ValueTypeId",
                table: "Sensors",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ValueTypes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Display = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValueTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sensors_ValueTypeId",
                table: "Sensors",
                column: "ValueTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sensors_ValueTypes_ValueTypeId",
                table: "Sensors",
                column: "ValueTypeId",
                principalTable: "ValueTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sensors_ValueTypes_ValueTypeId",
                table: "Sensors");

            migrationBuilder.DropTable(
                name: "ValueTypes");

            migrationBuilder.DropIndex(
                name: "IX_Sensors_ValueTypeId",
                table: "Sensors");

            migrationBuilder.DropColumn(
                name: "ValueTypeId",
                table: "Sensors");
        }
    }
}
