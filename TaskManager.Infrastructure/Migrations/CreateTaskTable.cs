using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Infrastructure.Migrations
{
    [Migration(2)]
    public class CreateTaskTable : Migration
    {
        public override void Up()
        {
            if (!Schema.Table("Tasks").Exists())
            {
                Create.Table("Tasks")
                    .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                    .WithColumn("Title").AsString()
                    .WithColumn("Description").AsString().Nullable()
                    .WithColumn("IsCompleted").AsBoolean()
                    .WithColumn("CreateAt").AsDateTime();
            }
        }

        public override void Down()
        {
            Delete.Table("Tasks");
        }
    }
}
