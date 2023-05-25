using GlobalVariables;
using Observer;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ObjectDrag : ObserverBase
{
    #region Serialized Variables

    [SerializeField] private Vector3 offset;

    #endregion

    #region Private Variables

    private Vector3 Pos => Camera.main.ScreenToWorldPoint(Input.mousePosition);
    private Vector3 _initialPos;
    private Tilemap _shapeTilemap;

    #endregion


    #region Monobehaviour Methods

    private void Awake(){
        _shapeTilemap = GetComponentInChildren<Tilemap>();
    } 

    private void OnEnable() 
    {
        _initialPos = transform.position;
    }

    private void OnMouseDrag() 
    {
        var transferPos = new Vector3(Pos.x, Pos.y, _initialPos.z);
        transform.position = transferPos + offset;
    }

    private void OnMouseUp()
    {   
        if(MainLogic.Instance.CheckValidPlacement(_shapeTilemap, Pos))
        {
            Push(CustomEvents.OnShapePlaced);
            Destroy(gameObject);
        }
        else{
            transform.position = _initialPos;
        }
    }

    #endregion
}