namespace Define
{
    public class SoilDefine:IDefine
    {
        public int Id { get; set; }
        public float[] Position { get; set; }
        public int Price { get; set; }
        public bool UnlockStart { get; set; }
    }
}

