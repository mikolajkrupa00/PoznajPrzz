﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace PoznajPrz.Infrastructure.Migrations
{
    public partial class IsPlaceConfirmed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsConfirmed",
                table: "Places",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsConfirmed",
                table: "Places");
        }
    }
}
