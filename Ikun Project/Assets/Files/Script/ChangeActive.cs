using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeActive : MonoBehaviour
{
    public GameObject obj;
    bool status = false;
    // Start is called before the first frame update
    void Start()
    {
        obj.SetActive(status);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void changeActive()
    {
        if(status == false)
        {
            status = true;
            obj.SetActive(status);
        }
        else
        {
            status = false;
            obj.SetActive(status);
        }
    }
}
