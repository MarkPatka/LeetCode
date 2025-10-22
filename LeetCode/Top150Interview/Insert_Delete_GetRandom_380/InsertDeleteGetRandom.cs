namespace LeetCode.Top150Interview.Insert_Delete_GetRandom_380;

public partial class Solution
{
    public class RandomizedSet
    {
        readonly Dictionary<int, int> _set;
        readonly Random _random;

        public RandomizedSet()
        {
            _set = [];
            _random = new();
        }

        public bool Insert(int val) => _set.TryAdd(val, -1);

        public bool Remove(int val) => _set.Remove(val);

        public int GetRandom()
        {
            int idx = _random.Next(_set.Count);
            int[] keys = [.. _set.Keys];
            return keys[idx];
        }
    }
}

