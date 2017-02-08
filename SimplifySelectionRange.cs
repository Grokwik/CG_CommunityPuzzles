using System;
using System.Text;
using System.Collections.Generic;

namespace SimplifySelectionRange
{
    class Solution
    {
        static string Simplify(string input)
        {
            var numsArray = input.Split(new Char[] { ',', '[', ']' });
            var nums = new List<int>();
            foreach (var n in numsArray)
            {
                if (n.Length == 0)
                    continue;
                nums.Add(int.Parse(n));
            }
            nums.Sort();
            var output = new StringBuilder();
            var rangeLength = 1;
            var rangeBeg = nums[0];
            output.Append(rangeBeg);
            for (var i = 1; i < nums.Count; i++)
            {
                var cNum = nums[i];
                if (cNum == rangeBeg + rangeLength)
                {
                    rangeLength++;
                }
                else
                {
                    if (rangeLength == 2)
                    {
                        output.Append(',');
                        output.Append(rangeBeg + rangeLength - 1);
                    }
                    else if (rangeLength > 2)
                    {
                        output.Append('-');
                        output.Append(rangeBeg + rangeLength - 1);
                    }
                    output.Append(',');
                    output.Append(cNum);
                    rangeBeg = cNum;
                    rangeLength = 1;
                }
            }
            if (rangeLength == 2)
            {
                output.Append(',');
                output.Append(rangeBeg + rangeLength - 1);
            }
            else if (rangeLength > 2)
            {
                output.Append('-');
                output.Append(rangeBeg + rangeLength - 1);
            }
            return output.ToString();
        }
    }
}