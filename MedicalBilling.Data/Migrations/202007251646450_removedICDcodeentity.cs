namespace MedicalBilling.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedICDcodeentity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ICD10Codes", "DiagnosticCodeId", "dbo.DiagnosticCode");
            DropForeignKey("dbo.ICD10Codes", "ProcedureCodeId", "dbo.ProcedureCode");
            DropIndex("dbo.ICD10Codes", new[] { "DiagnosticCodeId" });
            DropIndex("dbo.ICD10Codes", new[] { "ProcedureCodeId" });
            DropTable("dbo.ICD10Codes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ICD10Codes",
                c => new
                    {
                        Icd10CodesId = c.Int(nullable: false, identity: true),
                        ICD10Code = c.String(),
                        DiagnosticCodeId = c.Int(nullable: false),
                        ProcedureCodeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Icd10CodesId);
            
            CreateIndex("dbo.ICD10Codes", "ProcedureCodeId");
            CreateIndex("dbo.ICD10Codes", "DiagnosticCodeId");
            AddForeignKey("dbo.ICD10Codes", "ProcedureCodeId", "dbo.ProcedureCode", "ProcedureCodeId", cascadeDelete: true);
            AddForeignKey("dbo.ICD10Codes", "DiagnosticCodeId", "dbo.DiagnosticCode", "DiagnosticCodeId", cascadeDelete: true);
        }
    }
}
