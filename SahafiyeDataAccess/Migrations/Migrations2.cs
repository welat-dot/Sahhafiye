using FluentMigrator;
using System;
using System.Text;

namespace SahafiyeDataAccess.Migrations
{
    [Migration(2)]
    public class Migrations2 : Migration
    {
        public override void Down()
        {
            
        }

        public override void Up()
        {
            var hmac = new System.Security.Cryptography.HMACSHA512();
            //Roles Default insert
            Insert.IntoTable("roles").Row(new
            {
                RolesName = "Administrator"
            });
            Insert.IntoTable("roles").Row(new
            {
                RolesName = "SystemWorker"
            });

            Insert.IntoTable("user").Row(new
            {
                UserName = "Administrator",
                EmailAdress= "admin@administrator.com",
                TelNumber="01234567891",            
                PasswordHash  = hmac.Key,
                PasswordSalt = hmac.ComputeHash(Encoding.UTF8.GetBytes("admin")),
                RecordDate = DateTime.Now,
                UpdateDate = DateTime.Now

            });
          Insert.IntoTable("user").Row(new
            {
                UserName = "SystemWorker",
                EmailAdress = "syswrk@systemworker.com",
                TelNumber = "01234567894",
                PasswordHash = hmac.Key,
                PasswordSalt = hmac.ComputeHash(Encoding.UTF8.GetBytes("syswrk")),
                RecordDate = DateTime.Now,
                UpdateDate = DateTime.Now

            });
          

        }
    }
}
