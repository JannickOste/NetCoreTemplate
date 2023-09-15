namespace App.Core.Domain.Startup.Attributes;
public enum StartupPriorityLevel : byte
{
    Minimal  = 0,
    Low      = 10,
    Medium   = 20,
    High     = 30,
    Extreme  = 40,
    TopLevel = 50
}