using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWalkMapGen : MonoBehaviour
{
    [SerializeField] private Object mapTile;
    [SerializeField] private Vector2Int startPos = Vector2Int.zero;
    [SerializeField] private List<Vector2Int> startPosList;
    [SerializeField] private int walkLength = 10;
    private List<GameObject> tileList = new List<GameObject>();

    public void GenerateMap() {
        HashSet<Vector2Int> tilePositions;
        if (startPosList.Count > 0) {
            tilePositions = RandomWalkMultipleRooms();
            Debug.LogWarning("Multiple!");
        } else {
            tilePositions = RandomWalk();
            Debug.LogWarning("Single!");
        }
        foreach (var pos in tilePositions) {
            Debug.Log(pos);
        }
        DrawTiles(tilePositions);
    }

    private HashSet<Vector2Int> RandomWalk() {
        var curPos = startPos;
        HashSet<Vector2Int> tilePositions = new HashSet<Vector2Int>();
        var path = Algorithms.RandomWalk(curPos, walkLength);

        tilePositions.UnionWith(path);
        return tilePositions;
    }

    private HashSet<Vector2Int> RandomWalkMultipleRooms() {
        HashSet<Vector2Int> tilePositions = new HashSet<Vector2Int>();
        for (int i = 0; i < startPosList.Count; i++) {
            var curPos = startPosList[i];
            var path = Algorithms.RandomWalk(curPos, walkLength);
            tilePositions.UnionWith(path);
        }
        return tilePositions;
    }

    private void DrawTiles(HashSet<Vector2Int> tiles) {
        foreach (var tile in tiles) {
            Transform pos = gameObject.transform;
            pos.position = (Vector3Int)tile;
            var newTile = Instantiate(mapTile, pos.position, new Quaternion());
            tileList.Add((GameObject)newTile);
        }
    }
}
