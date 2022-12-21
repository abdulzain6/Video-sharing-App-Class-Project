using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using test.Models;

namespace test.Controllers;

public class HomeController : Controller
{

    private readonly ContactDBContext _context;


    public HomeController(ContactDBContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Create()
    {
        return View();
    }
    [HttpGet]
    public IActionResult Contact()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Contact(Contact contact)
    {
        if (ModelState.IsValid)
        {
            _context.Add(contact);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View("Contact");
    }


}

       