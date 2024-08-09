using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRANDEXCL.Model
{
    public class ProfitAndLossReport
    {
        public string invoiceno { get; set; }
        public string barcode { get; set; }
        public decimal priceexgst { get; set; }
        public decimal saleprice { get; set; }
        public DateTime date { get; set; }
        public decimal profitamount { get; set; }
        public decimal lossamount { get; set; }
    }
}
