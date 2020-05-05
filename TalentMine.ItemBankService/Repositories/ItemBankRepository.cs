using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;
using TalentMine.ItemBankService.Context;
using TalentMine.ItemBankService.Models;

namespace TalentMine.ItemBankService.Repositories
{
    public class ItemBankRepository: IItemBankRepository
    {
        public ItemBankContext itembankcontext;

        public ItemBankRepository(ItemBankContext itembankcontext)
        {
            this.itembankcontext = itembankcontext;
        }

        public void Create(ItemBank itemBank)
        {
            itembankcontext.ItemBanks.Add(itemBank);
            itembankcontext.SaveChanges();
        }

        public void Delete(ItemBank itemBank)
        {
            itembankcontext.ItemBanks.Remove(itemBank);
            itembankcontext.SaveChanges();
        }

        public ItemBank GetItemBankById(int id)
        {
            return itembankcontext.ItemBanks.Find(id);
        }

        public IEnumerable<ItemBank> GetItemBanks()
        {
            return itembankcontext.ItemBanks.ToList();
        }

        public void Update(ItemBank itemBank)
        {
            itembankcontext.ItemBanks.Update(itemBank);
            itembankcontext.SaveChanges();
        }

        public bool ItemBankExists(int id)
        {
            return itembankcontext.ItemBanks.Any(e => e.ItemBankID.Equals(id));
        }
    }
}
