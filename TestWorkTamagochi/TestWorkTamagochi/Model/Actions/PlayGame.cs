
namespace TestWorkTamagochi.Model.Actions
{
    public class PlayGame:Action
    {
        public PlayGame(Plaer plaer) : base(plaer)
        {
        }

        public override void DoMake()
        {
            plaer.HeppiPlaer.UpParam();
            plaer.SleepPlaer.DounParam();
            if(plaer.HeppiPlaer.Param>=plaer.HeppiPlaer.MaxParam)
            {
                plaer.HealthPlaer.DounParam();
                plaer.FullPlaer.DounParam();
            }
        }
    }
}
