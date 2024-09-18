using QFramework;
using SaveData;
using System;
using UnityEngine;

public class TimeSystem : AbstractSystem
{
    static Action _SecondAction;
    static Action<DateTime> _ClockAction;
    static float _secondTimer;
    DateTime _lastExitTime;
    protected override void OnInit()
    {
        CommonMono.AddFixedUpdateAction(() =>
        {
            _secondTimer += Time.fixedDeltaTime;
            if (_secondTimer >= 1)
            {
                _SecondAction?.Invoke();
                _secondTimer = 0;
            }
        });

        _SecondAction += () =>
          {
              if (JudgeExactHourOrHalfHour(DateTime.Now))
                  _ClockAction?.Invoke(DateTime.Now);
          };

        CommonMono.AddQuitAction(OnQuit);
        Load();
    }

    public static void RegisterSecondUpdateAction(Action fun) => _SecondAction += fun;
    public static void UnRegisterSecondUpdateAction(Action fun) => _SecondAction -= fun;
    public static void RegisterClockUpdateAction(Action<DateTime> fun) => _ClockAction += fun;
    public static void UnRegisterClockUpdateAction(Action<DateTime> fun) => _ClockAction -= fun;

    public float GetOfflinePeriod()//获取下线时间的长度(day)
    {
        if (_lastExitTime != null)
            return TimeConverter.SecondToDay((float)(DateTime.Now - _lastExitTime).TotalSeconds);
        else
            return 0;
    }

    public bool JudgeExitTimeOneDayApartClock(float clock)
    {
        DateTime currentTime = DateTime.Now;
        DateTime nextDayTime = _lastExitTime.AddDays(1).Date.AddHours(clock);
        if (currentTime > nextDayTime)
            return true;
        return false;
    }

    public bool JudgeTimeOneDayApartClock(float clock,DateTime lastTime)
    {
        DateTime currentTime = DateTime.Now;
        DateTime nextDayTime = lastTime.AddDays(1).Date.AddHours(clock);
        if (currentTime > nextDayTime)
            return true;
        return false;
    }

    bool JudgeExactHourOrHalfHour(DateTime time)
    {
        return (time.Minute == 0 || time.Minute == 30) && time.Second == 0;
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
