using QFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RestaurSystem : AbstractSystem
{
    protected override void OnInit()
    {

        this.RegisterEvent<UpdateFoodMenuUIEvent>(v => { 
            
        });
    }
}

