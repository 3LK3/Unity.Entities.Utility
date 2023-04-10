namespace Spindler.Utilities.Extensions
{
    public static class ArrayExtensions
    {
        public static bool Contains<T>(this T[] array, T containsItem) // where T : class, IEqualityComparer<T>
        {
            foreach (var item in array)
            {
                if (Equals(containsItem, item))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
