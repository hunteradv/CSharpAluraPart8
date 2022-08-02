using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ByteBank.Modelos;
using ByteBank.Modelos.Funcionarios;
using ByteBank.SistemaAgencia.Comparators;
using ByteBank.SistemaAgencia.Extensions;

namespace ByteBank.SistemaAgencia
{
    class Program
    {

        static void Main(string[] args)
        {
            IComparableTest();
        }

        private static void TestExtensionMethod()
        {
            var ages = new List<int>
            {
                1,
                10,
                25,
                21,
                4,
                499
            };

            ages.AddSeveral(2, 3, 5);
            ages.Sort();

            foreach (var age in ages)
            {
                Console.WriteLine(age);
            }

            Console.ReadLine();
        }

        private static void TestSort()
        {
            var names = new List<string>
            {
                "gustavo",
                "nathan",
                "rafael",
                "marcela"
            };

            names.Sort();

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }

            var ages = new List<int>
            {
                1,
                10,
                25,
                21,
                4,
                499
            };

            ages.AddSeveral(2, 3, 5);
            ages.Sort();

            foreach (var age in ages)
            {
                Console.WriteLine(age);
            }
        }

        private static void TestCheckingAccountListNull()
        {
            var accounts = new List<ContaCorrente>()
            {
                new ContaCorrente(341, 355943),
                new ContaCorrente(341, 302932),
                null,
                new ContaCorrente(351, 302933),
                new ContaCorrente(351, 12),
                null,
                null
            };

            var sortedAccountsNotNull = accounts.Where(account => account != null).OrderBy(account => account.Numero);

            foreach (var account in sortedAccountsNotNull)
            {
                Console.WriteLine($"conta: {account.Numero}, agencia: {account.Agencia}");
            }

            Console.ReadLine();
        }

        static void IComparableTest()
        {
            var accounts = new List<ContaCorrente>()
            {
                new ContaCorrente(341, 355943),
                new ContaCorrente(341, 302932),
                new ContaCorrente(351, 302933),
                new ContaCorrente(351, 1)
            };

            //ordenação com IComparable
            //accounts.Sort();

            //ordenação com Imcomparer
            accounts.Sort(new CurrentAccountComparatorByAgency());

            foreach (var account in accounts)
            {
                Console.WriteLine($"Agência {account.Agencia} | conta {account.Numero}");
            }

            Console.ReadLine();
        }
    

        static void SortTest()
        {
            var ages = new List<int>()
            {
                20,
                20,
                29,
                21,
                24,
            };

            //ages.Remove(20);

            ages.Sort();

            Console.WriteLine("Lista de idades");

            foreach (int age in ages)
            {
                Console.WriteLine($"idade: {age}");
            }

            Console.WriteLine();

            var names = new List<string>()
            {
                "Gustavo",
                "Michel",
                "Bruna",
                "Nathan",
                "Murilo"
            };

            names.Sort();

            Console.WriteLine("Lista de nomes");

            foreach (string name in names)
            {
                Console.WriteLine($"nome: {name}");
            }

            Console.ReadLine();
        }

        static int SomarVarios(params int[] numeros)
        {
            int acumulador = 0;
            foreach(int numero in numeros)
            {
                acumulador += numero;
            }
            return acumulador;
        }


        static void TestaListaDeContaCorrente()
        {
            //ListaDeContaCorrente lista = new ListaDeContaCorrente();
            ListContaCorrente list = new ListContaCorrente();

            ContaCorrente contaDoGui = new ContaCorrente(11111, 1111111);

            ContaCorrente[] contas = new ContaCorrente[]
            {
                contaDoGui,
                new ContaCorrente(874, 5679787),
                new ContaCorrente(874, 5679754)
            };

            list.AddSeveral(contas);

            list.AddSeveral(
                contaDoGui,
                new ContaCorrente(874, 5679787),
                new ContaCorrente(874, 5679787),
                new ContaCorrente(874, 5679787),
                new ContaCorrente(874, 5679787),
                new ContaCorrente(874, 5679787),
                new ContaCorrente(874, 5679787),
                new ContaCorrente(874, 5679787),
                new ContaCorrente(874, 5679787)
            );

            for (int i = 0; i < list.Size; i++)
            {
                ContaCorrente itemAtual = list[i];
                Console.WriteLine($"Item na posição {i} = Conta {itemAtual.Numero}/{itemAtual.Agencia}");
            }
        }



        static void TestaArrayDeContaCorrente()
        {
            ContaCorrente[] contas = new ContaCorrente[]
                {
                    new ContaCorrente(874, 5679787),
                    new ContaCorrente(874, 4456668),
                    new ContaCorrente(874, 7781438)
                };

            for (int indice = 0; indice < contas.Length; indice++)
            {
                ContaCorrente contaAtual = contas[indice];
                Console.WriteLine($"Conta {indice} {contaAtual.Numero}");
            }
        }

        static void TestaArrayInt()
        {
            // ARRAY de inteiros, com 5 posições!
            int[] idades = null;
            idades = new int[3];

            idades[0] = 15;
            idades[1] = 28;
            idades[2] = 35;
            //idades[3] = 50;
            //idades[4] = 28;
            //idades[5] = 60;

            Console.WriteLine(idades.Length);

            int acumulador = 0;
            for (int indice = 0; indice < idades.Length; indice++)
            {
                int idade = idades[indice];

                Console.WriteLine($"Acessando o array idades no índice {indice}");
                Console.WriteLine($"Valor de idades[{indice}] = {idade}");

                acumulador += idade;
            }

            int media = acumulador / idades.Length;
            Console.WriteLine($"Média de idades = {media}");
        }

    }
}
