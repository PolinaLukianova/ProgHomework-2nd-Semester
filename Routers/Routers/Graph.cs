namespace Routers;
public class Graph
{
    private readonly List<Edge> edges = [];
    public readonly List<int> vertices = [];

    public void Parser(string filePath)
    {
        foreach (string line in File.ReadLines(filePath))
        {
            string[] parts = line.Split(':');
            int begin = int.Parse(parts[0].Trim());

            if (!vertices.Contains(begin))
            {
                vertices.Add(begin);
            }

            foreach (string item in parts[1].Split(','))
            {
                int end = int.Parse(item.Split('(')[0].Trim());

                if (!vertices.Contains(end))
                {
                    vertices.Add(end);
                }
                string temp = item.Split('(')[1];
                int weight = int.Parse(temp.Split(')')[0].Trim());

                edges.Add(new Edge(begin, end, weight));
            }
        }
    }

    public bool IsConnected()
    {
        List<int> visited = [];
        int start = vertices[0];
        DFS(start, visited);

        if (visited.Count == vertices.Count)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void DFS(int start, List<int> visited)
    {
        visited.Add(start);

        foreach (var edge in edges)
        {
            if (edge.Begin == start && !visited.Contains(edge.End))
            {
                DFS(edge.End, visited);
            }
            if (edge.End == start && !visited.Contains(edge.Begin))
            {
                DFS(edge.Begin, visited);
            }
        }
    }

    public List<Edge> MST()
    {
        List<Edge> mst = [];
        edges.Sort();
        Dictionary<int, int> parent = vertices.ToDictionary(v => v, v => v);

        int Find(int i)
        {
            if (parent[i] == i)
            {
                return i;
            }
            return parent[i] = Find(parent[i]);
        }

        void Union(int i, int j)
        {
            int rootI = Find(i);
            int rootJ = Find(j);
            if (rootI != rootJ)
            {
                parent[rootI] = rootJ;
            }
        }

        foreach (Edge edge in edges)
        {
            int rootBegin = Find(edge.Begin);
            int rootEnd = Find(edge.End);

            if (rootBegin != rootEnd)
            {
                mst.Add(edge);
                Union(edge.Begin, edge.End);
            }
        }

        HashSet<int> connectedVert = [.. mst.SelectMany(e => new[] { e.Begin, e.End })
                                                .Distinct()];
        return mst;
    }
}