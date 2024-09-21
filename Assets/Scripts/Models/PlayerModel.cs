using QFramework;
namespace Models
{
    public class PlayerModel : AbstractModel
    {
        public bool isFirstEnter;
        public BindableProperty<int> Gold { get; set; } = new();
        protected override void OnInit()
        {
            isFirstEnter = true;
        }
    }

}
