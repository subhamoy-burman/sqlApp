using sqlApp.Models;
using System.Data.SqlClient;

namespace sqlApp.Services
{
    public class ProductService
    {
        private static string db_source = "meic-appserver.database.windows.net";
        private static string db_user = "sqladmin";
        private static string db_password = "Joy71723!";
        private static string db_database = "appdb";

        private SqlConnection GetConnection()
        {
            var _builder = new SqlConnectionStringBuilder();
            _builder.DataSource = db_source;
            _builder.UserID= db_user;
            _builder.Password= db_password;
            _builder.InitialCatalog = db_database;

            return new SqlConnection(_builder.ConnectionString);
        }

        public List<Product> GetProducts()
        {
            SqlConnection connection= GetConnection();
            var products = new List<Product>();

            string statement = "SELECT ProductId, ProductName, Quantity from Products";

            connection.Open();

            SqlCommand cmd = new SqlCommand(statement, connection);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Product product = new Product()
                    {
                        ProductId = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        Quantity = reader.GetInt32(2)
                    };

                    products.Add(product);
                }
            }

            connection.Close();
            return products;
        }

    }
}
