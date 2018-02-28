using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CarRentalApp.Migrations
{
    public partial class SeedFeatures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('4G LTE Wi-Fi')");
            migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('GPS')");
            migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Android / iPhone integrity')");
            migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Bluetooth')");
            migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('USB')");
            migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Keyless entry')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "DELETE FROM Features WHERE Name in ('4G LTE Wi-Fi','GPS','Android / iPhone integrity','Bluetooth','USB','Keyless entry'");
        }
    }
}
