using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TrainTimings.Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    Name = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("cities_pk", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypesFollowing",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    Name = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    Time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("TypesFollowing_pk", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypesTrains",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    Name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Tipes_pk", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trains",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    Number = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: false),
                    TypeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Trains_pk", x => x.Id);
                    table.ForeignKey(
                        name: "Trains_Tipes_Id_fk",
                        column: x => x.TypeId,
                        principalTable: "TypesTrains",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CitiesTrain",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    TrainId = table.Column<int>(type: "integer", nullable: false),
                    CityId = table.Column<int>(type: "integer", nullable: false),
                    TypeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("CitiesTrain_pk", x => x.Id);
                    table.ForeignKey(
                        name: "CitiesTrain_Cities_Id_fk",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "CitiesTrain_Trains_Id_fk",
                        column: x => x.TrainId,
                        principalTable: "Trains",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "CitiesTrain_TypesFollowing_Id_fk",
                        column: x => x.TypeId,
                        principalTable: "TypesFollowing",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Timings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    Arrival = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Departure = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Platform = table.Column<string>(type: "character varying", nullable: false),
                    TrainId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Timings_pk", x => x.Id);
                    table.ForeignKey(
                        name: "Timings_Trains_Id_fk",
                        column: x => x.TrainId,
                        principalTable: "Trains",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CitiesTrain_CityId",
                table: "CitiesTrain",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_CitiesTrain_TrainId",
                table: "CitiesTrain",
                column: "TrainId");

            migrationBuilder.CreateIndex(
                name: "IX_CitiesTrain_TypeId",
                table: "CitiesTrain",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Timings_TrainId",
                table: "Timings",
                column: "TrainId");

            migrationBuilder.CreateIndex(
                name: "IX_Trains_TypeId",
                table: "Trains",
                column: "TypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CitiesTrain");

            migrationBuilder.DropTable(
                name: "Timings");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "TypesFollowing");

            migrationBuilder.DropTable(
                name: "Trains");

            migrationBuilder.DropTable(
                name: "TypesTrains");
        }
    }
}
