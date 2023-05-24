using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public bool isFull;
    public Color color;

    public Cell()
    {
        this.isFull = false;
        this.color = new Color32(25, 28, 25, 255);

    }
    private void Awake()
    {
        //GameObject parentObject = this.transform.parent.gameObject;
        SpriteRenderer spriteRenderer = this.GetComponent<SpriteRenderer>();
        spriteRenderer.color = color;
    }


}
