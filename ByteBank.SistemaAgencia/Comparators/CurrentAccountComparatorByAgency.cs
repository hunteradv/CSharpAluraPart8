using ByteBank.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia.Comparators
{
    public class CurrentAccountComparatorByAgency : IComparer<CheckingAccount>
    {
        public int Compare(CheckingAccount x, CheckingAccount y)
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
