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
    public class AccountGroupsController : Controller
    {
        private BookWebDataProvider db = new BookWebDataProvider();

        // GET: Admin/AccountGroups
        public async Task<ActionResult> Index()
        {
            return View(await db.AccountGroups.ToListAsync());
        }

        // GET: Admin/AccountGroups/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountGroup accountGroup = await db.AccountGroups.FindAsync(id);
            if (accountGroup == null)
            {
                return HttpNotFound();
            }
            return View(accountGroup);
        }

        // GET: Admin/AccountGroups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/AccountGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,name")] AccountGroup accountGroup)
        {
            if (ModelState.IsValid)
            {
                db.AccountGroups.Add(accountGroup);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(accountGroup);
        }

        // GET: Admin/AccountGroups/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountGroup accountGroup = await db.AccountGroups.FindAsync(id);
            if (accountGroup == null)
            {
                return HttpNotFound();
            }
            return View(accountGroup);
        }

        // POST: Admin/AccountGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,name")] AccountGroup accountGroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accountGroup).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(accountGroup);
        }

        // GET: Admin/AccountGroups/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountGroup accountGroup = await db.AccountGroups.FindAsync(id);
            if (accountGroup == null)
            {
                return HttpNotFound();
            }
            return View(accountGroup);
        }

        // POST: Admin/AccountGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            AccountGroup accountGroup = await db.AccountGroups.FindAsync(id);
            db.AccountGroups.Remove(accountGroup);
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
