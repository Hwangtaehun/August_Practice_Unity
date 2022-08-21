using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemy : MonoBehaviour
{
    public GameObject prfabEnemy;
    public Vector2 limitMin;
    public Vector2 limitMax;
    private float delay;
    private int count;

    void Start()
    {
        StartCoroutine(Create());
    }

    IEnumerator Create()
    {
        while(true)
        {
            float r = Random.Range(limitMin.y, limitMax.y);
            Vector2 creatingPoint = new Vector2(limitMax.x, r);

            Instantiate(prfabEnemy, creatingPoint, Quaternion.identity);

            delay = 10.0f / (count + 4);
            yield return new WaitForSeconds(delay);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawLine(limitMin, limitMax);
    }
}
