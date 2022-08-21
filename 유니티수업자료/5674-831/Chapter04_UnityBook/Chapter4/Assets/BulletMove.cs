using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
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
        tr.Translate(Vector3.up * speed);
	}

    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(5.0f);
        Destroy(this.gameObject);
    }
}
