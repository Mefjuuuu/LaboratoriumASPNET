using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace WebApp.Controllers {
    public class TravelController : Controller {
        private static Dictionary<int, Travel> _travels = new Dictionary<int, Travel>();

        public IActionResult Index() {
            return View(_travels);
        }

        [HttpGet]
        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Travel model) {
            if (ModelState.IsValid) {
                int id = _travels.Keys.Count != 0 ? _travels.Keys.Max() : 0;
                model.Id = id + 1;
                _travels.Add(model.Id, model);

                return RedirectToAction("Index");
            }
            else {
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id) {
            if (_travels.ContainsKey(id)) {
                return View(_travels[id]);
            }
            else {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Edit(Travel model) {
            if (ModelState.IsValid) {
                _travels[model.Id] = model;
                return RedirectToAction("Index");
            }
            else {
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id) {
            if (_travels.ContainsKey(id)) {
                return View(_travels[id]);
            }
            else {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id) {
            if (_travels.ContainsKey(id)) {
                _travels.Remove(id);
                return RedirectToAction("Index");
            }
            else {
                return NotFound();
            }
        }

        [HttpGet]
        public IActionResult Details(int id) {
            if (_travels.ContainsKey(id)) {
                return View(_travels[id]);
            }
            else {
                return NotFound();
            }
        }
    }
}