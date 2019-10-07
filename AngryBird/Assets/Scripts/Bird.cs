using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//bird是世界坐标以中心为原点，mouse是屏幕坐标以左下为原点
public class Bird : MonoBehaviour
{
    private bool isClick = false;//默认没有点击
    public Transform rightPos;
    public float maxDis = 3;//默认最大距离3m

    private SpringJoint2D sp;
    private Rigidbody2D rg;

    private void Awake() {
        sp = GetComponent<SpringJoint2D>();//获取组件
        rg = GetComponent<Rigidbody2D>();
    }

    private void OnMouseDown() //鼠标按下调用
    {
        isClick=true;
        rg.isKinematic = true;//按鼠标的时候，不要dynamic
    }

    private void OnMouseUp() //鼠标抬起
    {
        isClick=false;
        rg.isKinematic = false;
        //Invoke用来处理函数延时调用。两个参数，第一个是方法名，第二个是延时的时间
        Invoke("Fly", 0.1f);
    }

    private void Update() {
        if(isClick){//鼠标一直按下，就要进行位置的跟随
            
            //通过摄像机位置把屏幕坐标转化成世界坐标：
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            //给小鸟坐标：两种方法
            //transform.position += new Vector3(0,0,10);//Camera的Z是-10，因此多加个10让小鸟能被看到
            transform.position += new Vector3(0,0,-Camera.main.transform.position.z);//减去Camera的z值

            //用Vector3.Distance计算两个向量的距离，结果是float的正数
            if(Vector3.Distance(transform.position, rightPos.position) > maxDis){//进行位置限定

                //小鸟位置减去右树枝位置，得到一个向量。用normalized单位化，只要方向不要值
                Vector3 pos = (transform.position - rightPos.position).normalized;
                pos*= maxDis;//最大长度的向量
                transform.position = pos + rightPos.position;//最后小鸟被限定的位置
            }
        }
    }
    void Fly(){
        sp.enabled = false;//鼠标抬起，弹簧组件禁用，就能飞出去
    }
}
