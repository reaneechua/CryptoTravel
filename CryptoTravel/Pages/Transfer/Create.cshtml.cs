using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CryptoTravel.Data;
using CryptoTravel.Models;

namespace CryptoTravel.Pages.Transfer
{
    public class CreateModel : PageModel
    {
        private readonly CryptoTravel.Data.CryptoTravelContext _context;

        public CreateModel(CryptoTravel.Data.CryptoTravelContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ConversionRate ConversionRate { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ConversionRate.Add(ConversionRate);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
