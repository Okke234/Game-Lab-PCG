using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWalkMapGen : MonoBehaviour
{
    [SerializeField] private Transform parent;
    [SerializeField] private Object mapTile;
    [SerializeField] private Vector2Int startPos = Vector2Int.zero;
    [SerializeField] private List<Vector2Int> startPosList;
    [SerializeField] private int walkLength = 10;
    [SerializeField] private int iterations = 1;
    [SerializeField] private bool startFromRandomTile = false;
    private List<Tile> tileList = new List<Tile>();
    private Dictionary<Vector2Int, int> PosToRoomnumberDict = new Dictionary<Vector2Int, int>();

    public void GenerateMap()
    {
        if(tileList.Count > 0)
        {
            foreach (var tile in tileList)
            {
                Destroy(tile.gameObject);
            }
            tileList.Clear();
        }
        HashSet<Vector2Int> tilePositions;
        tilePositions = RandomWalkMultipleRooms();
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
                Vector2Int curPos;
                if (j > 0 && startFromRandomTile)
                {
                    curPos = GetRandomStartPos(tilePositions, i);
                }
                else
                {
                    curPos = startPosList[i];
                }
                var path = Algorithms.RandomWalk(curPos, walkLength);
                tilePositions.UnionWith(path);
                foreach (var pos in path)
                {
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
            GameObject newTile = Instantiate(mapTile, pos.position, new Quaternion(), parent) as GameObject;
            newTile.AddComponent<Tile>().RoomId = PosToRoomnumberDict[tile];
            tileList.Add(newTile.GetComponent<Tile>());
        }
    }

    private Vector2Int GetRandomStartPos(HashSet<Vector2Int> tiles, int roomNumber)
    {
        List<Vector2Int> RoomTiles = new List<Vector2Int>();
        foreach (var tile in tiles)
        {
            if (PosToRoomnumberDict[tile] == roomNumber)
            {
                RoomTiles.Add(tile);
            }
        }
        return RoomTiles[Random.Range(0, RoomTiles.Count)];
    }
}
