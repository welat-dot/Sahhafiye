using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace SahafiyeDataAccess.Migrationsss
{
    [Migration(100000002)]
    public class Migrations2 : Migration
    {
        public override void Down()
        {
           
        }

        public override void Up()
        {
            Create.Table("User")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("EmailAdress").AsString(15)
                .WithColumn("TelNumber").AsString()
                .WithColumn("PasswordHash").AsBinary()
                .WithColumn("PasswordSalt").AsBinary()
                .WithColumn("UserDetailId").AsInt32()
                .WithColumn("RecordTime").AsDateTime()
                .WithColumn("UpdateTime").AsDateTime();
            Create.Table("UserDetail")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("Name").AsString()
                .WithColumn("SurName").AsString()
                .WithColumn("UserId").AsInt32().NotNullable().ForeignKey("User", "Id");
            Create.Table("AdressDetail")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("Adress").AsString().NotNullable()
                .WithColumn("UserId").AsInt32().NotNullable().ForeignKey("User", "Id");
            Create.Table("Store")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("StoreName").AsString(50).NotNullable()
                .WithColumn("TaxNumber").AsString(50).NotNullable()
                .WithColumn("OwnerId").AsInt32().NotNullable().ForeignKey("User", "Id")
                .WithColumn("StoreEmailAdress").AsString(50)
                .WithColumn("StoreTelNumber").AsString(50);
            Create.Table("Roles")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("RolesName").AsString(25).NotNullable();
            Create.Table("UserRoles")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("RoleId").AsInt32().NotNullable().ForeignKey("Roles", "Id")
                .WithColumn("UserId").AsInt32().NotNullable().ForeignKey("User", "Id");
            Create.Table("UserStore")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("UserId").AsInt32().NotNullable().ForeignKey("User", "Id")
                .WithColumn("StoreId").AsInt32().NotNullable().ForeignKey("Store", "Id");
            Create.Table("Authority")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("AuthorityName").AsString(50).NotNullable();
            Create.Table("UserAuthority")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("UserId").AsInt32().NotNullable().ForeignKey("User", "Id")
                .WithColumn("AuthorityId").AsInt32().NotNullable().ForeignKey("Authority", "Id")
                .WithColumn("StoreId").AsInt32().NotNullable().WithDefaultValue(0);
            Create.Index("IX_Authority_UserAuthority")
               .OnTable("UserAuthority")
               .OnColumn("AuthorityId")
               .Ascending()
               .WithOptions().NonClustered();
            Create.Index("IX_User_UserAuthority")
               .OnTable("UserAuthority")
               .OnColumn("UserId")
               .Ascending()
               .WithOptions().NonClustered();
            Create.Index("IX_User_UserStore")
                .OnTable("UserStore")
                .OnColumn("UserId")
                .Ascending()
                .WithOptions().NonClustered();
            Create.Index("IX_Store_UserStore")
                .OnTable("UserStore")
                .OnColumn("StoreId")
                .Ascending()
                .WithOptions().NonClustered();
            Create.Index("IX_User_UserRoles")
               .OnTable("UserRoles")
               .OnColumn("UserId")
               .Ascending()
               .WithOptions().NonClustered();
            Create.Index("IX_Roles_UserRoles")
                .OnTable("UserRoles")
                .OnColumn("RoleId")
                .Ascending()
                .WithOptions().NonClustered();
            Create.Index("IX_User_Store")
                .OnTable("Store")
                .OnColumn("OwnerId")
                .Ascending();
            Create.Index("IX_User_AdressDetail")
                .OnTable("AdressDetail")
                .OnColumn("UserId")
                .Ascending()
                .WithOptions().NonClustered();
            Create.Index("IX_User_UserDatail")
                .OnTable("UserDetail")
                .OnColumn("UserId")
                .Ascending()
                .WithOptions().NonClustered();
           
        }
    }
}
