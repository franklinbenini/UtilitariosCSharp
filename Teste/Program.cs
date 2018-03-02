using System;
using Utilitarios;

namespace Teste
{
    class Program
    {
        static void Main(string[] args)
        {
            ValidaCPF();
            ValidaCNPJ();
            IsNumero();
            Console.ReadLine();            
        }

        static void ValidaCPF()
        {
            if (Valida.CPF(98765432100))
                Console.WriteLine("CPF Válido");
            else
                Console.WriteLine("CPF Inválido");
        }

        static void ValidaCNPJ()
        {            
            if (Valida.CNPJ("00556819000130"))
                Console.WriteLine("CNPJ Válido");
            else
                Console.WriteLine("CNPJ Inválido");
        }

        static void IsNumero()
        {
            if (Valida.IsNumero("9"))
                Console.WriteLine("É Numero");
            else
                Console.WriteLine("Não é Numero");
        }
    }
}
