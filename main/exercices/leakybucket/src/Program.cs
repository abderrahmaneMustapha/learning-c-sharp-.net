using System;

namespace src
{
    class Program
    {

        static void Main(string[] args)

        {
            int[] inputs_list = {12, 23, 34, 55, 29, 12, 40,33};

            var bucket =  new Bucket(inputs_list);

            bucket.run();
    
        }

    
    }
}

