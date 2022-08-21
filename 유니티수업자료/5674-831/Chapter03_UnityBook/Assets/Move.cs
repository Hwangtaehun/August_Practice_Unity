using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    Transform tr;

    // Use this for initialization
    void Start()
    {
        /* //좌표 이동의 기본 원리
        tr = GetComponent<Transform>();

        tr.position = new Vector2(1, 0);
        */
    }

    // Update is called once per frame
    void Update()
    {
        tr = GetComponent<Transform>();

        /* //키보드로 움직이는 방법 1

        if(Input.GetKey(KeyCode.RightArrow))
        {
            tr.position = new Vector2(tr.position.x + 0.01f, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            tr.position = new Vector2(tr.position.x - 0.01f, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            tr.position = new Vector2(tr.position.y + 0.01f, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            tr.position = new Vector2(tr.position.y - 0.01f, 0);
        }

        */





        /* //키보드로 움직이는 방법 2 (단축)

        float x = Input.GetAxis("Horizontal") * 0.01f;
        float y = Input.GetAxis("Vertical") * 0.01f;

        tr.Translate(new Vector2(x, y));

        */


        //마우스(터치)로 움직이기

        if(Input.GetMouseButton(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            tr.position = Vector2.MoveTowards(tr.position, mousePosition, Time.deltaTime * 5f);
        }



    }
}
