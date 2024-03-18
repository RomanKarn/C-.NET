namespace TestWorkTamagochi.Model.Actions
{
    public class Eat : Action
    {
        public Eat(Plaer plaer) : base(plaer)
        {
        }

        public override void DoMake()
        {
            plaer.FullPlaer.UpParam();
            if(plaer.FullPlaer.Param>=plaer.FullPlaer.MaxParam)
            {
                plaer.HealthPlaer.DounParam();
            }

        }
    }
}
