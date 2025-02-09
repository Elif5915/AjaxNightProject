using AjaxNightProject.Context;
using AjaxNightProject.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AjaxNightProject.Controllers;
public class CustomerController : Controller
{
    private readonly AjaxContext _context;

    public CustomerController(AjaxContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult CustomerList()
    {
        var values = _context.Customers.ToList(); //müsteri listesini getirdik
        var jsonData = JsonConvert.SerializeObject(values); //musteri listesindeki dataları json formatına cevirdik
        return Json(jsonData); // json format verileri döndürdük
    }
    public IActionResult CustomerCreate(Customer customer)
    {
        _context.Customers.Add(customer);
        _context.SaveChanges();
        var values = JsonConvert.SerializeObject(customer);
        return Json(values);
    }
    public IActionResult CustomerDelete(int id)
    {
        var value = _context.Customers.Find(id);
        _context.Customers.Remove(value);
        _context.SaveChanges();
        return NoContent(); // NoContent diyerek en son işlemden sonra bir şey döndürme ama hata da vermesin diye kullandık

    }

    public IActionResult GetCustomer(int id)
    {
        var value = _context.Customers.Find(id);
        var jsonValues = JsonConvert.SerializeObject(value);
        return Json(jsonValues);
    }

    public IActionResult UpdateCustomer(Customer customer)
    {
        _context.Customers.Update(customer);
        _context.SaveChanges();
        return NoContent();
    }
}
