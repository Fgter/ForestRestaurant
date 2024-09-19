
struct UnlockSoilEvent
{
    public Soil soil { get; set; }
    public UnlockSoilEvent(Soil soil)
    {
        this.soil = soil;
    }
}

