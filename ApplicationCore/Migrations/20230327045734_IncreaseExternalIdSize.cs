using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationCore.Migrations
{
	/// <inheritdoc />
	public partial class IncreaseExternalIdSize : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<string>(
				name: "ExternalId",
				table: "PriceTypes",
				type: "character varying(7)",
				maxLength: 7,
				nullable: true,
				oldClrType: typeof(string),
				oldType: "character varying(4)",
				oldMaxLength: 4,
				oldNullable: true);
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<string>(
				name: "ExternalId",
				table: "PriceTypes",
				type: "character varying(4)",
				maxLength: 4,
				nullable: true,
				oldClrType: typeof(string),
				oldType: "character varying(7)",
				oldMaxLength: 7,
				oldNullable: true);
		}
	}
}
