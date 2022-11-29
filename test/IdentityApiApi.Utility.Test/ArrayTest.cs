using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IdentityApiApi.Utility.Test
{
    public class MyArray
    {
        private int[] array;
        private int size = 0;

        public MyArray(int capacity)
        {
            array = new int[capacity];
        }

        public void Insert(int element, int index)
        {
            if (index < 0 || index > size)
                throw new ArgumentOutOfRangeException("index");
            if (size >= array.Length)
                Resize();
            for (int i = size - 1; i >= index; i--)
            { array[i + 1] = array[i]; }
            array[index] = element;
            size++;
        }

        public void Resize()
        {
            int[] arrayNew = new int[array.Length * 2];
            array.CopyTo(arrayNew, 0);
            array = arrayNew;
        }

    }


    public class ArrayTest
    {
        [Fact]
        public void TestSpan()
        {
            MyArray myArray = new MyArray(4); 
            myArray.Insert(3, 0); 
            myArray.Insert(7, 1); 
            myArray.Insert(9, 2);
            myArray.Insert(5, 3);
            myArray.Insert(6, 1);
        }
    }
}
