using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoWork : MonoBehaviour
{
    Transform trPerson;

	// Use this for initialization
	void Start ()
    {
        trPerson = gameObject.transform.Find("person").transform;

        StartCoroutine(Move());
        StartCoroutine(MoneyPlus());
	}
	
	IEnumerator Move()
    {
        float originY = trPerson.position.y;
        while(true)
        {
            Vector2 movingPoint = new Vector2(trPerson.position.x,
            Random.Range(originY - 0.03f, originY + 0.01f));

            trPerson.position = Vector2.MoveTowards(trPerson.position, movingPoint, 3f);
            yield return new WaitForSeconds(0.06f);
        }
    }

    IEnumerator MoneyPlus()
    {
        while(true)
        {
            GameManager.gm.money += GameManager.gm.employeeIncreaseAmount;
            yield return new WaitForSeconds(1.0f);
        }
    }
}
