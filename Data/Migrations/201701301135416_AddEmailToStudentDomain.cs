using System.Data.Entity.Migrations;

namespace Data.Migrations
{
    public partial class AddEmailToStudentDomain : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Email", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "Email");
        }
    }
}
