namespace MedicalBilling.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProcedureCode", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProcedureCode", "Name");
        }
    }
}
