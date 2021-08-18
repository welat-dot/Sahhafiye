using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace SahafiyeDataAccess.Migrations
{


    [Migration(6)]
    public class Migrations6 : Migration
    {
        public override void Down()
        {
            throw new NotImplementedException();
        }

        public override void Up()
        {
            Insert.IntoTable("authority").Row(new {
                AuthorityName ="system",
                Code=0
            });
         
            
        }
    }
}
