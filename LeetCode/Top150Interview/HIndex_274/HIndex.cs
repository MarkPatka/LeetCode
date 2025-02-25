namespace LeetCode.Top150Interview.HIndex_274;

public class HIndex
{
    public int GetHIndex(int[] citations)
    {
        CountingSortDesc(citations);

        int hirsh = 0;
        while (hirsh  < citations.Length && citations[hirsh] >= hirsh + 1)
        {
            hirsh++;
        }
        return hirsh;
    }

    void CountingSortDesc(int[] array)
    {
        if (array.Length == 0) return;

        // Находим максимальное значение в массиве
        int max = array[0];
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] > max) max = array[i];
        }

        // Создаем массив для подсчета количества вхождений
        int[] count = new int[max + 1];

        // Подсчитываем количество вхождений каждого элемента
        for (int i = 0; i < array.Length; i++)
        {
            count[array[i]]++;
        }

        // Заполняем исходный массив отсортированными значениями
        int index = 0;
        int startIndex = count.Length - 1;
        for (int i = startIndex; i >= 0; i--)
        {
            while (count[i] > 0)
            {
                array[index++] = i;
                count[i]--;
            }
        }
    }
}
