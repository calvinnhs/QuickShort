using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickShort
{
    class program
    {
        //array of intergers to hold values
        private int[] arr = new int[20];
        private int cmp_count = 0; //number of comperation
        private int mov_count = 0; //number of data movements

        //number of elements in array
        private int n;


        void read()
        {
            while (true)
            {
                Console.Write("Enter the number of elements in the array :");
                string s = Console.ReadLine();
                n = Int32.Parse(s);
                if (n <= 20)
                    break;
                else
                    Console.WriteLine("\nArray can have maximum 20 elements \n");
            }
            Console.WriteLine("\n========================");
            Console.WriteLine("Enter Array Elements");
            Console.WriteLine("\n========================");

            //get array elements
            for(int i = 0; i < arr.Length; i++)
            {
                Console.Write("<" + (i + 1) + ">");
                string s1 = Console.ReadLine();
                arr[i] = Int32.Parse(s1);
            }
        }
        //swap the elements at index x with the elements at index y 

        void swap(int x, int y)
        {
            int temp;

            temp = arr[x];
            arr[x] = arr[y];
        }

        public void q_short(int low, int high)
        {
            int pivot, i, j;
            if (low > high)
                return;

            //partition the list into two parts:
            //one containing elements less that or equal to pivot
            //outher containing elements greather than pivot 

            i = low + 1;
            j = high;

            pivot = arr[i];
            while (i <= j)
            {
                //search for an elements less greater than pivot
                while ((arr[i] <= pivot) && (i <= high))
                {
                    i++;
                    cmp_count++;
                }
                cmp_count++;

                if (i < j)//if the greater elements is on the left of the elements
                {
                    //swap the elements at index i whit the at index j
                    swap(i, j);
                    mov_count++;
                }
            }
            //j now containts the index the last elements in the sorted list 

            if (low < j)
            {
                //move the pivot to its correct positcon in the list
                swap(low, j);
                mov_count++;

                //sort the list on the right of pivot using quick sort
                q_short(j + 1, high);

            }
        }
        void display()
        {
            Console.WriteLine("\n---------------------");
            Console.WriteLine(" sorted array elements ");
            Console.WriteLine("-----------------------");

            for (int J = 0; J < n; J++)
            {
                Console.WriteLine(arr[J]);
            }


            Console.WriteLine("\nnumber of comparasison :" + cmp_count);
            Console.WriteLine("\nnumber of data movemenets : " + mov_count);
        }
        int Getsize()
        {
            return n;
        }
        static void Main(string[] args)
        {
            program mylist = new program();
            mylist.read();
            mylist.q_short(0, mylist.Getsize() - 1);
            mylist.display();
            Console.WriteLine("\n\npress enter to exit.");
            Console.Read();
        }
    }
}
