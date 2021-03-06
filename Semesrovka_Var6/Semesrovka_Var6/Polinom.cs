﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semesrovka_Var6
{
    class Polinom
    {

        private List<Monom> _polinom;

        public Polinom(List<Monom> monoms) { _polinom = monoms; _polinom.Sort(SortByPower); } // создать по готовому списку

        public Polinom(string filePatch, IParser parser) { _polinom = parser.GetMonomsWichPatch(filePatch); _polinom.Sort(SortByPower); }// создать по патчу и парсеру  

        public void Insert(float coef, int deg)
        {
            _polinom.Add(new Monom(coef, deg));
            _polinom.Sort(SortByPower);
        }// Добавить моном в мн-н

        public void Combine() // приведение подобных членов в многочлене.
        {
            var groupBpPower = from monom in _polinom
                       group monom by monom.Power;

            float arg = 0f;
            foreach (IGrouping<int, Monom> monoms in groupBpPower)
            {
                if (monoms.Count<Monom>().Equals(1)) continue;

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

        public void Delete(int deg) // удалить элемент с данным показателем степени.
        {
            for (int i = 0; i < _polinom.Count; i++)
                if (_polinom[i].Power == deg) { _polinom.Remove(_polinom[i]); i--; };
        }

        public void Sum(Polinom p) //прибавить к нашему полиному полином p. Привести подобные члены.
        {
            _polinom.AddRange(p._polinom);
            Combine();
        }

        public void Derivate() // взять производную у полинома.
        {
            for (int i = 0; i < _polinom.Count; i++)
            {
                if(_polinom[i].Power.Equals(0)) { _polinom.Remove(_polinom[i]); continue; }
                _polinom[i].Value *= _polinom[i].Power;
                _polinom[i].Power--;
            }
        }

        public float Value(float x) // вычислить значение полинома в точке x, используя наиболее экономный способ (схема Горнера)
        {
            Combine();
            _polinom.Sort(SortByPower);          
            ToCanonicForm();

            if (x.Equals(0)) // за такую реализацию можно и убить...
                if (_polinom[_polinom.Count - 1].Power.Equals(0))
                    if (_polinom[_polinom.Count - 1].Value.Equals(0))
                        return 0;
                    else if (!_polinom[_polinom.Count - 1].Value.Equals(0))
                        return _polinom[_polinom.Count - 1].Value;

            float temp = _polinom[0].Value;
            
            for (int i = 1; i < _polinom.Count; ++i)
            {
                temp *= x;
                temp += _polinom[i].Value;
            }

            return temp;
        }

        public void DeleteOdd() // удалить из списка все элементы с нечетными коэффициентами
        {
            for (int i = 0; i < _polinom.Count; i++)
                if (_polinom[i].Value % 2 != 0)
                { 
                    _polinom.Remove(_polinom[i]);
                    i--;
                }
        }

        private int SortByPower(Monom x, Monom y)
        {
            if (x.Power > y.Power) return -1;
            else if (x.Power < y.Power) return 1;
            return 0;
        } // Служебный для Value(). Сортирует по степеням в убывающем порядке

        private void ToCanonicForm()
        {
            for (int i = 1, power = _polinom[0].Power - 1; 0 <= power && i < _polinom.Count; i++, power--)
                if (!_polinom[i].Power.Equals(power)) { Insert(0, power); _polinom.Sort(SortByPower); }

            if (_polinom[_polinom.Count - 1].Power.Equals(1)) Insert(0, 0); // если в полиноме степень при замыкающем коэф. 1, то вставить моном вида 0Х^0
        } // Служебный для Value(). Дополняет недостающие степени
    }
}
