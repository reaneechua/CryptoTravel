using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CryptoTravel.Data;
using CryptoTravel.Models;

namespace CryptoTravel.Pages.Transfer
{
    public class EditModel : PageModel
    {
        private readonly CryptoTravel.Data.CryptoTravelContext _context;

        public EditModel(CryptoTravel.Data.CryptoTravelContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ConversionRate ConversionRate { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conversionrate =  await _context.ConversionRate.FirstOrDefaultAsync(m => m.Id == id);
            if (conversionrate == null)
            {
                return NotFound();
            }
            ConversionRate = conversionrate;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ConversionRate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConversionRateExists(ConversionRate.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ConversionRateExists(int id)
        {
            return _context.ConversionRate.Any(e => e.Id == id);
        }
    }
}
