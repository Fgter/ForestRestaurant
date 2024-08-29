using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
using UnityEngine.Events;
using System;

public class UIWindowBase : MonoBehaviour
{
    public UnityAction<UIWindowBase, Result> OnCloseHanlder;

    public virtual Type Type
    {
        get => GetType();
    }
    public enum Result
    {
        None=0,
        Yes,
        No
    }
    //在第一次加载的时候调用
    public virtual void OnInit()
    {

    }
    public virtual void OnShow()
    {

    }
    public virtual void OnHide()
    {

    }
    public virtual void OnDestroyClose()
    {
        
    }

    void Close(Result result,bool destroy=false)
    {
        OnCloseHanlder?.Invoke(this, result);
        OnHide();
        if (destroy)
            OnDestroyClose();
        UIManager.instance.Close(Type);
    }

    public virtual void HideYes()
    {
        Close(Result.Yes);
    }

    public virtual void HideNo()
    {
        Close(Result.No);
    }

    public virtual void CloseYes()
    {
        Close(Result.Yes,true);
    }

    public virtual void CloseNo()
    {
        Close(Result.Yes,true);
    }
}
