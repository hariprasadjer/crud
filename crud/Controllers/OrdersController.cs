using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using crud.Data;
using crud.Models;
using crud.ViewModels;

namespace crud.Controllers
{
    // Handles CRUD operations for orders
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var orders = await _context.Orders.Include(o => o.Product).ToListAsync();
            return View(orders);
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var order = await _context.Orders
                .Include(o => o.Product)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (order == null) return NotFound();
            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            var vm = new OrderViewModel
            {
                OrderDate = DateTime.Today,
                Products = _context.Products.ToList()
            };
            return View(vm);
        }

        // POST: Orders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OrderViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var order = new Order
                {
                    ProductId = vm.ProductId,
                    Quantity = vm.Quantity,
                    OrderDate = vm.OrderDate
                };
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            vm.Products = _context.Products.ToList();
            return View(vm);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var order = await _context.Orders.FindAsync(id);
            if (order == null) return NotFound();

            var vm = new OrderViewModel
            {
                OrderId = order.OrderId,
                ProductId = order.ProductId,
                Quantity = order.Quantity,
                OrderDate = order.OrderDate,
                Products = _context.Products.ToList()
            };
            return View(vm);
        }

        // POST: Orders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, OrderViewModel vm)
        {
            if (id != vm.OrderId) return NotFound();
            if (ModelState.IsValid)
            {
                var order = await _context.Orders.FindAsync(id);
                if (order == null) return NotFound();

                order.ProductId = vm.ProductId;
                order.Quantity = vm.Quantity;
                order.OrderDate = vm.OrderDate;

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            vm.Products = _context.Products.ToList();
            return View(vm);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var order = await _context.Orders
                .Include(o => o.Product)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (order == null) return NotFound();
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
