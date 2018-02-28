using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CarRentalApp.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Makes (Name) Values ('BMW')");
            migrationBuilder.Sql("INSERT INTO Makes (Name) Values ('Audi')");
            migrationBuilder.Sql("INSERT INTO Makes (Name) Values ('Skoda')");

            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) Values ('M140i', (Select ID from Makes where Name = 'BMW'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) Values ('M240i', (Select ID from Makes where Name = 'BMW'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) Values ('M3', (Select ID from Makes where Name = 'BMW'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) Values ('M4', (Select ID from Makes where Name = 'BMW'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) Values ('530e', (Select ID from Makes where Name = 'BMW'))");


            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) Values ('A3', (Select ID from Makes where Name = 'Audi'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) Values ('A5', (Select ID from Makes where Name = 'Audi'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) Values ('Q7', (Select ID from Makes where Name = 'Audi'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) Values ('TT', (Select ID from Makes where Name = 'Audi'))");


            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) Values ('Fabia', (Select ID from Makes where Name = 'Skoda'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) Values ('Octavia', (Select ID from Makes where Name = 'Skoda'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Models WHERE MakeId in ((Select ID from Makes where Name = 'BMW'), (Select ID from Makes where Name = 'Audi'), (Select ID from Makes where Name = 'Skoda')");
            migrationBuilder.Sql("Delete from Makes WHERE Name in ('BMW', 'Audi', 'Skoda'");
        }
    }
}
