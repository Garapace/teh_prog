using System;

namespace laba2
{
    class Program
    {
        static void Main(string[] args)
        {
            BaseList ArrayList = new ArrayList();
            BaseList ChainList = new ChainList();
            BaseList TestArrayList = new ArrayList();
            BaseList TestChainList = new ChainList();
            Random random = new Random();

            /*for (int i = 1; i < 21; i++)
            {
                ArrayList.Add(random.Next(1,100));
            }
            ArrayList.Print();
            ArrayList.Sort();
            ArrayList.Print();

            TestArrayList.Assign(ArrayList);
            TestArrayList.Print();*/

            for (int i = 0; i < 5000; i++)
            {
                int operation = random.Next(0, 3);
                int digit = random.Next(0, 1000);
                int index = random.Next(0, 100);

                switch (operation)
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
                    Console.WriteLine("Error contained in\n" +
                                    "Array List: " + ArrayList[i] + "\n" +
                                    "Chain List: " + ChainList[i] + "\n" +
                                    "On " + i + " iteration");
                }
                else
                {
                    Console.WriteLine("Done.\n" +
                                    "Array List length - " + ArrayList.Count + "\n" +
                                    "Chain List length - " + ChainList.Count + "\n");
                    break;
                }
            }
        }
    }
}