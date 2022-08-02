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
    }
}   
