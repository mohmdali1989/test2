using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Accountant.Migrations
{
    /// <inheritdoc />
    public partial class Accountant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompanyFunction = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "mainUserTem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mainUserTem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MonthlyTypes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MonthlyOrMemoirs = table.Column<int>(type: "int", nullable: false),
                    MonthlyOrMemoirsName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlyTypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "programUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_programUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "mainUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Confirmed = table.Column<bool>(type: "bit", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mainUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_mainUser_company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "company",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "generalUser",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Confirmed = table.Column<bool>(type: "bit", nullable: false),
                    IDMainUser = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_generalUser", x => x.ID);
                    table.ForeignKey(
                        name: "FK_generalUser_company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "company",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_generalUser_mainUser_IDMainUser",
                        column: x => x.IDMainUser,
                        principalTable: "mainUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "companyDebts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameDebtor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AmountDebt = table.Column<int>(type: "int", nullable: false),
                    HistoryReligion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TypeDebt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionReligion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    IDMainUser = table.Column<int>(type: "int", nullable: true),
                    IDGeneralUser = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_companyDebts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_companyDebts_company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "company",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_companyDebts_generalUser_IDGeneralUser",
                        column: x => x.IDGeneralUser,
                        principalTable: "generalUser",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_companyDebts_mainUser_IDMainUser",
                        column: x => x.IDMainUser,
                        principalTable: "mainUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "companyObligations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommitmentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AmountDebt = table.Column<int>(type: "int", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastDatePayment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    IDMainUser = table.Column<int>(type: "int", nullable: true),
                    IDGeneralUser = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_companyObligations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_companyObligations_company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "company",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_companyObligations_generalUser_IDGeneralUser",
                        column: x => x.IDGeneralUser,
                        principalTable: "generalUser",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_companyObligations_mainUser_IDMainUser",
                        column: x => x.IDMainUser,
                        principalTable: "mainUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "contracts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberHours = table.Column<int>(type: "int", nullable: false),
                    NumberDays = table.Column<int>(type: "int", nullable: false),
                    WatchPrice = table.Column<int>(type: "int", nullable: false),
                    CompanyWorkSite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContractExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    IDMainUser = table.Column<int>(type: "int", nullable: true),
                    IDGeneralUser = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_contracts_company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "company",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_contracts_generalUser_IDGeneralUser",
                        column: x => x.IDGeneralUser,
                        principalTable: "generalUser",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_contracts_mainUser_IDMainUser",
                        column: x => x.IDMainUser,
                        principalTable: "mainUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "driver",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HobbyNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LicenseExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberWorkingDays = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    monthlyTypeId = table.Column<int>(type: "int", nullable: false),
                    IDMainUser = table.Column<int>(type: "int", nullable: true),
                    IDGeneralUser = table.Column<int>(type: "int", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_driver", x => x.Id);
                    table.ForeignKey(
                        name: "FK_driver_MonthlyTypes_monthlyTypeId",
                        column: x => x.monthlyTypeId,
                        principalTable: "MonthlyTypes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_driver_company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_driver_generalUser_IDGeneralUser",
                        column: x => x.IDGeneralUser,
                        principalTable: "generalUser",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_driver_mainUser_IDMainUser",
                        column: x => x.IDMainUser,
                        principalTable: "mainUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "fuelProvider",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameFuelProvider = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    stationLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    IDMainUser = table.Column<int>(type: "int", nullable: true),
                    IDGeneralUser = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fuelProvider", x => x.Id);
                    table.ForeignKey(
                        name: "FK_fuelProvider_company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "company",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_fuelProvider_generalUser_IDGeneralUser",
                        column: x => x.IDGeneralUser,
                        principalTable: "generalUser",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_fuelProvider_mainUser_IDMainUser",
                        column: x => x.IDMainUser,
                        principalTable: "mainUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "pagesPermissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Briefs = table.Column<bool>(type: "bit", nullable: false),
                    Car = table.Column<bool>(type: "bit", nullable: false),
                    Company = table.Column<bool>(type: "bit", nullable: false),
                    CompanyDebts = table.Column<bool>(type: "bit", nullable: false),
                    CompanyObligations = table.Column<bool>(type: "bit", nullable: false),
                    Contracts = table.Column<bool>(type: "bit", nullable: false),
                    CustomerDebts = table.Column<bool>(type: "bit", nullable: false),
                    Driver = table.Column<bool>(type: "bit", nullable: false),
                    DriversDiary = table.Column<bool>(type: "bit", nullable: false),
                    Expenses = table.Column<bool>(type: "bit", nullable: false),
                    Fuel = table.Column<bool>(type: "bit", nullable: false),
                    FuelProvider = table.Column<bool>(type: "bit", nullable: false),
                    GeneralUser = table.Column<bool>(type: "bit", nullable: false),
                    InsuranceCar = table.Column<bool>(type: "bit", nullable: false),
                    LicenseCar = table.Column<bool>(type: "bit", nullable: false),
                    MainUser = table.Column<bool>(type: "bit", nullable: false),
                    MainUserTem = table.Column<bool>(type: "bit", nullable: false),
                    Memo = table.Column<bool>(type: "bit", nullable: false),
                    Monthly = table.Column<bool>(type: "bit", nullable: false),
                    Payments = table.Column<bool>(type: "bit", nullable: false),
                    ProgramUser = table.Column<bool>(type: "bit", nullable: false),
                    RepairWorkshops = table.Column<bool>(type: "bit", nullable: false),
                    SparePartsCenters = table.Column<bool>(type: "bit", nullable: false),
                    WorkCompanies = table.Column<bool>(type: "bit", nullable: false),
                    WorkDiary = table.Column<bool>(type: "bit", nullable: false),
                    InputCompany = table.Column<bool>(type: "bit", nullable: false),
                    TrafficViolations = table.Column<bool>(type: "bit", nullable: false),
                    ReportscCar = table.Column<bool>(type: "bit", nullable: false),
                    IDUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pagesPermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pagesPermissions_generalUser_IDUser",
                        column: x => x.IDUser,
                        principalTable: "generalUser",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentHolder = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentAmount = table.Column<int>(type: "int", nullable: false),
                    DatePayment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IDMainUser = table.Column<int>(type: "int", nullable: true),
                    IDGeneralUser = table.Column<int>(type: "int", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_payments_company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_payments_generalUser_IDGeneralUser",
                        column: x => x.IDGeneralUser,
                        principalTable: "generalUser",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_payments_mainUser_IDMainUser",
                        column: x => x.IDMainUser,
                        principalTable: "mainUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "permissionsBriefs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDUser = table.Column<int>(type: "int", nullable: false),
                    Add = table.Column<bool>(type: "bit", nullable: false),
                    Edit = table.Column<bool>(type: "bit", nullable: false),
                    Delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permissionsBriefs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_permissionsBriefs_generalUser_IDUser",
                        column: x => x.IDUser,
                        principalTable: "generalUser",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "permissionsCar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDUser = table.Column<int>(type: "int", nullable: false),
                    Add = table.Column<bool>(type: "bit", nullable: false),
                    Edit = table.Column<bool>(type: "bit", nullable: false),
                    Delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permissionsCar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_permissionsCar_generalUser_IDUser",
                        column: x => x.IDUser,
                        principalTable: "generalUser",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "permissionsCompany",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDUser = table.Column<int>(type: "int", nullable: false),
                    Add = table.Column<bool>(type: "bit", nullable: false),
                    Edit = table.Column<bool>(type: "bit", nullable: false),
                    Delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permissionsCompany", x => x.Id);
                    table.ForeignKey(
                        name: "FK_permissionsCompany_generalUser_IDUser",
                        column: x => x.IDUser,
                        principalTable: "generalUser",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "permissionsCompanyDebts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDUser = table.Column<int>(type: "int", nullable: false),
                    Add = table.Column<bool>(type: "bit", nullable: false),
                    Edit = table.Column<bool>(type: "bit", nullable: false),
                    Delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permissionsCompanyDebts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_permissionsCompanyDebts_generalUser_IDUser",
                        column: x => x.IDUser,
                        principalTable: "generalUser",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "permissionsCompanyObligations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDUser = table.Column<int>(type: "int", nullable: false),
                    Add = table.Column<bool>(type: "bit", nullable: false),
                    Edit = table.Column<bool>(type: "bit", nullable: false),
                    Delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permissionsCompanyObligations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_permissionsCompanyObligations_generalUser_IDUser",
                        column: x => x.IDUser,
                        principalTable: "generalUser",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "permissionsContracts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDUser = table.Column<int>(type: "int", nullable: false),
                    Add = table.Column<bool>(type: "bit", nullable: false),
                    Edit = table.Column<bool>(type: "bit", nullable: false),
                    Delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permissionsContracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_permissionsContracts_generalUser_IDUser",
                        column: x => x.IDUser,
                        principalTable: "generalUser",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "permissionsCustomerDebts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDUser = table.Column<int>(type: "int", nullable: false),
                    Add = table.Column<bool>(type: "bit", nullable: false),
                    Edit = table.Column<bool>(type: "bit", nullable: false),
                    Delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permissionsCustomerDebts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_permissionsCustomerDebts_generalUser_IDUser",
                        column: x => x.IDUser,
                        principalTable: "generalUser",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "permissionsDriver",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDUser = table.Column<int>(type: "int", nullable: false),
                    Add = table.Column<bool>(type: "bit", nullable: false),
                    Edit = table.Column<bool>(type: "bit", nullable: false),
                    Delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permissionsDriver", x => x.Id);
                    table.ForeignKey(
                        name: "FK_permissionsDriver_generalUser_IDUser",
                        column: x => x.IDUser,
                        principalTable: "generalUser",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "permissionsDriversDiary",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDUser = table.Column<int>(type: "int", nullable: false),
                    Add = table.Column<bool>(type: "bit", nullable: false),
                    Edit = table.Column<bool>(type: "bit", nullable: false),
                    Delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permissionsDriversDiary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_permissionsDriversDiary_generalUser_IDUser",
                        column: x => x.IDUser,
                        principalTable: "generalUser",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "permissionsExpenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDUser = table.Column<int>(type: "int", nullable: false),
                    Add = table.Column<bool>(type: "bit", nullable: false),
                    Edit = table.Column<bool>(type: "bit", nullable: false),
                    Delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permissionsExpenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_permissionsExpenses_generalUser_IDUser",
                        column: x => x.IDUser,
                        principalTable: "generalUser",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PermissionsFuel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDUser = table.Column<int>(type: "int", nullable: false),
                    Add = table.Column<bool>(type: "bit", nullable: false),
                    Edit = table.Column<bool>(type: "bit", nullable: false),
                    Delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionsFuel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PermissionsFuel_generalUser_IDUser",
                        column: x => x.IDUser,
                        principalTable: "generalUser",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "permissionsFuelProvider",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDUser = table.Column<int>(type: "int", nullable: false),
                    Add = table.Column<bool>(type: "bit", nullable: false),
                    Edit = table.Column<bool>(type: "bit", nullable: false),
                    Delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permissionsFuelProvider", x => x.Id);
                    table.ForeignKey(
                        name: "FK_permissionsFuelProvider_generalUser_IDUser",
                        column: x => x.IDUser,
                        principalTable: "generalUser",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "permissionsGeneralUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDUser = table.Column<int>(type: "int", nullable: false),
                    Add = table.Column<bool>(type: "bit", nullable: false),
                    Edit = table.Column<bool>(type: "bit", nullable: false),
                    Delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permissionsGeneralUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_permissionsGeneralUser_generalUser_IDUser",
                        column: x => x.IDUser,
                        principalTable: "generalUser",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "permissionsInputCompany",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDUser = table.Column<int>(type: "int", nullable: false),
                    Add = table.Column<bool>(type: "bit", nullable: false),
                    Edit = table.Column<bool>(type: "bit", nullable: false),
                    Delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permissionsInputCompany", x => x.Id);
                    table.ForeignKey(
                        name: "FK_permissionsInputCompany_generalUser_IDUser",
                        column: x => x.IDUser,
                        principalTable: "generalUser",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "permissionsInsuranceCar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDUser = table.Column<int>(type: "int", nullable: false),
                    Add = table.Column<bool>(type: "bit", nullable: false),
                    Edit = table.Column<bool>(type: "bit", nullable: false),
                    Delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permissionsInsuranceCar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_permissionsInsuranceCar_generalUser_IDUser",
                        column: x => x.IDUser,
                        principalTable: "generalUser",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "permissionsLicenseCar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDUser = table.Column<int>(type: "int", nullable: false),
                    Add = table.Column<bool>(type: "bit", nullable: false),
                    Edit = table.Column<bool>(type: "bit", nullable: false),
                    Delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permissionsLicenseCar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_permissionsLicenseCar_generalUser_IDUser",
                        column: x => x.IDUser,
                        principalTable: "generalUser",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "permissionsMainUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDUser = table.Column<int>(type: "int", nullable: false),
                    Add = table.Column<bool>(type: "bit", nullable: false),
                    Edit = table.Column<bool>(type: "bit", nullable: false),
                    Delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permissionsMainUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_permissionsMainUser_generalUser_IDUser",
                        column: x => x.IDUser,
                        principalTable: "generalUser",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "permissionsMainUserTem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDUser = table.Column<int>(type: "int", nullable: false),
                    Add = table.Column<bool>(type: "bit", nullable: false),
                    Edit = table.Column<bool>(type: "bit", nullable: false),
                    Delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permissionsMainUserTem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_permissionsMainUserTem_generalUser_IDUser",
                        column: x => x.IDUser,
                        principalTable: "generalUser",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "permissionsMemo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDUser = table.Column<int>(type: "int", nullable: false),
                    Add = table.Column<bool>(type: "bit", nullable: false),
                    Edit = table.Column<bool>(type: "bit", nullable: false),
                    Delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permissionsMemo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_permissionsMemo_generalUser_IDUser",
                        column: x => x.IDUser,
                        principalTable: "generalUser",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "permissionsMonthly",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDUser = table.Column<int>(type: "int", nullable: false),
                    Add = table.Column<bool>(type: "bit", nullable: false),
                    Edit = table.Column<bool>(type: "bit", nullable: false),
                    Delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permissionsMonthly", x => x.Id);
                    table.ForeignKey(
                        name: "FK_permissionsMonthly_generalUser_IDUser",
                        column: x => x.IDUser,
                        principalTable: "generalUser",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "permissionsPayments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDUser = table.Column<int>(type: "int", nullable: false),
                    Add = table.Column<bool>(type: "bit", nullable: false),
                    Edit = table.Column<bool>(type: "bit", nullable: false),
                    Delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permissionsPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_permissionsPayments_generalUser_IDUser",
                        column: x => x.IDUser,
                        principalTable: "generalUser",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "permissionsProgramUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDUser = table.Column<int>(type: "int", nullable: false),
                    Add = table.Column<bool>(type: "bit", nullable: false),
                    Edit = table.Column<bool>(type: "bit", nullable: false),
                    Delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permissionsProgramUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_permissionsProgramUser_generalUser_IDUser",
                        column: x => x.IDUser,
                        principalTable: "generalUser",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "permissionsRepairWorkshops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDUser = table.Column<int>(type: "int", nullable: false),
                    Add = table.Column<bool>(type: "bit", nullable: false),
                    Edit = table.Column<bool>(type: "bit", nullable: false),
                    Delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permissionsRepairWorkshops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_permissionsRepairWorkshops_generalUser_IDUser",
                        column: x => x.IDUser,
                        principalTable: "generalUser",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "permissionsReportscCar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDUser = table.Column<int>(type: "int", nullable: false),
                    Add = table.Column<bool>(type: "bit", nullable: false),
                    Edit = table.Column<bool>(type: "bit", nullable: false),
                    Delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permissionsReportscCar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_permissionsReportscCar_generalUser_IDUser",
                        column: x => x.IDUser,
                        principalTable: "generalUser",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "permissionsSparePartsCenters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDUser = table.Column<int>(type: "int", nullable: false),
                    Add = table.Column<bool>(type: "bit", nullable: false),
                    Edit = table.Column<bool>(type: "bit", nullable: false),
                    Delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permissionsSparePartsCenters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_permissionsSparePartsCenters_generalUser_IDUser",
                        column: x => x.IDUser,
                        principalTable: "generalUser",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "permissionsTrafficViolations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDUser = table.Column<int>(type: "int", nullable: false),
                    Add = table.Column<bool>(type: "bit", nullable: false),
                    Edit = table.Column<bool>(type: "bit", nullable: false),
                    Delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permissionsTrafficViolations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_permissionsTrafficViolations_generalUser_IDUser",
                        column: x => x.IDUser,
                        principalTable: "generalUser",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "permissionsWorkCompanies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDUser = table.Column<int>(type: "int", nullable: false),
                    Add = table.Column<bool>(type: "bit", nullable: false),
                    Edit = table.Column<bool>(type: "bit", nullable: false),
                    Delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permissionsWorkCompanies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_permissionsWorkCompanies_generalUser_IDUser",
                        column: x => x.IDUser,
                        principalTable: "generalUser",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "permissionsWorkDiary",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDUser = table.Column<int>(type: "int", nullable: false),
                    Add = table.Column<bool>(type: "bit", nullable: false),
                    Edit = table.Column<bool>(type: "bit", nullable: false),
                    Delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permissionsWorkDiary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_permissionsWorkDiary_generalUser_IDUser",
                        column: x => x.IDUser,
                        principalTable: "generalUser",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "repairWorkshops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameRepairShop = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WorkshopLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkshopSpecialty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkingHours = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    IDMainUser = table.Column<int>(type: "int", nullable: true),
                    IDGeneralUser = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_repairWorkshops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_repairWorkshops_company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "company",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_repairWorkshops_generalUser_IDGeneralUser",
                        column: x => x.IDGeneralUser,
                        principalTable: "generalUser",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_repairWorkshops_mainUser_IDMainUser",
                        column: x => x.IDMainUser,
                        principalTable: "mainUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "sparePartsCenters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameCenter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CentrLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CenterSpecialty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CenterWorkingHours = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    IDMainUser = table.Column<int>(type: "int", nullable: true),
                    IDGeneralUser = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sparePartsCenters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sparePartsCenters_company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "company",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_sparePartsCenters_generalUser_IDGeneralUser",
                        column: x => x.IDGeneralUser,
                        principalTable: "generalUser",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_sparePartsCenters_mainUser_IDMainUser",
                        column: x => x.IDMainUser,
                        principalTable: "mainUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "workCompanies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    phoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberVirtualHours = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WatchPrice = table.Column<int>(type: "int", nullable: false),
                    DefaultNumberDays = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyWorkSite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PictureOfCntract = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContractExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IDMainUser = table.Column<int>(type: "int", nullable: true),
                    IDGeneralUser = table.Column<int>(type: "int", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workCompanies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_workCompanies_company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "company",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_workCompanies_generalUser_IDGeneralUser",
                        column: x => x.IDGeneralUser,
                        principalTable: "generalUser",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_workCompanies_mainUser_IDMainUser",
                        column: x => x.IDMainUser,
                        principalTable: "mainUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "briefs",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriverName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VacationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PushStatus = table.Column<bool>(type: "bit", nullable: false),
                    PushStatusDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    IDMainUser = table.Column<int>(type: "int", nullable: true),
                    IDDriver = table.Column<int>(type: "int", nullable: true),
                    IDGeneralUser = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_briefs", x => x.id);
                    table.ForeignKey(
                        name: "FK_briefs_company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "company",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_briefs_driver_IDDriver",
                        column: x => x.IDDriver,
                        principalTable: "driver",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_briefs_generalUser_IDGeneralUser",
                        column: x => x.IDGeneralUser,
                        principalTable: "generalUser",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_briefs_mainUser_IDMainUser",
                        column: x => x.IDMainUser,
                        principalTable: "mainUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "car",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameCar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaximumLoad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarWeight = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    IDMainUser = table.Column<int>(type: "int", nullable: true),
                    IDDriver = table.Column<int>(type: "int", nullable: false),
                    IDGeneralUser = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_car", x => x.Id);
                    table.ForeignKey(
                        name: "FK_car_company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "company",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_car_driver_IDDriver",
                        column: x => x.IDDriver,
                        principalTable: "driver",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_car_generalUser_IDGeneralUser",
                        column: x => x.IDGeneralUser,
                        principalTable: "generalUser",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_car_mainUser_IDMainUser",
                        column: x => x.IDMainUser,
                        principalTable: "mainUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "customerDebts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriverID = table.Column<int>(type: "int", nullable: true),
                    AmountDebt = table.Column<int>(type: "int", nullable: false),
                    HistoryReligion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    IDMainUser = table.Column<int>(type: "int", nullable: true),
                    IDGeneralUser = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customerDebts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_customerDebts_company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "company",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_customerDebts_driver_DriverID",
                        column: x => x.DriverID,
                        principalTable: "driver",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_customerDebts_generalUser_IDGeneralUser",
                        column: x => x.IDGeneralUser,
                        principalTable: "generalUser",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_customerDebts_mainUser_IDMainUser",
                        column: x => x.IDMainUser,
                        principalTable: "mainUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "monthly",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriverName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberWorkingDays = table.Column<int>(type: "int", nullable: false),
                    TransferAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    HandDeliveryAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NumberVacationDays = table.Column<int>(type: "int", nullable: false),
                    MonthlyReceiptDate = table.Column<DateOnly>(type: "date", nullable: false),
                    MonthlyReceiptTimer = table.Column<TimeOnly>(type: "time", nullable: false),
                    monthlyTypeId = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    IDDriver = table.Column<int>(type: "int", nullable: true),
                    IDMainUser = table.Column<int>(type: "int", nullable: true),
                    IDGeneralUser = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_monthly", x => x.id);
                    table.ForeignKey(
                        name: "FK_monthly_MonthlyTypes_monthlyTypeId",
                        column: x => x.monthlyTypeId,
                        principalTable: "MonthlyTypes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_monthly_company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "company",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_monthly_driver_IDDriver",
                        column: x => x.IDDriver,
                        principalTable: "driver",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_monthly_generalUser_IDGeneralUser",
                        column: x => x.IDGeneralUser,
                        principalTable: "generalUser",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_monthly_mainUser_IDMainUser",
                        column: x => x.IDMainUser,
                        principalTable: "mainUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "inputCompany",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDWorkCompanies = table.Column<int>(type: "int", nullable: false),
                    AmountMoneyReceived = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateReceiptMoney = table.Column<DateOnly>(type: "date", nullable: false),
                    IDMainUser = table.Column<int>(type: "int", nullable: true),
                    IDGeneralUser = table.Column<int>(type: "int", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inputCompany", x => x.Id);
                    table.ForeignKey(
                        name: "FK_inputCompany_company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "company",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_inputCompany_generalUser_IDGeneralUser",
                        column: x => x.IDGeneralUser,
                        principalTable: "generalUser",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_inputCompany_mainUser_IDMainUser",
                        column: x => x.IDMainUser,
                        principalTable: "mainUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_inputCompany_workCompanies_IDWorkCompanies",
                        column: x => x.IDWorkCompanies,
                        principalTable: "workCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "carInsurance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberCar = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CarType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsuranceType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LicenseStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LicenseExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IDMainUser = table.Column<int>(type: "int", nullable: true),
                    IDGeneralUser = table.Column<int>(type: "int", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    CarId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carInsurance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_carInsurance_car_CarId",
                        column: x => x.CarId,
                        principalTable: "car",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_carInsurance_company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "company",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_carInsurance_generalUser_IDGeneralUser",
                        column: x => x.IDGeneralUser,
                        principalTable: "generalUser",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_carInsurance_mainUser_IDMainUser",
                        column: x => x.IDMainUser,
                        principalTable: "mainUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "carLicense",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberCar = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CarType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LicenseStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LicenseExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IDMainUser = table.Column<int>(type: "int", nullable: true),
                    IDGeneralUser = table.Column<int>(type: "int", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    CarId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carLicense", x => x.Id);
                    table.ForeignKey(
                        name: "FK_carLicense_car_CarId",
                        column: x => x.CarId,
                        principalTable: "car",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_carLicense_company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "company",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_carLicense_generalUser_IDGeneralUser",
                        column: x => x.IDGeneralUser,
                        principalTable: "generalUser",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_carLicense_mainUser_IDMainUser",
                        column: x => x.IDMainUser,
                        principalTable: "mainUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "driversDiary",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriverId = table.Column<int>(type: "int", nullable: true),
                    TransportationLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoadType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    CreatedTime = table.Column<TimeSpan>(type: "time(0)", nullable: false),
                    IDMainUser = table.Column<int>(type: "int", nullable: true),
                    IDGeneralUser = table.Column<int>(type: "int", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    CarId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_driversDiary", x => x.ID);
                    table.ForeignKey(
                        name: "FK_driversDiary_car_CarId",
                        column: x => x.CarId,
                        principalTable: "car",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_driversDiary_company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "company",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_driversDiary_driver_DriverId",
                        column: x => x.DriverId,
                        principalTable: "driver",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_driversDiary_generalUser_IDGeneralUser",
                        column: x => x.IDGeneralUser,
                        principalTable: "generalUser",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_driversDiary_mainUser_IDMainUser",
                        column: x => x.IDMainUser,
                        principalTable: "mainUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "expenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeCar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NamePiece = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitPrice = table.Column<int>(type: "int", nullable: false),
                    NumberPieces = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<int>(type: "int", nullable: false),
                    MaintenancePrice = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateExchange = table.Column<DateOnly>(type: "date", nullable: false),
                    IDMainUser = table.Column<int>(type: "int", nullable: true),
                    IDGeneralUser = table.Column<int>(type: "int", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    CarId = table.Column<int>(type: "int", nullable: true),
                    PartsId = table.Column<int>(type: "int", nullable: false),
                    WorkshopsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_expenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_expenses_car_CarId",
                        column: x => x.CarId,
                        principalTable: "car",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_expenses_company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "company",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_expenses_generalUser_IDGeneralUser",
                        column: x => x.IDGeneralUser,
                        principalTable: "generalUser",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_expenses_mainUser_IDMainUser",
                        column: x => x.IDMainUser,
                        principalTable: "mainUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_expenses_repairWorkshops_WorkshopsID",
                        column: x => x.WorkshopsID,
                        principalTable: "repairWorkshops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_expenses_sparePartsCenters_PartsId",
                        column: x => x.PartsId,
                        principalTable: "sparePartsCenters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "trafficViolations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationOfViolation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfViolation = table.Column<DateOnly>(type: "date", nullable: false),
                    TiemOfViolation = table.Column<TimeOnly>(type: "time", nullable: false),
                    reasonForViolation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PushStatus = table.Column<bool>(type: "bit", nullable: false),
                    AmountViolated = table.Column<int>(type: "int", nullable: false),
                    dateLastTimePayFine = table.Column<DateOnly>(type: "date", nullable: false),
                    IdDrivr = table.Column<int>(type: "int", nullable: true),
                    IDMainUser = table.Column<int>(type: "int", nullable: true),
                    IDGeneralUser = table.Column<int>(type: "int", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    CarId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trafficViolations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_trafficViolations_car_CarId",
                        column: x => x.CarId,
                        principalTable: "car",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_trafficViolations_company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "company",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_trafficViolations_driver_IdDrivr",
                        column: x => x.IdDrivr,
                        principalTable: "driver",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_trafficViolations_generalUser_IDGeneralUser",
                        column: x => x.IDGeneralUser,
                        principalTable: "generalUser",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_trafficViolations_mainUser_IDMainUser",
                        column: x => x.IDMainUser,
                        principalTable: "mainUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "workDiary",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeansTransportation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransportationLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoadType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransportationPrice = table.Column<int>(type: "int", nullable: false),
                    CreatedDateOnly = table.Column<DateOnly>(type: "date", nullable: false),
                    CreatedDateTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberLoad = table.Column<int>(type: "int", nullable: false),
                    PaymentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IDMainUser = table.Column<int>(type: "int", nullable: true),
                    IDGeneralUser = table.Column<int>(type: "int", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    CarId = table.Column<int>(type: "int", nullable: true),
                    DriverId = table.Column<int>(type: "int", nullable: false),
                    OperatorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workDiary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_workDiary_car_CarId",
                        column: x => x.CarId,
                        principalTable: "car",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_workDiary_company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "company",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_workDiary_driver_DriverId",
                        column: x => x.DriverId,
                        principalTable: "driver",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_workDiary_generalUser_IDGeneralUser",
                        column: x => x.IDGeneralUser,
                        principalTable: "generalUser",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_workDiary_mainUser_IDMainUser",
                        column: x => x.IDMainUser,
                        principalTable: "mainUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_workDiary_workCompanies_OperatorId",
                        column: x => x.OperatorId,
                        principalTable: "workCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "fuel",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SupplyDateOnly = table.Column<DateOnly>(type: "date", nullable: false),
                    SupplyTimeOnly = table.Column<TimeOnly>(type: "time", nullable: false),
                    FuelQuantity = table.Column<int>(type: "int", nullable: false),
                    FuelType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    IDMainUser = table.Column<int>(type: "int", nullable: true),
                    IDGeneralUser = table.Column<int>(type: "int", nullable: true),
                    CarId = table.Column<int>(type: "int", nullable: true),
                    FuelProviderID = table.Column<int>(type: "int", nullable: false),
                    workDiaryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fuel", x => x.id);
                    table.ForeignKey(
                        name: "FK_fuel_car_CarId",
                        column: x => x.CarId,
                        principalTable: "car",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_fuel_company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "company",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_fuel_fuelProvider_FuelProviderID",
                        column: x => x.FuelProviderID,
                        principalTable: "fuelProvider",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_fuel_generalUser_IDGeneralUser",
                        column: x => x.IDGeneralUser,
                        principalTable: "generalUser",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_fuel_mainUser_IDMainUser",
                        column: x => x.IDMainUser,
                        principalTable: "mainUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_fuel_workDiary_workDiaryID",
                        column: x => x.workDiaryID,
                        principalTable: "workDiary",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MonthlyTypes",
                columns: new[] { "id", "MonthlyOrMemoirs", "MonthlyOrMemoirsName" },
                values: new object[,]
                {
                    { 1, 0, "الشهريات" },
                    { 2, 1, "اليوميات" }
                });

            migrationBuilder.InsertData(
                table: "mainUser",
                columns: new[] { "Id", "CompanyId", "Confirmed", "CreatedDate", "Name", "Password" },
                values: new object[] { 1, null, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "mohmdali", "123" });

            migrationBuilder.InsertData(
                table: "programUser",
                columns: new[] { "Id", "Name", "Password" },
                values: new object[] { 1, "mohmd", "123" });

            migrationBuilder.CreateIndex(
                name: "IX_briefs_CompanyId",
                table: "briefs",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_briefs_IDDriver",
                table: "briefs",
                column: "IDDriver");

            migrationBuilder.CreateIndex(
                name: "IX_briefs_IDGeneralUser",
                table: "briefs",
                column: "IDGeneralUser");

            migrationBuilder.CreateIndex(
                name: "IX_briefs_IDMainUser",
                table: "briefs",
                column: "IDMainUser");

            migrationBuilder.CreateIndex(
                name: "IX_car_CarNumber_CompanyId",
                table: "car",
                columns: new[] { "CarNumber", "CompanyId" },
                unique: true,
                filter: "[CompanyId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_car_CompanyId",
                table: "car",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_car_IDDriver",
                table: "car",
                column: "IDDriver");

            migrationBuilder.CreateIndex(
                name: "IX_car_IDGeneralUser",
                table: "car",
                column: "IDGeneralUser");

            migrationBuilder.CreateIndex(
                name: "IX_car_IDMainUser",
                table: "car",
                column: "IDMainUser");

            migrationBuilder.CreateIndex(
                name: "IX_carInsurance_CarId",
                table: "carInsurance",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_carInsurance_CompanyId",
                table: "carInsurance",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_carInsurance_IDGeneralUser",
                table: "carInsurance",
                column: "IDGeneralUser");

            migrationBuilder.CreateIndex(
                name: "IX_carInsurance_IDMainUser",
                table: "carInsurance",
                column: "IDMainUser");

            migrationBuilder.CreateIndex(
                name: "IX_carInsurance_NumberCar_CompanyId",
                table: "carInsurance",
                columns: new[] { "NumberCar", "CompanyId" },
                unique: true,
                filter: "[CompanyId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_carLicense_CarId",
                table: "carLicense",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_carLicense_CompanyId",
                table: "carLicense",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_carLicense_IDGeneralUser",
                table: "carLicense",
                column: "IDGeneralUser");

            migrationBuilder.CreateIndex(
                name: "IX_carLicense_IDMainUser",
                table: "carLicense",
                column: "IDMainUser");

            migrationBuilder.CreateIndex(
                name: "IX_carLicense_NumberCar_CompanyId",
                table: "carLicense",
                columns: new[] { "NumberCar", "CompanyId" },
                unique: true,
                filter: "[CompanyId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_company_CompanyName",
                table: "company",
                column: "CompanyName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_companyDebts_CompanyId",
                table: "companyDebts",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_companyDebts_IDGeneralUser",
                table: "companyDebts",
                column: "IDGeneralUser");

            migrationBuilder.CreateIndex(
                name: "IX_companyDebts_IDMainUser",
                table: "companyDebts",
                column: "IDMainUser");

            migrationBuilder.CreateIndex(
                name: "IX_companyObligations_CompanyId",
                table: "companyObligations",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_companyObligations_IDGeneralUser",
                table: "companyObligations",
                column: "IDGeneralUser");

            migrationBuilder.CreateIndex(
                name: "IX_companyObligations_IDMainUser",
                table: "companyObligations",
                column: "IDMainUser");

            migrationBuilder.CreateIndex(
                name: "IX_contracts_CompanyId",
                table: "contracts",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_contracts_IDGeneralUser",
                table: "contracts",
                column: "IDGeneralUser");

            migrationBuilder.CreateIndex(
                name: "IX_contracts_IDMainUser",
                table: "contracts",
                column: "IDMainUser");

            migrationBuilder.CreateIndex(
                name: "IX_customerDebts_CompanyId",
                table: "customerDebts",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_customerDebts_DriverID",
                table: "customerDebts",
                column: "DriverID");

            migrationBuilder.CreateIndex(
                name: "IX_customerDebts_IDGeneralUser",
                table: "customerDebts",
                column: "IDGeneralUser");

            migrationBuilder.CreateIndex(
                name: "IX_customerDebts_IDMainUser",
                table: "customerDebts",
                column: "IDMainUser");

            migrationBuilder.CreateIndex(
                name: "IX_driver_CompanyId",
                table: "driver",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_driver_IDGeneralUser",
                table: "driver",
                column: "IDGeneralUser");

            migrationBuilder.CreateIndex(
                name: "IX_driver_IDMainUser",
                table: "driver",
                column: "IDMainUser");

            migrationBuilder.CreateIndex(
                name: "IX_driver_monthlyTypeId",
                table: "driver",
                column: "monthlyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_driver_Name_CompanyId",
                table: "driver",
                columns: new[] { "Name", "CompanyId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_driversDiary_CarId",
                table: "driversDiary",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_driversDiary_CompanyId",
                table: "driversDiary",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_driversDiary_DriverId",
                table: "driversDiary",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_driversDiary_IDGeneralUser",
                table: "driversDiary",
                column: "IDGeneralUser");

            migrationBuilder.CreateIndex(
                name: "IX_driversDiary_IDMainUser",
                table: "driversDiary",
                column: "IDMainUser");

            migrationBuilder.CreateIndex(
                name: "IX_expenses_CarId",
                table: "expenses",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_expenses_CompanyId",
                table: "expenses",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_expenses_IDGeneralUser",
                table: "expenses",
                column: "IDGeneralUser");

            migrationBuilder.CreateIndex(
                name: "IX_expenses_IDMainUser",
                table: "expenses",
                column: "IDMainUser");

            migrationBuilder.CreateIndex(
                name: "IX_expenses_PartsId",
                table: "expenses",
                column: "PartsId");

            migrationBuilder.CreateIndex(
                name: "IX_expenses_WorkshopsID",
                table: "expenses",
                column: "WorkshopsID");

            migrationBuilder.CreateIndex(
                name: "IX_fuel_CarId",
                table: "fuel",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_fuel_CompanyId",
                table: "fuel",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_fuel_FuelProviderID",
                table: "fuel",
                column: "FuelProviderID");

            migrationBuilder.CreateIndex(
                name: "IX_fuel_IDGeneralUser",
                table: "fuel",
                column: "IDGeneralUser");

            migrationBuilder.CreateIndex(
                name: "IX_fuel_IDMainUser",
                table: "fuel",
                column: "IDMainUser");

            migrationBuilder.CreateIndex(
                name: "IX_fuel_workDiaryID",
                table: "fuel",
                column: "workDiaryID");

            migrationBuilder.CreateIndex(
                name: "IX_fuelProvider_CompanyId",
                table: "fuelProvider",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_fuelProvider_IDGeneralUser",
                table: "fuelProvider",
                column: "IDGeneralUser");

            migrationBuilder.CreateIndex(
                name: "IX_fuelProvider_IDMainUser",
                table: "fuelProvider",
                column: "IDMainUser");

            migrationBuilder.CreateIndex(
                name: "IX_generalUser_CompanyId",
                table: "generalUser",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_generalUser_IDMainUser",
                table: "generalUser",
                column: "IDMainUser");

            migrationBuilder.CreateIndex(
                name: "IX_generalUser_Name_CompanyId",
                table: "generalUser",
                columns: new[] { "Name", "CompanyId" },
                unique: true,
                filter: "[CompanyId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_inputCompany_CompanyId",
                table: "inputCompany",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_inputCompany_IDGeneralUser",
                table: "inputCompany",
                column: "IDGeneralUser");

            migrationBuilder.CreateIndex(
                name: "IX_inputCompany_IDMainUser",
                table: "inputCompany",
                column: "IDMainUser");

            migrationBuilder.CreateIndex(
                name: "IX_inputCompany_IDWorkCompanies",
                table: "inputCompany",
                column: "IDWorkCompanies");

            migrationBuilder.CreateIndex(
                name: "IX_mainUser_CompanyId",
                table: "mainUser",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_mainUser_Name",
                table: "mainUser",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_mainUserTem_Name",
                table: "mainUserTem",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_monthly_CompanyId",
                table: "monthly",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_monthly_IDDriver",
                table: "monthly",
                column: "IDDriver");

            migrationBuilder.CreateIndex(
                name: "IX_monthly_IDGeneralUser",
                table: "monthly",
                column: "IDGeneralUser");

            migrationBuilder.CreateIndex(
                name: "IX_monthly_IDMainUser",
                table: "monthly",
                column: "IDMainUser");

            migrationBuilder.CreateIndex(
                name: "IX_monthly_monthlyTypeId",
                table: "monthly",
                column: "monthlyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_pagesPermissions_IDUser",
                table: "pagesPermissions",
                column: "IDUser",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_payments_CompanyId",
                table: "payments",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_payments_IDGeneralUser",
                table: "payments",
                column: "IDGeneralUser");

            migrationBuilder.CreateIndex(
                name: "IX_payments_IDMainUser",
                table: "payments",
                column: "IDMainUser");

            migrationBuilder.CreateIndex(
                name: "IX_permissionsBriefs_IDUser",
                table: "permissionsBriefs",
                column: "IDUser",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_permissionsCar_IDUser",
                table: "permissionsCar",
                column: "IDUser",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_permissionsCompany_IDUser",
                table: "permissionsCompany",
                column: "IDUser",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_permissionsCompanyDebts_IDUser",
                table: "permissionsCompanyDebts",
                column: "IDUser",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_permissionsCompanyObligations_IDUser",
                table: "permissionsCompanyObligations",
                column: "IDUser",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_permissionsContracts_IDUser",
                table: "permissionsContracts",
                column: "IDUser",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_permissionsCustomerDebts_IDUser",
                table: "permissionsCustomerDebts",
                column: "IDUser",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_permissionsDriver_IDUser",
                table: "permissionsDriver",
                column: "IDUser",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_permissionsDriversDiary_IDUser",
                table: "permissionsDriversDiary",
                column: "IDUser",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_permissionsExpenses_IDUser",
                table: "permissionsExpenses",
                column: "IDUser",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PermissionsFuel_IDUser",
                table: "PermissionsFuel",
                column: "IDUser",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_permissionsFuelProvider_IDUser",
                table: "permissionsFuelProvider",
                column: "IDUser",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_permissionsGeneralUser_IDUser",
                table: "permissionsGeneralUser",
                column: "IDUser",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_permissionsInputCompany_IDUser",
                table: "permissionsInputCompany",
                column: "IDUser",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_permissionsInsuranceCar_IDUser",
                table: "permissionsInsuranceCar",
                column: "IDUser",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_permissionsLicenseCar_IDUser",
                table: "permissionsLicenseCar",
                column: "IDUser",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_permissionsMainUser_IDUser",
                table: "permissionsMainUser",
                column: "IDUser",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_permissionsMainUserTem_IDUser",
                table: "permissionsMainUserTem",
                column: "IDUser",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_permissionsMemo_IDUser",
                table: "permissionsMemo",
                column: "IDUser",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_permissionsMonthly_IDUser",
                table: "permissionsMonthly",
                column: "IDUser",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_permissionsPayments_IDUser",
                table: "permissionsPayments",
                column: "IDUser",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_permissionsProgramUser_IDUser",
                table: "permissionsProgramUser",
                column: "IDUser",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_permissionsRepairWorkshops_IDUser",
                table: "permissionsRepairWorkshops",
                column: "IDUser",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_permissionsReportscCar_IDUser",
                table: "permissionsReportscCar",
                column: "IDUser",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_permissionsSparePartsCenters_IDUser",
                table: "permissionsSparePartsCenters",
                column: "IDUser",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_permissionsTrafficViolations_IDUser",
                table: "permissionsTrafficViolations",
                column: "IDUser",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_permissionsWorkCompanies_IDUser",
                table: "permissionsWorkCompanies",
                column: "IDUser",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_permissionsWorkDiary_IDUser",
                table: "permissionsWorkDiary",
                column: "IDUser",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_programUser_Name",
                table: "programUser",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_repairWorkshops_CompanyId",
                table: "repairWorkshops",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_repairWorkshops_IDGeneralUser",
                table: "repairWorkshops",
                column: "IDGeneralUser");

            migrationBuilder.CreateIndex(
                name: "IX_repairWorkshops_IDMainUser",
                table: "repairWorkshops",
                column: "IDMainUser");

            migrationBuilder.CreateIndex(
                name: "IX_repairWorkshops_NameRepairShop_CompanyId",
                table: "repairWorkshops",
                columns: new[] { "NameRepairShop", "CompanyId" },
                unique: true,
                filter: "[CompanyId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_sparePartsCenters_CompanyId",
                table: "sparePartsCenters",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_sparePartsCenters_IDGeneralUser",
                table: "sparePartsCenters",
                column: "IDGeneralUser");

            migrationBuilder.CreateIndex(
                name: "IX_sparePartsCenters_IDMainUser",
                table: "sparePartsCenters",
                column: "IDMainUser");

            migrationBuilder.CreateIndex(
                name: "IX_trafficViolations_CarId",
                table: "trafficViolations",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_trafficViolations_CompanyId",
                table: "trafficViolations",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_trafficViolations_IdDrivr",
                table: "trafficViolations",
                column: "IdDrivr");

            migrationBuilder.CreateIndex(
                name: "IX_trafficViolations_IDGeneralUser",
                table: "trafficViolations",
                column: "IDGeneralUser");

            migrationBuilder.CreateIndex(
                name: "IX_trafficViolations_IDMainUser",
                table: "trafficViolations",
                column: "IDMainUser");

            migrationBuilder.CreateIndex(
                name: "IX_workCompanies_CompanyId",
                table: "workCompanies",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_workCompanies_CompanyName_CompanyId",
                table: "workCompanies",
                columns: new[] { "CompanyName", "CompanyId" },
                unique: true,
                filter: "[CompanyId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_workCompanies_IDGeneralUser",
                table: "workCompanies",
                column: "IDGeneralUser");

            migrationBuilder.CreateIndex(
                name: "IX_workCompanies_IDMainUser",
                table: "workCompanies",
                column: "IDMainUser");

            migrationBuilder.CreateIndex(
                name: "IX_workDiary_CarId",
                table: "workDiary",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_workDiary_CompanyId",
                table: "workDiary",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_workDiary_DriverId",
                table: "workDiary",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_workDiary_IDGeneralUser",
                table: "workDiary",
                column: "IDGeneralUser");

            migrationBuilder.CreateIndex(
                name: "IX_workDiary_IDMainUser",
                table: "workDiary",
                column: "IDMainUser");

            migrationBuilder.CreateIndex(
                name: "IX_workDiary_OperatorId",
                table: "workDiary",
                column: "OperatorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "briefs");

            migrationBuilder.DropTable(
                name: "carInsurance");

            migrationBuilder.DropTable(
                name: "carLicense");

            migrationBuilder.DropTable(
                name: "companyDebts");

            migrationBuilder.DropTable(
                name: "companyObligations");

            migrationBuilder.DropTable(
                name: "contracts");

            migrationBuilder.DropTable(
                name: "customerDebts");

            migrationBuilder.DropTable(
                name: "driversDiary");

            migrationBuilder.DropTable(
                name: "expenses");

            migrationBuilder.DropTable(
                name: "fuel");

            migrationBuilder.DropTable(
                name: "inputCompany");

            migrationBuilder.DropTable(
                name: "mainUserTem");

            migrationBuilder.DropTable(
                name: "monthly");

            migrationBuilder.DropTable(
                name: "pagesPermissions");

            migrationBuilder.DropTable(
                name: "payments");

            migrationBuilder.DropTable(
                name: "permissionsBriefs");

            migrationBuilder.DropTable(
                name: "permissionsCar");

            migrationBuilder.DropTable(
                name: "permissionsCompany");

            migrationBuilder.DropTable(
                name: "permissionsCompanyDebts");

            migrationBuilder.DropTable(
                name: "permissionsCompanyObligations");

            migrationBuilder.DropTable(
                name: "permissionsContracts");

            migrationBuilder.DropTable(
                name: "permissionsCustomerDebts");

            migrationBuilder.DropTable(
                name: "permissionsDriver");

            migrationBuilder.DropTable(
                name: "permissionsDriversDiary");

            migrationBuilder.DropTable(
                name: "permissionsExpenses");

            migrationBuilder.DropTable(
                name: "PermissionsFuel");

            migrationBuilder.DropTable(
                name: "permissionsFuelProvider");

            migrationBuilder.DropTable(
                name: "permissionsGeneralUser");

            migrationBuilder.DropTable(
                name: "permissionsInputCompany");

            migrationBuilder.DropTable(
                name: "permissionsInsuranceCar");

            migrationBuilder.DropTable(
                name: "permissionsLicenseCar");

            migrationBuilder.DropTable(
                name: "permissionsMainUser");

            migrationBuilder.DropTable(
                name: "permissionsMainUserTem");

            migrationBuilder.DropTable(
                name: "permissionsMemo");

            migrationBuilder.DropTable(
                name: "permissionsMonthly");

            migrationBuilder.DropTable(
                name: "permissionsPayments");

            migrationBuilder.DropTable(
                name: "permissionsProgramUser");

            migrationBuilder.DropTable(
                name: "permissionsRepairWorkshops");

            migrationBuilder.DropTable(
                name: "permissionsReportscCar");

            migrationBuilder.DropTable(
                name: "permissionsSparePartsCenters");

            migrationBuilder.DropTable(
                name: "permissionsTrafficViolations");

            migrationBuilder.DropTable(
                name: "permissionsWorkCompanies");

            migrationBuilder.DropTable(
                name: "permissionsWorkDiary");

            migrationBuilder.DropTable(
                name: "programUser");

            migrationBuilder.DropTable(
                name: "trafficViolations");

            migrationBuilder.DropTable(
                name: "repairWorkshops");

            migrationBuilder.DropTable(
                name: "sparePartsCenters");

            migrationBuilder.DropTable(
                name: "fuelProvider");

            migrationBuilder.DropTable(
                name: "workDiary");

            migrationBuilder.DropTable(
                name: "car");

            migrationBuilder.DropTable(
                name: "workCompanies");

            migrationBuilder.DropTable(
                name: "driver");

            migrationBuilder.DropTable(
                name: "MonthlyTypes");

            migrationBuilder.DropTable(
                name: "generalUser");

            migrationBuilder.DropTable(
                name: "mainUser");

            migrationBuilder.DropTable(
                name: "company");
        }
    }
}
