using System;
using Utilitarios;

namespace Teste
{
    class Program
    {
        static void Main(string[] args)
        {
            Valida();
            String();            
            Criptografia();            
            Converte();
            Data();
            Console.ReadLine();            
        }

        static void Valida()
        {
            if (UtlValida.CPF(98765432100))
                Console.WriteLine("CPF Válido");
            else
                Console.WriteLine("CPF Inválido");

            if (UtlValida.CNPJ("00556819000130"))
                Console.WriteLine("CNPJ Válido");
            else
                Console.WriteLine("CNPJ Inválido");

            if (UtlValida.IsNumero("9"))
                Console.WriteLine("É Numero");
            else
                Console.WriteLine("Não é Numero");

            if (UtlValida.URL("https://www.google.com.br"))
                Console.WriteLine("URL válida");
            else
                Console.WriteLine("URL não válida");

            if (UtlValida.Email("teste@teste.com.br"))
                Console.WriteLine("Email válido");
            else
                Console.WriteLine("Email não válido");
        }
        
        static void String()
        {
            Console.WriteLine(UtlString.RemoveAcentos("Palavra sem acento: ÁôêíàúÕõ"));
            Console.WriteLine(UtlString.RemoveCaracteresEspeciais("Palavra sem caracteres especiais: Ábc-123*..a2;b3$$c4&D5%E6@f7"));
            Console.WriteLine("Palavra sem as letras: " + UtlString.RemoveLetras(" Ábc -123*..a2;b3$$c4&D5%E6@f7"));
            Console.WriteLine("Palavra sem os números: " + UtlString.RemoveNumeros(" Ábc -123*..a2;b3$$c4&D5%E6@f7"));
        }              

        static void Criptografia()
        {
            Console.WriteLine("Palavra criptografada: " + UtlCriptografia.Criptografa("Este é um texto de texte de criptografia"));
            Console.WriteLine("Palavra criptografada: " + UtlCriptografia.Descriptografa(UtlCriptografia.Criptografa("Este é um texto de texte de criptografia")));
        }        

        static void Converte()
        {
            Console.WriteLine("Converte bool string S: " + UtlConverte.RetornaBool("S"));
            Console.WriteLine("Converte bool string n: " + UtlConverte.RetornaBool("n"));
            Console.WriteLine("Converte bool string 1: " + UtlConverte.RetornaBool("1"));
            Console.WriteLine("Converte bool string false: " + UtlConverte.RetornaBool("false"));
            Console.WriteLine("Converte bool byte 0: " + UtlConverte.RetornaBool(0));
            Console.WriteLine("Converte bool char s: " + UtlConverte.RetornaBool('s'));
            try
            {
                Console.WriteLine("Converte bool string A: " + UtlConverte.RetornaBool("A"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            try
            {
                Console.WriteLine("Converte bool byte 5: " + UtlConverte.RetornaBool(5));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            try
            {
                Console.WriteLine("Converte bool char U: " + UtlConverte.RetornaBool('U'));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        static void Data()
        {
            Console.WriteLine("Dia da semana: 0 (byte) " + UtlData.DiaSemanaExtenso(0));
            Console.WriteLine("Dia da semana: 3 (string) " + UtlData.DiaSemanaExtenso("3"));
            Console.WriteLine("Dia da semana: 6 (char) " + UtlData.DiaSemanaExtenso('6'));
            try
            {
                Console.WriteLine("Dia da semana: 8 " + UtlData.DiaSemanaExtenso(8));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine("Mês: 1 (byte) " + UtlData.MesExtenso(1));
            Console.WriteLine("Mês: 3 (string) " + UtlData.MesExtenso("3"));
            Console.WriteLine("Mês: 6 (char) " + UtlData.MesExtenso('6'));
            try
            {
                Console.WriteLine("Mês: -3 " + UtlData.MesExtenso(-3));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
