using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exceptionless;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TalentMine.ItemBankService.Models;
using TalentMine.ItemBankService.Services;

namespace TalentMine.ItemBankService.Controllers
{
    [Route("ItemBank")]
    [ApiController]
    public class ItemBankController : ControllerBase
    {
        private readonly IItemBankService itemBankService;
        private readonly IConfiguration configuration;

        public ItemBankController(IItemBankService itemBankService, IConfiguration configuration)
        {
            this.itemBankService = itemBankService;
            this.configuration = configuration;
        }

        // GET: api/ItemBanks
        [HttpGet]
        public ActionResult<IEnumerable<ItemBank>> GetItemBanks()
        {
            try
            {
                //return itemBankService.GetItemBanks().ToList();
                return itemBankService.GetItemBanks().Select(i => new ItemBank()
                {
                    Id = i.Id,
                    ItemBankID = i.ItemBankID,
                    Item = $"{configuration["ip"]}:{configuration["port"]} {i.Item}" //i.Item
                }).ToList();
            }
            catch (Exception ex)
            {
                ex.ToExceptionless().Submit();
            }
            return BadRequest();
        }

        // GET: api/ItemBanks/5
        [HttpGet("{id}")]
        public ActionResult<ItemBank> GetItemBank(int id)
        {
            try
            {
                var itemBank = itemBankService.GetItemBankById(id);

                if (itemBank == null)
                {
                    return NotFound();
                }

                return itemBank;
            }
            catch (Exception ex)
            {
                ex.ToExceptionless().Submit();
            }
            return BadRequest();
            
        }

        // PUT: api/ItemBanks/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutItemBank(int id, ItemBank itemBank)
        {
            if (id != itemBank.ItemBankID)
            {
                return BadRequest();
            }

            try
            {
                itemBankService.Update(itemBank);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!itemBankService.ItemBankExists(id))
                {
                    return NotFound();
                }
                else
                {
                    ex.ToExceptionless()
                        .AddObject(itemBank,"itembank", excludedPropertyNames: new []{"ItemBankID"}, maxDepth:2)
                        .Submit();
                }
            }

            return NoContent();
        }

        // POST: api/ItemBanks
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<ItemBank> PostItemBank(ItemBank itemBank)
        {
            
            try
            {
                itemBankService.Create(itemBank);

                return CreatedAtAction("GetItemBank", new { id = itemBank.ItemBankID }, itemBank);
            }
            catch (Exception ex)
            {
                ex.ToExceptionless().Submit();
            }
            return BadRequest();
        }

        // DELETE: api/ItemBanks/5
        [HttpDelete("{id}")]
        public ActionResult<ItemBank> DeleteItemBank(int id)
        {
            try
            {
                var itemBank = itemBankService.GetItemBankById(id);
                if (itemBank == null)
                {
                    return NotFound();
                }

                itemBankService.Delete(itemBank);
                return itemBank;
            }
            catch (Exception ex)
            {
                ex.ToExceptionless().Submit();
            }
            return BadRequest();
        }
    }
}
