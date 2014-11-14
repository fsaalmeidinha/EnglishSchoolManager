using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnglishSchoolManagerModel.Geral;

namespace EnglishSchoolManagerRules.Geral
{
    public interface IRN<Entidade>
    {
        Resultado Salvar(Entidade entidade);

        List<Entidade> Listar();
    }
}
