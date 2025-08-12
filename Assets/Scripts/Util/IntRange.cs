namespace Util
{
    public class IntRange
    {
        public int Min;
        public int Max;

        public IntRange() : this(0, 1) { }

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