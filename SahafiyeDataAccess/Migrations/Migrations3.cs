using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace SahafiyeDataAccess.Migrations
{
    [Migration(3)]
    public class Migrations3 : Migration
    {
        public override void Down()
        {
           
        }

        public override void Up()
        {
            Insert.IntoTable("userroles").Row(new
            {
                RoleId = 10,
                UserId = 4
            });
            Insert.IntoTable("userroles").Row(new
            {
                RoleId = 9,
                UserId = 3
            });
        }
    }
}
