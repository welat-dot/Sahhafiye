using SahafiyeCore.DataAccess.Query.MySQL;
using SahafiyeCore.Utilitis.Result.Abstract;
using SahafiyeCore.Utilitis.Result.Concreate;
using SahafiyeDataAccess.Abstract;
using SahhafiyeEntities.Dto;
using SahhafiyeEntities.UsersEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SahafiyeDataAccess.Concreate
{
    public class UserRepo : IUserRepo
    {
        private IUserManager userManager;
        private IMySQLGenarateRepository mySQLGenarate;
        public UserRepo(IUserManager userManager, IMySQLGenarateRepository mySQLGenarate)
        {
            this.userManager = userManager;
            this.mySQLGenarate = mySQLGenarate;
        }
        public bool AddUser(Users users)
        {
            object parametrs = new object();
            parametrs = new { EmailAdress  = users.EmailAdress, 
                              TelNumber    = users.TelNumber,
                              PasswordHash = users.PasswordHash,
                              PasswordSalt  = users.PasswordSalt, 
                              UserDetailId = users.UserDetailId,
                              RecordTime   = users.RecordTime, 
                              UpdateTime   = users.UpdateTime };
            string que = "INSERT INTO Users(EmailAdress,TelNumber,PasswordHash,PasswordSalt,UserDetailId,RecordTime,UpdateTime) OUTPUT INSTERTED.Id";
                   que += "  VALUES(@EmailAdress,@TelNumber,@PasswordHash,@PasswordSalt,@UserDetailId,@RecordTime,@UpdateTime)";
            var a = userManager.Syncfunctions(que,parametrs,users);
            return true;
        }

        public bool DeleteUser(int Id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Users> GetAllUsers()
        {
            MysqlQueryLists queryLists = new MysqlQueryLists();
            queryLists.SelectList.Add("*");
            //queryLists.WhereList.Add(filter);
            queryLists.FromList.Add(" Users as Users");
            string que = mySQLGenarate.BaseQuery(queryLists);
            que = mySQLGenarate.WhereQuery(que, queryLists.WhereList);
            return (userManager.Syncfunctions(que));

        }

        public Users GetUsers(List<string> filter)
        {
            MysqlQueryLists queryLists = new MysqlQueryLists();
            queryLists.SelectList.Add("*");
            queryLists.WhereList = filter;
            queryLists.FromList.Add(" user as Users");
            string que = mySQLGenarate.BaseQuery(queryLists);
            que = mySQLGenarate.WhereQuery(que, queryLists.WhereList);

            return (userManager.Get(que));
        }

        public bool UpdateUser(Users users)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Users> UserExisits(ForLoginDto loginDto )
        {
            MysqlQueryLists queryLists = new MysqlQueryLists();
            queryLists.SelectList.Add("*");
            queryLists.WhereList.Add(" Users.EmailAdress ='" + loginDto.EmailAdress + "'or Users.TelNumber = '" + loginDto.EmailAdress + "'");
            queryLists.FromList.Add(" Users as Users");
            string que = mySQLGenarate.BaseQuery(queryLists);
            que = mySQLGenarate.WhereQuery(que, queryLists.WhereList);
            return new SuccessDataResult<Users>((Users)(userManager.Syncfunctions(que).ToList())[0]);
        }
    }
}
