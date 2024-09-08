using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Products_api.Models;
using System.Data.SqlClient;
using System.Data.SqlClient;
using System.Text.Json;

namespace Products_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public ProductsController(IConfiguration configuration)
        {
            _configuration = configuration;
            
        }
        [HttpGet]
        [Route("products")]
        public IActionResult products()
        {
            string connectionstring = _configuration.GetConnectionString("ProductsCons").ToString();
            string query = "SELECT * FROM Products";

            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                List<Products> products = new List<Products>();

                while (reader.Read())
                {
                    Products product = new Products();
                    product.Product_Id = reader.GetInt32(0);
                    product.Product_name = reader.GetString(1);
                    product.supplier_id = reader.GetInt32(2);
                    product.category_id = reader.GetInt32(3);
                    product.quantity_per_unit = reader.GetString(4);
                    product.unit_price = reader.GetDecimal(5);

                    products.Add(product);
                }

                reader.Close();
                con.Close();

                return new JsonResult(products);
            }
        }



    }
        
    
}
