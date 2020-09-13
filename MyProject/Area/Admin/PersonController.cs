using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyProject.Models;

namespace MyProject.Area.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : AdminBase
    {
        public DataContext _context;
        public PersonController(DataContext context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
            ViewBag.Categories = _context.Categories.ToList();
            var list = _context.Patients.OrderByDescending(p => p).Include(p => p.Category).ToList();
            return View(list);
        }

        [HttpPost]
        public IActionResult Index(string category)
        {
            ViewBag.Categories = _context.Categories.ToList();
            var list = _context.Patients.OrderByDescending(p => p).Include(p => p.Category.EmergencyAssistance == category).ToList();
            list = _context.Patients.OrderByDescending(p => p).Include(p => p.Category).ToList();
            return View(list);
        }

        public IActionResult Add()
        {
            ViewBag.Categories = _context.Categories.ToList();
            ViewBag.AboutTheFunds = _context.AboutTheFunds.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Patients model, int CategoryId , int AboutTheFundsId )
        {
            var Category = await _context.Categories.FirstAsync(p => p.Id == CategoryId);
            var AboutTheFund = await _context.AboutTheFunds.FirstAsync(p => p.Id == AboutTheFundsId);
            model.Category = Category;
            model.AboutTheFund = AboutTheFund;
            _context.Patients.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult>Delete(int Id)
        {
            var model = await _context.Patients.FirstAsync(p => p.Id == Id);
            _context.Remove(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int Id)
        {
            var model =_context.Patients.Include(p => p.Category).Include(p => p.AboutTheFund).Single(p => p.Id == Id);
            var CategiryList = _context.Categories.Where(p => p.Id == model.Category.Id).ToList();
            var AboutTheFundList = _context.AboutTheFunds.Where(p => p.Id == model.AboutTheFund.Id).ToList();
            foreach (var  x in _context.Categories.ToList())
            {
                CategiryList.Add(x);
            }
            foreach (var x in _context.AboutTheFunds.ToList())
            {
                AboutTheFundList.Add(x);
            }
            ViewBag.Categories = CategiryList;
            ViewBag.AboutTheFunds = AboutTheFundList;
            return View(model);

        }
            
    }
     
}