using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AOWebApp2.Data;
using AOWebApp2.Models;
using Microsoft.IdentityModel.Tokens;
using AOWebApp2.ViewModels;

namespace AOWebApp2.Controllers
{
    public class CustomersController : Controller
    {
        private readonly AmazonOrdersDb2025Context _context;

        public CustomersController(AmazonOrdersDb2025Context context)
        {
            _context = context;
        }

        // GET: Customers
        public async Task<IActionResult> Index(CustomerSearchVM csvm)
        {
            #region SuburbQuery
            var suburbs = (from i in _context.Addresses
                           select i.Suburb)
                           .Distinct()
                           .OrderBy(i => i)
                           .ToList();

            csvm.SuburbList = new SelectList(suburbs, csvm.Suburb);
            //ViewBag.selectedSuburb = suburbName;
            #endregion
            
            var customerList = new List<Customer>();
            //ViewBag.customerSearched = searchCustomer;

            var customerListQuery = _context.Customers
                .Include(i => i.Address)
                .AsQueryable();

            if (string.IsNullOrWhiteSpace(csvm.SearchText) && csvm.Suburb.IsNullOrEmpty())
            {
                csvm.CustomerList = customerList;
                return View(csvm);
            }

            if (!string.IsNullOrWhiteSpace(csvm.SearchText))
            {
                customerListQuery = (from i in customerListQuery
                                     where i.FirstName.StartsWith(csvm.SearchText)
                                     || i.LastName.StartsWith(csvm.SearchText)
                                     select i)
                                 .OrderBy(i => !i.FirstName.StartsWith(csvm.SearchText))
                                 .ThenBy(i => !i.LastName.StartsWith(csvm.SearchText));
            }

            if (!csvm.Suburb.IsNullOrEmpty())
            {
                customerListQuery = customerListQuery
                    .Where(i => i.Address.Suburb == csvm.Suburb);
            }

            csvm.CustomerList= await customerListQuery.ToListAsync();
            ViewBag.customerCount = customerList.Count();
            return View(csvm);
            //return View(await amazonOrdersDb2025Context.ToListAsync());
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .Include(c => c.Address)
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            ViewData["AddressId"] = new SelectList(_context.Addresses, "AddressId", "AddressId");
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,FirstName,LastName,Email,MainPhoneNumber,SecondaryPhoneNumber,AddressId")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddressId"] = new SelectList(_context.Addresses, "AddressId", "AddressId", customer.AddressId);
            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            ViewData["AddressId"] = new SelectList(_context.Addresses, "AddressId", "AddressId", customer.AddressId);
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerId,FirstName,LastName,Email,MainPhoneNumber,SecondaryPhoneNumber,AddressId")] Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.CustomerId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddressId"] = new SelectList(_context.Addresses, "AddressId", "AddressId", customer.AddressId);
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .Include(c => c.Address)
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.CustomerId == id);
        }
    }
}
