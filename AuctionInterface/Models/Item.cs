using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionInterface.Models
{
    public class Item : Entity
    {
        public string Name { get; set; }
        public int StartPrice { get; set; }
        public int EndPrice { get; set; }
        public string Description { get; set; }
        public int SellerId { get; set; }
        public Person Seller { get; set; }
        public int? BuyerId { get; set; }
        public Person Buyer { get; set; }
    }
}
