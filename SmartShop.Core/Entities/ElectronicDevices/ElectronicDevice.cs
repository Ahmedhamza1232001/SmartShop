using SmartShop;

public abstract class ElectronicDevice : Product
{
    public double ScreenSize { get; set; }
    public string CellularTechnology { get; set; } = string.Empty;
    public int MemoryStorageCapacity { get; set; }
    public string SpecialFeatures { get; set; } = string.Empty;
    public double ItemWeight { get; set; }
}
