using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornerNode : Node
{
    public bool enabled;
    public Node up;
    public Node right;


    public CornerNode(Vector3 pos, bool status, float squareSize) : base(pos)
    {
        enabled = status;
        up = new Node(position + new Vector3(0, 0, 1) * squareSize / 2f);
        right = new Node(position + new Vector3(1, 0, 0) * squareSize / 2f);
    }

}
