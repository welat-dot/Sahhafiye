using FluentMigrator;

namespace SahafiyeDataAccess.Migrations
{
    [Migration(1)]
    public class Migrations1 : Migration
    {
        public override void Down()
        {

        }

        public override void Up()
        {
            Create.Table("User")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("UserName").AsString(15)
                .WithColumn("EmailAdress").AsString(100)
                .WithColumn("TelNumber").AsString()
                .WithColumn("PasswordHash").AsBinary()
                .WithColumn("PasswordSalt").AsBinary()
                .WithColumn("RecordDate").AsDateTime()
                .WithColumn("UpdateDate").AsDateTime();
            Create.Table("UserDetail")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("Name").AsString()
                .WithColumn("SurName").AsString()
                .WithColumn("UserId").AsInt32().NotNullable().ForeignKey("User", "Id");
            Create.Table("Roles")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("RolesName").AsString(25).NotNullable();
            Create.Table("UserRoles")
               .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
               .WithColumn("RoleId").AsInt32().NotNullable().ForeignKey("Roles", "Id")
               .WithColumn("UserId").AsInt32().NotNullable().ForeignKey("User", "Id");
            Create.Table("Authority")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("AuthorityName").AsString(50).NotNullable();
            Create.Table("UserAuthority")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("UserId").AsInt32().NotNullable().ForeignKey("User", "Id")
                .WithColumn("AuthorityId").AsInt32().NotNullable().ForeignKey("Authority", "Id")
                .WithColumn("StoreId").AsInt32().NotNullable().WithDefaultValue(0);
            Create.Index("IX_UserAuthority")
               .OnTable("UserAuthority")
               .OnColumn("UserId")
               .Ascending()
               .WithOptions().NonClustered();
            Create.Index("IX_UserRoles")
               .OnTable("UserRoles")
               .OnColumn("UserId")
               .Ascending()
               .WithOptions().NonClustered();
            Create.Index("IX_UserDetail")
               .OnTable("UserDetail")
               .OnColumn("UserId")
               .Ascending()
               .WithOptions().NonClustered();
        }
    }
}
