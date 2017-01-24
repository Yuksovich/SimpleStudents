using System.Data.Entity.Migrations;

namespace SimpleStudents.Web.Migrations
{
    public partial class AddedConfigurationsForDomains : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "FirstName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Students", "LastName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Teachers", "FirstName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Teachers", "LastName", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Teachers", "LastName", c => c.String());
            AlterColumn("dbo.Teachers", "FirstName", c => c.String());
            AlterColumn("dbo.Students", "LastName", c => c.String());
            AlterColumn("dbo.Students", "FirstName", c => c.String());
        }
    }
}
