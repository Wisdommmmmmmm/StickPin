using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinManage : MonoBehaviour
{
    public float speed = 50;
    private bool isAtStart = false;
    private bool isClick = false;
    private Transform StartPoint;
    private Transform Circle;
    private Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        StartPoint = GameObject.Find("StartPoint").transform;
        Circle = GameObject.Find("Circle").transform;
        target = Circle.transform.position;
        target.y = 0.55f;
    }

    // Update is called once per frame
    void Update()
    {
        if(isAtStart == false)
        {

            transform.position = Vector3.MoveTowards(transform.position, StartPoint.position, speed*Time.deltaTime);
            if(Vector3.Distance(transform.position, StartPoint.position) < 0.001f)
            {
                isAtStart = true;
            }
        }
        else
        {
            if(isClick)
            {
                transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
                if(Vector3.Distance(transform.position, target) < 0.001f)
                {
                    transform.position = target;
                    transform.parent = Circle;
                    isClick = false;
                }
            }
        }
    }
    public void Go()
    {
        isAtStart = true;
        isClick = true;
    }
}
