using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreate : MonoBehaviour
{
    public GameObject prefabEnemy;

    public Vector2 limitMin;
    public Vector2 limitMax;

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(CreateEnemy());
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    IEnumerator CreateEnemy()
    {
        while(true)
        {
            float r = Random.Range(limitMin.x, limitMax.x);
            Vector2 creatingPoint = new Vector2(r , limitMin.y);

            Instantiate(prefabEnemy, creatingPoint, Quaternion.identity);

            float creatingTime = Random.Range(0.5f, 3.0f);
            yield return new WaitForSeconds(creatingTime);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(limitMin, limitMax);
    }
}
