using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareGrid
{
    public Square[,] squares;

    public SquareGrid(int[,] floor, float squareSize)
    {
        int nodeCountX = floor.GetLength(0);
        int nodeCountY = floor.GetLength(1);
        float mapWidth = nodeCountX * squareSize;
        float mapHeight = nodeCountY * squareSize;

        CornerNode[,] cornerNodes = new CornerNode[nodeCountX, nodeCountY];

        for (int x = 0; x < nodeCountX; x++)
        {
            for (int y = 0; y < nodeCountY; y++)
            {
                Vector3 pos = new Vector3(-mapWidth / 2 + x * squareSize + squareSize / 2, 0, -mapHeight / 2 + y * squareSize + squareSize / 2);
                cornerNodes[x, y] = new CornerNode(pos, floor[x, y] == 1, squareSize);
            }
        }

        squares = new Square[nodeCountX - 1, nodeCountY - 1];
        for (int x = 0; x < nodeCountX - 1; x++)
        {
            for (int y = 0; y < nodeCountY - 1; y++)
            {
                squares[x, y] = new Square(cornerNodes[x, y + 1], cornerNodes[x + 1, y + 1], cornerNodes[x + 1, y], cornerNodes[x, y]);
            }
        }

    }
}
