using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraDrag : MonoBehaviour
{
    private Transform tr;
    private Vector2 firstTouch;
    public float limitMinY;
    public float limitMaxY;

	// Use this for initialization
	void Start ()
    {
        tr = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Move();
	}


    void Move()
    {
        if(Input.GetMouseButtonDown(0))
        {
            firstTouch = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if(Input.GetMouseButton(0))
        {

            Vector2 currentTouch = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Vector2.Distance(firstTouch, currentTouch) > 0.4f)  //드래그 범위일 때
            {
                if (firstTouch.y < currentTouch.y)   //처음 터치보다 위로 드래그함
                {
                    if(tr.position.y > limitMinY)   //카메라 드래그 가능 범위
                        tr.Translate(Vector2.down * 0.05f);
                }
                else if(firstTouch.y > currentTouch.y)
                {
                    if (tr.position.y < limitMaxY)  //카메라 드래그 가능 범위
                        tr.Translate(Vector2.up * 0.05f);
                }
            }
        }
        
    }
}
