namespace LeetCode.Top150Interview.GasStation_134;

public class GasStation
{
    // Low performance
    public int CanCompleteCircuit1(int[] gas, int[] cost)
    {
        int len = gas.Length;
        int[] deltas = new int[len];

        int checkSum = 0;
        for (int i = 0; i < len; i++)
        {
            int delta = gas[i] - cost[i];
            checkSum += delta;
            deltas[i] = delta;
        }
        if (checkSum < 0) return -1;

        int gasLeft = 0;
        int intervals = len - 1;
        for (int i = 0; i < intervals; i++)
        {
            if (deltas[i] > 0)
            {
                int j = 0;
                int idx = i + j;
                while (j < intervals)
                {
                    gasLeft += deltas[idx];
                    
                    if (gasLeft < 0)
                    {
                        gasLeft = 0; 
                        break;
                    }
                    if (idx == intervals) idx = -1;
                    j++;
                    idx++;
                }
                if (j == intervals) return i;
            }            
        }
        return intervals;
    }

    // This one is much better 
    public int CanCompleteCircuit2(int[] gas, int[] cost)
    {
        if (gas.Sum() < cost.Sum()) return -1; //if this condition is false then we have a solution

        int total = 0;
        int startIndex = 0;
        for (int index = 0; index < gas.Length; index++)
        {
            total += (gas[index] - cost[index]);

            if (total < 0)
            {
                // when difference is negative, then we have to start again
                total = 0;
                startIndex = index + 1;
            }
        }

        return startIndex;
    }
}
