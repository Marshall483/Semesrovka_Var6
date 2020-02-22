using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semesrovka_Var6
{
    class Polinom
    {

        private List<Monom> _polinom;

        public Polinom(List<Monom> monoms) => _polinom = monoms;

        public void Insert(float coef, int deg) // Добавить моном в мн-н
        {
            _polinom.Add(new Monom(coef, deg));
        }

        public void Combine() // приведение подобных членов в многочлене.
        {
            var linq = from monom in _polinom
                       group monom by monom.Power;

            float arg = 0f;
            foreach (IGrouping<int, Monom> monoms in linq)
            { 
                foreach (Monom monom in monoms)
                {
                    arg += monom.Value;
                }
                Delete(monoms.Key);
                Insert(arg, monoms.Key);
                arg = 0f;
            }
        }
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();

            foreach (var monom in _polinom)
                str.Append($"{monom.Value}X^{monom.Power} + ");

            str.Length -= 3;

            return str.ToString();
        }

        void Delete(int deg) // удалить элемент с данным показателем степени.
        {
            for (int i = 0; i < _polinom.Count - 1; i++)
                if (_polinom[i].Power == deg) { _polinom.Remove(_polinom[i]); i--; };
        }

        void sum(Polinom p) //прибавить к нашему полиному полином p. Привести подобные члены.
        {

        }

        void derivate() // взять производную у полинома.
        {

        }

        int value(int x) // вычислить значение полинома в точке x, используя наиболее экономный способ (схема Горнера)
        {
            throw new NotImplementedException();
        }

        void deleteOdd() // удалить из списка все элементы с нечетными коэффициентами
        {

        }
    }
}
