using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopMVC.Data;
using ShopMVC.Models;

namespace ShopMVC.Controllers
{
    public class SliderImagesController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ShopMVCContext _context;

        public SliderImagesController(IWebHostEnvironment webHostEnvironment,ShopMVCContext context)
        {
            _webHostEnvironment = webHostEnvironment;
            _context = context;
        }

        // GET: SliderImages
        public async Task<IActionResult> Index()
        {
              return _context.SliderImage != null ? 
                          View(await _context.SliderImage.ToListAsync()) :
                          Problem("Entity set 'ShopMVCContext.SliderImage'  is null.");
        }

        // GET: SliderImages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SliderImage == null)
            {
                return NotFound();
            }

            var sliderImage = await _context.SliderImage
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sliderImage == null)
            {
                return NotFound();
            }

            return View(sliderImage);
        }

        // GET: SliderImages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SliderImages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FileName,Caption")] SliderImage sliderImage, [FromForm(Name = "imageFile")] IFormFile imageFile)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "image", "slider");
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(fileStream);
                }

                sliderImage.FileName = uniqueFileName;
                _context.Add(sliderImage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sliderImage);
        }

        // GET: SliderImages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SliderImage == null)
            {
                return NotFound();
            }

            var sliderImage = await _context.SliderImage.FindAsync(id);
            if (sliderImage == null)
            {
                return NotFound();
            }
            return View(sliderImage);
        }

        // POST: SliderImages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FileName,Caption")] SliderImage sliderImage)
        {
            if (id != sliderImage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sliderImage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SliderImageExists(sliderImage.Id))
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
            return View(sliderImage);
        }

        // GET: SliderImages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SliderImage == null)
            {
                return NotFound();
            }

            var sliderImage = await _context.SliderImage
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sliderImage == null)
            {
                return NotFound();
            }

            return View(sliderImage);
        }

        // POST: SliderImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SliderImage == null)
            {
                return Problem("Entity set 'ShopMVCContext.SliderImage'  is null.");
            }
            var sliderImage = await _context.SliderImage.FindAsync(id);
            if (sliderImage != null)
            {
                _context.SliderImage.Remove(sliderImage);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SliderImageExists(int id)
        {
          return (_context.SliderImage?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
