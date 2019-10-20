using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionInterface.Models
{
    public class Lot:Entity
    {
        public int LotNumber { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
    }
}
