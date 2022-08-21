using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Transform tr;
    public float speed;

	// Use this for initialization
	void Start ()
    {
        tr = GetComponent<Transform>();
        StartCoroutine(DestroySelf());
	}
	
	// Update is called once per frame
	void Update ()
    {
        tr.Translate(Vector3.down * speed);
	}

    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(10.0f);
        Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject.Find("GameManager").GetComponent<Score>().score += 10;
        Destroy(gameObject);
        Destroy(collision.gameObject);
    }

}



