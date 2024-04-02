using System;

namespace laba2
{
    class Program
    {
        static void Main(string[] args)
        {
            BaseList ArrayList = new ArrayList();
            BaseList ChainList = new ChainList();
            Random random = new Random();

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

            ArrayList.Sort();



            BaseList CloneList1 = ArrayList.Clone();

            BaseList CloneList2 = new ChainList();
            CloneList2.Assign(ChainList);
            CloneList2.Sort();

            if (CloneList1.IsEqual(CloneList2))
            {
                Console.WriteLine("Accept");
            }
            else
            {
                Console.WriteLine("Bugged");
            }


            for (int i = 0; i < CloneList1.Count; i++)
            {
                if (CloneList1[i] != CloneList2[i])
                {
                    Console.WriteLine("Error contained in\n" +
                                    "Array List: " + CloneList1[i] + "\n" +
                                    "Chain List: " + CloneList2[i] + "\n" +
                                    "On " + i + " iteration");
                }
                else
                {
                    Console.WriteLine("Done.\n" +
                                    "Array List length - \t" + CloneList1.Count + "\n" +
                                    "Chain List length - \t" + CloneList2.Count + "\n");
                    break;
                }
            }
        }
    }
}