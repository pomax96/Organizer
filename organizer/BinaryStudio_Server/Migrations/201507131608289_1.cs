namespace BinaryStudio_Server.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Subtasks",
                c => new
                    {
                        SubtaskID = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Compleatet = c.Boolean(nullable: false),
                        Task_TaskID = c.Int(),
                    })
                .PrimaryKey(t => t.SubtaskID)
                .ForeignKey("dbo.Tasks", t => t.Task_TaskID)
                .Index(t => t.Task_TaskID);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        TaskID = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Compleatet = c.Boolean(nullable: false),
                        Date = c.String(),
                        Category = c.String(),
                    })
                .PrimaryKey(t => t.TaskID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subtasks", "Task_TaskID", "dbo.Tasks");
            DropIndex("dbo.Subtasks", new[] { "Task_TaskID" });
            DropTable("dbo.Tasks");
            DropTable("dbo.Subtasks");
        }
    }
}
