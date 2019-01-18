using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Analise_Dados
{
    class Orders
    {
        public int Id { get; set; }
        public int Employee_id { get; set; }
        public int Customer_id { get; set; }
        public int Shipper_id { get; set; }
        public int Tax_status_id { get; set; }
        public int Status_id { get; set; }
        public string Ship_name { get; set; }
        public string Ship_address { get; set; }
        public string Ship_city { get; set; }
        public string Ship_state_province { get; set; }
        public string Ship_zip_postal_code { get; set; }
        public string Ship_country_region { get; set; }
        public string Notes { get; set; }
        public string Payment_type { get; set; }
        public double Shipping_fee { get; set; }
        public double Tax_rate { get; set; }
        public DateTime Order_date { get; set; }
        public DateTime Paid_date { get; set; }
        public DateTime Shipped_date { get; set; }
        public double Taxes { get; set; }
        




    }
}
