using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCup.Google
{
    class ArrayQuestions
    {
        public void waveSort(int[] input)
        {
            Array.Sort(input);
            for (int i = 1; i < input.Length; i+=2)
            {
                int temp = input[i];
                input[i] = input[i - 1];
                input[i - 1] = temp;
            }
        }
    }
}
