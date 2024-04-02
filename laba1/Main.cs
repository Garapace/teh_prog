using System;
using System.Collections;

namespace laba1
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList ArrayList = new ArrayList();
            ChainList ChainList = new ChainList();
            DoublyChainList DoublyChainList = new DoublyChainList();
            Random random = new Random();

            for (int i = 0; i < 5000; i++)
            {
                int operation = random.Next(0, 3);
                int digit = random.Next(0, 1000);
                int index = random.Next(0, 100);

                switch(operation)
                {
                    case 0:
                        ArrayList.Add(digit);
                        ChainList.Add(digit);
                        DoublyChainList.Add(digit);
                        break;
                    case 1:
                        ArrayList.Delete(index);
                        ChainList.Delete(index);
                        DoublyChainList.Delete(index);
                        break;
                    case 2:
                        ArrayList.Insert(digit, index);
                        ChainList.Insert(digit, index);
                        DoublyChainList.Insert(digit, index);
                        break;
                }
            }

            /*Console.WriteLine("Array List");
            ArrayList.Print();
            Console.WriteLine("Chain List");
            ChainList.Print();
            Console.WriteLine();*/



            for (int i = 0; i < ArrayList.Count; i++)
            {
                if (ArrayList[i] != ChainList[i])
                {
                    Console.WriteLine("Error contained in\n" +
                                    "Array List: " + ArrayList[i] + "\n" +
                                    "Chain List: " + ChainList[i] + "\n" +
                                    "Doubly Chain List: " + DoublyChainList[i] + "\n" +
                                    "On " + i + " iteration");
                } else {
                    Console.WriteLine("Done.\n" + 
                                    "Array List length - \t" + ArrayList.Count + "\n" + 
                                    "Chain List length - \t" + ChainList.Count + "\n" + 
                                    "Doubly Chain List length - " + DoublyChainList.Count);
                    break;
                }
            }

        }
    }
}