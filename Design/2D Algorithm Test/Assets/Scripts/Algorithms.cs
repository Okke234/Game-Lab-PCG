using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class Algorithms {
    /* Random walk algorithm to create somewhat natural-looking rooms.
     * Use a HashSet to ignore all duplicate tiles the random walk comes across.
     */
    public static HashSet<Vector2Int> RandomWalk(Vector2Int startPos, int walkLength) {

        HashSet<Vector2Int> path = new HashSet<Vector2Int>();

        path.Add(startPos);
        var prevPos = startPos;

        for(int i = 0; i < walkLength; i++) {
            var newPos = prevPos + Direction.GetRandomDirection();
            path.Add(newPos);
            prevPos = newPos;
        }

        return path;
    }
}
