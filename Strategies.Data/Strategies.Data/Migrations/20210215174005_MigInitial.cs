using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Strategies.Data.Migrations
{
    public partial class MigInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rockets",
                columns: table => new
                {
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    stages = table.Column<int>(type: "int", nullable: false),
                    boosters = table.Column<int>(type: "int", nullable: false),
                    cost_per_launch = table.Column<int>(type: "int", nullable: false),
                    success_rate_pct = table.Column<int>(type: "int", nullable: false),
                    first_flight = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    company = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    wikipedia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    id = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rockets", x => x.ItemId);
                });

            migrationBuilder.InsertData(
                table: "Rockets",
                columns: new[] { "ItemId", "active", "boosters", "company", "cost_per_launch", "country", "description", "first_flight", "id", "name", "stages", "success_rate_pct", "type", "wikipedia" },
                values: new object[,]
                {
                    { new Guid("122ace60-c863-4b2b-874b-2d1b9a4c70a2"), false, 0, "SpaceX", 6700000, "Republic of the Marshall Islands", "The Falcon 1 was an expendable launch system privately developed and manufactured by SpaceX during 2006-2009. On 28 September 2008, Falcon 1 became the first privately-developed liquid-fuel launch vehicle to go into orbit around the Earth.", "2006-03-24", "5e9d0d95eda69955f709d1eb", "Falcon 1", 2, 40, "rocket", "https://en.wikipedia.org/wiki/Falcon_1" },
                    { new Guid("9e293d4c-d291-45a6-b7fc-1e24cce5921a"), true, 0, "SpaceX", 50000000, "United States", "Falcon 9 is a two-stage rocket designed and manufactured by SpaceX for the reliable and safe transport of satellites and the Dragon spacecraft into orbit.", "2010-06-04", "5e9d0d95eda69973a809d1ec", "Falcon 9", 2, 97, "rocket", "https://en.wikipedia.org/wiki/Falcon_9" },
                    { new Guid("5e9d5754-7ac1-40bb-9c02-04b71cc16640"), true, 2, "SpaceX", 90000000, "United States", "With the ability to lift into orbit over 54 metric tons (119,000 lb)--a mass equivalent to a 737 jetliner loaded with passengers, crew, luggage and fuel--Falcon Heavy can lift more than twice the payload of the next closest operational vehicle, the Delta IV Heavy, at one-third the cost.", "2018-02-06", "5e9d0d95eda69974db09d1ed", "Falcon Heavy", 2, 100, "rocket", "https://en.wikipedia.org/wiki/Falcon_Heavy" },
                    { new Guid("39d0295d-5452-4d7f-9db3-6f7967700490"), false, 0, "SpaceX", 7000000, "United States", "Starship and Super Heavy Rocket represent a fully reusable transportation system designed to service all Earth orbit needs as well as the Moon and Mars. This two-stage vehicle � composed of the Super Heavy rocket (booster) and Starship (ship) � will eventually replace Falcon 9, Falcon Heavy and Dragon.", "2021-12-01", "5e9d0d96eda699382d09d1ee", "Starship", 2, 0, "rocket", "https://en.wikipedia.org/wiki/SpaceX_Starship" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rockets");
        }
    }
}
