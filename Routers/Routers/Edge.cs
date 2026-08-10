namespace Routers;

public class Edge(int begin, int end, int weight): IComparable<Edge>
{
    public int Weight { get; } = weight;
    public int Begin { get; } = begin;
    public int End { get; } = end;

    public int CompareTo(Edge? other)
    {
        if (other == null)
        {
            return 1;
        }
        return other.Weight.CompareTo(Weight);
    }
}
