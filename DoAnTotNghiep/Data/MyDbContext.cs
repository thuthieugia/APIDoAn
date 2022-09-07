using Microsoft.EntityFrameworkCore;

namespace DoAnTotNghiep.Data
{ 
    public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions options) : base(options) { }

        #region DbSet
        public DbSet<AttendanceDB> Attendances { get; set; }
        public DbSet<BuildingDB> Buildings { get; set; }
        public DbSet<ClassDB> Classs { get; set; }
        public DbSet<CourseDB> Courses { get; set; }
        public DbSet<DetailModuleClassDB> DetailModuleClasss { get; set; }
        public DbSet<DetailPracticeGroupDB> DetailPracticeGroups { get; set; }
        public DbSet<EquipmentDB> Equipments { get; set; }
        public DbSet<MaintainanceDB> Maintainances { get; set; }
        public DbSet<MajorsDB> Majorss { get; set; }
        public DbSet<ModuleDB> Modules { get; set; }
        public DbSet<ModuleClassDB> ModuleClasss { get; set; }
        public DbSet<OlogyDB> Ologys { get; set; }
        public DbSet<PermissionDB> Permissions { get; set; }
        public DbSet<PracticalLaboratoryDB> PracticalLaboratorys { get; set; }
        public DbSet<PracticeGroupDB> PracticeGroups { get; set; }
        public DbSet<PracticeScheduleDB> PracticeSchedules { get; set; }
        public DbSet<PracticeShiftDB> PracticeShifts { get; set; }
        public DbSet<SchoolYearDB> SchoolYears { get; set; }
        public DbSet<SemesterDB> Semesters { get; set; }
        public DbSet<StudentDB> Students { get; set; }
        public DbSet<SubjectDB> Subjects { get; set; }
        public DbSet<TeacherDB> Teachers { get; set; }
        public DbSet<TechnicalStaffDB> TechnicalStaffs { get; set; }
        public DbSet<UserDB> Users { get; set; }


        #endregion
    }
}