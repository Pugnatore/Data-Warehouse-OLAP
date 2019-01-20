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
        public int Status_id { get; set; }
        public int Id_remetente { get; set; }
        public string Payment_type { get; set; }
        public DateTime Order_date { get; set; }
        public DateTime Paid_date { get; set; }
        public DateTime Shipped_date { get; set; }
        public DateTime Created_Time { get; set; }
        public string Type { get; set; }
        




    }
}
