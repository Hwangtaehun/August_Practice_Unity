using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyMove : MonoBehaviour
{
    public Vector2 point;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //위치 이동
        transform.position = Vector2.MoveTowards(transform.position, point, Time.deltaTime * 10f);

        //스프라이트 컬러 페이드 아웃
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, sr.color.a - 0.01f);
	}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(point, 0.2f);
    }
}
