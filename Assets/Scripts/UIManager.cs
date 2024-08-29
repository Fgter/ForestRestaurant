using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using QFramework;

public class UIManager : Singleton<UIManager>
{
    Dictionary<Type, UIElement> UIResources = new Dictionary<Type, UIElement>();
    ResLoader resLoader = ResLoader.Allocate();
    class UIElement
    {
        public string AssetName;
        public GameObject Instance;
        public UIWindowBase script;
    }
    public UIManager()
    {
    }
    public T Show<T> () where T:UIWindowBase
    {
        Type type = typeof(T);
        if(UIResources.ContainsKey(type))
        {
            UIElement info = UIResources[type];
            if(info.Instance!=null)
            {
                info.Instance.SetActive(true);
                info.script.OnShow();
            }
            else
            {
                GameObject prefab = resLoader.LoadSync<GameObject>(info.AssetName);
                if(prefab==null)
                {
                    Debug.LogError(info.AssetName + "can not find");
                    return default;
                }
                info.Instance= GameObject.Instantiate(prefab);
                info.script = info.Instance.GetComponent<T>();
                info.Instance.SetActive(true);
                info.script.OnInit();
                info.script.OnShow();
            }
            return info.script as T;
        }
        else
        {
            Debug.LogError(typeof(T).ToString() + "is not in dictionary");
            return default;
        }

    }

    public void Close(Type type,bool destroy=false)
    {
        if(UIResources.ContainsKey(type))
        {
            UIElement info = UIResources[type];
            if(info.Instance!=null)
            {
                if (!destroy)
                {
                        info.script.OnHide();
                        info.Instance.SetActive(false);
                }
                else
                {
                    info.script.OnHide();
                    info.script.OnDestroyClose();
                    GameObject.Destroy(info.Instance);
                    info.Instance = null;
                    info.script = null;
                }
            }
        }
    }
}
