using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TalentMine.ItemBankService.Models;

namespace TalentMine.ItemBankService.Context
{
    public class ItemBankInitializer
    {
        public static void Initialize(ItemBankContext context)
        {
            context.Database.EnsureCreated();

            if (context.ItemBanks.Any()) 
            {
                return;
            }

            var itembanks = new ItemBank[]
            {
                new ItemBank{ItemBankID=1,Item="Item 1 is the first one, please take the test."},
                new ItemBank{ItemBankID=2,Item="Item 2 is the first one, please take the test."},
                new ItemBank{ItemBankID=3,Item="Item 3 is the first one, please take the test."},
                new ItemBank{ItemBankID=4,Item="Item 4 is the first one, please take the test."},
                new ItemBank{ItemBankID=5,Item="Item 5 is the first one, please take the test."},

                new ItemBank{ItemBankID=6,Item="Item 6 is the first one, please take the test."},
                new ItemBank{ItemBankID=7,Item="Item 7 is the first one, please take the test."},
                new ItemBank{ItemBankID=8,Item="Item 8 is the first one, please take the test."},
                new ItemBank{ItemBankID=9,Item="Item 9 is the first one, please take the test."},
                new ItemBank{ItemBankID=10,Item="Item 10 is the first one, please take the test."}

            };
            foreach(var item in itembanks)
            {
                context.ItemBanks.Add(item);
            }
            context.SaveChanges();
        }
    }
}
