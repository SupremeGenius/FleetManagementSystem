﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FleetManagementWebApplication.Models;
using Microsoft.AspNetCore.Http;

namespace FleetManagementWebApplication.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private int Id;
        private string Name=" Account ";
        private int CompanyId;
        private string CompanyName=" Company ";
        private readonly NotificationManager NotificationManager;
        public  VehiclesController(ApplicationDbContext context)
        {
            _context = context;
            NotificationManager = new NotificationManager();
        }

        // GET: Vehicles
        public async Task<IActionResult> Index()
        {
            if (!isLogedIn())
                return RedirectToRoute("Home");
            Name = HttpContext.Session.GetString("Name");
            CompanyName = HttpContext.Session.GetString("CompanyName");
            CompanyId = (int)HttpContext.Session.GetInt32("CompanyId");
            ViewData["Name"] = Name;
            ViewData["CompanyName"] = CompanyName;     
            ViewData["type"] = HttpContext.Session.GetString("OrderType");
            ViewData["QueryPlaceHolder"] = "Vehicles";
            ViewData["Notifications"] =NotificationManager.GetNotifications(CompanyId,_context);
            return View(await _context.Vehicles.Where(v => v.Company.Id == CompanyId).ToListAsync());
   
        }

        public async Task<IActionResult> Search(string Query="")
        {
            if (!isLogedIn())
                return RedirectToRoute("Home");
            Name = HttpContext.Session.GetString("Name");
            CompanyId = (int)HttpContext.Session.GetInt32("CompanyId");
            CompanyName = HttpContext.Session.GetString("CompanyName");
            ViewData["Name"] = Name;
            ViewData["CompanyName"] = CompanyName;
            ViewData["type"] = HttpContext.Session.GetString("OrderType");
            ViewData["QueryPlaceHolder"] = "Vehicles";
            if (Query == null)
                return View("/Views/Vehicles/Index.cshtml",await _context.Vehicles.Where(v => v.Company.Id == CompanyId).ToListAsync());
            string[] query = Query.Split(" ");

            var infoQuery = (
                          from v in _context.Vehicles
                          where v.Company.Id == CompanyId && (v.Model == query[0] || v.Make == query[0] || v.LicensePlate == query[0])
                          select v);
            if (query.Length > 1)
                infoQuery = infoQuery.Intersect
                       (from v in _context.Vehicles
                        where v.Company.Id == CompanyId && (v.Model == query[1] || v.Make == query[1] || v.LicensePlate == query[1])
                        select v);
            if (query.Length > 2)
                infoQuery = infoQuery.Intersect
                       (from v in _context.Vehicles
                        where v.Company.Id == CompanyId && (v.Model == query[2] || v.Make == query[2] || v.LicensePlate == query[2])
                        select v);

                ViewData["Query"] = Query; 
            return View("/Views/Vehicles/Index.cshtml",infoQuery.ToList<Vehicle>());
        }

        [HttpPost]
        public async Task<IActionResult> Details(int id)
        {
            if (!isLogedIn())
                return RedirectToRoute("Home");
            Name = HttpContext.Session.GetString("Name");
            CompanyName = HttpContext.Session.GetString("CompanyName");
            CompanyId = (int)HttpContext.Session.GetInt32("CompanyId");
            ViewData["Notifications"] = NotificationManager.GetNotifications(CompanyId, _context);
            ViewData["Name"] = Name;
            ViewData["CompanyName"] = CompanyName;
            ViewData["QueryPlaceHolder"] = "Vehicles";

            if (id == 0)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // GET: Vehicles/Create
        public IActionResult Create()
        {
            if (!isLogedIn())
                return RedirectToRoute("Home");
            Name = HttpContext.Session.GetString("Name");
            CompanyName = HttpContext.Session.GetString("CompanyName");
            CompanyId = (int)HttpContext.Session.GetInt32("CompanyId");
            ViewData["Notifications"] = NotificationManager.GetNotifications(CompanyId, _context);
            ViewData["Name"] = Name;
            ViewData["CompanyName"] = CompanyName;
            ViewData["type"]= _context.Companies.FirstOrDefault(c => c.Id == CompanyId).OrderType;
            ViewData["QueryPlaceHolder"] = "Vehicles";
            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LicensePlate,Make,Model,purchaseDate,Odometer,PayLoad,EmissionsCO2,FuelConsumption,fuelType,FuelLevel,CurrentLoad")] Vehicle vehicle)
        {
            if (!isLogedIn())
                return RedirectToRoute("Home");
            Name = HttpContext.Session.GetString("Name");
            CompanyName = HttpContext.Session.GetString("CompanyName");
            CompanyId = (int)HttpContext.Session.GetInt32("CompanyId");
            ViewData["Notifications"] = NotificationManager.GetNotifications(CompanyId, _context);
            ViewData["Name"] = Name;
            ViewData["CompanyName"] = CompanyName;
            ViewData["type"] = HttpContext.Session.GetString("OrderType");
            ViewData["QueryPlaceHolder"] = "Vehicles";
            if (ModelState.IsValid)
            {
               
                vehicle.Company= _context.Companies.FirstOrDefault(c => c.Id == CompanyId);
                _context.Add(vehicle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehicle);
        }

   
        public async Task<IActionResult> GetEdit(long?  id)
        {
            if (!isLogedIn())
                return RedirectToRoute("Home");
            Name = HttpContext.Session.GetString("Name");
            CompanyName = HttpContext.Session.GetString("CompanyName");
            CompanyId = (int)HttpContext.Session.GetInt32("CompanyId");
            ViewData["Notifications"] = NotificationManager.GetNotifications(CompanyId, _context);
            ViewData["Name"] = Name;
            ViewData["CompanyName"] = CompanyName;
            ViewData["QueryPlaceHolder"] = "Vehicles";
            ViewData["type"] = _context.Companies.FirstOrDefault(c => c.Id == CompanyId).OrderType;
            if (id == null)
            {
                return NotFound();
            }
     
            var vehicle = await _context.Vehicles.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return View("/Views/Vehicles/Edit.cshtml",vehicle);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,LicensePlate,Make,Model,purchaseDate,Odometer,PayLoad,EmissionsCO2,FuelConsumption,fuelType,FuelLevel,CurrentLoad")] Vehicle vehicle)
        {
            if (!isLogedIn())
                return RedirectToRoute("Home");
            Name = HttpContext.Session.GetString("Name");
            CompanyName = HttpContext.Session.GetString("CompanyName");
            CompanyId = (int)HttpContext.Session.GetInt32("CompanyId");
            ViewData["Notifications"] = NotificationManager.GetNotifications(CompanyId, _context);
            ViewData["Name"] = Name;
            ViewData["CompanyName"] = CompanyName;
            ViewData["type"] = HttpContext.Session.GetString("OrderType");
            ViewData["QueryPlaceHolder"] = "Vehicles";

            if (id != vehicle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicle);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleExists(vehicle.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(vehicle);
        }

        public async Task<IActionResult> Delete(long? id)
        {
            if (!isLogedIn())
                return RedirectToRoute("Home");
            Name = HttpContext.Session.GetString("Name");
            CompanyName = HttpContext.Session.GetString("CompanyName");
            CompanyId =(int) HttpContext.Session.GetInt32("CompanyId");
            ViewData["Notifications"] = NotificationManager.GetNotifications(CompanyId, _context);
            ViewData["Name"] = Name;
            ViewData["CompanyName"] = CompanyName;
            ViewData["QueryPlaceHolder"] = "Vehicles";

            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (!isLogedIn())
                return RedirectToRoute("Home");
            Name = HttpContext.Session.GetString("Name");
            CompanyName = HttpContext.Session.GetString("CompanyName");
            CompanyId = (int)HttpContext.Session.GetInt32("CompanyId");
            ViewData["Notifications"] = NotificationManager.GetNotifications(CompanyId, _context);
            ViewData["Name"] = Name;
            ViewData["CompanyName"] = CompanyName;
            ViewData["QueryPlaceHolder"] = "Vehicles";
            var vehicle = await _context.Vehicles.FindAsync(id);
            _context.Vehicles.Remove(vehicle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleExists(long id)
        {
         
            return _context.Vehicles.Any(e => e.Id == id);
        }
        private bool isLogedIn()
        {
            if (HttpContext.Session.GetInt32("LoggedIn") == null)
                return false;
            else
                return true;

        }
    }
}
