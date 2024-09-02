using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Data
{
    public class PlantDefine:IDefine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string[] Animation { get; set; }
        [JsonIgnore]
        public int GrowthStageCount { get => Animation.Length; }//收获前有几个生长阶段
        public float[] GrowthPercentPort { get; set; }//每个阶段的百分比突破口(0-1]  //不包含0
        public string[] StagesName { get; set; }//每个生长阶段的名称
        public float MatureTime { get; set; }//从种子长到成熟需要的时间(day)
        public int SeasonCount { get; set; }//一次种植可收获几次
        public int HarvestId { get; set; }//收获物id
        public int HarvestCountMin { get; set; }//收获个数最小值
        public int HarvestCountMax { get; set; }//收获个数最大值
    }
}
