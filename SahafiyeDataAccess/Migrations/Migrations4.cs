using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace SahafiyeDataAccess.Migrations
{
    [Migration(4)]
    public class Migrations4 : Migration
    {
        public override void Down()
        {
            throw new NotImplementedException();
        }

        public override void Up()
        {
            Alter.Table("authority").AddColumn("Code").AsInt32().NotNullable();
          
        }
    }
}
