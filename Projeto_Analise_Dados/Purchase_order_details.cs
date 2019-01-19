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
        public string Purchase_order_id { get; set; }
        public int Product_id { get; set; }
        public decimal Quantity { get; set; }
        public decimal Unit_cost { get; set; }
        public DateTime Create_Time { get; set; }
        public string Type { get; set; }


    }
}
