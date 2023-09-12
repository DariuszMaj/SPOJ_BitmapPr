using System;
using System.Text;
using System.Collections.Generic;
namespace BITMAP_SPOJ
{
    public static class Program
    {
        private static readonly Tuple<int, int>[] MyBitmapChecked = new[]{Tuple.Create(-1, 0), Tuple.Create(1, 0),Tuple.Create(0, -1), Tuple.Create(0, 1),};
        private static void Main()
        {
            int Testy = int.Parse(Console.ReadLine());
            while (Testy-- > 0)
            {
                int[] MyDataRow = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                int MyRowsChecked = MyDataRow[0];
                int MyColumnsChecked = MyDataRow[1];
                string[] DefRow = new string[MyRowsChecked];
                for (int i = 0; i < MyRowsChecked; ++i){DefRow[i] = Console.ReadLine();}
                var Results = new StringBuilder();
                int?[,] MyWhite = new int?[MyRowsChecked, MyColumnsChecked];
                var MyPIX = new Queue<Tuple<int, int>>();
                for (int i = 0; i < MyRowsChecked; ++i)
                {
                    for (int x = 0; x < MyColumnsChecked; ++x)
                    {
                        if (DefRow[i][x] == '1')
                        {
                            MyWhite[i, x] = 0;
                            MyPIX.Enqueue(Tuple.Create(i, x));
                        }
                    }
                }
                while (MyPIX.Count > 0)
                {
                    int DimensionsChecked = MyPIX.Count;
                    for (int i = 0; i < DimensionsChecked; ++i)
                    {
                        Tuple<int, int> PIXa = MyPIX.Dequeue();
                        int PIXaRow = PIXa.Item1;
                        int PIXaColumn = PIXa.Item2;
                        int WhiteChecked = MyWhite[PIXaRow, PIXaColumn].Value + 1;
                        foreach (var NearPIX in MyBitmapChecked)
                        {
                            int NearPIXRow = PIXaRow + NearPIX.Item1;
                            int NearPIXColumn = PIXaColumn + NearPIX.Item2;
                            if (NearPIXRow >= 0 && NearPIXRow < MyRowsChecked && NearPIXColumn >= 0 && NearPIXColumn < MyColumnsChecked && !MyWhite[NearPIXRow, NearPIXColumn].HasValue)
                            {
                                MyWhite[NearPIXRow, NearPIXColumn] = WhiteChecked;
                                MyPIX.Enqueue(Tuple.Create(NearPIXRow, NearPIXColumn));
                            }
                        }
                    }
                }
                for (int x = 0; x < MyRowsChecked; ++x)
                {
                    Results.Append(MyWhite[x, 0]);
                    for (int i = 1; i < MyColumnsChecked; ++i){Results.Append($" {MyWhite[x, i]}");}
                    Results.AppendLine();
                }
                Console.Write(Results);
                Console.ReadLine();
            }
        }
    }
}
