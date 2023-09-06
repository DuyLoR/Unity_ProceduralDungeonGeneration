using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "WallRuleTile", menuName = "Tiles/Wall Rule Tile")]
public class WallRuleTile : RuleTile<WallRuleTile.Neighbor>
{
    public enum TileType
    {
        Floor,
        Wall,
    }

    public class Neighbor : TilingRule.Neighbor
    {
        public const int IsFloor = 3;
        public const int IsNotFloor = 4;
    }

    public Tilemap floorTilemap;

    /// <summary>
    /// Checks if there is a match given the neighbor matching rule and a Tile.
    /// </summary>
    /// <param name="neighbor">Neighbor matching rule.</param>
    /// <param name="other">Tile to match.</param>
    /// <returns>True if there is a match, False if not.</returns>
    public override bool RuleMatch(int neighbor, TileBase tile)
    {
        if (tile == null)
            return false;

        TileType tileType = TileType.Floor; // Sử dụng giá trị mặc định là Floor

        if (floorTilemap != null)
        {
            // Kiểm tra xem Tile tại vị trí cụ thể có phải là Floor hay không
            Vector3Int tilePosition = new Vector3Int(0, 0, 0);
            TileBase floorTile = floorTilemap.GetTile(tilePosition);

            if (floorTile != null)
            {
                // Nếu có Tile trên floorTilemap, thì đánh dấu là Floor
                tileType = TileType.Floor;
            }
            else
            {
                // Nếu không có Tile trên floorTilemap, thì đánh dấu là Wall
                tileType = TileType.Wall;
            }
        }

        switch (neighbor)
        {
            case Neighbor.This:
                return true;
            case Neighbor.NotThis:
                return false;
            case Neighbor.IsFloor:
                return tileType == TileType.Floor;
            case Neighbor.IsNotFloor:
                return tileType != TileType.Floor;
        }
        return base.RuleMatch(neighbor, tile);
    }
}
