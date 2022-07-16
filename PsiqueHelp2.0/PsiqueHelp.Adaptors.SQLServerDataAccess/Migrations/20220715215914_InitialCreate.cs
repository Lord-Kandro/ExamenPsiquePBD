using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PsiqueHelp.Adaptors.SQLServerDataAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_ConTer",
                columns: table => new
                {
                    ConTer_id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_ConTer", x => x.ConTer_id);
                });

            migrationBuilder.CreateTable(
                name: "tb_UserDa",
                columns: table => new
                {
                    Id_UserDa = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Nick = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Department = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Cell = table.Column<int>(nullable: false),
                    IdPerson = table.Column<string>(nullable: true),
                    age = table.Column<int>(nullable: false),
                    Created_at = table.Column<DateTime>(nullable: false),
                    Updated_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_UserDa", x => x.Id_UserDa);
                });

            migrationBuilder.CreateTable(
                name: "tb_Mediums",
                columns: table => new
                {
                    Id_Medios = table.Column<Guid>(nullable: false),
                    video = table.Column<string>(nullable: true),
                    music = table.Column<string>(nullable: true),
                    image = table.Column<string>(nullable: true),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false),
                    ConTer_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Mediums", x => x.Id_Medios);
                    table.ForeignKey(
                        name: "FK_tb_Mediums_tb_ConTer_ConTer_id",
                        column: x => x.ConTer_id,
                        principalTable: "tb_ConTer",
                        principalColumn: "ConTer_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_PsyDa",
                columns: table => new
                {
                    Id_User_Psy = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Nick = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Department = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    cell = table.Column<int>(nullable: false),
                    idPerson = table.Column<string>(nullable: true),
                    Register_S = table.Column<int>(nullable: false),
                    folio = table.Column<int>(nullable: false),
                    volume = table.Column<int>(nullable: false),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false),
                    ConTer_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_PsyDa", x => x.Id_User_Psy);
                    table.ForeignKey(
                        name: "FK_tb_PsyDa_tb_ConTer_ConTer_id",
                        column: x => x.ConTer_id,
                        principalTable: "tb_ConTer",
                        principalColumn: "ConTer_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_Notes",
                columns: table => new
                {
                    id_Note = table.Column<Guid>(nullable: false),
                    title = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    date = table.Column<DateTime>(nullable: false),
                    Id_UserDa = table.Column<Guid>(nullable: false),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Notes", x => x.id_Note);
                    table.ForeignKey(
                        name: "FK_tb_Notes_tb_UserDa_Id_UserDa",
                        column: x => x.Id_UserDa,
                        principalTable: "tb_UserDa",
                        principalColumn: "Id_UserDa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_Forum",
                columns: table => new
                {
                    Id_Forum = table.Column<Guid>(nullable: false),
                    topic = table.Column<string>(nullable: true),
                    Id_UserDa = table.Column<Guid>(nullable: false),
                    Id_User_Psy = table.Column<Guid>(nullable: false),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Forum", x => x.Id_Forum);
                    table.ForeignKey(
                        name: "FK_tb_Forum_tb_UserDa_Id_UserDa",
                        column: x => x.Id_UserDa,
                        principalTable: "tb_UserDa",
                        principalColumn: "Id_UserDa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_Forum_tb_PsyDa_Id_User_Psy",
                        column: x => x.Id_User_Psy,
                        principalTable: "tb_PsyDa",
                        principalColumn: "Id_User_Psy",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_LoginUsers",
                columns: table => new
                {
                    Id_Login = table.Column<Guid>(nullable: false),
                    email = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false),
                    Id_UserDa = table.Column<Guid>(nullable: false),
                    Id_User_Psy = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_LoginUsers", x => x.Id_Login);
                    table.ForeignKey(
                        name: "FK_tb_LoginUsers_tb_UserDa_Id_UserDa",
                        column: x => x.Id_UserDa,
                        principalTable: "tb_UserDa",
                        principalColumn: "Id_UserDa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_LoginUsers_tb_PsyDa_Id_User_Psy",
                        column: x => x.Id_User_Psy,
                        principalTable: "tb_PsyDa",
                        principalColumn: "Id_User_Psy",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_comments",
                columns: table => new
                {
                    Id_UserDa = table.Column<Guid>(nullable: false),
                    Id_Forum = table.Column<Guid>(nullable: false),
                    title = table.Column<string>(nullable: true),
                    comment = table.Column<string>(nullable: true),
                    timedate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_comments", x => new { x.Id_Forum, x.Id_UserDa });
                    table.ForeignKey(
                        name: "FK_tb_comments_tb_Forum_Id_Forum",
                        column: x => x.Id_Forum,
                        principalTable: "tb_Forum",
                        principalColumn: "Id_Forum",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_comments_tb_UserDa_Id_UserDa",
                        column: x => x.Id_UserDa,
                        principalTable: "tb_UserDa",
                        principalColumn: "Id_UserDa");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_comments_Id_UserDa",
                table: "tb_comments",
                column: "Id_UserDa");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Forum_Id_UserDa",
                table: "tb_Forum",
                column: "Id_UserDa");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Forum_Id_User_Psy",
                table: "tb_Forum",
                column: "Id_User_Psy");

            migrationBuilder.CreateIndex(
                name: "IX_tb_LoginUsers_Id_UserDa",
                table: "tb_LoginUsers",
                column: "Id_UserDa",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_LoginUsers_Id_User_Psy",
                table: "tb_LoginUsers",
                column: "Id_User_Psy",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_Mediums_ConTer_id",
                table: "tb_Mediums",
                column: "ConTer_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Notes_Id_UserDa",
                table: "tb_Notes",
                column: "Id_UserDa");

            migrationBuilder.CreateIndex(
                name: "IX_tb_PsyDa_ConTer_id",
                table: "tb_PsyDa",
                column: "ConTer_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_comments");

            migrationBuilder.DropTable(
                name: "tb_LoginUsers");

            migrationBuilder.DropTable(
                name: "tb_Mediums");

            migrationBuilder.DropTable(
                name: "tb_Notes");

            migrationBuilder.DropTable(
                name: "tb_Forum");

            migrationBuilder.DropTable(
                name: "tb_UserDa");

            migrationBuilder.DropTable(
                name: "tb_PsyDa");

            migrationBuilder.DropTable(
                name: "tb_ConTer");
        }
    }
}
