using Microsoft.EntityFrameworkCore.Migrations;

namespace voidBitz.NETCore.NetCoreCountries.DataAccess.Migrations
{
    public partial class seeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var seeder = new SeedData.SeedDataMigration();
            seeder.Seed(migrationBuilder);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
