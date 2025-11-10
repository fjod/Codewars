using System.Collections.Generic;

namespace CodeWars;

public class Node
{
    public int val;
    public IList<Node> children;

    public Node() {
        val = 0;
        children = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        children = new List<Node>();
    }

    public Node(int _val, List<Node> children) {
        val = _val;
        this.children = children;
    }
}