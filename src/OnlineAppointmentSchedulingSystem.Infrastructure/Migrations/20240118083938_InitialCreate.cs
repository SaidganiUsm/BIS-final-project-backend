﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineAppointmentSchedulingSystem.Infrastructure.Migrations
{
	/// <inheritdoc />
	public partial class InitialCreate : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "AppointmentsStatuses",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
					Created = table.Column<DateTime>(type: "datetime2", nullable: true),
					Updated = table.Column<DateTime>(type: "datetime2", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AppointmentsStatuses", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Categories",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					CategoryName = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false),
					Created = table.Column<DateTime>(type: "datetime2", nullable: true),
					Updated = table.Column<DateTime>(type: "datetime2", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Categories", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Roles",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
					NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
					ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Roles", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Users",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
					LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
					CategoryId = table.Column<int>(type: "int", nullable: true),
					UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
					NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
					Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
					NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
					EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
					PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
					SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
					ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
					PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Users", x => x.Id);
					table.ForeignKey(
						name: "FK_Users_Categories_CategoryId",
						column: x => x.CategoryId,
						principalTable: "Categories",
						principalColumn: "Id");
				});

			migrationBuilder.CreateTable(
				name: "RoleClaims",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					RoleId = table.Column<int>(type: "int", nullable: false),
					ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
					ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_RoleClaims", x => x.Id);
					table.ForeignKey(
						name: "FK_RoleClaims_Roles_RoleId",
						column: x => x.RoleId,
						principalTable: "Roles",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "Appointments",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Date = table.Column<DateTime>(type: "datetime2", nullable: false),
					ClientId = table.Column<int>(type: "int", nullable: false),
					DoctorId = table.Column<int>(type: "int", nullable: false),
					AppointmentStatusId = table.Column<int>(type: "int", nullable: true),
					LocationId = table.Column<int>(type: "int", nullable: false),
					RateId = table.Column<int>(type: "int", nullable: true),
					Result = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
					Created = table.Column<DateTime>(type: "datetime2", nullable: true),
					Updated = table.Column<DateTime>(type: "datetime2", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Appointments", x => x.Id);
					table.ForeignKey(
						name: "FK_Appointments_AppointmentsStatuses_AppointmentStatusId",
						column: x => x.AppointmentStatusId,
						principalTable: "AppointmentsStatuses",
						principalColumn: "Id");
					table.ForeignKey(
						name: "FK_Appointments_Users_ClientId",
						column: x => x.ClientId,
						principalTable: "Users",
						principalColumn: "Id");
					table.ForeignKey(
						name: "FK_Appointments_Users_DoctorId",
						column: x => x.DoctorId,
						principalTable: "Users",
						principalColumn: "Id");
				});

			migrationBuilder.CreateTable(
				name: "UserClaims",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					UserId = table.Column<int>(type: "int", nullable: false),
					ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
					ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_UserClaims", x => x.Id);
					table.ForeignKey(
						name: "FK_UserClaims_Users_UserId",
						column: x => x.UserId,
						principalTable: "Users",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "UserLogins",
				columns: table => new
				{
					LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
					ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
					ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
					UserId = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
					table.ForeignKey(
						name: "FK_UserLogins_Users_UserId",
						column: x => x.UserId,
						principalTable: "Users",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "UserRoles",
				columns: table => new
				{
					UserId = table.Column<int>(type: "int", nullable: false),
					RoleId = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
					table.ForeignKey(
						name: "FK_UserRoles_Roles_RoleId",
						column: x => x.RoleId,
						principalTable: "Roles",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_UserRoles_Users_UserId",
						column: x => x.UserId,
						principalTable: "Users",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "UserTokens",
				columns: table => new
				{
					UserId = table.Column<int>(type: "int", nullable: false),
					LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
					Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
					Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
					table.ForeignKey(
						name: "FK_UserTokens_Users_UserId",
						column: x => x.UserId,
						principalTable: "Users",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "Rates",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					ClientId = table.Column<int>(type: "int", nullable: false),
					DoctorId = table.Column<int>(type: "int", nullable: false),
					RatingValue = table.Column<byte>(type: "tinyint", nullable: false),
					Comment = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true),
					AppointmentId = table.Column<int>(type: "int", nullable: false),
					Created = table.Column<DateTime>(type: "datetime2", nullable: true),
					Updated = table.Column<DateTime>(type: "datetime2", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Rates", x => x.Id);
					table.ForeignKey(
						name: "FK_Rates_Appointments_AppointmentId",
						column: x => x.AppointmentId,
						principalTable: "Appointments",
						principalColumn: "Id");
					table.ForeignKey(
						name: "FK_Rates_Users_ClientId",
						column: x => x.ClientId,
						principalTable: "Users",
						principalColumn: "Id");
					table.ForeignKey(
						name: "FK_Rates_Users_DoctorId",
						column: x => x.DoctorId,
						principalTable: "Users",
						principalColumn: "Id");
				});

			migrationBuilder.CreateIndex(
				name: "IX_Appointments_AppointmentStatusId",
				table: "Appointments",
				column: "AppointmentStatusId");

			migrationBuilder.CreateIndex(
				name: "IX_Appointments_ClientId",
				table: "Appointments",
				column: "ClientId");

			migrationBuilder.CreateIndex(
				name: "IX_Appointments_DoctorId",
				table: "Appointments",
				column: "DoctorId");

			migrationBuilder.CreateIndex(
				name: "IX_Rates_AppointmentId",
				table: "Rates",
				column: "AppointmentId",
				unique: true);

			migrationBuilder.CreateIndex(
				name: "IX_Rates_ClientId",
				table: "Rates",
				column: "ClientId");

			migrationBuilder.CreateIndex(
				name: "IX_Rates_DoctorId",
				table: "Rates",
				column: "DoctorId");

			migrationBuilder.CreateIndex(
				name: "IX_RoleClaims_RoleId",
				table: "RoleClaims",
				column: "RoleId");

			migrationBuilder.CreateIndex(
				name: "RoleNameIndex",
				table: "Roles",
				column: "NormalizedName",
				unique: true,
				filter: "[NormalizedName] IS NOT NULL");

			migrationBuilder.CreateIndex(
				name: "IX_UserClaims_UserId",
				table: "UserClaims",
				column: "UserId");

			migrationBuilder.CreateIndex(
				name: "IX_UserLogins_UserId",
				table: "UserLogins",
				column: "UserId");

			migrationBuilder.CreateIndex(
				name: "IX_UserRoles_RoleId",
				table: "UserRoles",
				column: "RoleId");

			migrationBuilder.CreateIndex(
				name: "EmailIndex",
				table: "Users",
				column: "NormalizedEmail");

			migrationBuilder.CreateIndex(
				name: "IX_Users_CategoryId",
				table: "Users",
				column: "CategoryId");

			migrationBuilder.CreateIndex(
				name: "UserNameIndex",
				table: "Users",
				column: "NormalizedUserName",
				unique: true,
				filter: "[NormalizedUserName] IS NOT NULL");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "Rates");

			migrationBuilder.DropTable(
				name: "RoleClaims");

			migrationBuilder.DropTable(
				name: "UserClaims");

			migrationBuilder.DropTable(
				name: "UserLogins");

			migrationBuilder.DropTable(
				name: "UserRoles");

			migrationBuilder.DropTable(
				name: "UserTokens");

			migrationBuilder.DropTable(
				name: "Appointments");

			migrationBuilder.DropTable(
				name: "Roles");

			migrationBuilder.DropTable(
				name: "AppointmentsStatuses");

			migrationBuilder.DropTable(
				name: "Users");

			migrationBuilder.DropTable(
				name: "Categories");
		}
	}
}
