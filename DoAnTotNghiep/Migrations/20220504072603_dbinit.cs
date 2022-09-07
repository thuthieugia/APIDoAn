using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DoAnTotNghiep.Migrations
{
    public partial class dbinit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Building",
                columns: table => new
                {
                    BuildingID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BuildingName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BaseBuilding = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Building", x => x.BuildingID);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    CourseID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.CourseID);
                });

            migrationBuilder.CreateTable(
                name: "Ology",
                columns: table => new
                {
                    OlogyID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OlogyName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ology", x => x.OlogyID);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    PermissionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PermissionName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.PermissionID);
                });

            migrationBuilder.CreateTable(
                name: "PracticeShift",
                columns: table => new
                {
                    PracticeShiftID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PracticeShiftName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PracticeShift", x => x.PracticeShiftID);
                });

            migrationBuilder.CreateTable(
                name: "SchoolYear",
                columns: table => new
                {
                    SchoolYearID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SchoolYearName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolYear", x => x.SchoolYearID);
                });

            migrationBuilder.CreateTable(
                name: "Semester",
                columns: table => new
                {
                    SemesterID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SemesterName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semester", x => x.SemesterID);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    SubjectID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubjectName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.SubjectID);
                });

            migrationBuilder.CreateTable(
                name: "TechnicalStaff",
                columns: table => new
                {
                    TechnicalStaffID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TechnicalStaffCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnicalStaff", x => x.TechnicalStaffID);
                });

            migrationBuilder.CreateTable(
                name: "Majors",
                columns: table => new
                {
                    MajorsID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MajorsCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MajorsName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OlogyID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OlogyName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Majors", x => x.MajorsID);
                    table.ForeignKey(
                        name: "FK_Majors_Ology_OlogyID",
                        column: x => x.OlogyID,
                        principalTable: "Ology",
                        principalColumn: "OlogyID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PassWord = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PermissionID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PermissionName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Users_Permission_PermissionID",
                        column: x => x.PermissionID,
                        principalTable: "Permission",
                        principalColumn: "PermissionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Module",
                columns: table => new
                {
                    ModuleID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModuleCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModuleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfModule = table.Column<float>(type: "real", nullable: true),
                    Theory = table.Column<float>(type: "real", nullable: true),
                    Practice = table.Column<float>(type: "real", nullable: true),
                    BigExercise = table.Column<float>(type: "real", nullable: true),
                    SubjectID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SubjectName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModuleClassCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Module", x => x.ModuleID);
                    table.ForeignKey(
                        name: "FK_Module_Subject_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "Subject",
                        principalColumn: "SubjectID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PracticalLaboratory",
                columns: table => new
                {
                    PracticalLaboratoryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PracticalLaboratoryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PracticalLaboratoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfSeats = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuildingID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BuildingName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OlogyID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OlogyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubjectID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SubjectName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PracticalLaboratory", x => x.PracticalLaboratoryID);
                    table.ForeignKey(
                        name: "FK_PracticalLaboratory_Building_BuildingID",
                        column: x => x.BuildingID,
                        principalTable: "Building",
                        principalColumn: "BuildingID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PracticalLaboratory_Ology_OlogyID",
                        column: x => x.OlogyID,
                        principalTable: "Ology",
                        principalColumn: "OlogyID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PracticalLaboratory_Subject_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "Subject",
                        principalColumn: "SubjectID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    TeacherID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeacherCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubjectID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SubjectName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.TeacherID);
                    table.ForeignKey(
                        name: "FK_Teacher_Subject_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "Subject",
                        principalColumn: "SubjectID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    ClassID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClassCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClassName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MajorsID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MajorsName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MajorsCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class", x => x.ClassID);
                    table.ForeignKey(
                        name: "FK_Class_Course_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Class_Majors_MajorsID",
                        column: x => x.MajorsID,
                        principalTable: "Majors",
                        principalColumn: "MajorsID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    EquipmentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EquipmentCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PracticalLaboratoryID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EquipmentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EquipmentStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.EquipmentID);
                    table.ForeignKey(
                        name: "FK_Equipment_PracticalLaboratory_PracticalLaboratoryID",
                        column: x => x.PracticalLaboratoryID,
                        principalTable: "PracticalLaboratory",
                        principalColumn: "PracticalLaboratoryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Maintainance",
                columns: table => new
                {
                    MaintainanceID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PracticalLaboratoryID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PracticalLaboratoryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PracticalLaboratoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TechnicalStaffID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TechnicalStaffCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaintainanceStatus = table.Column<int>(type: "int", nullable: false),
                    Request = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maintainance", x => x.MaintainanceID);
                    table.ForeignKey(
                        name: "FK_Maintainance_PracticalLaboratory_PracticalLaboratoryID",
                        column: x => x.PracticalLaboratoryID,
                        principalTable: "PracticalLaboratory",
                        principalColumn: "PracticalLaboratoryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Maintainance_TechnicalStaff_TechnicalStaffID",
                        column: x => x.TechnicalStaffID,
                        principalTable: "TechnicalStaff",
                        principalColumn: "TechnicalStaffID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ModuleClass",
                columns: table => new
                {
                    ModuleClassID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModuleClassCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModuleID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SemesterID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SemesterName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModuleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModuleCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubjectName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfModule = table.Column<int>(type: "int", nullable: false),
                    TeacherID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SchoolYearID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SchoolYearName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleClass", x => x.ModuleClassID);
                    table.ForeignKey(
                        name: "FK_ModuleClass_SchoolYear_SchoolYearID",
                        column: x => x.SchoolYearID,
                        principalTable: "SchoolYear",
                        principalColumn: "SchoolYearID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModuleClass_Teacher_TeacherID",
                        column: x => x.TeacherID,
                        principalTable: "Teacher",
                        principalColumn: "TeacherID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    StudentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    ClassID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ClassName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClassCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.StudentID);
                    table.ForeignKey(
                        name: "FK_Student_Class_ClassID",
                        column: x => x.ClassID,
                        principalTable: "Class",
                        principalColumn: "ClassID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PracticeGroup",
                columns: table => new
                {
                    PracticeGroupID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PracticeGroupCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModuleClassID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PracticeGroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeacherID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModuleClassCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModuleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubjectName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PracticeGroup", x => x.PracticeGroupID);
                    table.ForeignKey(
                        name: "FK_PracticeGroup_ModuleClass_ModuleClassID",
                        column: x => x.ModuleClassID,
                        principalTable: "ModuleClass",
                        principalColumn: "ModuleClassID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PracticeGroup_Teacher_TeacherID",
                        column: x => x.TeacherID,
                        principalTable: "Teacher",
                        principalColumn: "TeacherID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetailModuleClass",
                columns: table => new
                {
                    DetailModuleClassID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModuleClassID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StudentID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FrequentPoints1 = table.Column<float>(type: "real", nullable: true),
                    FrequentPoints2 = table.Column<float>(type: "real", nullable: true),
                    MediumScore = table.Column<float>(type: "real", nullable: true),
                    ModuleClassCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClassName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MajorsName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailModuleClass", x => x.DetailModuleClassID);
                    table.ForeignKey(
                        name: "FK_DetailModuleClass_ModuleClass_ModuleClassID",
                        column: x => x.ModuleClassID,
                        principalTable: "ModuleClass",
                        principalColumn: "ModuleClassID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetailModuleClass_Student_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetailPracticeGroup",
                columns: table => new
                {
                    DetailPracticeGroupID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PracticeGroupID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StudentID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PracticeGroupCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PracticeGroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClassName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailPracticeGroup", x => x.DetailPracticeGroupID);
                    table.ForeignKey(
                        name: "FK_DetailPracticeGroup_PracticeGroup_PracticeGroupID",
                        column: x => x.PracticeGroupID,
                        principalTable: "PracticeGroup",
                        principalColumn: "PracticeGroupID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetailPracticeGroup_Student_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PracticeSchedule",
                columns: table => new
                {
                    PracticeScheduleID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PracticeShiftID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PracticeShiftName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PracticeGroupID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PracticeGroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PracticalLaboratoryID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PracticalLaboratoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SchoolYearID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SchoolYearName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SemesterID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SemesterName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeacherID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Request = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PracticeSchedule", x => x.PracticeScheduleID);
                    table.ForeignKey(
                        name: "FK_PracticeSchedule_PracticalLaboratory_PracticalLaboratoryID",
                        column: x => x.PracticalLaboratoryID,
                        principalTable: "PracticalLaboratory",
                        principalColumn: "PracticalLaboratoryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PracticeSchedule_PracticeGroup_PracticeGroupID",
                        column: x => x.PracticeGroupID,
                        principalTable: "PracticeGroup",
                        principalColumn: "PracticeGroupID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PracticeSchedule_PracticeShift_PracticeShiftID",
                        column: x => x.PracticeShiftID,
                        principalTable: "PracticeShift",
                        principalColumn: "PracticeShiftID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PracticeSchedule_SchoolYear_SchoolYearID",
                        column: x => x.SchoolYearID,
                        principalTable: "SchoolYear",
                        principalColumn: "SchoolYearID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PracticeSchedule_Semester_SemesterID",
                        column: x => x.SemesterID,
                        principalTable: "Semester",
                        principalColumn: "SemesterID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PracticeSchedule_Teacher_TeacherID",
                        column: x => x.TeacherID,
                        principalTable: "Teacher",
                        principalColumn: "TeacherID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Attendance",
                columns: table => new
                {
                    AttendanceID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StudentCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PracticeScheduleID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AttendanceStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendance", x => x.AttendanceID);
                    table.ForeignKey(
                        name: "FK_Attendance_PracticeSchedule_PracticeScheduleID",
                        column: x => x.PracticeScheduleID,
                        principalTable: "PracticeSchedule",
                        principalColumn: "PracticeScheduleID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Attendance_Student_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_PracticeScheduleID",
                table: "Attendance",
                column: "PracticeScheduleID");

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_StudentID",
                table: "Attendance",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Class_CourseID",
                table: "Class",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Class_MajorsID",
                table: "Class",
                column: "MajorsID");

            migrationBuilder.CreateIndex(
                name: "IX_DetailModuleClass_ModuleClassID",
                table: "DetailModuleClass",
                column: "ModuleClassID");

            migrationBuilder.CreateIndex(
                name: "IX_DetailModuleClass_StudentID",
                table: "DetailModuleClass",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_DetailPracticeGroup_PracticeGroupID",
                table: "DetailPracticeGroup",
                column: "PracticeGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_DetailPracticeGroup_StudentID",
                table: "DetailPracticeGroup",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_PracticalLaboratoryID",
                table: "Equipment",
                column: "PracticalLaboratoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Maintainance_PracticalLaboratoryID",
                table: "Maintainance",
                column: "PracticalLaboratoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Maintainance_TechnicalStaffID",
                table: "Maintainance",
                column: "TechnicalStaffID");

            migrationBuilder.CreateIndex(
                name: "IX_Majors_OlogyID",
                table: "Majors",
                column: "OlogyID");

            migrationBuilder.CreateIndex(
                name: "IX_Module_SubjectID",
                table: "Module",
                column: "SubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleClass_SchoolYearID",
                table: "ModuleClass",
                column: "SchoolYearID");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleClass_TeacherID",
                table: "ModuleClass",
                column: "TeacherID");

            migrationBuilder.CreateIndex(
                name: "IX_PracticalLaboratory_BuildingID",
                table: "PracticalLaboratory",
                column: "BuildingID");

            migrationBuilder.CreateIndex(
                name: "IX_PracticalLaboratory_OlogyID",
                table: "PracticalLaboratory",
                column: "OlogyID");

            migrationBuilder.CreateIndex(
                name: "IX_PracticalLaboratory_SubjectID",
                table: "PracticalLaboratory",
                column: "SubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_PracticeGroup_ModuleClassID",
                table: "PracticeGroup",
                column: "ModuleClassID");

            migrationBuilder.CreateIndex(
                name: "IX_PracticeGroup_TeacherID",
                table: "PracticeGroup",
                column: "TeacherID");

            migrationBuilder.CreateIndex(
                name: "IX_PracticeSchedule_PracticalLaboratoryID",
                table: "PracticeSchedule",
                column: "PracticalLaboratoryID");

            migrationBuilder.CreateIndex(
                name: "IX_PracticeSchedule_PracticeGroupID",
                table: "PracticeSchedule",
                column: "PracticeGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_PracticeSchedule_PracticeShiftID",
                table: "PracticeSchedule",
                column: "PracticeShiftID");

            migrationBuilder.CreateIndex(
                name: "IX_PracticeSchedule_SchoolYearID",
                table: "PracticeSchedule",
                column: "SchoolYearID");

            migrationBuilder.CreateIndex(
                name: "IX_PracticeSchedule_SemesterID",
                table: "PracticeSchedule",
                column: "SemesterID");

            migrationBuilder.CreateIndex(
                name: "IX_PracticeSchedule_TeacherID",
                table: "PracticeSchedule",
                column: "TeacherID");

            migrationBuilder.CreateIndex(
                name: "IX_Student_ClassID",
                table: "Student",
                column: "ClassID");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_SubjectID",
                table: "Teacher",
                column: "SubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PermissionID",
                table: "Users",
                column: "PermissionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendance");

            migrationBuilder.DropTable(
                name: "DetailModuleClass");

            migrationBuilder.DropTable(
                name: "DetailPracticeGroup");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "Maintainance");

            migrationBuilder.DropTable(
                name: "Module");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "PracticeSchedule");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "TechnicalStaff");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "PracticalLaboratory");

            migrationBuilder.DropTable(
                name: "PracticeGroup");

            migrationBuilder.DropTable(
                name: "PracticeShift");

            migrationBuilder.DropTable(
                name: "Semester");

            migrationBuilder.DropTable(
                name: "Class");

            migrationBuilder.DropTable(
                name: "Building");

            migrationBuilder.DropTable(
                name: "ModuleClass");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Majors");

            migrationBuilder.DropTable(
                name: "SchoolYear");

            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.DropTable(
                name: "Ology");

            migrationBuilder.DropTable(
                name: "Subject");
        }
    }
}
