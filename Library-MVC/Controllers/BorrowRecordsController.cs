using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Library_MVC.Data;
using Library_MVC.Models;

namespace Library_MVC.Controllers
{
    public class BorrowRecordsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BorrowRecordsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BorrowRecords
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.BorrowRecord.Include(b => b.Book).Include(b => b.Member);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: BorrowRecords/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrowRecord = await _context.BorrowRecord
                .Include(b => b.Book)
                .Include(b => b.Member)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (borrowRecord == null)
            {
                return NotFound();
            }

            return View(borrowRecord);
        }

        // GET: BorrowRecords/Create
        public IActionResult Create()
        {
            ViewData["BookId"] = new SelectList(_context.Book, "Id", "Author_Name");
            ViewData["MemberId"] = new SelectList(_context.Member, "Id", "Email");
            return View();
        }

        // POST: BorrowRecords/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BookId,MemberId,BorrowDate,DueDate,ReturnDate")] BorrowRecord borrowRecord)
        {
            Console.WriteLine("1");
            //if (ModelState.IsValid)
            {
                Console.WriteLine("2");
                _context.Add(borrowRecord);
                await _context.SaveChangesAsync();
                Console.WriteLine("3");
                return RedirectToAction(nameof(Index));
            }
            Console.WriteLine("4");
            ViewData["BookId"] = new SelectList(_context.Book, "Id", "Author_Name", borrowRecord.BookId);
            ViewData["MemberId"] = new SelectList(_context.Member, "Id", "Email", borrowRecord.MemberId);
            Console.WriteLine("5");
            return View(borrowRecord);
        }

        // GET: BorrowRecords/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrowRecord = await _context.BorrowRecord.FindAsync(id);
            if (borrowRecord == null)
            {
                return NotFound();
            }
            ViewData["BookId"] = new SelectList(_context.Book, "Id", "Author_Name", borrowRecord.BookId);
            ViewData["MemberId"] = new SelectList(_context.Member, "Id", "Email", borrowRecord.MemberId);
            return View(borrowRecord);
        }

        // POST: BorrowRecords/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BookId,MemberId,BorrowDate,DueDate,ReturnDate")] BorrowRecord borrowRecord)
        {
            if (id != borrowRecord.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(borrowRecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BorrowRecordExists(borrowRecord.Id))
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
            ViewData["BookId"] = new SelectList(_context.Book, "Id", "Author_Name", borrowRecord.BookId);
            ViewData["MemberId"] = new SelectList(_context.Member, "Id", "Email", borrowRecord.MemberId);
            return View(borrowRecord);
        }

        // GET: BorrowRecords/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrowRecord = await _context.BorrowRecord
                .Include(b => b.Book)
                .Include(b => b.Member)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (borrowRecord == null)
            {
                return NotFound();
            }

            return View(borrowRecord);
        }

        // POST: BorrowRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var borrowRecord = await _context.BorrowRecord.FindAsync(id);
            if (borrowRecord != null)
            {
                _context.BorrowRecord.Remove(borrowRecord);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BorrowRecordExists(int id)
        {
            return _context.BorrowRecord.Any(e => e.Id == id);
        }
    }
}
