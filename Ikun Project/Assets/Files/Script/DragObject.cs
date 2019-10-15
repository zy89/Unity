using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 pos;
    private float mzcoord;
    private void OnMouseDown()
    {
        pos = gameObject.transform.position - getMousePos();
        mzcoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
    }

    private Vector3 getMousePos()
    {
        Vector3 point = Input.mousePosition;
        pos.z = mzcoord;
        return Camera.main.ScreenToWorldPoint(pos);
    }

    private void OnMouseDrag()
    {
        transform.position = getMousePos() + pos;
    }
}
