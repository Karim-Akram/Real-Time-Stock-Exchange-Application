namespace Real_Time_Stock_Exchange_Application.Models
{
    public class Order
    {
        public string Symbol { get; set; }
        public string OrderType { get; set; }
        public int Quantity { get; set; }
    }
}
