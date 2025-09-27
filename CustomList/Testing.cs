using MyCustomList;
using System;

public class Program
{
    static void Main(string[] args)
    {
        CustomList<int> customList = new CustomList<int>();

        customList.Add(1);
        customList.Add(2);
        customList.Add(3);
        customList.Add(4);
        customList.Add(5);
        customList.Add(6);

        //removing
        customList.Remove(2);
        //checking if exists
        bool f = customList.Contains(3);
        Console.WriteLine(f);

        //removing at
        customList.RemoveAt(1);

        //inserting at
        customList.InsertAt(1, 100);

        //clearing
        customList.Clear();
        customList.Print();
    }
}