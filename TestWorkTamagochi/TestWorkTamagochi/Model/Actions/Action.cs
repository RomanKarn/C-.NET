namespace TestWorkTamagochi.Model.Actions
{
    public abstract class Action 
    {
        protected Plaer plaer;
        public Action(Plaer plaer) 
        {
         this.plaer = plaer;
        }
        public virtual void DoMake()
        {

        }
    }
}
