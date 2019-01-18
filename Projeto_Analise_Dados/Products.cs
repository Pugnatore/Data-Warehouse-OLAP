using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Analise_Dados
{
    class Products
    {
        public string Supplier_ids { get; set; }
        public int Id { get; set; }
        public string Product_code { get; set; }
        public string Product_name { get; set; }
        public string Description { get; set; }
        public double Standard_cost { get; set; }
        public double List_price { get; set; }
        public int Reorder_level { get; set; }
        public int Target_level  { get; set; }
        public string Quantity_per_unit { get; set; }
        public int Discontinued { get; set; }
        public int Minimum_reorder_quantity { get; set; }
        public string Category { get; set; }
        public string Attachments { get; set; }
        



    }
}
