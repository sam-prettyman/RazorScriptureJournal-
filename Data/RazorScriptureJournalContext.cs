using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RazorScriptureJournal.Models
{
    public class RazorScriptureJournalContext : DbContext
    {
        public RazorScriptureJournalContext (DbContextOptions<RazorScriptureJournalContext> options)
            : base(options)
        {
        }

        public DbSet<RazorScriptureJournal.Models.Scripture> Scripture { get; set; }
    }
}
