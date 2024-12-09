using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
  delegate double OperationDelegate(double x, double y);
  static void Main(string[] args)
  {
    OperationDelegate addition = (x, y) => x + y;
    OperationDelegate subtraction = (x, y) => x - y;
    OperationDelegate multiplication = (x, y) => x * y;
    OperationDelegate division = (x, y) => y != 0 ? x / y : throw new DivideByZeroException("Impossible!");

    Console.WriteLine("Choose an operation: ");
    foreach (var op in Enum.GetValues(typeof(Operation)))
    {
      Console.WriteLine($"{(int)op} - {op}");
    }

    int choice;
    Console.WriteLine("Your choice: ");
    choice = int.Parse(Console.ReadLine());


    Console.WriteLine("Enter your first number: ");
    double n1 = double.Parse(Console.ReadLine());

    Console.WriteLine("Enter your second number: ");
    double n2 = double.Parse(Console.ReadLine());

    double resultat = 0;

    try
    {
      switch ((Operation)choice)
      {
        case Operation.Addition:
          resultat = addition(n1, n2);
          break;
        case Operation.Subtraction:
          resultat = subtraction(n1, n2);
          break;
        case Operation.Multiplication:
          resultat = multiplication(n1, n2);
          break;
        case Operation.Division:
          resultat = division(n1, n2);
          break;
        default:
          Console.WriteLine("Choix invalide.");
          return;
      }
      Console.WriteLine($"Le résultat de l'opération est : {resultat}");
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Erreur : {ex.Message}");
    }
  }
}

enum Operation
{
  Addition,
  Subtraction,
  Multiplication,
  Division,
}
