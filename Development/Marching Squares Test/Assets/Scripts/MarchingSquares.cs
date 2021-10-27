using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarchingSquares : MonoBehaviour
{

    public SquareGrid squareGrid;
    List<Vector3> vertices;
    List<int> triangles;

    public void GenerateMesh(int[,] floor, float squareSize)
    {
        squareGrid = new SquareGrid(floor, squareSize);

        vertices = new List<Vector3>();
        triangles = new List<int>();

        for (int x = 0; x < squareGrid.squares.GetLength(0); x++)
        {
            for (int y = 0; y < squareGrid.squares.GetLength(1); y++)
            {
                TriangulateSquare(squareGrid.squares[x, y]);
            }
        }

        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.RecalculateNormals();

    }

    void TriangulateSquare(Square square)
    {
        switch (square.config)
        {
            case 0:
                break;

            // 1 points:
            case 1:
                MeshFromPoints(square.bottom, square.bottomLeft, square.left);
                break;
            case 2:
                MeshFromPoints(square.right, square.bottomRight, square.bottom);
                break;
            case 4:
                MeshFromPoints(square.top, square.topRight, square.right);
                break;
            case 8:
                MeshFromPoints(square.topLeft, square.top, square.left);
                break;

            // 2 points:
            case 3:
                MeshFromPoints(square.right, square.bottomRight, square.bottomLeft, square.left);
                break;
            case 6:
                MeshFromPoints(square.top, square.topRight, square.bottomRight, square.bottom);
                break;
            case 9:
                MeshFromPoints(square.topLeft, square.top, square.bottom, square.bottomLeft);
                break;
            case 12:
                MeshFromPoints(square.topLeft, square.topRight, square.right, square.left);
                break;
            case 5:
                MeshFromPoints(square.top, square.topRight, square.right, square.bottom, square.bottomLeft, square.left);
                break;
            case 10:
                MeshFromPoints(square.topLeft, square.top, square.right, square.bottomRight, square.bottom, square.left);
                break;

            // 3 point:
            case 7:
                MeshFromPoints(square.top, square.topRight, square.bottomRight, square.bottomLeft, square.left);
                break;
            case 11:
                MeshFromPoints(square.topLeft, square.top, square.right, square.bottomRight, square.bottomLeft);
                break;
            case 13:
                MeshFromPoints(square.topLeft, square.topRight, square.right, square.bottom, square.bottomLeft);
                break;
            case 14:
                MeshFromPoints(square.topLeft, square.topRight, square.bottomRight, square.bottom, square.left);
                break;

            // 4 point:
            case 15:
                MeshFromPoints(square.topLeft, square.topRight, square.bottomRight, square.bottomLeft);
                break;
        }

    }

    void MeshFromPoints(params Node[] points)
    {
        AssignVertices(points);

        if (points.Length >= 3)
            CreateTriangle(points[0], points[1], points[2]);
        if (points.Length >= 4)
            CreateTriangle(points[0], points[2], points[3]);
        if (points.Length >= 5)
            CreateTriangle(points[0], points[3], points[4]);
        if (points.Length >= 6)
            CreateTriangle(points[0], points[4], points[5]);

    }

    void AssignVertices(Node[] points)
    {
        for (int i = 0; i < points.Length; i++)
        {
            if (points[i].vertexIndex == -1)
            {
                points[i].vertexIndex = vertices.Count;
                vertices.Add(points[i].position);
            }
        }
    }

    void CreateTriangle(Node a, Node b, Node c)
    {
        triangles.Add(a.vertexIndex);
        triangles.Add(b.vertexIndex);
        triangles.Add(c.vertexIndex);
    }
}
