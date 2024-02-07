using Microsoft.AspNetCore.Mvc;
using Real_Time_Stock_Exchange_Application.Models;
using System;
using System.Collections.Generic;

namespace Real_Time_Stock_Exchange_Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
       
        private static readonly List<Order> OrdersHistory = new List<Order>
        {
            new Order { Symbol = "AAPL", OrderType = "Buy", Quantity = 10 },
            new Order { Symbol = "GOOGL", OrderType = "Sell", Quantity = 5 },
            new Order { Symbol = "AMZN", OrderType = "Sell", Quantity = 50 },
            new Order { Symbol = "MSFT", OrderType = "Sell", Quantity = 70 },


            
        };

       
        [HttpGet]
        public IActionResult GetOrders()
        {
            try
            {
           
                return Ok(OrdersHistory);
            }
            catch (Exception ex)
            {
              
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }
}
