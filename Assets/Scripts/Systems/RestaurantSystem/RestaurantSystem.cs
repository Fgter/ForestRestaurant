using QFramework;
using System;
using UnityEngine;

public class RestaurantSystem : AbstractSystem
{
    int _jg = 5;//间隔时间触发随机出售(s)
    float _thisTime = 0;//当前时间(s)
    float _trigger = 0.6f;//每次触发时的概率
    System.Random random = new System.Random();
    static Action SoldAction;
    protected override void OnInit()
    {
        CommonMono.AddFixedUpdateAction(() =>
        {
            _thisTime += Time.fixedDeltaTime;
            if (_thisTime >= _jg)
            {
                _thisTime -= _jg;
                if (RandomTrigger(_trigger))
                {
                    SoldAction?.Invoke();
                }
            }
        });
        CommonMono.AddQuitAction(Save);
        Load();
    }
    public static void AddSoldAction(Action action) => SoldAction+=action;
    public static void RemoveSoldAction(Action action) =>SoldAction-=action;
    public static void RemoveAllSoldAction() => SoldAction = null;
    bool RandomTrigger(float probability)//触发概率(0-1)
    {
        if (probability <= 0)
        {
            return false;
        }
        else if (probability>=1)
        {
            return true;
        }
        int ls = random.Next(0,100);
        if (ls<=(int)(probability*100))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    void Save()
    {
        Debug.Log("保存下线后的数据");
    }
    void Load()
    {
        Debug.Log("加载上次下线的数据");
    }
}

