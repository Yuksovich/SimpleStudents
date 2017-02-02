using System.Data.Entity.Migrations;

namespace SimpleStudents.Data.Migrations
{
    public partial class explicitIdsInTeacherCourseDomain : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TeacherCourses", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.TeacherCourses", "Teacher_Id", "dbo.Teachers");
            DropIndex("dbo.TeacherCourses", new[] { "Course_Id" });
            DropIndex("dbo.TeacherCourses", new[] { "Teacher_Id" });
            RenameColumn(table: "dbo.TeacherCourses", name: "Course_Id", newName: "CourseId");
            RenameColumn(table: "dbo.TeacherCourses", name: "Teacher_Id", newName: "TeacherId");
            AlterColumn("dbo.TeacherCourses", "CourseId", c => c.Int(nullable: false));
            AlterColumn("dbo.TeacherCourses", "TeacherId", c => c.Int(nullable: false));
            CreateIndex("dbo.TeacherCourses", "TeacherId");
            CreateIndex("dbo.TeacherCourses", "CourseId");
            AddForeignKey("dbo.TeacherCourses", "CourseId", "dbo.Courses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TeacherCourses", "TeacherId", "dbo.Teachers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeacherCourses", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.TeacherCourses", "CourseId", "dbo.Courses");
            DropIndex("dbo.TeacherCourses", new[] { "CourseId" });
            DropIndex("dbo.TeacherCourses", new[] { "TeacherId" });
            AlterColumn("dbo.TeacherCourses", "TeacherId", c => c.Int());
            AlterColumn("dbo.TeacherCourses", "CourseId", c => c.Int());
            RenameColumn(table: "dbo.TeacherCourses", name: "TeacherId", newName: "Teacher_Id");
            RenameColumn(table: "dbo.TeacherCourses", name: "CourseId", newName: "Course_Id");
            CreateIndex("dbo.TeacherCourses", "Teacher_Id");
            CreateIndex("dbo.TeacherCourses", "Course_Id");
            AddForeignKey("dbo.TeacherCourses", "Teacher_Id", "dbo.Teachers", "Id");
            AddForeignKey("dbo.TeacherCourses", "Course_Id", "dbo.Courses", "Id");
        }
    }
}
