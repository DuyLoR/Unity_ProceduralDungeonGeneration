using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WallGenerator
{
    /// <summary>
    /// Create walls with positions and tilemap, and what is wall type
    /// </summary>
    /// <param name="floorPositions"></param>
    /// <param name="tilemapVisualizer"></param>
    public static void CreateWalls(HashSet<Vector2Int> floorPositions, TilemapVisualizer tilemapVisualizer)
    {
        var basicWallPositions = FindWallsInDirections(floorPositions, Direction2D.cardinalDirectionsList);
        foreach (var position in basicWallPositions)
        {
            tilemapVisualizer.PaintSingleBasicWall(position);
        }
    }

    /// <summary>
    /// This function return HashSet<Vector2Int> contains position what is had 1 neighbourPosition not inside floorPosition <4 derection>
    /// </summary>
    /// <param name="floorPositions"></param>
    /// <param name="cardinalDirectionsList"></param>
    /// <returns></returns>
    private static HashSet<Vector2Int> FindWallsInDirections(HashSet<Vector2Int> floorPositions, List<Vector2Int> cardinalDirectionsList)
    {
        HashSet<Vector2Int> wallPositions = new HashSet<Vector2Int>();
        foreach (var position in floorPositions)
        {
            foreach (var direction in cardinalDirectionsList)
            {
                var neighbourPosition = position + direction;
                if (floorPositions.Contains(neighbourPosition) == false)
                {
                    wallPositions.Add(neighbourPosition);
                }
            }
        }
        return wallPositions;
    }
}
