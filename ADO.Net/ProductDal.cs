using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.Net
{
    class ProductDal
    {
        SqlConnection _connection= new SqlConnection(@"server=(localdb)\MSSQLLocalDB;initial catalog=Etrade;integrated security=true");
        public List<Product> GetAll()
        {
           
            ConnectionControl();

            SqlCommand command = new SqlCommand("select * from Products",_connection);
            
            SqlDataReader reader = command.ExecuteReader();

            List<Product> products = new List<Product>();

            while (reader.Read())
            {
                Product product = new Product
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString(),
                    StockAmount =Convert.ToInt32(reader["StockAmount"]),
                    UnitPrice = Convert.ToDecimal(reader["UnıtPrice"])
                };
                products.Add(product);
            }

            reader.Close();

            _connection.Close();

            return products;
        }

        private void ConnectionControl()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
        }

        public DataTable GetAll2()
        {
            
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }

            SqlCommand command = new SqlCommand("select * from Products", _connection);

            SqlDataReader reader = command.ExecuteReader();

            DataTable dataTable = new DataTable();
            dataTable.Load(reader);

            reader.Close();

           _connection.Close();

            return dataTable;
        }

        public void Add(Product product)
        {
            ConnectionControl();
            SqlCommand sqlCommand = new SqlCommand(
                "Insert into Products values(@name,@UnıtPrice,@StockAmount) ", _connection);
            sqlCommand.Parameters.AddWithValue("@name", product.Name);
            sqlCommand.Parameters.AddWithValue("@UnıtPrice", product.UnitPrice);
            sqlCommand.Parameters.AddWithValue("@StockAmount", product.StockAmount);

            sqlCommand.ExecuteNonQuery();


            _connection.Close();
        }
    }

    }