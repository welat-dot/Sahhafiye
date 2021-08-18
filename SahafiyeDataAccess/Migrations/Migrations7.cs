using Dapper;
using FluentMigrator;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SahafiyeDataAccess.Migrations
{
    [Migration(7)]
    public class Migrations7 : Migration
    {
        public override void Down()
        {
            throw new NotImplementedException();
        }

        public override void Up()
        {
            
            string SQ = "";
            SQ += "select Id from users where UserName = 'Administrator' ";
            int admnID = 0;
            int autriID = 0;
            using (var connection = new MySqlConnection(@"server = localhost; user = root; password = welat.123; database = Sahhafiye_DB; "))
            {
                IEnumerable<int> b = connection.Query<int>(SQ);
                List<int> b1 = b.ToList();
                admnID = b1[0];
                SQ = "select Id from authority where Code = 0 ";
                b= connection.Query<int>(SQ);
                b1 = b.ToList();
                autriID = b1[0];
            }
            Insert.IntoTable("userauthority").Row(new
            {
                UserId= admnID,
                AuthorityId= autriID
            });
        }
    }
}
