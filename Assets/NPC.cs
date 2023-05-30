using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
public float speed = 1.19f;
Vector3 pointA;
Vector3 pointB;

void Start()
{
    pointA = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
    pointB = new Vector3(transform.localPosition.x+3,transform.localPosition.y, transform.localPosition.z);
}

void Update()
{
    //PingPong between 0 and 1
    float time = Mathf.PingPong(Time.time * speed, 1);
    transform.localPosition = Vector3.Lerp(pointA, pointB, time);
}
}
