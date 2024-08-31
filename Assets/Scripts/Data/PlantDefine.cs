using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PlantDefine
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public string[] Animation { get; set; }
        public int GrowthStage { get; set; }//收获前有几个生长阶段
        public int HarvestingCount { get; set; }//一次种植可收获几次
    }
}
