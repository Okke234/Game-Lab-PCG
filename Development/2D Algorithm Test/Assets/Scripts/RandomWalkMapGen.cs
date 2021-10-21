using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWalkMapGen : MonoBehaviour
{
    [SerializeField] private Object mapTile;
    [SerializeField] private Vector2Int startPos = Vector2Int.zero;
    [SerializeField] private List<Vector2Int> startPosList;
    [SerializeField] private int walkLength = 10;
    [SerializeField] private int iterations = 1;
    [SerializeField] private bool startFromRandomTile;
    private List<GameObject> tileList = new List<GameObject>();
    private Dictionary<Vector2Int, int> PosToRoomnumberDict = new Dictionary<Vector2Int, int>();

    public void GenerateMap()
    {
        HashSet<Vector2Int> tilePositions;
        tilePositions = RandomWalkMultipleRooms();
        /*Debug.LogWarning("Multiple!");
        foreach (var pos in tilePositions)
        {
            Debug.Log(pos);
        }*/
        DrawTiles(tilePositions);
    }

    //Obsolete.
    private HashSet<Vector2Int> RandomWalk()
    {
        var curPos = startPos;
        HashSet<Vector2Int> tilePositions = new HashSet<Vector2Int>();
        var path = Algorithms.RandomWalk(curPos, walkLength);
        tilePositions.UnionWith(path);
        return tilePositions;
    }

    private HashSet<Vector2Int> RandomWalkMultipleRooms()
    {
        HashSet<Vector2Int> tilePositions = new HashSet<Vector2Int>();
        for (int i = 0; i < startPosList.Count; i++)
        {
            for (int j = 0; j < iterations; j++)
            {
                var curPos = startPosList[i];
                var path = Algorithms.RandomWalk(curPos, walkLength);
                tilePositions.UnionWith(path);
                foreach (var pos in path)
                {
                    //Debug.Log(pos);
                    if (!PosToRoomnumberDict.ContainsKey(pos))
                    {
                        PosToRoomnumberDict.Add(pos, i);
                    }
                }
            }
        }
        return tilePositions;
    }

    private void DrawTiles(HashSet<Vector2Int> tiles)
    {
        foreach (var tile in tiles)
        {
            Transform pos = gameObject.transform;
            pos.position = (Vector3Int)tile;
            GameObject newTile = Instantiate(mapTile, pos.position, new Quaternion()) as GameObject;
            tileList.Add((GameObject)newTile);
        }
    }
}
