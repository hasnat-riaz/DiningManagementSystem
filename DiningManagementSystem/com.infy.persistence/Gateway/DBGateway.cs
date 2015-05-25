using System.Configuration;
using System.Data.SqlClient;

namespace DiningManagementSystem.com.infy.persistence.Gateway
{
    public class DBGateway
    {
        public SqlConnection aSqlConnection { get; set; }


        public SqlCommand aSqlCommand { get; set; }

        public DBGateway()
        {
            string conn = ConfigurationManager.ConnectionStrings[
                  "DiningManagementSystem.Properties.Settings.MydatabaseConnectionString"].ConnectionString;
            aSqlConnection = new SqlConnection(conn);

            aSqlCommand = new SqlCommand();
        }
    }
}
