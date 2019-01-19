using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Analise_Dados
{
    class Inventory
    {
        public int Id { get; set; }
        public int Product_id { get; set; }
        public decimal Quantity { get; set; }
        public string Type { get; set; }
        public DateTime Create_Date { get; set; }
    }
}
