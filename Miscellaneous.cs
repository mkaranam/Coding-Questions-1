using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCup.Google
{
    class Miscellaneous
    {
        public int aPOWb(int a, int b)
        {
            int result=1;
            if (b == 1) return a;
            if (b == 0) return 1;
            if (b % 2 == 1)
            {
                result = a;
                b--;
            }
            int half = aPOWb(a,b/2);
            return result * half * half;
        }

        public int atoi(String input)
        {
	        if(input.Length==0) throw new System.ArgumentNullException();
	
	        char[] inp = input.Trim().ToCharArray();
	        bool isNegative=false;
	        int start=0;
	        int number=0;
	
	        if(inp[0]=='-')
	        {
		        isNegative = true;
		        start = 1;
	        }
	        for(int i=start;i<inp.Length;i++)
	        {
		        int temp = inp[i]-'0';
		        //Has to be a number between 0 and 9
		        if(temp > 9 || temp < 0) throw new System.ArgumentException();
                checked
                {
                    number = (number*10) + temp;
                }
		        
	        }
            if (isNegative) checked { number *= -1; }
                
	        return number;
        }

        public int FactorialZeroes(int input)
        {
            if (input < 0) throw new System.ArgumentException();
            int div = 5;
            int numZeroes = 0;
            while (div <= input)
            {
                numZeroes += input / div;
                div *= 5;
            }
            return numZeroes;
        }
    }
}
