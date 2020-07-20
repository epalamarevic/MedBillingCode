namespace MedicalBilling.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedmoredetails : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Diagnosis", "Symptoms", c => c.String());
            AddColumn("dbo.Diagnosis", "Treatments", c => c.String());
            AddColumn("dbo.Procedure", "Preperation", c => c.String());
            AddColumn("dbo.Procedure", "Risks", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Procedure", "Risks");
            DropColumn("dbo.Procedure", "Preperation");
            DropColumn("dbo.Diagnosis", "Treatments");
            DropColumn("dbo.Diagnosis", "Symptoms");
        }
    }
}
