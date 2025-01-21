using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Context;
using WebApplication3.Models;

namespace WebApplication3.Controllers;

[Authorize]
public class CustomerController : Controller {
    private readonly GravityDbContext _context;

    public CustomerController(GravityDbContext context) {
        _context = context;
    }


    public async Task<IActionResult> Index(int page = 1, int size = 20) {
        var totalRecords = await _context.customers.CountAsync();
        var customers = await _context
            .customers
            .Include(c => c.customer_addresses)
            .ThenInclude(ca => ca.address)
            .ThenInclude(a => a.country)
            .Include(c => c.cust_orders)
            .OrderBy(e => e.customer_id)
            .Skip((page - 1) * size)
            .Take(size)
            .AsNoTracking()
            .ToListAsync();

        ViewBag.CurrentPage = page;
        ViewBag.TotalPages = (int)Math.Ceiling(totalRecords / (double)size);
        ViewBag.PageSize = size;

        return View(customers);
    }


    public async Task<IActionResult> Details(int? id) {
        if (id == null) {
            return NotFound();
        }

        var customer = await _context.customers
            .FirstOrDefaultAsync(m => m.customer_id == id);
        if (customer == null) {
            return NotFound();
        }

        return View(customer);
    }

    public IActionResult Create() {
        return View();
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        [Bind("customer_id,first_name,last_name,email,country")] Customer customer)
    {
        if (ModelState.IsValid)
        {
            var maxCustomerId = await _context.customers
                .OrderByDescending(c => c.customer_id)
                .Select(c => c.customer_id)
                .FirstOrDefaultAsync();

            customer.customer_id = maxCustomerId + 1;

            _context.Add(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View(customer);
    }


    public async Task<IActionResult> Edit(int? id) {
        if (id == null) {
            return NotFound();
        }

        var customer = await _context.customers.FindAsync(id);
        if (customer == null) {
            return NotFound();
        }

        return View(customer);
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id,
        [Bind("customer_id,first_name,last_name,email,country")]
        Customer customer) {
        if (id != customer.customer_id) {
            return NotFound();
        }

        if (ModelState.IsValid) {
            try {
                _context.Update(customer);
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!CustomerExists(customer.customer_id)) {
                    return NotFound();
                }

                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        return View(customer);
    }

    public async Task<IActionResult> Delete(int? id) {
        if (id == null) {
            return NotFound();
        }

        var customer = await _context.customers
            .FirstOrDefaultAsync(m => m.customer_id == id);
        if (customer == null) {
            return NotFound();
        }

        return View(customer);
    }

    public async Task<IActionResult> Orders(int? id) {
        if (id == null) {
            return NotFound();
        }

        var orders = await _context.cust_orders
            .Where(o => o.customer_id == id)
            .ToListAsync();

        if (orders == null) {
            return NotFound();
        }

        return View(orders);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id) {
        var customer = await _context.customers.FindAsync(id);
        if (customer != null) {
            _context.customers.Remove(customer);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool CustomerExists(int id) {
        return _context.customers.Any(e => e.customer_id == id);
    }

    public async Task<IActionResult> CustomerOrders(int id)
    {
        var orders = await _context.cust_orders
            .Include(o => o.shipping_method)
            .Where(o => o.customer_id == id)
            .ToListAsync();

        if (orders == null || !orders.Any())
        {
            return NotFound("No orders found for this customer.");
        }

        return View(orders); 
    }
    
    public async Task<IActionResult> OrderDetails(int id)
    {
        var order = await _context.cust_orders
            .Include(o => o.order_histories)
            .FirstOrDefaultAsync(o => o.order_id == id);

        if (order == null)
        {
            return NotFound("Order not found.");
        }

        return View(order);
    }
    
    [HttpPost]
    public async Task<IActionResult> UpdateStatus(int order_id, int new_status)
    {
        var order = await _context.cust_orders
            .Include(o => o.order_histories)
            .FirstOrDefaultAsync(o => o.order_id == order_id);

        if (order == null)
        {
            return NotFound("Order not found.");
        }

        var currentStatus = order.order_histories
            .OrderByDescending(h => h.status_date)
            .FirstOrDefault()?.status_id ?? 0;

        if (currentStatus >= 4)
        {
            return BadRequest("Cannot update status. Current status is 4 or higher.");
        }

        var history = new Order_history
        {
            order_id = order_id,
            status_id = new_status,
            status_date = DateTime.Now
        };

        _context.order_histories.Add(history);
        
        return RedirectToAction("Index");
    }
}