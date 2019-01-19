using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Analise_Dados
{
    class Fatura
    {
        public int Id_Fatura{ get; set; }
        public int Id_Order { get; set; }
        public DateTime Created_Time { get; set; }
        public string Type { get; set; }
    }
}
