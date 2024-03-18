namespace TestWorkTamagochi.Model.Actions
{
    public class Sleeping : Action
    {
        public Sleeping(Plaer plaer) : base(plaer)
        {
        }

        public override void DoMake()
        {
            plaer.SleepPlaer.UpFullParam();
            plaer.HealthPlaer.UpParam();
            plaer.HeppiPlaer.DounParam();
            plaer.FullPlaer.DounParam();
        }
    }
}
