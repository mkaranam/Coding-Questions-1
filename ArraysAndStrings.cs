using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysAndStrings
{
    class Program
    {
        public bool hasUnique(String s)
        {
            bool[] chars = new bool[256];
            for (int i = 0; i < chars.Length; i++) chars[i] = false;
            foreach (char c in s)
            {
                if (!chars[c]) chars[c] = true;
                else return false;
            }
            return true;
        }

        public bool arePermut(String s1, String s2)
        {
            if (s1.Length != s2.Length) return false;
            int[] chars = new int[256];
            for (int i = 0; i < chars.Length; i++) chars[i] = 0;
            foreach (char c in s1) chars[c]++;
            foreach (char c in s2) chars[c]--;
            for (int i = 0; i < chars.Length; i++) if (chars[i] != 0) return false;
            return true;
        }

        public String replaceSpaces(String s)
        {
            char[] chars = new char[s.Length * 3];
            int index = chars.Length - 1;
            s.CopyTo(0, chars, 0, s.Length);
            for (int i = s.Length-1 ; i >= 0 ; i--)
            {
                if (chars[i] == ' ')
                {
                    chars[index--] = '0';
                    chars[index--] = '2';
                    chars[index--] = '%';
                }
                else
                {
                    chars[index--] = chars[i];
                }
            }
            int cnt=0;
            for (int i = index; i < chars.Length; i++) chars[cnt++] = chars[i];
            for (int i = cnt; i < chars.Length; i++) chars[i] = ' ';
            return (new String(chars));
        }

        public String compressString(String s)
        {
            if (s.Length <= 1) return s;
            StringBuilder sb = new StringBuilder();
            char prev;
            char? cur = null;
            int cnt = 1;
            prev = s.ElementAt(0);
            for (int i = 1; i < s.Length; i++)
            {
                cur = s.ElementAt(i);
                if (cur == prev) cnt++;
                else
                {
                    sb.Append(prev + "" + cnt);
                    cnt = 1;
                    if (sb.Length > s.Length) return s;
                }
                prev = cur.Value;
            }
            sb.Append(cur.Value + "" + cnt);

            if (sb.Length > s.Length) return s;
            else return sb.ToString();
        }

        public void matrixRotation(int[,] image)
        {
            int length = image.GetLength(0);
            int first, last;
            first = last = -1;
            for (int i = 0; i < length/2 ; ++i)
            {
                first = i;
                last = length - i -1;
                for (int j = first; j < last; ++j)
                {
                    int offset = j - first;

                    int temp = image[first, j];
                    image[first, j] = image[last - offset, first];
                    image[last - offset, first] = image[last, last - offset];
                    image[last, last - offset] = image[j, last];
                    image[j,last] = temp;
                }
            }
        }

        public void print(int[,] image)
        {
            Console.WriteLine("\n\n Matrix: ");
    
            for (int i = 0; i < image.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int j = 0; j < image.GetLength(1); j++)
                {
                    Console.Write(image[i, j] + " ");
                }
            }
        }

        public void matrixReplace(int[,] image)
        {
            int[] rows = new int[image.GetLength(0)];
            int[] cols = new int[image.GetLength(1)];
            for (int i = 0; i < rows.Length; i++) rows[i] = 0;
            for (int i = 0; i < cols.Length; i++) cols[i] = 0;

            for (int i = 0; i < image.GetLength(0); i++)
            {
                for (int j = 0; j < image.GetLength(1); j++)
                {
                    if (image[i, j] == 0)
                    {
                        rows[i]++;
                        cols[j]++;
                    }
                }
            }

            for (int i = 0; i < image.GetLength(0); i++)
            {
                for (int j = 0; j < image.GetLength(1); j++)
                {
                    if (rows[i] > 0 || cols[j] > 0)
                    {
                        image[i, j] = 0;
                    }
                }
            }


        }

        public bool isRotatedString(String s1, String s2)
        {
            return isSubString(s1 + s1, s2);
        }

        private bool isSubString(String s1, String s2)
        {
            return true;
        }
    }
}
