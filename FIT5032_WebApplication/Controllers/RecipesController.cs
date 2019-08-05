using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FIT5032_WebApplication.Models;
using Microsoft.AspNet.Identity;
using Newtonsoft;

namespace FIT5032_WebApplication.Controllers
{
    public class RecipesController : Controller
    {
        private RecipeModel db = new RecipeModel();

        // GET: Recipes
        public ActionResult Index()
        {
            return View(db.Recipes.ToList());
        }

        // GET: Recipes/Details/5
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe recipe = db.Recipes.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

        // GET: Recipes/Create
        public ActionResult Create()
        {
            var response = Request["g-Recaptcha-response"];
            string secretKey = "6LeyBXYUAAAAAI61KP3ec0rTgcpCzVISwvPjDYAi";
            var client = new WebClient();

            ViewData["Message"] = "Google reCaptcha validation success";

            return View();
        }

        // POST: Recipes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Cal,Ingredients,Carbs,Protein,Fat,PrepTime,Servings,Instructions,MealType")] Recipe recipe,
        HttpPostedFileBase postedFile)
        {
            ModelState.Clear();
            var myUniqueFileName = string.Format(@"{0}", Guid.NewGuid());
            recipe.Path = myUniqueFileName;
            TryValidateModel(recipe);

            if (ModelState.IsValid)
            {
                string serverPath = Server.MapPath("~/Uploads/");
                string fileExtension = Path.GetExtension(postedFile.FileName);
                string filePath = recipe.Path + fileExtension;
                recipe.Path = filePath;
                postedFile.SaveAs(serverPath + recipe.Path);          
                recipe.DateCreated = System.DateTime.Now.Date;
                recipe.UserId = User.Identity.GetUserId();
                recipe.Status = "Waiting";

                db.Recipes.Add(recipe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(recipe);
        }

        // GET: Recipes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe recipe = db.Recipes.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

        // POST: Recipes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Path,Name,Cal,DateCreated,Ingredients,Carbs,Protein,Fat,PrepTime,Servings,Instructions,UserId,MealType,Status")] Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recipe).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(recipe);
        }

        // GET: Recipes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe recipe = db.Recipes.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

        // POST: Recipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recipe recipe = db.Recipes.Find(id);
            db.Recipes.Remove(recipe);
            db.SaveChanges();
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

        public ActionResult MyRecipes()
        {
            return View(db.Recipes.ToList());
        }

        public ActionResult Approval()
        {
            return View(db.Recipes.ToList());
        }

        public ActionResult Breakfast()
        {
            return View(db.Recipes.ToList());
        }

        public ActionResult Lunch()
        {
            return View(db.Recipes.ToList());
        }

        public ActionResult Dinner()
        {
            return View(db.Recipes.ToList());
        }
    }
}
