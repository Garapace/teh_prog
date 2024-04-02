using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba1
{
    class ArrayList
    {
        private int[] buffer;
        private int quantity = 0;

        private void Expanding() // метод расширения списка
        {
            if (buffer == null) // если список пустой, добавляем ему одну ячейку
            {
                buffer = new int[1];
                return;
            }

            if (buffer.Length != quantity) // если длина списка не равна кол-ву элементов в этом списке, то выходим из метода расширения
            {
                return;
            }

            // если предыдущие if'ы не сработали, то выполняется код ниже

            int[] temp = new int[quantity * 2]; // создаём временный список
            for (int i = 0; i < quantity; i++)
            {
                temp[i] = buffer[i]; // присваиваем элементы списка buffer во временный массив
            }
            buffer = temp; // приравниваем основной список к временному
        }

        public void Add(int digit) // метод добавления элемента в конец списка, на вход подаётся число
        {
            Expanding();
            buffer[quantity] = digit; // в список в ячейку с индексом quantity (кол-во элементов в это списке) присваивается поданное на вход метода число
            quantity++; // увеличение кол-ва эл-тов на один
        }

        public void Insert(int digit, int index) // метод вставки элемента в любое существующее место списка
        {
            if (index < 0 || index > quantity) { Console.WriteLine("Индекс вне диапазона"); return; } // если индекс превышает кол-во эл-тов массива, то выходим из метода

            if (index == quantity) { Add(digit); return; } // если поданный индекс совпадает с кол-вом эл-ов, то идём в метод Add()

            Expanding();

            for (int i = quantity; i > index; i--)
            {
                buffer[i] = buffer[i - 1];
            }
            buffer[index] = digit;
            quantity++;
        }

        public void Delete(int index) // метод удаление элемента списка по его индексу
        {
            if (index < 0 || index >= quantity) { Console.WriteLine("Индекс вне диапазона"); return; } // проверка на выход за диапазон списка

            for (int i = index; i < quantity - 1; i++) // удаление элемента
            {
                buffer[i] = buffer[i + 1];
            }
            quantity--; 
        }

        public void Clear() // метод очиски списка
        {
            quantity = 0;  
        }

        public int Count
        {
            get { return quantity; }
        }


        public int this[int index]
        {
            get
            {
                if (index < 0 || index >= quantity) // если хотим получить элемент, стоящий на индексе меньше нулевого, то возвращаем нуль
                {
                    return 0;
                }
                return buffer[index];
            }

            set
            {
                if (index < 0 || index > quantity) // если обращение к отрицательному элементу, тогда выход из метода
                {
                    return;
                }

                buffer[index] = value;
            }
        }

        public void Print() // метод вывода списка в консоль
        {
            for (int i = 0; i < quantity; i++)
            {
                Console.Write("{0} ", buffer[i]);
            }
            Console.WriteLine();
        }
    }
}