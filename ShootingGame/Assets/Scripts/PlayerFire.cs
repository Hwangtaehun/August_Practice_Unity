using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletFactory;
    public int poolSize = 10;
    public List<GameObject> bulletObjectPool;
    //public GameObject firePosition;

    // Start is called before the first frame update
    void Start()
    {
        bulletObjectPool = new List<GameObject>();

        for(int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletFactory);

            bulletObjectPool.Add(bullet);
            bullet.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if(bulletObjectPool.Count > 0)
            {
                GameObject bullet = bulletObjectPool[0];
                bullet.SetActive(true);
                bulletObjectPool.Remove(bullet);

                bullet.transform.position = transform.position;
            }
        }
    }
}
