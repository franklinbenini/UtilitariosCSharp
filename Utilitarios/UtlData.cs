using System;

namespace Utilitarios
{
    /// <summary>
    /// Classe utilitária para trabalhar com datas
    /// </summary>
    public static class UtlData
    {
        /// <summary>
        /// Retorna o dia da semana por extenso
        /// </summary>
        /// <param name="pDia">Dia da semana de 0 a 6 (0 para domingo e 6 para sábado)</param>
        /// <returns>Dia da semana por extenso</returns>
        public static string DiaSemanaExtenso(string pDia)
        {
            pDia = pDia.Trim();
            if (!pDia.Equals("0") && !pDia.Equals("1") && !pDia.Equals("2") && !pDia.Equals("3") &&
                !pDia.Equals("4") && !pDia.Equals("5") && !pDia.Equals("6"))
            {
                throw new Exception("Valor do parâmetro deve estar entre 0 e 6. O valor passado foi: " + pDia.ToString());
            }

            switch (pDia)
            {
                case "0":
                    {
                        return "Domingo";
                    }
                case "1":
                    {
                        return "Segunda-Feira";
                    }
                case "2":
                    {
                        return "Terça-Feira";
                    }
                case "3":
                    {
                        return "Quarta-Feira";
                    }
                case "4":
                    {
                        return "Quinta-Feira";
                    }
                case "5":
                    {
                        return "Sexta-Feira";
                    }
                case "6":
                    {
                        return "Sábado";
                    }
                default:
                    {
                        return "";
                    }
            }
        }

        /// <summary>
        /// Retorna o dia da semana por extenso
        /// </summary>
        /// <param name="pDia">Dia da semana de 0 a 6 (0 para domingo e 6 para sábado)</param>
        /// <returns>Dia da semana por extenso</returns>
        public static string DiaSemanaExtenso(char pDia)
        {
            return DiaSemanaExtenso(pDia.ToString());
        }

        /// <summary>
        /// Retorna o dia da semana por extenso
        /// </summary>
        /// <param name="pDia">Dia da semana de 0 a 6 (0 para domingo e 6 para sábado)</param>
        /// <returns>Dia da semana por extenso</returns>
        public static string DiaSemanaExtenso(int pDia)
        {
            return DiaSemanaExtenso(pDia.ToString());
        }

        /// <summary>
        /// Retorna o mês por extenso
        /// </summary>
        /// <param name="pMes">Mês entre 1 e 12 (1 para janeiro e 12 para dezembro)</param>
        /// <returns>Mês por extenso</returns>
        public static string MesExtenso(string pMes)
        {
            pMes = pMes.Trim();
            if (!pMes.Equals("1") && !pMes.Equals("2") && !pMes.Equals("3") && !pMes.Equals("4") &&
                !pMes.Equals("5") && !pMes.Equals("6") && !pMes.Equals("7") && !pMes.Equals("8") &&
                !pMes.Equals("9") && !pMes.Equals("10") && !pMes.Equals("11") && !pMes.Equals("12"))
            {
                throw new Exception("Valor do parâmetro deve estar entre 1 e 12. O valor passado foi: " + pMes.ToString());
            }

            switch (pMes)
            {                
                case "1":
                    {
                        return "Janeiro";
                    }
                case "2":
                    {
                        return "Fevereiro";
                    }
                case "3":
                    {
                        return "Março";
                    }
                case "4":
                    {
                        return "Abril";
                    }
                case "5":
                    {
                        return "Maio";
                    }
                case "6":
                    {
                        return "Junho";
                    }
                case "7":
                    {
                        return "Julho";
                    }
                case "8":
                    {
                        return "Agosto";
                    }
                case "9":
                    {
                        return "Setembro";
                    }
                case "10":
                    {
                        return "Outubro";
                    }
                case "11":
                    {
                        return "Novembro";
                    }
                case "12":
                    {
                        return "Dezembro";
                    }
                default:
                    {
                        return "";
                    }
            }
        }

        /// <summary>
        /// Retorna o mês por extenso
        /// </summary>
        /// <param name="pMes">Mês entre 1 e 12 (1 para janeiro e 12 para dezembro)</param>
        /// <returns>Mês por extenso</returns>
        public static string MesExtenso(char pMes)
        {
            return MesExtenso(pMes.ToString());
        }

        /// <summary>
        /// Retorna o mês por extenso
        /// </summary>
        /// <param name="pMes">Mês entre 1 e 12 (1 para janeiro e 12 para dezembro)</param>
        /// <returns>Mês por extenso</returns>
        public static string MesExtenso(int pMes)
        {
            return MesExtenso(pMes.ToString());
        }
    }
}
