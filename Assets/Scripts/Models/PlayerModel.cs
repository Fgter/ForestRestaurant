using QFramework;
namespace Models
{
    public class PlayerModel : AbstractModel
    {
        public BindableProperty<int> Gold { get; set; } = new ();
        protected override void OnInit()
        {
        }
    }

}
