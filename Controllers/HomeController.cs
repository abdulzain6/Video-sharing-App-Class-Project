﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace test.Controllers;

public class HomeController : Controller
{

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
}
