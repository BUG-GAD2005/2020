using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell 
{
    public int x;
    public int y;
    public bool isFull;
    Color color;

    public Cell(int x, int y, bool isFull=false, Color color= default(Color))
    {
        this.x = x;
        this.y = y;
        isFull = false;
        this.color = color == default(Color) ? new Color32(25, 28, 25, 255) : color;

    }


}
