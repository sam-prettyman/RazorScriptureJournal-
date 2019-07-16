using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
namespace RazorScriptureJournal.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorScriptureJournalContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RazorScriptureJournalContext>>()))
            {
                // Look for any movies.
                if (context.Scripture.Any())
                {
                    return;   // DB has been seeded
                }

                context.Scripture.AddRange(
                    new Scripture
                    {
                        Collection = "New Testament",
                        Book = "Matthew",
                        Chapter = 7,
                        Verse = 7,
                        Notes = "Knock and it will open"
                    },
                    new Scripture
                    {
                        Collection = "Book of Mormon",
                        Book = "Mornoni",
                        Chapter = 10,
                        Verse = 2,
                        Notes = "WOW, I CAN ADD NOTES"
                    },
                         new Scripture
                         {
                             Collection = "Old Testament",
                             Book = "Mark",
                             Chapter = 10,
                             Verse = 12,
                             Notes = "I like this verse"
                         }
                );
                context.SaveChanges();
            }
        }
    }
}