using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YouLearn.Infra.Migrations
{
    public partial class Setup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(maxLength: 200, nullable: false),
                    Password = table.Column<string>(maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Channel",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdUser = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    UrlLogo = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Channel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Channel_User_IdUser",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlayList",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    IdUser = table.Column<Guid>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayList_User_IdUser",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Video",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdChannel = table.Column<Guid>(nullable: true),
                    IdPlayList = table.Column<Guid>(nullable: true),
                    IdUser = table.Column<Guid>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 200, nullable: false),
                    Description = table.Column<string>(maxLength: 255, nullable: false),
                    Tags = table.Column<string>(maxLength: 100, nullable: false),
                    OrdemNaPlayList = table.Column<int>(nullable: false),
                    OrderPlayList = table.Column<int>(nullable: false),
                    IdVideoYoutube = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Video", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Video_Channel_IdChannel",
                        column: x => x.IdChannel,
                        principalTable: "Channel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Video_PlayList_IdPlayList",
                        column: x => x.IdPlayList,
                        principalTable: "PlayList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Video_User_IdUser",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Channel_IdUser",
                table: "Channel",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_PlayList_IdUser",
                table: "PlayList",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Video_IdChannel",
                table: "Video",
                column: "IdChannel");

            migrationBuilder.CreateIndex(
                name: "IX_Video_IdPlayList",
                table: "Video",
                column: "IdPlayList");

            migrationBuilder.CreateIndex(
                name: "IX_Video_IdUser",
                table: "Video",
                column: "IdUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Video");

            migrationBuilder.DropTable(
                name: "Channel");

            migrationBuilder.DropTable(
                name: "PlayList");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
