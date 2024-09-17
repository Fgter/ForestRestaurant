using QFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class RestaurantSystem : AbstractSystem
{
    int _jg = 20;//间隔时间触发随机出售(s)
    float _thisTime = 0;//当前时间(s)
    float _trigger = 1;//每次触发时的概率
    System.Random random = new System.Random();
    protected override void OnInit()
    {
        CommonMono.AddFixedUpdateAction(() =>
        {
            _thisTime += Time.fixedDeltaTime;
            if(_thisTime >= _jg)
            {
                _thisTime = 0;
                if (RandomTrigger(_trigger))
                {
                    Sold();
                }
            }
        });
        //上线时候持续执行
        //下线的时候(求差:取多余间隔)
        //再次上限的时候(求差:取多余间隔)
    }
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
        if (ls<=(int)probability*100)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    void Sold()
    {

    }
}

