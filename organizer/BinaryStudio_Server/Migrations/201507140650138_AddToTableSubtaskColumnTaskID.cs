namespace BinaryStudio_Server.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddToTableSubtaskColumnTaskID : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Subtasks", "Task_TaskID", "dbo.Tasks");
            DropIndex("dbo.Subtasks", new[] { "Task_TaskID" });
            RenameColumn(table: "dbo.Subtasks", name: "Task_TaskID", newName: "TaskID");
            AlterColumn("dbo.Subtasks", "TaskID", c => c.Int(nullable: false));
            CreateIndex("dbo.Subtasks", "TaskID");
            AddForeignKey("dbo.Subtasks", "TaskID", "dbo.Tasks", "TaskID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subtasks", "TaskID", "dbo.Tasks");
            DropIndex("dbo.Subtasks", new[] { "TaskID" });
            AlterColumn("dbo.Subtasks", "TaskID", c => c.Int());
            RenameColumn(table: "dbo.Subtasks", name: "TaskID", newName: "Task_TaskID");
            CreateIndex("dbo.Subtasks", "Task_TaskID");
            AddForeignKey("dbo.Subtasks", "Task_TaskID", "dbo.Tasks", "TaskID");
        }
    }
}
