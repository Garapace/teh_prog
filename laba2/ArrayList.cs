using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba2
{
    class ArrayList : BaseList
    {
        private int[] buffer;

        public ArrayList()
        {
            buffer = new int[4];
            quantity = 0;
        }

        protected override BaseList EmptyClone()
        {
            ArrayList ArrayList = new ArrayList();
            return ArrayList;
        }

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

        public override void Add(int digit) // метод добавления элемента в конец списка, на вход подаётся число
        {
            if (buffer.Length == quantity) { Expanding(); }
            buffer[quantity] = digit; // в список в ячейку с индексом quantity (кол-во элементов в это списке) присваивается поданное на вход метода число
            quantity++; // увеличение кол-ва эл-тов на один
        }

        public override void Insert(int digit, int index) // метод вставки элемента в любое существующее место списка
        {
            if (index < 0 || index > quantity) { return; } // если индекс превышает кол-во эл-тов массива, то выходим из метода

            if (index == quantity) { Add(digit); return; } // если поданный индекс совпадает с кол-вом эл-ов, то идём в метод Add()

            if (buffer.Length == quantity) { Expanding(); }

            for (int i = quantity; i > index; i--)
            {
                buffer[i] = buffer[i - 1];
            }
            buffer[index] = digit;
            quantity++;
        }

        public override void Delete(int index) // метод удаление элемента списка по его индексу
        {
            if (index < 0 || index >= quantity) { return; } // проверка на выход за диапазон списка

            for (int i = index; i < quantity - 1; i++) // удаление элемента
            {
                buffer[i] = buffer[i + 1];
            }
            quantity--;
        }

        public override void Clear() // метод очиски списка
        {
            quantity = 0;
        }


        public override int this[int index]
        {
            get
            {
                if (index < 0 || index >= quantity) // если хотим получить элемент, находящийся вне диапазона, то возвращаем нуль
                {
                    return 0;
                }
                return buffer[index];
            }

            set
            {
                if (index >= 0 || index < quantity) 
                {
                    buffer[index] = value;
                }
            }
        }

        public override void Print() // метод вывода списка в консоль
        {
            for (int i = 0; i < quantity; i++)
            {
                Console.Write("{0} ", buffer[i]);
            }
            Console.WriteLine();
        }
    }
}
