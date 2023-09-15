namespace App.Core.Domain.Startup.Attributes; 

public class ConfigureSetupOptions : Attribute  
{
    public bool Enabled { get; }
    public byte Priority { get; }

    public ConfigureSetupOptions(bool enabled = true, StartupPriorityLevel priority = StartupPriorityLevel.Minimal)
    {
        Enabled = enabled;
        Priority = (byte)priority;
    }
}
