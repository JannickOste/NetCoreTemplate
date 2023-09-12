namespace App.Core.Domain.Startup; 

public class StartupHelperOptions : Attribute  
{
    private readonly bool enabled ;
    public bool Enabled {get => this.enabled; }

    private readonly int priority = 0;
    public int Priority {get => this.priority; }

    public StartupHelperOptions(
        bool enabled = true, 
        int priority = 100
    ){
        this.enabled = enabled;
        this.priority = priority;
    }
}

