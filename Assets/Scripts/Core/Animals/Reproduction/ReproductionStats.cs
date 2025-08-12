

using DG.DemiLib;

namespace Core.Animals.Reproduction
{
    public class ReproductionStats
    {
        public float MateTime;
        public float MateCooldownTime;
        public int PregnancyDuration;
        public IntRange ChildCountRange = new IntRange(1, 2);
    }
}