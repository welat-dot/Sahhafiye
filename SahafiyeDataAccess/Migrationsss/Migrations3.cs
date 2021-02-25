using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace SahafiyeDataAccess.Migrationsss
{
    [Migration(100000003)]
   public class Migrations3 : Migration
    {
        public override void Down()
        {
            throw new NotImplementedException();
        }

        public override void Up()
        {
            Create.Column("RoleId").OnTable("Authority").AsInt32().NotNullable().ForeignKey("Roles", "Id");
            Create.Index("IX_Roles_Authority")
                .OnTable("Authority")
                .OnColumn("RoleId")
                .Ascending()
                .WithOptions().NonClustered();

        }
    }
}
