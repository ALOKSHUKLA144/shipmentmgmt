using Microsoft.Data.SqlClient;
using System.Data;

namespace shipmentmgmt_WebapiCore.DataLayer
{
    public class dataaccess
    {
        private readonly string _conn;
        public dataaccess(IConfiguration configuration)
        {
            _conn = configuration.GetConnectionString("defaultconnection");
        }
        public int ExecuteNOnquery(string proc, SqlParameter[] param)
        {
            using(SqlConnection conn = new SqlConnection(this._conn))
            {
                using(SqlCommand cmd = new SqlCommand(proc, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (param != null)
                    cmd.Parameters.AddRange(param);
                    conn.Open();
                    int res= cmd.ExecuteNonQuery();
                    conn.Close();
                    return res;
                }

            }
        }

        //for insert only
        public int Executescaler(string proc, SqlParameter[] param)
        {
            using (SqlConnection conn = new SqlConnection(this._conn))
            {
                using (SqlCommand cmd = new SqlCommand(proc, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (param != null)
                        cmd.Parameters.AddRange(param);
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    int res = (result != null) ? Convert.ToInt32(result) : 0;
                    conn.Close();
                    return res;
                }

            }
        }

        public DataTable select(string proc, SqlParameter[] param)
        {
            using(SqlConnection  conn = new SqlConnection(this._conn))
            {
                using(SqlCommand cmd = new SqlCommand(proc, conn))
                {
                    cmd.CommandType= CommandType.StoredProcedure;
                    if (param != null)
                        cmd.Parameters.AddRange(param);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }


            }
        }
    }
}
