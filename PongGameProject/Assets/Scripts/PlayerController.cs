using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public KeyCode upKey;
    public KeyCode downKey;

    public float speed;

    private Rigidbody2D rigidbody2D;
    private AudioSource audio;//得到声音组件

    

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(upKey))
        {
            rigidbody2D.velocity = new Vector2(0, speed);//x no speend, only y needs it
        }else if(Input.GetKey(downKey)){
            rigidbody2D.velocity = new Vector2(0, -speed);
            //// 如果同时按上下，满足第一个if就不会往下执行了。所以上优先于下
        }
        else
        {
            rigidbody2D.velocity = new Vector2(0, 0);
        }

    }

    void OnCollisionEnter2D() {
        
        //随机一下播放速度
        audio.pitch = Random.Range(0.8f, 1.2f);

        audio.Play();
        //Debug.Log("started");
    }
}
