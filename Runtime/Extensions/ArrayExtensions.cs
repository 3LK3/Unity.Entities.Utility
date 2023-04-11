namespace Elke.Entities.Utility.Extensions
{
    public static class ArrayExtensions
    {
        public static bool Contains<T>(this T[] array, T containsItem)
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
