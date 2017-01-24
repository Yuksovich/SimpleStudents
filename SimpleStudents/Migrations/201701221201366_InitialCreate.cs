using System.Data.Entity.Migrations;

namespace SimpleStudents.Web.Migrations
{
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Teacher_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teachers", t => t.Teacher_Id)
                .Index(t => t.Teacher_Id);
            
            CreateTable(
                "dbo.Descriptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Mark = c.Int(nullable: false),
                        Course_Id = c.Int(),
                        Student_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.Course_Id)
                .ForeignKey("dbo.Students", t => t.Student_Id)
                .Index(t => t.Course_Id)
                .Index(t => t.Student_Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Position = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Position = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "Teacher_Id", "dbo.Teachers");
            DropForeignKey("dbo.Descriptions", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.Descriptions", "Course_Id", "dbo.Courses");
            DropIndex("dbo.Descriptions", new[] { "Student_Id" });
            DropIndex("dbo.Descriptions", new[] { "Course_Id" });
            DropIndex("dbo.Courses", new[] { "Teacher_Id" });
            DropTable("dbo.Teachers");
            DropTable("dbo.Students");
            DropTable("dbo.Descriptions");
            DropTable("dbo.Courses");
        }
    }
}
