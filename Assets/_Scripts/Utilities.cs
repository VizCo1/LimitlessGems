
public class CounterRequest
{
    public Counter counter { get; private set; }
    public int gem { get; private set; }

    public CounterRequest(Counter c, int g)
    {
        counter = c;
        gem = g;   
    }
}
