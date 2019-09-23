using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;//施加力需要得到刚体

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();//获取组件
        int number = Random.Range(0,2);// generate 0 or 1
        if(number==1){
            rigidbody2D.AddForce(new Vector2(100,0));//往x方向施加100的力，也就是右边
        }else{
            rigidbody2D.AddForce(new Vector2(-100,0));//左
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
