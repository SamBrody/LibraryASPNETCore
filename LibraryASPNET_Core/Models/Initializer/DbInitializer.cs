using System;
using System.Collections.Generic;
using LibraryASPNET_Core.Models;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryASPNET_Core.Models.Initializer
{
    public class DbInitializer
    {
        public static void Initialize(LibraryContext context)
        {
            context.Database.EnsureCreated();

            if (context.Books_.Any())
            {
                return;
            }

            var shelves = new Shelves[]
                {
                    new Shelves{Name="A"},
                    new Shelves{Name="B"},
                    new Shelves{Name="C"},
                    new Shelves{Name="D"}
                };
            foreach (Shelves s in shelves)
            {
                context.Shelves_.Add(s);
            }
            context.SaveChanges();
        }
    }
}
