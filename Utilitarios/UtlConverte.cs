using System;
using System.Collections.Generic;
using System.Text;

namespace Utilitarios
{
    /// <summary>
    /// Classe utilitária para trabalhar com conversões
    /// </summary>
    public static class UtlConverte
    {
        /// <summary>
        /// Converte um valor "S" e "N", ou "1" e "0", ou "true" e "false" (string) para true ou false (bool)
        /// </summary>
        /// <param name="valor">string com valor booleano</param>
        /// <returns>true se "S" ou "1" e false se "N" ou "0"</returns>
        public static bool RetornaBool(string valor)
        {            
            string aux = valor.Trim().ToUpper();
            if (!aux.Equals("S") && !aux.Equals("N") && !aux.Equals("0") && !aux.Equals("1") && !aux.Equals("TRUE") && !aux.Equals("FALSE"))
                throw new Exception("O valor não é um booleano válido. Valor passado como parâmetro foi: " + valor);

            return aux.Equals("S") || aux.Equals("1") || aux.Equals("TRUE");
        }

        /// <summary>
        /// Converte um valor 'S' e 'N', ou '1' e '0' para true ou false
        /// </summary>
        /// <param name="valor">char com valor booleano</param>
        /// <returns>true se 'S' ou '1' e false se 'N' ou '0'</returns>
        public static bool RetornaBool(char valor)
        {
            return RetornaBool(valor.ToString());
        }

        /// <summary>
        /// Converte um valor 1 ou 0 para true ou false
        /// </summary>
        /// <param name="valor">byte com valor 0 ou 1</param>
        /// <returns>true se 1, false se 0</returns>
        public static bool RetornaBool(byte valor)
        {
            return RetornaBool(valor.ToString());            
        }
    }
}
