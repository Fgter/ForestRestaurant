using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;

public class ClearSoilCommond : AbstractCommand
{
    Soil soil;
    public ClearSoilCommond(Soil soil)
    {
        this.soil = soil;
    }
    protected override void OnExecute()
    {
        soil.plant = null;
    }
}
