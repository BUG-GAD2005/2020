using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ShapePlacement : MonoBehaviour
{
    public Tilemap shapeTilemap;
    
    private List<Vector2> _shapeTileBaseList;

    private void Start()
    {
        _shapeTileBaseList = GetAllTiles(shapeTilemap);

        foreach (var t in _shapeTileBaseList)
        {
            Debug.Log(t);
        }
    }

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
    

}