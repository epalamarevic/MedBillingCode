namespace MedicalBilling.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addnametocodes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DiagnosticCode", "Name", c => c.String());
            AddColumn("dbo.ProcedureCode", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProcedureCode", "Name");
            DropColumn("dbo.DiagnosticCode", "Name");
        }
    }
}
