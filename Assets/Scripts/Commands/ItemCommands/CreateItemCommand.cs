using QFramework;
using UnityEngine;
using Models;
using Define;
using System.Reflection;
using System;

class CreateItemCommand : AbstractCommand<Item>
{
    int id;
    Item result;
    public CreateItemCommand(int id)
    {
        this.id = id;
    }
    protected override Item OnExecute()
    {
        Type type = this.SendQuery(new GetItemTypeQuery(id));
        MethodInfo method = this.GetType().GetMethod("CreateItem", BindingFlags.Instance | BindingFlags.NonPublic).MakeGenericMethod(type);
        method.Invoke(this, null);
        return result;
    }

    void CreateItem<T>() where T : Item
    {
        Type itemType = typeof(T);
        Type defineType = typeof(T).GetProperty("define").PropertyType;
        dynamic define = this.SendQuery(new GetDefineByType(defineType, id));
        result = Activator.CreateInstance(typeof(T), new object[] { define }) as T;
    }
}
