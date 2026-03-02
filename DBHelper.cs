using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace OnlineShoppingApp
{
    class DBHelper
    {
        // 🔹 connection string (cs) yahin define hota hai
        static string cs =
            ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

        // 🔹 ALL PRODUCTS
        public static DataSet GetProducts()
        {
            SqlConnection con = new SqlConnection(cs);
            SqlDataAdapter da =
                new SqlDataAdapter("SELECT * FROM Products", con);

            DataSet ds = new DataSet();
            da.Fill(ds, "Products");
            return ds;
        }

        // 🔹 PRODUCTS BY CATEGORY (YE WAHI CODE HAI JO TU PUCH RAHA THA)
        public static DataSet GetProductsByCategory(string category)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlDataAdapter da =
                new SqlDataAdapter(
                    "SELECT * FROM Products WHERE Category=@cat", con);

            da.SelectCommand.Parameters.AddWithValue("@cat", category);

            DataSet ds = new DataSet();
            da.Fill(ds, "Products");
            return ds;
        }
    }
}