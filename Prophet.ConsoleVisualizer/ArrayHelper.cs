namespace Prophet.ConsoleVisualizer
{
    public static class ArrayHelper
    {
        public static T[,] To2D<T>(this T[] array)
        {
            var result = new T[array.Length, 1];

            for (var i = 0; i < array.Length; i++)
            {
                result[i, 0] = array[i];
            }

            return result;
        }
    }
}