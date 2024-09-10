using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
using System;
using SaveData;

public class TimeSystem : AbstractSystem
{
    static Action _FiexdUpdateAction;
    static Action _SecondAction;
    static float _secondTimer;
    DateTime _lastExitTime;
    protected override void OnInit()
    {
        CommonMono.AddFixedUpdateAction(_FiexdUpdateAction);
        CommonMono.AddFixedUpdateAction(() =>
        {
            _secondTimer += Time.fixedDeltaTime;
            if (_secondTimer >= 1)
            {
                _SecondAction?.Invoke();
                _secondTimer = 0;
            }
        });
        CommonMono.AddQuitAction(OnQuit);
        Load();
    }

    public static void AddFixedUpdateAction(Action fun) => _FiexdUpdateAction += fun;
    public static void RemoveFixedUpdateAction(Action fun) => _FiexdUpdateAction -= fun;
    public static void AddSecondUpdateAction(Action fun) => _SecondAction += fun;
    public static void RemoveSecondUpdateAction(Action fun) => _SecondAction -= fun;

    public float GetOfflinePeriod()//获取下线时间的长度(day)
    {
        if (_lastExitTime != null)
            return TimeConverter.SecondToDay((DateTime.Now - _lastExitTime).Seconds);
        else
            return 0;
    }

    void OnQuit()
    {
        Save();
    }

    void Save()
    {
        TimeSaveData timeSaveData = new TimeSaveData();
        timeSaveData.lastExitTime= DateTime.Now;
        this.GetUtility<Storage>().Save(timeSaveData);
    }
    void Load()
    {
        var data = this.GetUtility<Storage>().Load<TimeSaveData>();
        if (data == default)
            return;
            _lastExitTime = data.lastExitTime;
    }
}
