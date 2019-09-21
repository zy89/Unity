using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private BoxCollider2D rightWall;//直接在代码里得到wall，设为private
    private BoxCollider2D leftWall;
    private BoxCollider2D downWall;
    private BoxCollider2D upWall;

    // Start is called before the first frame update
    void Start()
    {
        ResetWall();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ResetWall(){
        rightWall=transform.Find("rightWall").GetComponent<BoxCollider2D>();
        leftWall=transform.Find("leftWall").GetComponent<BoxCollider2D>();
        upWall=transform.Find("upWall").GetComponent<BoxCollider2D>();
        downWall=transform.Find("downWall").GetComponent<BoxCollider2D>();

        //以上墙为例，坐标x是屏幕宽的一半，y是屏幕的高。也就是固定在屏幕上边框的中点
        //申明一个变量,获取上墙
        Vector3 upWallPosition = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width/2, Screen.height));
        upWall.transform.position = upWallPosition;//赋值给upWall
    }
}
