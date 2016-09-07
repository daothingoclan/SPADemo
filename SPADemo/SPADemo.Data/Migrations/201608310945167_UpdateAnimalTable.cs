namespace SPADemo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAnimalTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Animal", "Name", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Animal", "Name", c => c.String());
        }
    }
}
