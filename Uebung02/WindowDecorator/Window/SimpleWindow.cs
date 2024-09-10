namespace Window;

public class SimpleWindow : IWindow
{
    public string GetDescription(){
        return "Simple window";
    }

    public double GetCost(){
        return 100.0;
    }

}