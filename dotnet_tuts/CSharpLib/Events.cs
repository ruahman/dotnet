namespace CSharpLib;

// events are just delegates that can be registered with an event
public delegate void Notify(); // delegate

public class ProcessBusinessLogic
{
    public event Notify? ProcessCompleted; // event

    public void StartProcess()
    {
        Console.WriteLine("Process Started!");
        OnProcessCompleted();
    }

    protected virtual void OnProcessCompleted() //protected virtual method
    {
        //if ProcessCompleted is not null then call delegate
        ProcessCompleted?.Invoke();
    }
}

public class ProcessBusinessLogic2
{
    // declaring an event using built-in EventHandler
    public event EventHandler ProcessCompleted;

    public void StartProcess()
    {
        Console.WriteLine("Process Started!");
        // some code here..
        OnProcessCompleted(EventArgs.Empty); //No event data
    }

    protected virtual void OnProcessCompleted(EventArgs e)
    {
        ProcessCompleted?.Invoke(this, e);
    }
}

public class Events
{
    public static void Test()
    {
        var bl = new ProcessBusinessLogic();
        bl.ProcessCompleted += bl_ProcessCompleted; // register with an event
        bl.StartProcess();
    }

    public static void Test2()
    {
        var bl = new ProcessBusinessLogic2();
        bl.ProcessCompleted += bl_ProcessCompleted2;
        bl.StartProcess();
    }

    // event handler
    public static void bl_ProcessCompleted()
    {
        Console.WriteLine("Process Completed!");
    }

    // event handler
    public static void bl_ProcessCompleted2(object sender, EventArgs e)
    {
        Console.WriteLine("Process Completed!");
    }
}