﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FunOlympic1;
using FunOlympic1.Data;
using Microsoft.AspNetCore.Authorization;

namespace FunOlympic1.Pages
{
    public class VideoPlayModel1 : PageModel
    {




        [BindProperty]
        public string VideoLink { get; set; }
        
       
        public async Task<IActionResult> OnGetAsync(string? id)
        {
           VideoLink = id;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
           

            return RedirectToPage("./Index");
        }


    }
}
