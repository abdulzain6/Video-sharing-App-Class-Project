using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using test.Models;
using System.Text;
using System.Web;



namespace test.Controllers; 

public class HomeController : Controller
{

    private readonly AppDBContext _context;


    public HomeController(AppDBContext context)
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

    [HttpGet]
    public IActionResult Contact()
    {
        return View();
    }

    private byte[] GetByteArrayFromImage(IFormFile file)
    {
        using (var target = new MemoryStream())
        {
            file.CopyTo(target);
            return target.ToArray();
        }
    }

    [HttpPost]
    public IActionResult Paste(string data)
    {
        try{
            byte[] bytes = Encoding.ASCII.GetBytes(data);  

            Guid id = Guid.NewGuid();
            var model = new test.Models.File{
                Id = id,
                FileData = bytes
            };
    
            _context.Add(model);
            _context.SaveChanges();

            ViewBag.link = id;

            return View("GetFile");
        }
        catch
        {
            ViewBag.Error = "Error";
            return RedirectToAction("Index");

        }
        
        
    }
    
    [HttpPost]
    public IActionResult FileUpload(IFormFile data)
    {

        try
        {
            var bytes = GetByteArrayFromImage(data);

            Guid id = Guid.NewGuid();
            var model = new test.Models.File{
                Id = id,
                FileData = bytes
            };
    
            _context.Add(model);
            _context.SaveChanges();

            ViewBag.link = id;
            return View("GetFile");    
        }
        catch
        {
            ViewBag.Error = "Error";
            return RedirectToAction("Index");
        }
        
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

    [HttpGet]
    public IActionResult FileDownload(string id)
    {
        Guid guid = Guid.Parse(id);
        var model = _context.Files.SingleOrDefault(m => m.Id == guid);
        return File(model.FileData, System.Net.Mime.MediaTypeNames.Application.Octet, id);
    }


}

       