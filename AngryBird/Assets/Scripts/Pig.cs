using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : MonoBehaviour
{
    public float maxSpeed;
    public float minSpeed;
    private SpriteRenderer render;//获取图片组件，受伤要换图

    public Sprite hurt;//用来放受伤的猪

    private void Awake()
    {
        render = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //print(collision.relativeVelocity.magnitude); //控制台可以输出碰撞的速度来调整合适的最大最小速度

        //用相对速度判断，通过.magnitude转换成值
        if(collision.relativeVelocity.magnitude > maxSpeed){//直接死亡
            Destroy(gameObject);
        }else if(collision.relativeVelocity.magnitude >minSpeed && collision.relativeVelocity.magnitude < maxSpeed){
            render.sprite = hurt;//图片替换成受伤的猪
        }
    }
}
