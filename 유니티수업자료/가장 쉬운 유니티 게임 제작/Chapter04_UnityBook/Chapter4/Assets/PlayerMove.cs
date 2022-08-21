using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public float speed;

    Transform tr;
    Vector2 mousePosition;

    public Vector2 limitPoint1;
    public Vector2 limitPoint2;

    public GameObject prefabBullet;

	void Start ()
    {
        tr = GetComponent<Transform>();

        StartCoroutine(FireBullet());
	}
	
	void Update ()
    {
        if(Input.GetMouseButton(0))
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if(mousePosition.x < limitPoint1.x)
            {
                mousePosition = new Vector2(limitPoint1.x, mousePosition.y);
            }
            if(mousePosition.y > limitPoint1.y)
            {
                mousePosition = new Vector2(mousePosition.x, limitPoint1.y);
            }
            if (mousePosition.x > limitPoint2.x)
            {
                mousePosition = new Vector2(limitPoint2.x, mousePosition.y);
            }
            if (mousePosition.y < limitPoint2.y)
            {
                mousePosition = new Vector2(mousePosition.x, limitPoint2.y);
            }

            tr.position = Vector2.MoveTowards(tr.position, mousePosition, Time.deltaTime * speed);
        }
        
	}

    IEnumerator FireBullet()
    {
        while(true)
        {
            Instantiate(prefabBullet, tr.position, Quaternion.identity);

            yield return new WaitForSeconds(0.3f);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(limitPoint1, new Vector2(limitPoint2.x, limitPoint1.y));
        Gizmos.DrawLine(limitPoint1, new Vector2(limitPoint1.x, limitPoint2.y));
        Gizmos.DrawLine(new Vector2(limitPoint1.x, limitPoint2.y), limitPoint2);
        Gizmos.DrawLine(new Vector2(limitPoint2.x, limitPoint1.y), limitPoint2);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene("GameOver");
    }
}
