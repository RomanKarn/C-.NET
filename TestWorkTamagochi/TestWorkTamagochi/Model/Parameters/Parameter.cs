using System.Windows;

namespace TestWorkTamagochi.Model.Parameters
{
    public abstract class Parameter
    {
        protected string nameParamener;
        public Parameter(int maxParam, string nameParamener)
        {
            MaxParam = maxParam;
            Param = MaxParam;
            this.nameParamener = nameParamener;
        }
        public int Param {  get; protected set; }
        public int MaxParam { get; protected set; }
        public virtual void UpParam()
        {
            Param++;
            if(Param > MaxParam)
                Param = MaxParam;
            
        }
        public virtual void DounParam()
        {
            Param--;
            if (Param <= 0)
            {
                Param = 0;
                MessageBox.Show("Ваш питомец заболел от не достатка " + this.nameParamener);
            }
        }
        public virtual void UpFullParam()
        {
            Param = MaxParam;
        }


    }
}
