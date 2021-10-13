using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Direction {
    public static List<Vector2Int> directionsList = new List<Vector2Int> {
        new Vector2Int(0,1),
        new Vector2Int(0,-1),
        new Vector2Int(1,0),
        new Vector2Int(-1,0),
    };

    public static Vector2Int GetRandomDirection() {
        return directionsList[Random.Range(0, directionsList.Count)];
    }
}
