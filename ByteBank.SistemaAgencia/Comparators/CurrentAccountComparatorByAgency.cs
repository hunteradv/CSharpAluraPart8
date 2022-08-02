using ByteBank.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia.Comparators
{
    public class CurrentAccountComparatorByAgency : IComparer<ContaCorrente>
    {
        public int Compare(ContaCorrente x, ContaCorrente y)
        {
            if(x is null)
            {
                return 1;
            }

            if(y is null)
            {
                return -1;
            }

            return x.Agencia.CompareTo(y.Agencia);

            //Este return segue a mesma logica dos ifs abaixo

            //if(x.Agencia < y.Agencia)
            //{
            //    return -1;
            //}

            //if(x.Agencia == y.Agencia)
            //{
            //    return 0;
            //}

            //return 1;
        }
    }
}
