using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Analise_Dados
{
    class Order_Details
    {
        public int Id { get; set; }
        public int Order_id { get; set; }
        public int Product_id { get; set; }
        public double Quantity { get; set; }
        public double Unit_price { get; set; }
        public double Discount { get; set; }
        public int Status_id { get; set; }
        public DateTime Date_allocated { get; set; }
        public int Purchase_order_id { get; set; }
        public int Inventory_id { get; set; }
        

    }
}
