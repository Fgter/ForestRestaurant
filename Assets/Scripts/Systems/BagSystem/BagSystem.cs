using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
using Models;
using SaveData;

public class BagSystem : AbstractSystem
{
    ItemModel _model;
    protected override void OnInit()
    {
        _model = this.GetModel<ItemModel>();
        Load();
        CommonMono.AddQuitAction(Save);
    }

    void Load()
    {
        BagSaveData saveData = this.GetUtility<Storage>().Load<BagSaveData>();
        if (saveData.items == null)
            return;
        foreach (var data in saveData.items)
        {
            this.SendCommand(new AddItemCommand(data.id, data.count));
        }
    }

    void Save()
    {
        BagSaveData saveData = new BagSaveData();
        saveData.items = new List<ItemSaveData>();
        foreach (var item in _model.Items)
        {
            saveData.items.Add(new ItemSaveData(item.Key, item.Value.count));
        }
        this.GetUtility<Storage>().Save(saveData);
    }
}
