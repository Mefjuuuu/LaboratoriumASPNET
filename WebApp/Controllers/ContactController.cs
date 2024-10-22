using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class ContactController : Controller {
    private static Dictionary<int, ContactModel> _contacts = new() {
        {
            1,
            new ContactModel {
                Id = 1, Name = "Jan", Surname = "Kowalski", Email = "", PhoneNumber = "123 456 789",
                BirthDate = new DateOnly(1990, 1, 1)
            }
        }, {
            2,
            new ContactModel {
                Id = 2, Name = "Anna", Surname = "Nowak", Email = "", PhoneNumber = "987 654 321",
                BirthDate = new DateOnly(1995, 5, 5)
            }
        }, {
            3,
            new ContactModel {
                Id = 3, Name = "Piotr", Surname = "Wiśniewski", Email = "", PhoneNumber = "456 789 123",
                BirthDate = new DateOnly(2000, 10, 10)
            }
        }
    };

    public IActionResult Index() {
        return View(_contacts);
    }

    public IActionResult Add() {
        return View();
    }

    [HttpPost]
    public IActionResult Add(ContactModel contactModel) {
        if (!ModelState.IsValid) {
            return View(contactModel);
        }
        
        int newId = _contacts.Keys.Max() + 1;
        contactModel.Id = newId;

        _contacts.Add(newId, contactModel);

        return RedirectToAction("Index");
    }
    
    public IActionResult Edit(int id) {
        if (!_contacts.ContainsKey(id)) {
            return NotFound();
        }

        return View(_contacts[id]);
    }
    
    [HttpPost]
    public IActionResult Edit(ContactModel contactModel) {
        if (!ModelState.IsValid) {
            return View(contactModel);
        }

        _contacts[contactModel.Id] = contactModel;

        return RedirectToAction("Index");
    }
    
    public IActionResult Delete(int id) {
        if (!_contacts.ContainsKey(id)) {
            return NotFound();
        }

        _contacts.Remove(id);

        return RedirectToAction("Index");
    }
    
    public IActionResult Details(int id) {
        if (!_contacts.ContainsKey(id)) {
            return NotFound();
        }

        return View(_contacts[id]);
    }
    
}