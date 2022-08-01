using ByteBank.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    // [item][item][item][item][item]
    //                                ^
    //                                 `- _proximaPosicao


    public class CheckingAccountList
    {
        private CheckingAccount[] _items;
        private int _nextposition;
        
        public int Size
        {
            get
            {
                return _nextposition;
            }
        }

        public CheckingAccountList(int startingCapacity = 5)
        {
            _items = new CheckingAccount[startingCapacity];
            _nextposition = 0;
        }

        public void MyMethod(string text = "texto padrao", int number = 5)
        {

        }

        public void Insert(CheckingAccount item)
        {
            VerificarCapacidade(_nextposition + 1);

            // Console.WriteLine($"Adicionando item na posição {_proximaPosicao}");

            _items[_nextposition] = item;
            _nextposition++;
        }
        
        public void AddSeveral(params CheckingAccount[] items)
        {
            foreach(CheckingAccount account in items)
            {
                Insert(account);
            }
        }

        public void Delete(CheckingAccount item)
        {
            int indiceItem = -1;

            for(int i = 0; i < _nextposition; i++)
            {
                CheckingAccount itemAtual = _items[i];

                if (itemAtual.Equals(item))
                {
                    indiceItem = i;
                    break;
                }
            }

            // Quero remover o 0x01

            // [0x03] [0x04] [0x05] [null]
            //                       ^
            //                        ` _proximaPosicao

            for (int i = indiceItem; i < _nextposition-1; i++)
            {
                _items[i] = _items[i + 1];
            }

            _nextposition--;
            _items[_nextposition] = null;
        }

        public CheckingAccount GetItemNoIndice(int indice)
        {
            if(indice < 0 || indice >= _nextposition)
            {
                throw new ArgumentOutOfRangeException(nameof(indice));
            }

            return _items[indice];
        }

        private void VerificarCapacidade(int tamanhoNecessario)
        {
            if(_items.Length >= tamanhoNecessario)
            {
                return;
            }

            int novoTamanho = _items.Length * 2;
            if (novoTamanho < tamanhoNecessario)
            {
                novoTamanho = tamanhoNecessario;
            }

            // Console.WriteLine("Aumentando capacidade da lista!");

            CheckingAccount[] novoArray = new CheckingAccount[novoTamanho];

            for(int indice = 0; indice < _items.Length; indice++)
            {
                novoArray[indice] = _items[indice];
                // Console.WriteLine(".");
            }

            _items = novoArray;
        }
        
        public CheckingAccount this[int indice]
        {
            get
            {
                return GetItemNoIndice(indice);
            }
        }

    }
}
