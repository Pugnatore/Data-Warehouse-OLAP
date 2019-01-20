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
        public int Product_id { get; set; }
        public decimal Quantity { get; set; }
        public decimal Unit_price { get; set; }
        public int Id_Factos { get; set; }
        public string Type { get; set; }
        public DateTime Create_Date { get; set; }
       

    }
}
