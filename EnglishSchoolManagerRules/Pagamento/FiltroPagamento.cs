using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishSchoolManagerRules.Pagamento
{
    public class FiltroPagamento
    {
        public DateTime DataInicialVencimento { get; set; }
        public DateTime DataFinalVencimento { get; set; }
        public bool? StatusPagamentoEfetuado { get; set; }
    }
}
