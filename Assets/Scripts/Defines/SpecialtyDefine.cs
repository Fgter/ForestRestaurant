using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Define
{
    public class SpecialtyDefine : IIconItemDefine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }
}
