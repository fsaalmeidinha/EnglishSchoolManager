using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonsAPI.Serialize;

namespace EnglishSchoolManagerModel
{
    public partial class Aula
    {
        public Aula()
        {
            IdsAlunos = new List<int>();
        }

        public List<HorarioAula> GetHorariosAula()
        {
            return GetHorariosAula(this.HorariosJson);
        }

        public void SetHorariosAula(List<HorarioAula> horariosAula)
        {
            if (horariosAula == null)
            {
                this.HorariosJson = String.Empty;
            }
            else
            {
                this.HorariosJson = JavaScriptSerializerHelper.Serialize(horariosAula);
            }
        }

        public static List<HorarioAula> GetHorariosAula(string horariosJson)
        {
            if (String.IsNullOrEmpty(horariosJson))
            {
                return new List<HorarioAula>();
            }
            else
            {
                return JavaScriptSerializerHelper.Deserialize<List<HorarioAula>>(horariosJson);
            }
        }

        public string DescricaoHorariosAula
        {
            get
            {
                List<HorarioAula> horariosAula = GetHorariosAula(this.HorariosJson);
                return String.Join("\r\n", horariosAula.Select(horarioAula => horarioAula.DescricaoHorarioAula));
            }
            set { }
        }

        public List<int> IdsAlunos { get; set; }
    }
}
