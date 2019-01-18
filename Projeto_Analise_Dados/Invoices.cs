using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Analise_Dados
{
    class Invoices
    {
        public int Id { get; set; }
        public int Order_id { get; set; }
        public DateTime Invoice_date { get; set; }
        public int Due_date { get; set; }
        public double Tax { get; set; }
        public double Shipping { get; set; }
        public double Amount_due { get; set; }
        
    }
}
