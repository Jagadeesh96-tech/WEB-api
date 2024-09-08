namespace Products_api.Models
{
    public class Products
    {
        public int Product_Id { get; set; }
        public string Product_name { get; set; }
        public int supplier_id { get; set; }

        public int category_id { get; set; }
        public string quantity_per_unit { get; set; }
        public decimal unit_price { get; set; }
    }
}
