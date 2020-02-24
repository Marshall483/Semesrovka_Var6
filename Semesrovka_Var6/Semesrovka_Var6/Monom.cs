using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semesrovka_Var6
{
    public class Monom
    {
        public float Value { get; set; }

        public int Power { get; set; }

        public Monom(float val, int power)
        {
            Value = val;
            Power = power;
        }

        public override bool Equals(object obj)
        {
            Monom mon = obj as Monom;

            if (mon.Power.Equals(Power) && mon.Value.Equals(Value))
                return true;
            return false;
        }
    }
}
