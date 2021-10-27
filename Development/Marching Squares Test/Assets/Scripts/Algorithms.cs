using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class Algorithms
{
    /* Random walk algorithm to create somewhat natural-looking rooms.
     * Use a HashSet to ignore all duplicate tiles the random walk comes across.
     */
    public static HashSet<Vector2Int> RandomWalk(Vector2Int startPos, int walkLength, int maxWidth, int maxHeight)
    {

        HashSet<Vector2Int> path = new HashSet<Vector2Int>();

        path.Add(startPos);
        var prevPos = startPos;

        for (int i = 0; i < walkLength; i++)
        {
            var newPos = prevPos + Direction.GetRandomDirection(DirectionsToIgnore(prevPos, maxWidth, maxHeight));
            path.Add(newPos);
            prevPos = newPos;
        }

        return path;
    }

    // Respect bounds by blocking directions that would lead outside of them.
    private static Vector2Int[] DirectionsToIgnore(Vector2Int pos, int maxWidth, int maxHeight)
    {
        // There is a maximum of two directions to ignore.
        Vector2Int[] dirs = new Vector2Int[2];

        // Corners
        if (pos.x >= maxWidth - 1 && pos.y >= maxHeight - 1)
        {
            dirs[0] = Vector2Int.right;
            dirs[1] = Vector2Int.up;
        }
        if (pos.x <= 1 && pos.y >= maxHeight - 1)
        {
            dirs[0] = Vector2Int.left;
            dirs[1] = Vector2Int.up;
        }
        if (pos.x >= maxWidth - 1 && pos.y <= 1)
        {
            dirs[0] = Vector2Int.right;
            dirs[1] = Vector2Int.down;
        }
        if (pos.x <= 1 && pos.y <= 1)
        {
            dirs[0] = Vector2Int.left;
            dirs[1] = Vector2Int.down;
        }
        // Sides
        if (pos.x >= maxWidth - 1)
            dirs[0] = Vector2Int.right;
        if (pos.x <= 1)
            dirs[0] = Vector2Int.left;
        if (pos.y >= maxHeight - 1)
            dirs[0] = Vector2Int.up;
        if (pos.y <= 1)
            dirs[0] = Vector2Int.down;

        /*for (int i = 0; i < dirs.Length; i++)
        {
            Debug.LogWarning($"Dirs: {dirs[i]}");
        }*/

        return dirs;
    }
}
