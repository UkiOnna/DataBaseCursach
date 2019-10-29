using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionInterface.CustomModels
{
    public class CustomLot
    {
        public int Id { get; set; }
        public int LotNumber { get; set; }
        public int ItemId { get; set; }
        public string Item { get; set; }
    }
}
