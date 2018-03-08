namespace BookATable.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Automatic : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reservations", "Comment", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reservations", "Comment", c => c.String(maxLength: 550));
        }
    }
}
