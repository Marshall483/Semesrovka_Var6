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
        static readonly string _filePatch = @"C:\GitRepos\Semestrovka\polinom.txt"; // 5,5-5 2,1-6 7-2 3-5 1,96-5 3-4 2-3 1,7-1 1,56-1
        static readonly string __filePatch = @"C:\GitRepos\Semestrovka\polinom2.txt";  // 7-3 2-1 3-0

        static void Main()
        {
            IParser parser = new Parser();

            Polinom polinom = new Polinom(parser.GetMonomsWichPatch(_filePatch));
            Console.WriteLine("Полином 1: \n" + polinom);

            Polinom superPolinom = new Polinom(__filePatch, parser);
            Console.WriteLine("Полином 2: \n" + superPolinom);

            polinom.Combine();
            Console.WriteLine("Полином 1 после приведения подобных членов: \n" + polinom);

            superPolinom.Insert(3, 3);
            Console.WriteLine("Полином 2 после вставки монома вида 3X^3 : \n" + superPolinom);

            superPolinom.Combine();
            Console.WriteLine("Полином 2 после приведения подобных членов: \n" + superPolinom);

            Console.WriteLine("Возьмём производную у 2 полинома:");
            superPolinom.Derivate();
            Console.WriteLine("Полином 2: \n" + superPolinom);

            Console.WriteLine("Теперь вычислим его значение в точке х = 2 : \nP`n(2) = " + superPolinom.Value(2) );

            Console.WriteLine("Удалим нечетные элементы из 1 полинома :");
            polinom.DeleteOdd();
            Console.WriteLine("Полином 1: \n" + polinom);

            Console.WriteLine("Полином1 + Полином 2 = ");
            polinom.Sum(superPolinom);
            Console.WriteLine(polinom);

            Console.ReadKey();
        }
    }
}
