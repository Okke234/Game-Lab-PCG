using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Direction
{
    /* Werkt niet want static. Schrijf zeker in article :)
     * private static List<Vector2Int> directionsList = new List<Vector2Int> {
        new Vector2Int(0,1),
        new Vector2Int(0,-1),
        new Vector2Int(1,0),
        new Vector2Int(-1,0),
    };*/

    public static Vector2Int GetRandomDirection(Vector2Int[] blockedDirs)
    {
        List<Vector2Int> dirs = new List<Vector2Int> {
        new Vector2Int(0,1),
        new Vector2Int(0,-1),
        new Vector2Int(1,0),
        new Vector2Int(-1,0),
        };
        foreach (var blockedDir in blockedDirs)
        {
            dirs.Remove(blockedDir);
        }
        return dirs[Random.Range(0, dirs.Count)];
    }
}
