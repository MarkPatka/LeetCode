using System.Text;

namespace LeetCode.AddBinary_67;

public partial class Solution 
{
    /// <summary>
    /// The best one, using ~0ms of runtime and O(1) space while Array.Reverse()
    /// </summary>
    public string AddBinary(string a, string b)
    {
        int i = a.Length - 1;
        int j = b.Length - 1;
        int carry = 0;

        var sb = new StringBuilder(105);

        while (i >= 0 || j >= 0 || carry > 0)
        {
            int sum = carry; 

            if (i >= 0) sum += a[i--] - '0';
            if (j >= 0) sum += b[j--] - '0';

            sb.Append((char)('0' + (sum & 1))); // sum & 1 - берет младший бит (0 или 1); '0' + (sum & 1) - преобразует 0/1 обратно в символ '0'/'1'
            carry = sum >> 1;                   // sum >> 1 - сдвиг вправо эквивалентен (sum / 2) - это перенос
            // пример: sum = 0 + 1 + 1 = 2; цифра = 0 (2 & 1); перенос = 1 (2 >> 1)
        }
        int left = 0, right = sb.Length - 1;
        while (left < right)
        {
            (sb[right], sb[left]) = (sb[left], sb[right]);
            left++; right--;
        }
        return sb.ToString();
    }

    /// <summary>
    /// The worst solution using ~2ms of runtime, string concatenation overhead and multiple if-statements
    /// </summary>
    public string AddBinary_1(string a, string b)
    {
        StringBuilder stringBuilder = new(104);
        byte nextDigitNumber = 0;

        (a, b) = a.Length > b.Length 
            ? (a, _ = new string('0', a.Length - b.Length) + b) 
            : (b, _ = new string('0', b.Length - a.Length) + a); 

        for (int i = a.Length - 1; i >= 0; --i)
        {
            if (a[i] == b[i])
            {
                if (a[i] == '1' && nextDigitNumber == 1)
                {
                    stringBuilder.Append('1');
                }
                else if (a[i] == '1' && nextDigitNumber == 0)
                {
                    stringBuilder.Append('0');
                    nextDigitNumber = 1;
                }
                else if (nextDigitNumber == 1)
                {
                    stringBuilder.Append('1');
                    nextDigitNumber = 0;
                }
                else
                {
                    stringBuilder.Append('0');
                }
            }
            else
            {
                stringBuilder.Append(nextDigitNumber == 1 ? '0' : '1');
            }
        }
        
        if (nextDigitNumber == 1) 
            stringBuilder.Append('1');

        int left = 0, right = stringBuilder.Length - 1;
        while (left < right)
        {
            (stringBuilder[right], stringBuilder[left]) = (stringBuilder[left], stringBuilder[right]);
            left++; right--;
        }
        return stringBuilder.ToString();

    }

}
