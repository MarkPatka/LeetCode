using System.ComponentModel.Design;

namespace LeetCode.Top150Interview.IntegerToRoman_12;

public partial class Solution
{
    private static readonly Dictionary<int, char> romans = new()
    {
        { 1,    'I' },
        { 5,    'V' },
        { 10,   'X' },
        { 50,   'L' },
        { 100,  'C' },
        { 500,  'D' },
        { 1000, 'M' }
    };

    private readonly LinkedList<KeyValuePair<int, char>> romansKeyValuePairsLinkedList =
        new(
        [
            new KeyValuePair<int, char>(1,   'I'),
            new KeyValuePair<int, char>(5,   'V'),
            new KeyValuePair<int, char>(10,  'X'),
            new KeyValuePair<int, char>(50,  'L'),
            new KeyValuePair<int, char>(100, 'C'),
            new KeyValuePair<int, char>(500, 'D'),
            new KeyValuePair<int, char>(1000,'M'),
        ]);

    /// <summary>
    /// Bad performace solution. 
    /// Here is just a playground to try some approaches.
    /// Need to improve
    /// </summary>
    public string IntegerToRoman(int num)
    {
        string roman = string.Empty;
        int[] decimalParts = DecomposeNumber(num);
        
        for (int i = 0; i < decimalParts.Length; i++)
        {
            int part = decimalParts[i];
            int partLen = decimalParts.Length - 1 - i;
            if (!romans.ContainsKey(part))
            {
                int keyGrade = (int)Math.Pow(10, partLen);
                var firstNum = part / keyGrade;
                if (firstNum == 4)
                {
                    roman += romans[keyGrade];
                    var node = romansKeyValuePairsLinkedList.First!;
                    while (node != null)
                    {
                        if (node.Value.Key == keyGrade)
                        {
                            roman += node.Next!.Value.Value;
                            break;
                        }
                        node = node.Next!.Next;
                    }
                }
                else if (firstNum == 9)
                {
                    roman += romans[keyGrade];
                    var node = romansKeyValuePairsLinkedList.First!;
                    while (node != null)
                    {
                        if (node.Value.Key > keyGrade)
                        {
                            roman += node.Value.Value;
                            break;
                        }
                        node = node.Next!.Next;
                    }
                }
                else
                {
                    var node = romansKeyValuePairsLinkedList.Last!;
                    
                    if (keyGrade == 1000)
                    {
                        while (part > 0)
                        {
                            roman += node.Value.Value;
                            part -= node.Value.Key;
                        }
                    }
                    else
                    {
                        while (part > 0)
                        {
                            if (node.Value.Key > part)
                            {
                                node = node.Previous!;
                                continue;
                            }
                            else
                            {
                                roman += node.Value.Value;
                                part -= node.Value.Key;
                            }
                        }
                    }
                }
            }
            else
            {
                roman += romans[part];
            }
        }
            return roman;
    }

    private int[] DecomposeNumber(int n)
    {
        int temp = n, digitCount = 0;
        while (temp > 0)
        {
            digitCount++;
            temp /= 10;
        }

        int[] parts = new int[digitCount];
        int position = 1;

        for (int i = 0; n > 0; i++)
        {
            int digit = n % 10;
            if (digit != 0)
            {
                parts[digitCount - 1 - i] = digit * position;
            }
            n /= 10;
            position *= 10;
        }
        return parts;
    }
}
