using QFramework;
namespace Models
{
    public class PlayerModel : AbstractModel
    {
        public BindableProperty<int> Gold = new BindableProperty<int>();
        protected override void OnInit()
        {
            
        }
    }

}
