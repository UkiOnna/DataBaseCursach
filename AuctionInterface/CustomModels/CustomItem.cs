using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionInterface.CustomModels
{
    public class CustomItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StartPrice { get; set; }
        public int? EndPrice { get; set; }
        public string Description { get; set; }
        public int SellerId { get; set; }
        public string Seller { get; set; }
        public int? BuyerId { get; set; }
        public int? AuctionId { get; set; }
        public string Auction { get; set; }
        public string Buyer { get; set; }
        public int LotNumber { get; set; }
    }
}
