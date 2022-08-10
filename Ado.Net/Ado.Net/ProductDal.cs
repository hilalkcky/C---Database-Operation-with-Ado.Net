using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Ado.Net
{
    public class ProductDal

    {
        SqlConnection _connection = new SqlConnection(@"Data Source = DESKTOP-KAD7EA3; Initial Catalog = ETrade; Integrated Security = True; Persist Security Info = False");

        public DataTable GetAll()
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Select * from Products", _connection);
            SqlDataReader reader = command.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);//datatable reader ile doldurur
            reader.Close();
            _connection.Close();
            return dataTable;
        }
        public void Add(Product product)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Insert Into Products values(@name,@unitprice,@stockamount)",_connection);
            command.Parameters.AddWithValue("@name", product.Name);
            command.Parameters.AddWithValue("@unitprice", product.UnitPrice);
            command.Parameters.AddWithValue("@stockamount", product.StockAmount);
            command.ExecuteNonQuery();
            _connection.Close();
        }
        public void Update(Product product)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Update Products set Name=@name,UnitPrice=@unitprice,StockAmount=@stockamount where Id=@ıd", _connection);
            command.Parameters.AddWithValue("@name", product.Name);
            command.Parameters.AddWithValue("@unitprice", product.UnitPrice);
            command.Parameters.AddWithValue("@stockamount", product.StockAmount);
            command.Parameters.AddWithValue("@ıd", product.Id);
            command.ExecuteNonQuery();
            _connection.Close();
        }
        public void Delete(Product product)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Delete from Products where Id=@ıd", _connection);
            command.Parameters.AddWithValue("@ıd",product.Id);
            command.ExecuteNonQuery();
            _connection.Close();
        }

        private void ConnectionControl()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
        }
    }
}