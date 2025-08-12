namespace Util
{
    public class IntRange
    {
        public int Min { get; set; }
        public int Max { get; set; }

        public IntRange(int min, int max)
        {
            Min = min;
            Max = max;
        }

        public int GetRandomValue()
        {
            return UnityEngine.Random.Range(Min, Max + 1);
        }
    }
}