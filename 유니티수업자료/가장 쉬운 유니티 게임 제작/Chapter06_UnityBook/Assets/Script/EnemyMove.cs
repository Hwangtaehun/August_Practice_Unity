using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

    Transform tr;
    public float speed;

	void Start () {
        tr = GetComponent<Transform>();
    }
	
	void Update () {
        tr.Translate(Vector2.left * speed * Time.deltaTime);
    }
}