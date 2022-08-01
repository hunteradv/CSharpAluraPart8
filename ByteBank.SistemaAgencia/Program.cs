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
            SortTest();
        }

        private static void TestCheckingAccountListNull()
        {
            var accounts = new List<CheckingAccount>()
            {
                new CheckingAccount(341, 355943),
                new CheckingAccount(341, 302932),
                null,
                new CheckingAccount(351, 302933),
                new CheckingAccount(351, 12),
                null,
                null
            };

            var sortedAccountsNotNull = accounts.Where(account => account != null).OrderBy(account => account.Number);

            foreach (var account in sortedAccountsNotNull)
            {
                Console.WriteLine($"conta: {account.Number}, agencia: {account.Agencia}");
            }

            Console.ReadLine();
        }

        static void IComparableTest()
        {
            var accounts = new List<CheckingAccount>()
            {
                new CheckingAccount(341, 355943),
                new CheckingAccount(341, 302932),
                new CheckingAccount(351, 302933),
                new CheckingAccount(351, 1)
            };

            //ordenação com IComparable
            //accounts.Sort();

            //ordenação com Imcomparer
            accounts.Sort(new CurrentAccountComparatorByAgency());

            
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
            ListaDeContaCorrente lista = new ListaDeContaCorrente();

            CheckingAccount contaDoGui = new CheckingAccount(11111, 1111111);

            CheckingAccount[] contas = new CheckingAccount[]
            {
                contaDoGui,
                new CheckingAccount(874, 5679787),
                new CheckingAccount(874, 5679754)
            };

            lista.AdicionarVarios(contas);

            lista.AdicionarVarios(
                contaDoGui,
                new CheckingAccount(874, 5679787),
                new CheckingAccount(874, 5679787),
                new CheckingAccount(874, 5679787),
                new CheckingAccount(874, 5679787),
                new CheckingAccount(874, 5679787),
                new CheckingAccount(874, 5679787),
                new CheckingAccount(874, 5679787),
                new CheckingAccount(874, 5679787)
            );

            for (int i = 0; i < lista.Tamanho; i++)
            {
                CheckingAccount itemAtual = lista[i];
                Console.WriteLine($"Item na posição {i} = Conta {itemAtual.Number}/{itemAtual.Agencia}");
            }
        }



        static void TestaArrayDeContaCorrente()
        {
            CheckingAccount[] contas = new CheckingAccount[]
                {
                    new CheckingAccount(874, 5679787),
                    new CheckingAccount(874, 4456668),
                    new CheckingAccount(874, 7781438)
                };

            for (int indice = 0; indice < contas.Length; indice++)
            {
                CheckingAccount contaAtual = contas[indice];
                Console.WriteLine($"Conta {indice} {contaAtual.Number}");
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
