
namespace TestWorkTamagochi.Model.Actions
{
    public class Healing : Action
    {
        public Healing(Plaer plaer) : base(plaer)
        {
        }
        public override void DoMake()
        {
            plaer.HealthPlaer.UpFullParam();
            plaer.FullPlaer.DounParam();
            plaer.SleepPlaer.DounParam();
            plaer.HeppiPlaer.DounParam();
            plaer.HeppiPlaer.DounParam();
        }
    }
}
