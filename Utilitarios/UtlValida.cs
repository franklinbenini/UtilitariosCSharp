using System;
using System.Text.RegularExpressions;

namespace Utilitarios
{
    /// <summary>
    /// Classe utilitária com métodos para efetuar validações
    /// </summary>
    public static class UtlValida
    {
        /// <summary>
        /// Verifica se um digito informado é um numero
        /// </summary>
        /// <param name="numero">string com um caracter para verificar se é um numero</param>
        /// <returns>Boolean True/False</returns>
        public static bool IsNumero(string numero)
        {
            int n;
            return Int32.TryParse(numero, out n);
        }

        /// <summary>
        /// Informar um CPF completo para validação do digito verificador
        /// </summary>
        /// <param name="cpf">Int64 com o numero CPF completo com Digito</param>
        /// <returns>Boolean True/False onde True=Digito CPF Valido</returns>
        public static bool CPF(Int64 cpf)
        {
            return CPF(cpf.ToString("D11"));
        }
    
        /// <summary>
        /// Informar um CPF completo para validação do digito verificador
        /// </summary>
        /// <param name="cpf">string com o numero CPF completo com Digito</param>
        /// <returns>Boolean True/False onde True=Digito CPF Valido</returns>
        public static bool CPF(string cpf)
        {
            if (string.IsNullOrEmpty(cpf.Trim()))
                return false;
            
            if (!Regex.IsMatch(cpf, @"^[0-9]+$"))
                return false;

            string new_cpf = "";
            for (int i = 0; i < cpf.Length; i++)
            {
                if (IsNumero(cpf.Substring(i, 1)))
                {
                    new_cpf += cpf.Substring(i, 1);
                }
            }                
            new_cpf = Convert.ToInt64(new_cpf).ToString("D11");
            if (new_cpf.Length > 11)
            {
                return false;
            }

            if (cpf == "00000000000" || cpf == "11111111111" || cpf == "22222222222" || cpf == "33333333333" || 
                cpf == "44444444444" || cpf == "55555555555" || cpf == "66666666666" || cpf == "77777777777" || 
                cpf == "88888888888" || cpf == "99999999999" || cpf == "01234567890" || cpf == "98765432100")
            {
                return false;
            }

            if (CalculaDigCPF(new_cpf.Substring(0, 9)) == new_cpf.Substring(9, 2))
            {
                return true;
            }
    
            return false;
        }
            
        /// <summary>
        /// Informar um CNPJ completo para validação do digito verificador
        /// </summary>
        /// <param name="cnpj">Int64 com o numero CNPJ completo com Digito</param>
        /// <returns>Boolean True/False onde True=Digito CNPJ Valido</returns>
        public static bool CNPJ(Int64 cnpj)
        {
            return CNPJ(cnpj.ToString("D14"));
        }

        /// <summary>
        /// Informar um CNPJ completo para validação do digito verificador
        /// </summary>
        /// <param name="cnpj">string com o numero CNPJ completo com Digito</param>
        /// <returns>Boolean True/False onde True=Digito CNPJ Valido</returns>
        public static bool CNPJ(string cnpj)
        {
            if (string.IsNullOrEmpty(cnpj))
                return false;
            
            if (!Regex.IsMatch(cnpj, @"^[0-9]+$"))
                return false;

            string new_cnpj = "";                        
            for (int i = 0; i < cnpj.Length; i++)
            {
                if (IsNumero(cnpj.Substring(i, 1)))
                {
                    new_cnpj += cnpj.Substring(i, 1);
                }
            }            
            new_cnpj = Convert.ToInt64(new_cnpj).ToString("D14");            
            if (new_cnpj.Length > 14)
            {
                return false;
            }

            if (cnpj == "00000000000000" || cnpj == "11111111111111" || cnpj == "22222222222222" || cnpj == "33333333333333" ||
                cnpj == "44444444444444" || cnpj == "55555555555555" || cnpj == "66666666666666" || cnpj == "77777777777777" ||
                cnpj == "88888888888888" || cnpj == "99999999999999")
            {
                return false;
            }

            if (CalculaDigCNPJ(new_cnpj.Substring(0, 12)) == new_cnpj.Substring(12, 2))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Verifica se é uma URL válida
        /// </summary>
        /// <param name="url">string com url a ser validada</param>
        /// <returns>true se for válido, false do contrário</returns>
        public static bool URL(string url)
        {            
            var match = Regex.Match(url, @"^((http|https)://)?([\w-]+\.)+[\w]+(/[\w- ./?]*)?$", RegexOptions.IgnoreCase);
            return match.Success;            
        }

        /// <summary>
        /// Verifica se é um e-mail Válido
        /// </summary>
        /// <param name="email">string com e-mail a ser verificado</param>
        /// <returns>true se for válido, false caso contrário</returns>
        public static bool Email(string email)
        {   
            Regex regExpEmail = new Regex("^[A-Za-z0-9](([_.-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([.-]?[a-zA-Z0-9]+)*)([.][A-Za-z]{2,4})$");
            Match match = regExpEmail.Match(email);

            if (match.Success)
                return true;
            else
                return false;            
        }

        /// <summary>
        /// Calcula o Digito verificador de um CPF informado  
        /// </summary>
        /// <param name="cpf">int64 com o CPF contendo 9 digitos e sem o digito verificador</param>
        /// <returns>string com o digito calculado do CPF ou null caso o cpf informado for maior que 9 digitos</returns>
        private static string CalculaDigCPF(Int64 cpf)
        {
            return CalculaDigCPF(cpf.ToString("D9"));
        }

        /// <summary>
        /// Calcula o Digito verificador de um CPF informado  
        /// </summary>
        /// <param name="cpf">string com o CPF contendo 9 digitos e sem o digito verificador</param>
        /// <returns>string com o digito calculado do CPF ou null caso o cpf informado for maior que 9 digitos</returns>
        private static string CalculaDigCPF(string cpf)
        {
            string new_cpf = "";
            string digito = "";
            Int32 Aux1 = 0;
            Int32 Aux2 = 0;

            for (int i = 0; i < cpf.Length; i++)
            {
                if (IsNumero(cpf.Substring(i, 1)))
                {
                    new_cpf += cpf.Substring(i, 1);
                }
            }
            new_cpf = Convert.ToInt64(new_cpf).ToString("D9");
            if (new_cpf.Length > 9)
            {
                return null;
            }
            Aux1 = 0;
            for (int i = 0; i < new_cpf.Length; i++)
            {
                Aux1 += Convert.ToInt32(new_cpf.Substring(i, 1)) * (10 - i);
            }
            Aux2 = 11 - (Aux1 % 11);
            if (Aux2 > 9)
            {
                digito += "0";
            }
            else
            {
                digito += Aux2.ToString();
            }
            new_cpf += digito;
            Aux1 = 0;
            for (int i = 0; i < new_cpf.Length; i++)
            {
                Aux1 += Convert.ToInt32(new_cpf.Substring(i, 1)) * (11 - i);
            }
            Aux2 = 11 - (Aux1 % 11);
            if (Aux2 > 9)
            {
                digito += "0";
            }
            else
            {
                digito += Aux2.ToString();
            }
            return digito;
        }
        
        /// <summary>
        /// Calcula o Digito verificador de um CNPJ informado  
        /// </summary>
        /// <param name="cnpj">int64 com o CNPJ contendo 12 digitos e sem o digito verificador</param>
        /// <returns>string com o digito calculado do CNPJ ou null caso o CNPJ informado for maior que 12 digitos</returns>
        private static string CalculaDigCNPJ(Int64 cnpj)
        {
            return CalculaDigCNPJ(cnpj.ToString("D12"));
        }

        /// <summary>
        /// Calcula o Digito verificador de um CNPJ informado  
        /// </summary>
        /// <param name="cnpj">string com o CNPJ contendo 12 digitos e sem o digito verificador</param>
        /// <returns>string com o digito calculado do CNPJ ou null caso o CNPJ informado for maior que 12 digitos</returns>
        private static string CalculaDigCNPJ(string cnpj)
        {            
            string new_cnpj = "";
            string digito = "";
            int[] calculo = new int[] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            Int32 Aux1 = 0;
            Int32 Aux2 = 0;
            
            for (int i = 0; i < cnpj.Length; i++)
            {
                if (IsNumero(cnpj.Substring(i, 1)))
                {
                    new_cnpj += cnpj.Substring(i, 1);
                }
            }            
            new_cnpj = Convert.ToInt64(new_cnpj).ToString("D12");            
            if (new_cnpj.Length > 12)
            {
                return null;
            }            
            Aux1 = 0;
            for (int i = 0; i < new_cnpj.Length; i++)
            {
                Aux1 += Convert.ToInt32(new_cnpj.Substring(i, 1)) * calculo[i];
            }
            Aux2 = (Aux1 % 11);            
            if (Aux2 < 2)
            {
                digito += "0";
            }
            else
            {
                digito += (11 - Aux2).ToString();
            }            
            new_cnpj += digito;            
            calculo = new int[] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            Aux1 = 0;
            for (int i = 0; i < new_cnpj.Length; i++)
            {
                Aux1 += Convert.ToInt32(new_cnpj.Substring(i, 1)) * calculo[i];
            }
            Aux2 = (Aux1 % 11);            
            if (Aux2 < 2)
            {
                digito += "0";
            }
            else
            {
                digito += (11 - Aux2).ToString();
            }

            return digito;
        }
    }
}
