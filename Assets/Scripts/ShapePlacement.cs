using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ShapePlacement : MonoBehaviour
{
    #region Public Methods

    public List<Vector2> GetAllTiles(Tilemap tilemap)
    {
        var resArray = new List<Vector2>();

        var bounds = tilemap.cellBounds;
        for (int x = bounds.min.x; x < bounds.max.x; x++)
        {
            for (int y = bounds.min.y; y < bounds.max.y; y++)
            {
            
                var cellPosition = new Vector3Int(x, y, 0);
                var tile = tilemap.GetTile(cellPosition);

                if (tile == null) continue;

                resArray.Add(new Vector2(x, y));
            }

        }
        return resArray;
    }

    #endregion
}