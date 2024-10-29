using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Models.services;

namespace WebApp.Controllers;

public class ContactController : Controller {

    private readonly IContactService contactService;

    public ContactController(IContactService contactService) {
        this.contactService = contactService;
    }
    
    public IActionResult Index() {
        return View(contactService.GetAll());
    }

    public IActionResult Add() {
        return View();
    }

    [HttpPost]
    public IActionResult Add(ContactModel contactModel) {
        if (!ModelState.IsValid) {
            return View(contactModel);
        }
        contactService.Add(contactModel);
        return RedirectToAction(nameof(Index));
    }
    
    public IActionResult Edit(int id) {
        if (contactService.GetById(id) == null) {
            return NotFound();
        }

        return View(contactService.GetById(id));
    }
    
    [HttpPost]
    public IActionResult Edit(ContactModel contactModel) {
        if (!ModelState.IsValid) {
            return View(contactModel);
        }

        contactService.Update(contactModel);

        return RedirectToAction(nameof(Index));
    }
    
    public IActionResult Delete(int id) {
        if (contactService.GetById(id) == null) {
            return NotFound();
        }

        contactService.Delete(id);

        return RedirectToAction(nameof(Index));
    }
    
    public IActionResult Details(int id) {
        if (contactService.GetById(id) == null) {
            return NotFound();
        }

        return View(contactService.GetById(id));
    }
    
}