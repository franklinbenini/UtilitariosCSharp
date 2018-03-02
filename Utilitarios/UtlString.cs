using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Utilitarios
{
    /// <summary>
    /// Classe utilitária com métodos para manipular strings
    /// </summary>
    public static class UtlString
    {
        /// <summary>
        /// Remove os acentos de uma string
        /// </summary>
        /// <param name="text">string com os acentos a serem removidos</param>
        /// <returns>string sem acentos</returns>
        public static string RemoveAcentos(this string texto)
        {
            StringBuilder sbRetorno = new StringBuilder();
            var arrayTexto = texto.Normalize(NormalizationForm.FormD).ToCharArray();
            foreach (char letra in arrayTexto)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(letra) != UnicodeCategory.NonSpacingMark)
                    sbRetorno.Append(letra);
            }
            return sbRetorno.ToString();
        }

        /// <summary>
        /// Remove todos caracteres especiais (que não são letras ou números) da string
        /// </summary>
        /// <param name="texto">string com caracteres a serem removidos</param>
        /// <returns>retorna string sem caracteres especiais</returns>
        public static string RemoveCaracteresEspeciais(string texto)
        {
            return Regex.Replace(texto, "[^0-9a-zA-Z]+", "");
        }

        /// <summary>
        /// Remove todos caracteres não numéricos da string
        /// </summary>
        /// <param name="texto">string com caracteres não numéricos</param>
        /// <returns>string sem as letras</returns>
        public static string RemoveLetras(string texto)
        {
            return RemoveLetras(texto, false);
        }

        /// <summary>
        /// Remove todos caracteres não numéricos da string
        /// </summary>
        /// <param name="texto">string com caracteres não numéricos</param>
        /// <param name="mantemAcentuadas">se true mantém letras acentuadas, se false exclui elas também</param>
        /// <returns>string sem as letras</returns>
        public static string RemoveLetras(string texto, bool mantemAcentuadas)
        {
            string tmp = texto;
            if (!mantemAcentuadas)
                tmp = RemoveAcentos(texto);

            return Regex.Replace(tmp, @"[A-Za-z ]", "");
        }

        /// <summary>
        /// Remove todos caracteres não alfabéticos da string
        /// </summary>
        /// <param name="texto">string com caracteres não alfabéticos</param>
        /// <returns>string só com letras</returns>
        public static string RemoveNumeros(string texto)
        {
            return Regex.Replace(texto, @"[\d-]", "");
        }
    }
}
