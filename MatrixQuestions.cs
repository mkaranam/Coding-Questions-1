using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCup.Google
{
    class MatrixQuestions
    {
        public int FindConnectedArea(int[,] input,int sR,int sC)
        {
            if (input.GetLength(0) == 0) throw new System.Exception();
            if(sR > input.GetLength(0) || sR < 0) throw new System.Exception();
            if(sC > input.GetLength(1) || sC < 0) throw new System.Exception();

            HashSet<String> Checked = new HashSet<string>();
            Checked.Add(sR + " " + sC);
            return findArea(input,Checked,new int[]{sR,sC});
        }

        private int findArea(int[,] input, HashSet<String> Checked,int[] position)
        {
            int Area = 1;
            List<int[]> candidates = getPossibleCells(input, position[0], position[1]);
            foreach (int[] candidate in candidates)
            {
                String temp = candidate[0] + " " + candidate[1];
                if (!Checked.Contains(temp))
                {
                    Checked.Add(temp);
                    Area += findArea(input, Checked, candidate);
                }
            }
            return Area;

        }

        private List<int[]> getPossibleCells(int[,] input, int row, int col)
        {
            List<int[]> candidates = new List<int[]>();
            
            for (int i = -1; i < 2; i++)
            {
                if (((row + i) < 0) || ((row + i) == input.GetLength(0))) break;
                for (int j = -1; j < 2; j++)
                {
                    if (((col + j) < 0 )|| ((col + j) == input.GetLength(1))) break;
                    if (input[row + i, col + j] > 0) candidates.Add(new int[2] { row + i, col + j });
                }
            }
            return candidates;
        }
    }
}
