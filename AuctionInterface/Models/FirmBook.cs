using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionInterface.Models
{
    public class FirmBook : Entity
    {
        public int AuctionId { get; set; }
        public Auction Auction { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
    }
}
