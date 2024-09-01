using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
using System;

public class TimeSystem : AbstractSystem
{
    static Action m_FiexdUpdateAction;
    static Action m_SecondAction;
    static float secondTimer;
    DateTime m_lastExitTime;
    protected override void OnInit()
    {
        CommonMono.AddFixedUpdateAction(m_FiexdUpdateAction);
        CommonMono.AddFixedUpdateAction(() =>
        {
            secondTimer += Time.fixedDeltaTime;
            if (secondTimer >= 1)
            {
                m_SecondAction?.Invoke();
                secondTimer = 0;
            }
        });
    }

    public static void AddFixedUpdateAction(Action fun) => m_FiexdUpdateAction += fun;
    public static void RemoveFixedUpdateAction(Action fun) => m_FiexdUpdateAction -= fun;
    public static void AddSecondUpdateAction(Action fun) => m_SecondAction += fun;
    public static void RemoveSecondUpdateAction(Action fun) => m_SecondAction -= fun;

    public float GetOfflinePeriod()//获取下线时间的长度(day)
    {
        if (m_lastExitTime != null)
            return TimeConverter.SecondToDay((DateTime.Now - m_lastExitTime).Seconds);
        else
            return 0;
    }
}
