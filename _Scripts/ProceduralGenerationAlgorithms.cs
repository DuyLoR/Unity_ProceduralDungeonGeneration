using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The algorithms will be available for any class that wants to access
/// <summary>
/// This is the procedural of generation algorithms
/// </summary>
public static class ProceduralGenerationAlgorithms
{
    //start the algorithms RAMDOM WARK
    public static HashSet<Vector2Int> SimpleRandomWalk(Vector2Int startPosition, int walkLength)
    {
        // Hashset<data> simply remove duplicates since we are using random walk and random walk can step on the same field twice
        // //and there is no need to process the same field

        HashSet<Vector2Int> path = new HashSet<Vector2Int>();
        path.Add(startPosition);
        var previousPosition = startPosition;

        for (int i = 0; i < walkLength; i++)
        {
            var newPosition = previousPosition + Direction2D.GetRandomCardinal8Direction();
            path.Add(newPosition);
            previousPosition = newPosition;
        }
        return path;
    }
    /// <summary>
    /// Create corridors, the last on our path to get the next start position --> no need HashSet
    /// </summary>
    /// <param name="startPosition"></param>
    /// <param name="corridorLength"></param>
    /// <returns></returns>
    public static List<Vector2Int> RandomWalkCorridor(Vector2Int startPosition, int corridorLength)
    {
        List<Vector2Int> corridor = new List<Vector2Int>();
        var direction = Direction2D.GetRandomCardinalDirection();
        var currentPosition = startPosition;
        corridor.Add(currentPosition);
        for (int i = 0; i < corridorLength; i++)
        {
            currentPosition += direction;
            corridor.Add(currentPosition);
        }
        return corridor;
    }
}

/// <summary>
/// this class will allow us to get a random direction
/// </summary>
public static class Direction2D
{
    /// <summary> 
    ///danh sach cac huong chinh<cardinaldirections>
    /// </summary>
    public static List<Vector2Int> cardinalDirectionsList = new List<Vector2Int>
    {
        new Vector2Int(0, 1),   //UP
        new Vector2Int(1, 0),   //RIGHT
        new Vector2Int(0, -1),  //DOWN
        new Vector2Int(-1, 0),  //LEFT
    };

    public static List<Vector2Int> cardinal8DirectionsList = new List<Vector2Int>
    {
        new Vector2Int(0, 1),   //UP
        new Vector2Int(1, 1),   //UP-RIGHT
        new Vector2Int(1, 0),   //RIGHT
        new Vector2Int(1, -1),   //RIGHT-DOWN
        new Vector2Int(0, -1),  //DOWN
        new Vector2Int(-1, -1),  //DOWN-LEFT
        new Vector2Int(-1, 0),  //LEFT
        new Vector2Int(-1, 1),  //LEFT-UP
    };

    public static Vector2Int GetRandomCardinalDirection()
    {
        return cardinalDirectionsList[Random.Range(0, cardinalDirectionsList.Count)];
    }
    public static Vector2Int GetRandomCardinal8Direction()
    {
        return cardinal8DirectionsList[Random.Range(0, cardinal8DirectionsList.Count)];
    }
}
