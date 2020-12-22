using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model.Entity;

namespace BookWeb.Areas.Admin.Controllers
{
    public class BillsController : Controller
    {
        private BookWebDataProvider db = new BookWebDataProvider();

        // GET: Admin/Bills
        public async Task<ActionResult> Index()
        {
            var bills = db.Bills.Include(b => b.Account).Include(b => b.Account1).Include(b => b.Discount);
            return View(await bills.ToListAsync());
        }

        // GET: Admin/Bills/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bill bill = await db.Bills.FindAsync(id);
            if (bill == null)
            {
                return HttpNotFound();
            }
            return View(bill);
        }

        // GET: Admin/Bills/Create
        public ActionResult Create()
        {
            ViewBag.idCustomer = new SelectList(db.Accounts, "id", "username");
            ViewBag.idEmployee = new SelectList(db.Accounts, "id", "username");
            ViewBag.idDiscount = new SelectList(db.Discounts, "id", "id");
            return View();
        }

        // POST: Admin/Bills/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,idCustomer,idEmployee,idDiscount,sale,checkin,shipaddress,shipMobile")] Bill bill)
        {
            if (ModelState.IsValid)
            {
                db.Bills.Add(bill);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.idCustomer = new SelectList(db.Accounts, "id", "username", bill.idCustomer);
            ViewBag.idEmployee = new SelectList(db.Accounts, "id", "username", bill.idEmployee);
            ViewBag.idDiscount = new SelectList(db.Discounts, "id", "id", bill.idDiscount);
            return View(bill);
        }

        // GET: Admin/Bills/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bill bill = await db.Bills.FindAsync(id);
            if (bill == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCustomer = new SelectList(db.Accounts, "id", "username", bill.idCustomer);
            ViewBag.idEmployee = new SelectList(db.Accounts, "id", "username", bill.idEmployee);
            ViewBag.idDiscount = new SelectList(db.Discounts, "id", "id", bill.idDiscount);
            return View(bill);
        }

        // POST: Admin/Bills/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,idCustomer,idEmployee,idDiscount,sale,checkin,shipaddress,shipMobile")] Bill bill)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bill).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.idCustomer = new SelectList(db.Accounts, "id", "username", bill.idCustomer);
            ViewBag.idEmployee = new SelectList(db.Accounts, "id", "username", bill.idEmployee);
            ViewBag.idDiscount = new SelectList(db.Discounts, "id", "id", bill.idDiscount);
            return View(bill);
        }

        // GET: Admin/Bills/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bill bill = await db.Bills.FindAsync(id);
            if (bill == null)
            {
                return HttpNotFound();
            }
            return View(bill);
        }

        // POST: Admin/Bills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Bill bill = await db.Bills.FindAsync(id);
            db.Bills.Remove(bill);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
