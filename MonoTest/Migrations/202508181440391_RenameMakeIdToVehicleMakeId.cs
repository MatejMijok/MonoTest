namespace MonoTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameMakeIdToVehicleMakeId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VehicleModels", "VehicleMake_Id", "dbo.VehicleMakes");
            DropIndex("dbo.VehicleModels", new[] { "VehicleMake_Id" });
            RenameColumn(table: "dbo.VehicleModels", name: "VehicleMake_Id", newName: "VehicleMakeId");
            AlterColumn("dbo.VehicleModels", "VehicleMakeId", c => c.Int(nullable: false));
            CreateIndex("dbo.VehicleModels", "VehicleMakeId");
            AddForeignKey("dbo.VehicleModels", "VehicleMakeId", "dbo.VehicleMakes", "Id", cascadeDelete: true);
            DropColumn("dbo.VehicleModels", "MakeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VehicleModels", "MakeId", c => c.Int(nullable: false));
            DropForeignKey("dbo.VehicleModels", "VehicleMakeId", "dbo.VehicleMakes");
            DropIndex("dbo.VehicleModels", new[] { "VehicleMakeId" });
            AlterColumn("dbo.VehicleModels", "VehicleMakeId", c => c.Int());
            RenameColumn(table: "dbo.VehicleModels", name: "VehicleMakeId", newName: "VehicleMake_Id");
            CreateIndex("dbo.VehicleModels", "VehicleMake_Id");
            AddForeignKey("dbo.VehicleModels", "VehicleMake_Id", "dbo.VehicleMakes", "Id");
        }
    }
}
