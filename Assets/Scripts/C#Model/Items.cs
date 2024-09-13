using Define;
using System;

/// <summary>
/// 可以在背包里面的Item
/// </summary>
public class Item //子类构造函数记得给父类的define赋值,因为没有不能重写define属性
{
    public int count { get; set; }
    public virtual IIconItemDefine define { get; set; }
    public Type Type { get => this.GetType(); }
}
public class SeedItem : Item
{
    public new SeedDefine define { get; set; }
    public SeedItem(SeedDefine define)
    {
        base.define = define;
        this.define = define;
        this.count = 0;
    }
}

public class HarvestItem:Item
{
    public new HarvestDefine define { get; set; }
    public HarvestItem(HarvestDefine define)
    {
        base.define = define;
        this.define = define;
        this.count = 0;
    }
}

public class FoodItem:Item
{
    public new FoodDefine define { get; set; }
    public FoodItem(FoodDefine define)
    {
        base.define = define;
        this.define = define;
        this.count = 0;
    }
}

public class SpecialtyItem : Item
{
    public new SpecialtyDefine define { get; set; }
    public SpecialtyItem(SpecialtyDefine define)
    {
        base.define = define;
        this.define = define;
        this.count = 0;
    }
}
