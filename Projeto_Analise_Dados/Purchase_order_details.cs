using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Analise_Dados
{
    class Purchase_order_details
    {

        public int Id { get; set; }
        public int Purchase_order_id { get; set; }
        public int Product_id { get; set; }
        public double Quantity { get; set; }
        public double Unit_cost { get; set; }
        public DateTime Date_received { get; set; }
        public int Posted_to_inventory { get; set; }
        public int Inventory_id { get; set; }
   
        
    }
}
