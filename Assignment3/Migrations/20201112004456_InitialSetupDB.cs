using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment3.Migrations
{
    public partial class InitialSetupDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Fruit",
            //    columns: table => new
            //    {
            //        FruitID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(unicode: false, nullable: true),
            //        Color = table.Column<string>(unicode: false, nullable: true),
            //        created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
            //        updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Fruit", x => x.FruitID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Planet",
            //    columns: table => new
            //    {
            //        PlanetID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(unicode: false, nullable: true),
            //        Color = table.Column<string>(unicode: false, nullable: true),
            //        created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
            //        updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Planet", x => x.PlanetID);
            //    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fruit");

            migrationBuilder.DropTable(
                name: "Planet");
        }
    }
}
