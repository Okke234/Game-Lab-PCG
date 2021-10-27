using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Direction
{
    private static List<Vector2Int> directionsList = new List<Vector2Int> {
        new Vector2Int(0,1),
        new Vector2Int(0,-1),
        new Vector2Int(1,0),
        new Vector2Int(-1,0),
    };

    public static Vector2Int GetRandomDirection(Vector2Int[] blockedDirs)
    {
        /*for (int i = 0; i < blockedDirs.Length; i++)
        {
            Debug.Log(blockedDirs[i]);
        }*/
        List<Vector2Int> dirs = new List<Vector2Int> {
        new Vector2Int(0,1),
        new Vector2Int(0,-1),
        new Vector2Int(1,0),
        new Vector2Int(-1,0),
        };
        //Debug.Log($"First Dirs: {dirs.Count}");
        foreach (var blockedDir in blockedDirs)
        {
            dirs.Remove(blockedDir);
        }
        //Debug.Log($"Second Dirs: {dirs.Count}");
        //Debug.Log($"List: {directionsList.Count}");
        return dirs[Random.Range(0, dirs.Count)];
    }
}
