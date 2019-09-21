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
        ResetWall();//调用
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //新写一个设置墙位置的方法
    void ResetWall(){
        rightWall=transform.Find("rightWall").GetComponent<BoxCollider2D>();
        leftWall=transform.Find("leftWall").GetComponent<BoxCollider2D>();
        upWall=transform.Find("upWall").GetComponent<BoxCollider2D>();
        downWall=transform.Find("downWall").GetComponent<BoxCollider2D>();

        //高效方法：获取屏幕右上角点的世界坐标，存在temp里
        Vector3 tempPosition = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        //分别给4个墙
        upWall.transform.position = new Vector3(0, tempPosition.y+0.5f, 0);//自身宽1，所以向上再移动0.5
        upWall.size = new Vector2(tempPosition.x * 2, 1);

        downWall.transform.position = new Vector3(0, -tempPosition.y-0.5f, 0);//down就是负的
        downWall.size = new Vector2(tempPosition.x * 2, 1);

        rightWall.transform.position = new Vector3(tempPosition.x+0.5f, 0, 0);
        rightWall.size = new Vector2(1, tempPosition.y * 2);

        leftWall.transform.position = new Vector3(-tempPosition.x-0.5f, 0, 0);
        leftWall.size = new Vector2(1, tempPosition.y * 2);

        /* 低效
        //以上墙为例，坐标x是屏幕宽的一半，y是屏幕的高。也就是固定在屏幕上边框的中点
        //申明一个变量,获取上墙
        Vector3 upWallPosition = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width/2, Screen.height));
        upWall.transform.position = upWallPosition + new Vector3(0,0.5f,0);//赋值给upWall，y值上移0.5保证墙在镜头外
        //接下去是设置wall的size，宽与屏幕一样宽，高是1
        float width = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).x*2;
        upWall.size = new Vector2(width,1);
        */
    }
}
