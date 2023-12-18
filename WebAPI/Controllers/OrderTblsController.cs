using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppAPITest.Model;

namespace WebAppAPITest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderTblsController : ControllerBase
    {
        private readonly OrderTblDBContext _context;

        public OrderTblsController(OrderTblDBContext context)
        {
            _context = context;
        }

        // GET: api/OrderTbls
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderTbl>>> GetOrders()
        {
          if (_context.Orders == null)
          {
              return NotFound();
          }
            return await _context.Orders.ToListAsync();
        }

        // GET: api/OrderTbls/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderTbl>> GetOrderTbl(int id)
        {
          if (_context.Orders == null)
          {
              return NotFound();
          }
            var orderTbl = await _context.Orders.FindAsync(id);

            if (orderTbl == null)
            {
                return NotFound();
            }

            return orderTbl;
        }

        // PUT: api/OrderTbls/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderTbl(int id, OrderTbl orderTbl)
        {
            if (id != orderTbl.ItemCode)
            {
                return BadRequest();
            }

            _context.Entry(orderTbl).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderTblExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/OrderTbls
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderTbl>> PostOrderTbl(OrderTbl orderTbl)
        {
          if (_context.Orders == null)
          {
              return Problem("Entity set 'OrderTblDBContext.Orders'  is null.");
          }
            _context.Orders.Add(orderTbl);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderTbl", new { id = orderTbl.ItemCode }, orderTbl);
        }

        // DELETE: api/OrderTbls/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderTbl(int id)
        {
            if (_context.Orders == null)
            {
                return NotFound();
            }
            var orderTbl = await _context.Orders.FindAsync(id);
            if (orderTbl == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(orderTbl);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderTblExists(int id)
        {
            return (_context.Orders?.Any(e => e.ItemCode == id)).GetValueOrDefault();
        }
    }
}
