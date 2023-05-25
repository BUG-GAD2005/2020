using UnityEngine;
using UnityEngine.Tilemaps;

public class ObjectDrag : MonoBehaviour
{
    private Vector3 _initialMouseOffset;
    private Vector3 _initialObjPos;
    private Tilemap _shapeTilemap;
    private Camera _mainCamera;

    private void Start()
    {
        _shapeTilemap = GetComponent<Tilemap>();
        _mainCamera = Camera.main;
    }

    private void OnMouseDown()
    {
        var initialMousePos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        _initialObjPos = transform.position;
        _initialMouseOffset = _initialObjPos - initialMousePos;
    }

    private void OnMouseDrag()
    {
        var currentMousePos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        var targetPos = currentMousePos + _initialMouseOffset;

        transform.position = targetPos;
    }

    private void OnMouseUp()
    {
        var currentMousePos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        var targetPos = currentMousePos + _initialMouseOffset;

        if (MainLogic.Instance.CheckValidPlacement(_shapeTilemap, targetPos))
        {
            Debug.Log("Object dropped in valid position");
            Destroy(gameObject.transform.parent.parent.gameObject);
        }
        else
        {
            transform.position = _initialObjPos;
        }
    }
}