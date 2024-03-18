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
            Random random = new Random();

            for (int i = 0; i < 5000; i++)
            {
                int operation = random.Next(0, 4);
                int digit = random.Next(0, 1000);
                int index = random.Next(0, 100);

                switch(operation)
                {
                    case 0:
                        ArrayList.Add(digit);
                        ChainList.Add(digit);
                        break;
                    case 1:
                        ArrayList.Delete(index);
                        ChainList.Delete(index);
                        break;
                    case 2:
                        ArrayList.Insert(digit, index);
                        ChainList.Insert(digit, index);
                        break;
                }
            }

            for (int i = 0; i < ArrayList.Count; i++)
            {
                if (ArrayList[i] != ChainList[i])
                {
                    Console.WriteLine("Error contained in " + ArrayList.Count + " " + ChainList.Count + " " + i);
                    break;
                }
            }

            Console.WriteLine("Accept " + ArrayList[0] + " " + ChainList[0]);
        }
    }
}