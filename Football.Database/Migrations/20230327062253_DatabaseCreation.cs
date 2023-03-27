using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Football.Database.Migrations
{
    public partial class DatabaseCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "Manager",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'8', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: false),
                    YellowCard = table.Column<int>(nullable: false, defaultValue: 0),
                    RedCard = table.Column<int>(nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manager", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Player",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'31', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: false),
                    YellowCard = table.Column<int>(nullable: false, defaultValue: 0),
                    RedCard = table.Column<int>(nullable: false, defaultValue: 0),
                    MinutesPlayed = table.Column<int>(nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Referee",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'5', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: false),
                    MinutesPlayed = table.Column<int>(nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Referee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Match",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'3', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HouseManagerId = table.Column<int>(nullable: false),
                    AwayManagerId = table.Column<int>(nullable: false),
                    RefereeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Match", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Match_Manager_AwayManagerId",
                        column: x => x.AwayManagerId,
                        principalSchema: "public",
                        principalTable: "Manager",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Match_Manager_HouseManagerId",
                        column: x => x.HouseManagerId,
                        principalSchema: "public",
                        principalTable: "Manager",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Match_Referee_RefereeId",
                        column: x => x.RefereeId,
                        principalSchema: "public",
                        principalTable: "Referee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AwayPlayer",
                schema: "public",
                columns: table => new
                {
                    PlayerId = table.Column<int>(nullable: false),
                    MatchId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AwayPlayer", x => new { x.PlayerId, x.MatchId });
                    table.ForeignKey(
                        name: "FK_AwayPlayer_Match_MatchId",
                        column: x => x.MatchId,
                        principalSchema: "public",
                        principalTable: "Match",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AwayPlayer_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalSchema: "public",
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HousePlayer",
                schema: "public",
                columns: table => new
                {
                    PlayerId = table.Column<int>(nullable: false),
                    MatchId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HousePlayer", x => new { x.PlayerId, x.MatchId });
                    table.ForeignKey(
                        name: "FK_HousePlayer_Match_MatchId",
                        column: x => x.MatchId,
                        principalSchema: "public",
                        principalTable: "Match",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HousePlayer_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalSchema: "public",
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AwayPlayer_MatchId",
                schema: "public",
                table: "AwayPlayer",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_HousePlayer_MatchId",
                schema: "public",
                table: "HousePlayer",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_AwayManagerId",
                schema: "public",
                table: "Match",
                column: "AwayManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_HouseManagerId",
                schema: "public",
                table: "Match",
                column: "HouseManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_RefereeId",
                schema: "public",
                table: "Match",
                column: "RefereeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AwayPlayer",
                schema: "public");

            migrationBuilder.DropTable(
                name: "HousePlayer",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Match",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Player",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Manager",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Referee",
                schema: "public");
        }
    }
}
