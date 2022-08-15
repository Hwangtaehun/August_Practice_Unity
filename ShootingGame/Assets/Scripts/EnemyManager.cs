using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    float currentTime;
    float minTime = 1;
    float maxTime = 5;
    public float createTime = 1;
    public GameObject enemyFactory;

    // Start is called before the first frame update
    void Start()
    {
        createTime = UnityEngine.Random.Range(minTime, maxTime);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > createTime)
        {
            GameObject enemy = Instantiate(enemyFactory);
            enemy.transform.position = transform.position;
            currentTime = 0;
            createTime = UnityEngine.Random.Range(minTime, maxTime);
        }
    }
}
