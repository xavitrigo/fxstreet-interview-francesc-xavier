using Microsoft.EntityFrameworkCore.Migrations;

namespace Football.Database.Migrations
{
    public partial class DataInitialization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "public",
                table: "Manager",
                columns: new[] { "Id", "Name", "RedCard" },
                values: new object[] { 1, "Alex", 1 });

            migrationBuilder.InsertData(
                schema: "public",
                table: "Manager",
                columns: new[] { "Id", "Name", "YellowCard" },
                values: new object[,]
                {
                    { 2, "Zidane", 1 },
                    { 3, "Guardiola", 1 },
                    { 4, "Rafa", 2 }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "Manager",
                columns: new[] { "Id", "Name", "RedCard", "YellowCard" },
                values: new object[,]
                {
                    { 5, "Jose", 2, 2 },
                    { 6, "Ancelotti", 1, 1 }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "Manager",
                columns: new[] { "Id", "Name" },
                values: new object[] { 7, "Diego" });

            migrationBuilder.InsertData(
                schema: "public",
                table: "Player",
                columns: new[] { "Id", "MinutesPlayed", "Name", "YellowCard" },
                values: new object[] { 18, 58, "Theo", 2 });

            migrationBuilder.InsertData(
                schema: "public",
                table: "Player",
                columns: new[] { "Id", "MinutesPlayed", "Name", "RedCard", "YellowCard" },
                values: new object[,]
                {
                    { 19, 36, "Cristiano", 1, 4 },
                    { 20, 71, "Gavi", 3, 1 }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "Player",
                columns: new[] { "Id", "MinutesPlayed", "Name", "RedCard" },
                values: new object[,]
                {
                    { 21, 86, "Lautaro", 2 },
                    { 22, 82, "Joshua", 2 }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "Player",
                columns: new[] { "Id", "MinutesPlayed", "Name", "RedCard", "YellowCard" },
                values: new object[] { 23, 90, "Eder", 1, 1 });

            migrationBuilder.InsertData(
                schema: "public",
                table: "Player",
                columns: new[] { "Id", "MinutesPlayed", "Name", "YellowCard" },
                values: new object[] { 27, 12, "Raul", 1 });

            migrationBuilder.InsertData(
                schema: "public",
                table: "Player",
                columns: new[] { "Id", "MinutesPlayed", "Name", "RedCard", "YellowCard" },
                values: new object[,]
                {
                    { 25, 57, "Thomas", 3, 3 },
                    { 26, 51, "Rafael", 4, 4 }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "Player",
                columns: new[] { "Id", "MinutesPlayed", "Name", "YellowCard" },
                values: new object[] { 17, 68, "Pedri", 5 });

            migrationBuilder.InsertData(
                schema: "public",
                table: "Player",
                columns: new[] { "Id", "MinutesPlayed", "Name", "RedCard", "YellowCard" },
                values: new object[,]
                {
                    { 28, 87, "Mason", 1, 1 },
                    { 29, 64, "Andrew", 2, 3 },
                    { 30, 56, "Recee", 2, 2 },
                    { 24, 39, "Harry", 1, 2 },
                    { 16, 12, "Antonio", 2, 4 },
                    { 14, 68, "Rafael", 1, 2 }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "Player",
                columns: new[] { "Id", "MinutesPlayed", "Name", "RedCard" },
                values: new object[] { 6, 90, "Jordi", 2 });

            migrationBuilder.InsertData(
                schema: "public",
                table: "Player",
                columns: new[] { "Id", "MinutesPlayed", "Name", "RedCard", "YellowCard" },
                values: new object[,]
                {
                    { 13, 54, "Luka", 3, 1 },
                    { 12, 77, "Fabinho", 3, 3 },
                    { 11, 76, "Sadio", 2, 1 },
                    { 10, 23, "Karim", 1, 1 }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "Player",
                columns: new[] { "Id", "MinutesPlayed", "Name", "YellowCard" },
                values: new object[] { 9, 48, "Geronimo", 1 });

            migrationBuilder.InsertData(
                schema: "public",
                table: "Player",
                columns: new[] { "Id", "MinutesPlayed", "Name", "RedCard", "YellowCard" },
                values: new object[,]
                {
                    { 8, 35, "Fran", 1, 3 },
                    { 7, 65, "Kylian", 3, 1 },
                    { 15, 89, "Bernardo", 1, 3 }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "Player",
                columns: new[] { "Id", "MinutesPlayed", "Name", "YellowCard" },
                values: new object[,]
                {
                    { 5, 80, "Philippe", 1 },
                    { 4, 67, "Gerard", 4 }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "Player",
                columns: new[] { "Id", "MinutesPlayed", "Name", "RedCard", "YellowCard" },
                values: new object[,]
                {
                    { 3, 23, "Iker", 2, 3 },
                    { 2, 52, "Cristiano", 1, 2 },
                    { 1, 78, "Lionel", 1, 1 }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "Referee",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 2, "Howard" },
                    { 3, "Mateu" },
                    { 1, "Pierluigi" },
                    { 4, "Luis" }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "Match",
                columns: new[] { "Id", "AwayManagerId", "HouseManagerId", "RefereeId" },
                values: new object[,]
                {
                    { 1, 4, 3, 3 },
                    { 2, 6, 5, 4 }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "AwayPlayer",
                columns: new[] { "PlayerId", "MatchId" },
                values: new object[,]
                {
                    { 7, 1 },
                    { 8, 1 },
                    { 9, 1 },
                    { 10, 1 },
                    { 11, 1 },
                    { 15, 2 },
                    { 14, 2 },
                    { 13, 2 },
                    { 12, 2 }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "HousePlayer",
                columns: new[] { "PlayerId", "MatchId" },
                values: new object[,]
                {
                    { 22, 2 },
                    { 21, 2 },
                    { 19, 1 },
                    { 24, 2 },
                    { 18, 1 },
                    { 17, 1 },
                    { 16, 1 },
                    { 20, 1 },
                    { 25, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "public",
                table: "AwayPlayer",
                keyColumns: new[] { "PlayerId", "MatchId" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                schema: "public",
                table: "AwayPlayer",
                keyColumns: new[] { "PlayerId", "MatchId" },
                keyValues: new object[] { 8, 1 });

            migrationBuilder.DeleteData(
                schema: "public",
                table: "AwayPlayer",
                keyColumns: new[] { "PlayerId", "MatchId" },
                keyValues: new object[] { 9, 1 });

            migrationBuilder.DeleteData(
                schema: "public",
                table: "AwayPlayer",
                keyColumns: new[] { "PlayerId", "MatchId" },
                keyValues: new object[] { 10, 1 });

            migrationBuilder.DeleteData(
                schema: "public",
                table: "AwayPlayer",
                keyColumns: new[] { "PlayerId", "MatchId" },
                keyValues: new object[] { 11, 1 });

            migrationBuilder.DeleteData(
                schema: "public",
                table: "AwayPlayer",
                keyColumns: new[] { "PlayerId", "MatchId" },
                keyValues: new object[] { 12, 2 });

            migrationBuilder.DeleteData(
                schema: "public",
                table: "AwayPlayer",
                keyColumns: new[] { "PlayerId", "MatchId" },
                keyValues: new object[] { 13, 2 });

            migrationBuilder.DeleteData(
                schema: "public",
                table: "AwayPlayer",
                keyColumns: new[] { "PlayerId", "MatchId" },
                keyValues: new object[] { 14, 2 });

            migrationBuilder.DeleteData(
                schema: "public",
                table: "AwayPlayer",
                keyColumns: new[] { "PlayerId", "MatchId" },
                keyValues: new object[] { 15, 2 });

            migrationBuilder.DeleteData(
                schema: "public",
                table: "HousePlayer",
                keyColumns: new[] { "PlayerId", "MatchId" },
                keyValues: new object[] { 16, 1 });

            migrationBuilder.DeleteData(
                schema: "public",
                table: "HousePlayer",
                keyColumns: new[] { "PlayerId", "MatchId" },
                keyValues: new object[] { 17, 1 });

            migrationBuilder.DeleteData(
                schema: "public",
                table: "HousePlayer",
                keyColumns: new[] { "PlayerId", "MatchId" },
                keyValues: new object[] { 18, 1 });

            migrationBuilder.DeleteData(
                schema: "public",
                table: "HousePlayer",
                keyColumns: new[] { "PlayerId", "MatchId" },
                keyValues: new object[] { 19, 1 });

            migrationBuilder.DeleteData(
                schema: "public",
                table: "HousePlayer",
                keyColumns: new[] { "PlayerId", "MatchId" },
                keyValues: new object[] { 20, 1 });

            migrationBuilder.DeleteData(
                schema: "public",
                table: "HousePlayer",
                keyColumns: new[] { "PlayerId", "MatchId" },
                keyValues: new object[] { 21, 2 });

            migrationBuilder.DeleteData(
                schema: "public",
                table: "HousePlayer",
                keyColumns: new[] { "PlayerId", "MatchId" },
                keyValues: new object[] { 22, 2 });

            migrationBuilder.DeleteData(
                schema: "public",
                table: "HousePlayer",
                keyColumns: new[] { "PlayerId", "MatchId" },
                keyValues: new object[] { 24, 2 });

            migrationBuilder.DeleteData(
                schema: "public",
                table: "HousePlayer",
                keyColumns: new[] { "PlayerId", "MatchId" },
                keyValues: new object[] { 25, 2 });

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Manager",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Manager",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Manager",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Player",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Player",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Player",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Player",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Player",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Player",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Player",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Player",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Player",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Player",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Player",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Player",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Referee",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Referee",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Match",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Match",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Player",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Player",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Player",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Player",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Player",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Player",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Player",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Player",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Player",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Player",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Player",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Player",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Player",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Player",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Player",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Player",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Player",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Player",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Manager",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Manager",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Manager",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Manager",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Referee",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Referee",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
