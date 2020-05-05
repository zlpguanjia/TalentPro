using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;

namespace TalentMine.ItemBankService.Models
{
    /// <summary>
    /// Item Model
    /// </summary>
    public class ItemBank
    {
        /// <summary>
        /// Item ID primary key
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// ItemBank ID Foreiger Key
        /// </summary>
        public int ItemBankID { get; set; }
        /// <summary>
        /// Item Text
        /// </summary>
        public string Item { get; set; }
    }
}
