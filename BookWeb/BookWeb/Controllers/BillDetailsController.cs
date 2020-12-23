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

namespace BookWeb.Controllers
{
    public class BillDetailsController : Controller
    {
        private BookWebDataProvider db = new BookWebDataProvider();

        // GET: BillDetails
        public async Task<ActionResult> Index()
        {
            var billDetails = db.BillDetails.Include(b => b.Bill);
            return View(await billDetails.ToListAsync());
        }

        // GET: BillDetails/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BillDetail billDetail = await db.BillDetails.FindAsync(id);
            if (billDetail == null)
            {
                return HttpNotFound();
            }
            return View(billDetail);
        }

        // GET: BillDetails/Create
        public ActionResult Create()
        {
            ViewBag.idBill = new SelectList(db.Bills, "id", "shipaddress");
            return View();
        }

        // POST: BillDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,idBill,quantity,price")] BillDetail billDetail)
        {
            if (ModelState.IsValid)
            {
                db.BillDetails.Add(billDetail);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.idBill = new SelectList(db.Bills, "id", "shipaddress", billDetail.idBill);
            return View(billDetail);
        }

        // GET: BillDetails/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BillDetail billDetail = await db.BillDetails.FindAsync(id);
            if (billDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.idBill = new SelectList(db.Bills, "id", "shipaddress", billDetail.idBill);
            return View(billDetail);
        }

        // POST: BillDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,idBill,quantity,price")] BillDetail billDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(billDetail).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.idBill = new SelectList(db.Bills, "id", "shipaddress", billDetail.idBill);
            return View(billDetail);
        }

        // GET: BillDetails/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BillDetail billDetail = await db.BillDetails.FindAsync(id);
            if (billDetail == null)
            {
                return HttpNotFound();
            }
            return View(billDetail);
        }

        // POST: BillDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            BillDetail billDetail = await db.BillDetails.FindAsync(id);
            db.BillDetails.Remove(billDetail);
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
