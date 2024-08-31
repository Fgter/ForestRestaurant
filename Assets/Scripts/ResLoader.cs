using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResLoader : Singleton<ResLoader>
{
    public T Load<T>(string path) where T : Object
    {
        return Resources.Load<T>(path);
    }

    public T[] LoadAll<T>(string path) where T:Object
    {
        return Resources.LoadAll<T>(path);
    }
}
