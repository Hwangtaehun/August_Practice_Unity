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
#if UNITY_ANDROID
        GameObject.Find("Joystick canvas XYBZ").SetActive(true);
#elif UNITY_EDITOR || UNITY_STANDALONE
        GameObject.Find("Joystick canvas XYBZ").SetActive(false);
#endif
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        if(Input.GetButtonDown("Fire1"))
        {
            fire();
        }
#endif
    }

    public void fire()
    {
        if (bulletObjectPool.Count > 0)
        {
            GameObject bullet = bulletObjectPool[0];
            bullet.SetActive(true);
            bulletObjectPool.Remove(bullet);

            bullet.transform.position = transform.position;
        }
    }
}