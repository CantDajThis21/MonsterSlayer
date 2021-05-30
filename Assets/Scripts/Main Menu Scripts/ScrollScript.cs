using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollScript : MonoBehaviour
{
    public float speed = 0.5f;
    private Vector2 StartPosition;

    void Start(){
        StartPosition = transform.position;
    }

    void Update(){
       transform.Translate(Vector3.left*speed*Time.deltaTime);
    }
}
