using System.Collections.Generic;

namespace UnitTests.SupportingItems
{
    public static class Results
    {
        public static void Reset()
        {
            Index.Clear();
        }

        public static int Count => Index.Count;

        public static List<string> Index { get; } = new List<string>();

        public static void Add(string item)
        {
            Index.Add(item);
        }
    }
}
