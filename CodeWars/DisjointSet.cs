namespace CodeWars;

class DisjointSet
{
    private int[] array;

    public int GetArrayValue(int i)
    {
        return array[i];
    }
    
    public DisjointSet(int amount)
    {
        array = new int[amount];
        for (int i = 0; i < amount; i++)
        {
            // each vertex is on it's own
            array[i] = i;
        }
    }

    public void union(int x, int y)
    {
        int rootX = findRoot(x);
        int rootY = findRoot(y);
        if (rootX != rootY) {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == rootY)
                {
                    array[i] = rootX;
                }
            }
        }
    }

    public int findRoot(int element)
    {
        if (array[element] == element) return element;
        int temp = element;
        while (true)
        {
            temp = array[temp];
            if (array[temp] == temp) return temp;
        }
    }

    public bool connected(int x, int y)
    {
        return findRoot(x) == findRoot(y);
    }
}