namespace SimpleStudents.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DomainModelChanged : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Descriptions", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.Courses", "Teacher_Id", "dbo.Teachers");
            DropIndex("dbo.Courses", new[] { "Teacher_Id" });
            DropIndex("dbo.Descriptions", new[] { "Course_Id" });
            CreateTable(
                "dbo.TeacherCourses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Course_Id = c.Int(),
                        Teacher_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.Course_Id)
                .ForeignKey("dbo.Teachers", t => t.Teacher_Id)
                .Index(t => t.Course_Id)
                .Index(t => t.Teacher_Id);
            
            AddColumn("dbo.Descriptions", "TeacherCourse_Id", c => c.Int());
            CreateIndex("dbo.Descriptions", "TeacherCourse_Id");
            AddForeignKey("dbo.Descriptions", "TeacherCourse_Id", "dbo.TeacherCourses", "Id");
            DropColumn("dbo.Courses", "Teacher_Id");
            DropColumn("dbo.Descriptions", "Course_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Descriptions", "Course_Id", c => c.Int());
            AddColumn("dbo.Courses", "Teacher_Id", c => c.Int());
            DropForeignKey("dbo.Descriptions", "TeacherCourse_Id", "dbo.TeacherCourses");
            DropForeignKey("dbo.TeacherCourses", "Teacher_Id", "dbo.Teachers");
            DropForeignKey("dbo.TeacherCourses", "Course_Id", "dbo.Courses");
            DropIndex("dbo.Descriptions", new[] { "TeacherCourse_Id" });
            DropIndex("dbo.TeacherCourses", new[] { "Teacher_Id" });
            DropIndex("dbo.TeacherCourses", new[] { "Course_Id" });
            DropColumn("dbo.Descriptions", "TeacherCourse_Id");
            DropTable("dbo.TeacherCourses");
            CreateIndex("dbo.Descriptions", "Course_Id");
            CreateIndex("dbo.Courses", "Teacher_Id");
            AddForeignKey("dbo.Courses", "Teacher_Id", "dbo.Teachers", "Id");
            AddForeignKey("dbo.Descriptions", "Course_Id", "dbo.Courses", "Id");
        }
    }
}
