using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DemoEFCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace DemoPE.Web.Controllers
{
    public class AccountUsersController : Controller
    {
        private readonly BookPublisherContext _context;
        private readonly IHttpContextAccessor httpContextAccessor;

        public AccountUsersController(BookPublisherContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            this.httpContextAccessor = httpContextAccessor;
        }

        // GET: AccountUsers
        public async Task<IActionResult> Index()
        {
            if (httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                return null;
            }
            return View(await _context.AccountUsers.ToListAsync());
        }

        // GET: AccountUsers/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountUser = await _context.AccountUsers
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (accountUser == null)
            {
                return NotFound();
            }

            return View(accountUser);
        }

        // GET: AccountUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AccountUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserPassword,UserFullname,UserRole")] AccountUser accountUser)
        {
            if (ModelState.IsValid)
            {
                accountUser.UserId = Guid.NewGuid();
                _context.Add(accountUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(accountUser);
        }

        // GET: AccountUsers/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountUser = await _context.AccountUsers.FindAsync(id);
            if (accountUser == null)
            {
                return NotFound();
            }
            return View(accountUser);
        }

        // POST: AccountUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("UserId,UserPassword,UserFullname,UserRole")] AccountUser accountUser)
        {
            if (id != accountUser.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accountUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountUserExists(accountUser.UserId))
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
            return View(accountUser);
        }

        // GET: AccountUsers/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountUser = await _context.AccountUsers
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (accountUser == null)
            {
                return NotFound();
            }

            return View(accountUser);
        }

        // POST: AccountUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var accountUser = await _context.AccountUsers.FindAsync(id);
            _context.AccountUsers.Remove(accountUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountUserExists(Guid id)
        {
            return _context.AccountUsers.Any(e => e.UserId == id);
        }
    }
}
