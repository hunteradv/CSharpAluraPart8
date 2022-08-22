using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia.Extensions
{
    public static class ExtensionList
    {
        public static void AddSeveral<T>(this List<T> IntList, params T[] items)
        {
            foreach (T item in items)
            {
                IntList.Add(item);
            }
        }
        
        public static string FormataCpf(this string value, int tamanho)
        {
            var cpf = value.Substring(0, 3) + "." + value.Substring(3, 3) + "." + value.Substring(6, 3) + "-" + value.Substring(9, 2);

            if (tamanho != 0)
            {
                cpf = cpf.Substring(0, tamanho - 1);
            }

            return cpf;
        }
    }
}   
