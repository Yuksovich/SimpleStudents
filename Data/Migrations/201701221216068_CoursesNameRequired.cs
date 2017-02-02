using System.Data.Entity.Migrations;

namespace SimpleStudents.Data.Migrations
{
    public partial class CoursesNameRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Courses", "Name", c => c.String());
        }
    }
}
