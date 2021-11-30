using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permutations
{
    public class PermutationsEngine
    {
        public IEnumerable<IEnumerable<int>> PermuteUnique(int[] input)
        {
            var result = new List<IEnumerable<int>>();
            Array.Sort(input);

            bool[] used = new bool[input.Length];
            Backtracking(input, new List<int>(), result, used);
            return result;

        }

        //input - the list of numbers to get permutatiosn of
        //value - the permutation value
        //result - list of permutation values
        //used - array to keep track of if a value has been checked
        private void Backtracking(int[] input, List<int> value, List<IEnumerable<int>> result, bool[] used)
        {
            if (value.Count == input.Length)
            {
                result.Add(new List<int>(value));
                return;
            }
            else
             {
                for (int i = 0; i < input.Length; i++)
                {
                    if (i > 0 && input[i] == input[i - 1] && used[i - 1] || used[i]) continue;

                    value.Add(input[i]);
                    used[i] = true;
                     Backtracking(input, value, result, used);
                    value.RemoveAt(value.Count - 1);
                    used[i] = false;
                 }
            }
        }
    }
}
