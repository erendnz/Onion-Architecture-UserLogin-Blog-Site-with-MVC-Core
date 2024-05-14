using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog.Infrastructure.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "APP_ROLE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 3 INCREMENT BY 1"),
                    Name = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APP_ROLE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "APP_USER",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 2 INCREMENT BY 1"),
                    AD = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    SOYAD = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    UserName = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APP_USER", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "KONULAR",
                columns: table => new
                {
                    KONU_ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 5 INCREMENT BY 1"),
                    KonuAdi = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    EKLEME_TARIHI = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    GUNCELLENME_TARİHİ = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    SILINME_TARIHI = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    KAYIT_DURUMU = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KONULAR", x => x.KONU_ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    RoleId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ClaimType = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ClaimValue = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_APP_ROLE_RoleId",
                        column: x => x.RoleId,
                        principalTable: "APP_ROLE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    UserId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ClaimType = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ClaimValue = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_APP_USER_UserId",
                        column: x => x.UserId,
                        principalTable: "APP_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    UserId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_APP_USER_UserId",
                        column: x => x.UserId,
                        principalTable: "APP_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    RoleId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_APP_ROLE_RoleId",
                        column: x => x.RoleId,
                        principalTable: "APP_ROLE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_APP_USER_UserId",
                        column: x => x.UserId,
                        principalTable: "APP_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LoginProvider = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    Value = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_APP_USER_UserId",
                        column: x => x.UserId,
                        principalTable: "APP_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MAKALELER",
                columns: table => new
                {
                    MAKALE_ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    BASLIK = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    DETAY = table.Column<string>(type: "NCLOB", maxLength: 100000, nullable: false),
                    RESIM_YOLU = table.Column<string>(type: "NVARCHAR2(1000)", maxLength: 1000, nullable: true),
                    GORUNTULENME_SAYISI = table.Column<int>(type: "NUMBER(10)", nullable: false, defaultValue: 0),
                    EKLEME_TARIHI = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    GUNCELLENME_TARİHİ = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    SILINME_TARIHI = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    KAYIT_DURUMU = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    MAKALE_EKLEYEN_ID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    KONU_ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MAKALELER", x => x.MAKALE_ID);
                    table.ForeignKey(
                        name: "FK_MAKALELER_APP_USER_MAKALE_EKLEYEN_ID",
                        column: x => x.MAKALE_EKLEYEN_ID,
                        principalTable: "APP_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MAKALELER_KONULAR_KONU_ID",
                        column: x => x.KONU_ID,
                        principalTable: "KONULAR",
                        principalColumn: "KONU_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "APP_ROLE",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "11eb58b8-81d4-4ea9-9773-2126d858959a", "Admin", "ADMIN" },
                    { 2, "9cf38978-429a-4055-ab0a-6fc94905f860", "Uye", "UYE" }
                });

            migrationBuilder.InsertData(
                table: "APP_USER",
                columns: new[] { "ID", "AccessFailedCount", "AD", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "SOYAD", "TwoFactorEnabled", "UserName" },
                values: new object[] { 1, 0, "Cevdet", "708f1c0e-27ea-4a7c-9d81-5f515dca2f8e", "cevdet@deneme.com", false, false, null, "CEVDET@DENEME.COM", "CEVDO", "AQAAAAEAACcQAAAAEMCnHyCRGr4CxdqogygFMitb+M7H925pRk561p8uTTpMEs1aQcNkmLLJhBWr/nUUUQ==", null, false, "335f879e-caa0-40fb-907a-c6b9e7069585", "Korkmaz", false, "Cevdo" });

            migrationBuilder.InsertData(
                table: "KONULAR",
                columns: new[] { "KONU_ID", "EKLEME_TARIHI", "GUNCELLENME_TARİHİ", "KAYIT_DURUMU", "KonuAdi", "SILINME_TARIHI" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Sanat", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Bilim", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Felsefe", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 1, 1 });

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "APP_ROLE",
                column: "NormalizedName",
                unique: true,
                filter: "\"NormalizedName\" IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "APP_USER",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "APP_USER",
                column: "NormalizedUserName",
                unique: true,
                filter: "\"NormalizedUserName\" IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_MAKALELER_KONU_ID",
                table: "MAKALELER",
                column: "KONU_ID");

            migrationBuilder.CreateIndex(
                name: "IX_MAKALELER_MAKALE_EKLEYEN_ID",
                table: "MAKALELER",
                column: "MAKALE_EKLEYEN_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "MAKALELER");

            migrationBuilder.DropTable(
                name: "APP_ROLE");

            migrationBuilder.DropTable(
                name: "APP_USER");

            migrationBuilder.DropTable(
                name: "KONULAR");
        }
    }
}
