using Microsoft.AspNetCore.Mvc;
using Real_Time_Stock_Exchange_Application.Models;
using System;
using System.Threading.Tasks;

namespace Real_Time_Stock_Exchange_Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StocksController : ControllerBase
    {
        private readonly AlphaVantageService _alphaVantageService;

        public StocksController(AlphaVantageService alphaVantageService)
        {
            _alphaVantageService = alphaVantageService;
        }

        // Endpoint to retrieve real-time stock data
        [HttpGet]
        public async Task<IActionResult> GetStocks(string symbol)
        {
            try
            {
                string stockData = await _alphaVantageService.GetStockData(symbol);

                if (stockData != null)
                {
                    return Ok(stockData);
                }
                else
                {
                    return StatusCode(500, "Failed to retrieve stock data.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        // Endpoint to retrieve historical stock data for a given symbol
        [HttpGet("{symbol}/history")]
        public async Task<IActionResult> GetStockHistory(string symbol)
        {
            try
            {
                string stockHistory = await _alphaVantageService.GetStockHistory(symbol);

                if (stockHistory != null)
                {
                    return Ok(stockHistory);
                }
                else
                {
                    return StatusCode(500, "Failed to retrieve stock history data.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        // Endpoint to create an order
        [HttpPost("order")]
        public IActionResult CreateOrder([FromBody] Order order)
        {
            try
            {
                // Validate the order data
                if (order == null)
                {
                    return BadRequest("Invalid order data: Order object is null.");
                }

                if (string.IsNullOrEmpty(order.Symbol))
                {
                    return BadRequest("Invalid order data: Symbol is required.");
                }

                if (string.IsNullOrEmpty(order.OrderType) ||
                    (order.OrderType.ToLower() != "buy" && order.OrderType.ToLower() != "sell"))
                {
                    return BadRequest("Invalid order data: Order type must be 'buy' or 'sell'.");
                }

                if (order.Quantity == null)
                {
                    return BadRequest("Invalid order data: Quantity is required.");
                }

                if (order.Quantity <= 0)
                {
                    return BadRequest("Invalid order data: Quantity must be greater than zero.");
                }

                
                string message = $"Order for {order.Quantity} shares of {order.Symbol} ({order.OrderType}) has been successfully created.";
                return Ok(message);
            }
            catch (Exception ex)
            {
            
                return StatusCode(500, $"An error occurred while processing the order: {ex.Message}");
            }
        }


    }
}
