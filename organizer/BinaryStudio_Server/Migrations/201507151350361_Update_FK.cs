namespace BinaryStudio_Server.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_FK : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Subtasks", "TaskID", "dbo.Tasks");
            DropIndex("dbo.Subtasks", new[] { "TaskID" });
            AddColumn("dbo.Tasks", "Subtask_SubtaskID", c => c.Int());
            CreateIndex("dbo.Tasks", "Subtask_SubtaskID");
            AddForeignKey("dbo.Tasks", "Subtask_SubtaskID", "dbo.Subtasks", "SubtaskID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "Subtask_SubtaskID", "dbo.Subtasks");
            DropIndex("dbo.Tasks", new[] { "Subtask_SubtaskID" });
            DropColumn("dbo.Tasks", "Subtask_SubtaskID");
            CreateIndex("dbo.Subtasks", "TaskID");
            AddForeignKey("dbo.Subtasks", "TaskID", "dbo.Tasks", "TaskID", cascadeDelete: true);
        }
    }
}
