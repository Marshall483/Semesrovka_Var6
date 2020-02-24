using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Semesrovka_Var6
{
    interface IParser
    {
        List<Monom> GetMonoms(string filePatch);
    }
    public class Parser : IParser
    {
        public List<Monom> GetMonoms(string filePatch)
        {
            if (!File.Exists(filePatch))
                throw new FormatException("Incorrect file patch");


            List<Monom> temp = new List<Monom>();

            using (TextReader tr = File.OpenText(filePatch))
            {
               var monoms = from val in tr.ReadToEnd().Split(' ')
                            where !val.Equals(null)
                            let _val = val.Split('-')
                            select new Monom(float.Parse(_val[0]), int.Parse(_val[1]));

                    temp.AddRange(monoms);
            }

            return temp;

        }
    }
}
