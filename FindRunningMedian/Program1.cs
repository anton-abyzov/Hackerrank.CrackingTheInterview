using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class PriorityHeap
{
    private int[] a;
    private int size;
    private Func<int, int, bool> compare;

    private bool MinHeapCompare(int i, int j)
    {
        if (i < j) return true; else return false;
    }

    private bool MaxHeapCompare(int i, int j)
    {
        if (j < i) return true; else return false;
    }

    public PriorityHeap(int n, bool maxheap = false)
    {
        a = new int[n];
        size = 0;
        compare = MinHeapCompare;
        if (maxheap)
        {
            compare = MaxHeapCompare;
        }
    }

    private void FixUp()
    {
        int i = size - 1;
        while ((i > 0) && compare(a[i], a[parent(i)]))
        {
            swap(i, parent(i));
            i = parent(i);
        }
    }

    private void FixDown()
    {
        int i = 0;
        while (hasleft(i))
        {
            int small = left(i);
            if (hasright(i) && compare(a[right(i)], a[small])) { small = right(i); }
            if (compare(a[i], a[small])) break;
            swap(i, small);
            i = small;
        }
    }

    private int left(int i) { return 2 * i + 1; }

    private int right(int i) { return 2 * i + 2; }

    private int parent(int i) { return (i - 1) / 2; }

    private bool hasleft(int i) { return left(i) < size; }

    private bool hasright(int i) { return right(i) < size; }

    private bool hasparent(int i) { return parent(i) >= 0; }

    private void swap(int i, int j)
    {
        int temp = a[i];
        a[i] = a[j];
        a[j] = temp;
    }

    public void Add(int n)
    {
        a[size] = n;
        size++;
        FixUp();
    }

    public int Count()
    {
        return size;
    }

    public int Peek()
    {
        return a[0];
    }

    public int Remove()
    {
        int temp = a[0];
        a[0] = a[size - 1];
        size--;
        FixDown();
        return temp;
    }
}

class Solution
{

    static void add(PriorityHeap lows, PriorityHeap highs, int a)
    {
        if (lows.Count() == 0)
        {
            lows.Add(a);
            return;
        }

        if (a < lows.Peek())
        {
            lows.Add(a);
            if (lows.Count() > highs.Count() + 1)
            {
                highs.Add(lows.Remove());
            }
        }
        else
        {
            highs.Add(a);
            if (highs.Count() > lows.Count() + 1)
            {
                lows.Add(highs.Remove());
            }
        }
    }

    static decimal median(PriorityHeap lows, PriorityHeap highs)
    {
        if (lows.Count() == highs.Count())
        {
            return (((decimal)(lows.Peek() + highs.Peek())) / 2);
        }
        else if (lows.Count() > highs.Count())
        {
            return lows.Peek();
        }
        else
        {
            return highs.Peek();
        }
    }

    static void Main(String[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        int[] a = new int[n];
        PriorityHeap lows = new PriorityHeap(n, true);
        PriorityHeap highs = new PriorityHeap(n);

        for (int a_i = 0; a_i < n; a_i++)
        {
            a[a_i] = Convert.ToInt32(Console.ReadLine());
            add(lows, highs, a[a_i]);
            Console.WriteLine("{0:f1}", median(lows, highs));
        }
    }
}