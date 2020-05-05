using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TalentMine.ItemBankService.Models;
using TalentMine.ItemBankService.Repositories;

namespace TalentMine.ItemBankService.Services
{
    public class ItemBankServiceImpl : IItemBankService
    {
        public readonly IItemBankRepository itemBankRepository;
        public ItemBankServiceImpl(IItemBankRepository itemBankRepository)
        {
            this.itemBankRepository = itemBankRepository;
        }

        public ItemBank GetItemBankById(int id)
        {
            return itemBankRepository.GetItemBankById(id);
        }

        public IEnumerable<ItemBank> GetItemBanks()
        {
            return itemBankRepository.GetItemBanks();
        }

        public void Create(ItemBank itemBank)
        {
            itemBankRepository.Create(itemBank);
        }

        public void Update(ItemBank itemBank)
        {
            itemBankRepository.Update(itemBank);
        }

        public void Delete(ItemBank itemBank)
        {
            itemBankRepository.Delete(itemBank);
        }

        public bool ItemBankExists(int id)
        {
            return itemBankRepository.ItemBankExists(id);
        }
    }
}
