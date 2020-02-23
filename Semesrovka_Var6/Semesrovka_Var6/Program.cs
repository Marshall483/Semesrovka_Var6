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
 
    class Program // 5,5-5 2,1-6 7-2 3-5 1,96-5 3-4 2-3 1,7-1 1,56-1 1-0
    {
        static string _filePatch = @"C:\GitRepos\Semestrovka\polinom.txt";
        static void Main(string[] args)
        {
            Polinom polinom = new Polinom(Parser.GetMonoms(_filePatch));


            Console.WriteLine(polinom);
            Console.WriteLine(polinom.Value(2));
            Console.WriteLine(polinom);

            Console.ReadKey();
        }
    }
}
