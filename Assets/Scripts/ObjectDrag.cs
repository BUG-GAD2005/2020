using UnityEngine;
using UnityEngine.Tilemaps;

public class ObjectDrag : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    
    private Vector3 Pos => Camera.main.ScreenToWorldPoint(Input.mousePosition);
    private Vector3 _initialPos;
    private Tilemap _shapeTilemap;


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
        if(MainLogic.Instance.CheckValidPlacement(_shapeTilemap, Pos)){
            Debug.Log("Object dropped in valid position");
            Destroy(gameObject);
        }
        else{
            transform.position = _initialPos;
        }
    }
}