using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TalentMine.ItemBankService.Models;

namespace TalentMine.ItemBankService.Services
{
    public interface IItemBankService
    {
        IEnumerable<ItemBank> GetItemBanks();
        ItemBank GetItemBankById(int id);
        void Create(ItemBank itemBank);
        void Update(ItemBank itemBank);
        void Delete(ItemBank itemBank);
        bool ItemBankExists(int id);
    }
}
