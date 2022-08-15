using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    float currentTime;
    float minTime = 0.5f;
    float maxTime = 1.5f;
    public float createTime = 1.0f;
    public GameObject enemyFactory;
    public int poolSize = 10;
    public List<GameObject> enemyObjectPool;
    public Transform[] spawnPosition;


    // Start is called before the first frame update
    void Start()
    {
        createTime = Random.Range(minTime, maxTime);

        enemyObjectPool = new List<GameObject>();
        for(int i = 0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(enemyFactory);
            enemyObjectPool.Add(enemy);
            enemy.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > createTime)
        {
            if(enemyObjectPool.Count > 0)
            {
                GameObject enemy = enemyObjectPool[0];
                enemyObjectPool.Remove(enemy);
                int index = Random.Range(0, spawnPosition.Length);
                enemy.transform.position = spawnPosition[index].position;
                enemy.SetActive(true);
            }

            //for (int i = 0; i < poolSize; i++)
            //{
            //    GameObject enemy = enemyObjectPool[i];
            //    if(enemy.activeSelf == false)
            //    {
            //        enemy.transform.position = transform.position;        
            //    }
            //}

            createTime = Random.Range(minTime, maxTime);
            currentTime = 0;           
        }
    }
}
