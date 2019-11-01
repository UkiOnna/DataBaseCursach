using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionInterface.Models
{
    public class Auction:Entity
    {
        public string Name { get; set; }
        public string Adress { get; set; }
        public DateTimeOffset AuctionDate { get; set; }
        public string Specify { get; set; }
        public IEnumerable<Item> Items { get; set; }
    }
}
