using LearnApp.Models;
using LearnApp.Services;
using LearnApp.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnApp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CustomerService customerService;

        public CustomerController(CustomerService customerService)
        {
            this.customerService = customerService;
        }
        public ActionResult Index()
        {
            return View();
        }

        //Get
        public ActionResult Create()
        {
            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            this.customerService.Create(customer);
            return RedirectToAction(nameof(Read));
        }
        public ActionResult Read()
        {
            var customers = this.customerService.Get();
            return View(customers);
        }
        
        //Get
        public ActionResult Update()
        {
            var customer = this.customerService.Get();
            CategoryModel cm = new CategoryModel();
            cm.ListCategory = customer;
            cm.SelectedAns = string.Empty;
            return View(cm);
        }

        //Get
        public ActionResult PostUpdate(CategoryModel cm)
        {
            string id = cm.SelectedAns; 
            var customer = this.customerService.Get(id);
            Customer c = new Customer();
            c.getValue = customer;
            return View(c);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PostUpdate(string name, Customer customer)
        {
            if (name != customer.Name)
                return NotFound();
            //return View(id);
            if (ModelState.IsValid)
            {
                this.customerService.Update(name, customer);
                return RedirectToAction(nameof(Read));
            }

            return View(customer);
        }

        //Get
        public ActionResult Delete()
        {
            var customer = this.customerService.Get();
            CategoryModel cm = new CategoryModel();
            cm.ListCategory = customer;
            cm.SelectedAns = string.Empty;
            return View(cm);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(CategoryModel cm)
        {
            string name = cm.SelectedAns;
                this.customerService.Remove(name);
                return RedirectToAction(nameof(Read));
            
        }
    }
}
