using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace SahafiyeDataAccess.Migrations
{
    [Migration(5)]
    public class Migrations5 : Migration
    {
        public override void Down()
        {
            throw new NotImplementedException();
        }

        public override void Up()
        {
            Rename.Table("user").To("users"); 
        }
    }
}
