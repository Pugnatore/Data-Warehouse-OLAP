using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Analise_Dados
{
    class Purchase_Orders
    {
        public int Id { get; set; }
        public int Supplier_id { get; set; }
        public DateTime Created_by { get; set; }
        public DateTime submitted_date { get; set; }
        public DateTime creation_date { get; set; }
        public int Status_id { get; set; }
        public DateTime Expected_date { get; set; }
        public double Shipping_fee { get; set; }
        public double Taxes { get; set; }
        public DateTime Payment_date { get; set; }
        public double Payment_amount { get; set; }
        public string Payment_method { get; set; }
        public string Notes { get; set; }
        public int Approved_by { get; set; }
        public DateTime Approved_date { get; set; }
        public int Submitted_by { get; set; }




    }
}
