using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorScriptureJournal.Models;

namespace RazorScriptureJournal.Pages.Scriptures
{
    public class IndexModel : PageModel
    {
        private readonly RazorScriptureJournal.Models.RazorScriptureJournalContext _context;

        public IndexModel(RazorScriptureJournal.Models.RazorScriptureJournalContext context)
        {
            _context = context;
        }
        public IList<Scripture> Scripture { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public SelectList Books { get; set; }
        [BindProperty(SupportsGet = true)]
        public string ScriptureBooks { get; set; }
        public string OrderBy { get; set; }



        public async Task OnGetAsync()
        {
            // Use LINQ to get list of genres.
            IQueryable<string> BookQuery = from b in _context.Scripture
                                           orderby b.Book
                                           select b.Book;


            var scriptures = from s in _context.Scripture select s;

            if (!string.IsNullOrEmpty(SearchString))
            {
                scriptures = scriptures.Where(s => s.Notes.Contains(SearchString));

            }



            if (!string.IsNullOrEmpty(ScriptureBooks))
            {
                scriptures = scriptures.Where(s => s.Book == ScriptureBooks);

            }

            // Sort for book or date
            if (!string.IsNullOrEmpty(OrderBy))
            {
                switch (OrderBy)
                {

                    case "entryDate":
                        scriptures = scriptures.OrderBy(s => s.EntryDate);
                        break;
                    case "book":
                        scriptures = scriptures.OrderBy(s => s.Book);
                        break;

                }
            }



            Books = new SelectList(await BookQuery.Distinct().ToListAsync());
            Scripture = await scriptures.ToListAsync();
        }
    }
}
