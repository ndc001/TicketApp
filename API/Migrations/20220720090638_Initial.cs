using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    ticket_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ticket_type = table.Column<int>(type: "int", nullable: false),
                    ticket_resolution_type = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    ticket_status = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ticket_description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    assigned_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    resolved_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    resolution_note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.ticket_id);
                });

            migrationBuilder.CreateTable(
                name: "TicketNote",
                columns: table => new
                {
                    ticket_note_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    note_text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_history_note = table.Column<bool>(type: "bit", nullable: false),
                    is_internal = table.Column<bool>(type: "bit", nullable: false),
                    fk_ticket_id = table.Column<int>(type: "int", nullable: false),
                    ticket_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketNote", x => x.ticket_note_id);
                    table.ForeignKey(
                        name: "FK_TicketNote_Ticket_ticket_id",
                        column: x => x.ticket_id,
                        principalTable: "Ticket",
                        principalColumn: "ticket_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TicketNote_ticket_id",
                table: "TicketNote",
                column: "ticket_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TicketNote");

            migrationBuilder.DropTable(
                name: "Ticket");
        }
    }
}
