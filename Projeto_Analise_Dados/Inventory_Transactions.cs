using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Analise_Dados
{
    class Inventory_Transactions
    {

        public int Id { get; set; }
        public int Transaction_type { get; set; }
        public DateTime Transaction_created_date { get; set; }
        public DateTime Transaction_modified_date { get; set; }
        public int Product_id { get; set; }
        public int Quantity { get; set; }
        public int Purchase_order_id { get; set; }
        public int Customer_order_id { get; set; }
        public string Comments { get; set; }
   
    }
}
