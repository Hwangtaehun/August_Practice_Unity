using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Work : MonoBehaviour
{
    public GameObject prefabMoney;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(Move());
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(EventSystem.current.IsPointerOverGameObject() == false)
            {
                CreateMoney();
            }
        }
            
    }

    IEnumerator Move()
    {
        while (true)
        {

            if(Input.GetMouseButtonDown(0))
            {
                GetComponent<Animator>().SetTrigger("click");
            }
            yield return new WaitForSeconds(0.01f);
        }
    }

    void CreateMoney()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        GameObject obj = Instantiate(prefabMoney, mousePosition, Quaternion.identity);

        GameObject text = obj.transform.Find("Canvas").transform.Find("Text").gameObject;
        text.GetComponent<Text>().text = "+ " + 
            GameManager.gm.moneyIncreaseAmount.ToString("###,###");

        GameManager.gm.money += GameManager.gm.moneyIncreaseAmount;

        Destroy(obj, 7f);
    }
}
