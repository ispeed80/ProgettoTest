using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoTest
{
    public class Esame
    {
        public string CodiceMinisteriale { get; set; }
        public string CodiceInterno { get; set; }
        public string DescrizioneEsame { get; set; }
        public string Ambulatorio { get; set; }
        public string ParteCorpo { get; set; }

        public override string ToString()
        {
            return DescrizioneEsame; // serve per far apparire il nome nell'elenco ListBox
        }
    }
}
