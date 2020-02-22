using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Semesrovka_Var6
{
    public static class Parser
    {
        public static List<Monom> GetMonoms(string filePatch)
        {
            if (!File.Exists(filePatch))
                throw new FormatException("Incorrect file patch");


            IEnumerable<Monom> monoms;
            List<Monom> temp = new List<Monom>();

            using (TextReader tr = File.OpenText(filePatch))
            {
                monoms = from val in tr.ReadToEnd().Split(' ')
                                          let _val = val.Split('-')
                                          select new Monom(float.Parse(_val[0]), int.Parse(_val[1]));
            }

            foreach (Monom monom in monoms)
                temp.Add(monom);

            return temp;

        }
    }
}
