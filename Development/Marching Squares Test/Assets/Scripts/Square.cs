using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square
{

    public CornerNode topLeft, topRight, bottomRight, bottomLeft;
    public Node top, right, bottom, left;
    public int config;

    public Square(CornerNode tl, CornerNode tr, CornerNode br, CornerNode bl)
    {
        topLeft = tl;
        topRight = tr;
        bottomRight = br;
        bottomLeft = bl;

        top = topLeft.right;
        right = bottomRight.up;
        bottom = bottomLeft.right;
        left = bottomLeft.up;

        if (topLeft.enabled)
            config += 8;
        if (topRight.enabled)
            config += 4;
        if (bottomRight.enabled)
            config += 2;
        if (bottomLeft.enabled)
            config += 1;
    }

}
