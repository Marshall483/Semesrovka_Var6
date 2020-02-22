using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semesrovka_Var6
{
    
  /* Класс Polinom - полином от одной переменной с целочисленными коэффициентами.
     Представить в виде списка, каждый элемент которого содержит пару "коэффициент-степень"
    
    Реализовать следующие методы:
    Polinom(String filename) : построение списка по полиному, заданному парами
    коэффициент-степень в текством файле filename.

  String toString(): возврат строкового представления полинома

  void insert(int coef, int deg) - вставка монома coef* x^deg в полином.
  void combine(): приведение подобных членов в многочлене.

  void delete(int deg) - удалить элемент с данным показателем степени.
  void sum(Polinom p): прибавить к нашему полиному полином p. Привести подобные члены.

  void derivate(): взять производную у полинома.
  int value(int x): вычислить значение полинома в точке x, используя наиболее экономный способ (схема Горнера)

  void deleteOdd(): удалить из списка все элементы с нечетными коэффициентами */
 
    class Program
    {
        static string _filePatch = @"C:\GitRepos\Semestrovka\polinom.txt";
        static void Main(string[] args)
        {
            List<Monom> monoms = Parser.GetMonoms(_filePatch);

            Console.ReadKey();
        }
    }
}
