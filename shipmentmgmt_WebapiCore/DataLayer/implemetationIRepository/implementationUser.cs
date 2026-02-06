using Microsoft.Data.SqlClient;
using shipmentmgmt_WebapiCore.BusinessLayer.IRepsitory;
using shipmentmgmt_WebapiCore.BusinessLayer.Models;
using System.Data;

namespace shipmentmgmt_WebapiCore.DataLayer.implemetationIRepository
{
    public class implementationUser : Iuser
    {
        private readonly dataaccess _db;
        private readonly string _connectionString;
        public implementationUser(IConfiguration configuration, dataaccess db)
        {
            _connectionString = configuration.GetConnectionString("defaultconnection");
            _db = db;
        }
        public int AddUser(user user)
        {
            int res = _db.Executescaler("sp_crud_user", new SqlParameter[]
            {
              new SqlParameter("@userid",user.UserId),
              new SqlParameter("@password",user.Password),
              new SqlParameter("@Roles",user.Roles),
              new SqlParameter("@action",1),
            });
            return res;


            //using (SqlConnection conn = new SqlConnection(_connectionString))
            //{
            //    using (SqlCommand cmd = new SqlCommand("sp_ManageUser", conn))
            //    {
            //        cmd.CommandType = CommandType.StoredProcedure;
            //        cmd.Parameters.AddWithValue("@Action", 1);
            //        cmd.Parameters.AddWithValue("@UserId", user.UserId);
            //        cmd.Parameters.AddWithValue("@Password", user.Password);
            //        cmd.Parameters.AddWithValue("@Roles", user.Roles ?? (object)DBNull.Value);
            //        conn.Open();
            //        object result = cmd.ExecuteScalar();
            //        return Convert.ToInt32(result);
            //    }
            //}
        }

        public int DeleteUser(int id)
        {
            int res = _db.ExecuteNOnquery("sp_crud_user", new SqlParameter[]
               {
                 new SqlParameter("@Id",id),
                 new SqlParameter("@action",3),
               });
            return res;
        }

        public List<user> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public user GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(user user)
        {
            throw new NotImplementedException();
        }
    }
}
