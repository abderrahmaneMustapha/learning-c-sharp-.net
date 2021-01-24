using System;

namespace src
{
    class Program
    {

        static void Main(string[] args)

        {
            const int BUCKET_SIZE_LIMIT = 100;
            int actual_bucket_size = BUCKET_SIZE_LIMIT;
            int[] inputs_list = { 22, 5, 50, 44, 1, 3, 64, 30, 29 };
            const int OUTPUT_SIZE = 20;
            int index = 0;
            Boolean valueAdded = true;
            while (true)
            {
                int input = inputs_list[index];
                valueAdded = fillBucketOrNot(ref actual_bucket_size, input);
                actual_bucket_size = drop(BUCKET_SIZE_LIMIT, actual_bucket_size, OUTPUT_SIZE);

                index = advance(index, valueAdded);
                if (index == inputs_list.Length)
                {
                    break;
                }
            }
        }

        private static int advance(int index, bool valueAdded)
        {
            if (valueAdded == true)
            {
                System.Console.WriteLine("Advance");
                index += 1;

            }

            return index;
        }

        private static int drop(int BUCKET_SIZE_LIMIT, int actual_bucket_size, int OUTPUT_SIZE)
        {
            if (actual_bucket_size <= BUCKET_SIZE_LIMIT - OUTPUT_SIZE)
            {
                System.Console.WriteLine("DROP");
                actual_bucket_size += OUTPUT_SIZE;
            }

            return actual_bucket_size;
        }

        private static bool fillBucketOrNot(ref int actual_bucket_size, int input)
        {
            bool valueAdded;
            if (actual_bucket_size >= input)
            {
                actual_bucket_size -= input;
                valueAdded = true;
                System.Console.WriteLine($"FILL by {input}");
            }
            else
            {
                System.Console.WriteLine("Cant Advance, Drop more");
                valueAdded = false;
            }
            System.Console.WriteLine($"Bucket size {actual_bucket_size}");
            return valueAdded;
        }
    }
}

