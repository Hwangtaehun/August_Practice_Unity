using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Castle : MonoBehaviour
{
    private float MaxHp;
    private float Damge;
    public Image GuageBar;

    // Start is called before the first frame update
    void Start()
    {
        MaxHp = 10;
        Damge = 1;
        GuageBar = GameObject.Find("HpGuage").GetComponent<Image>();
        GuageBar.fillAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(GuageBar.fillAmount <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GuageBar.fillAmount -= Damge / MaxHp;
        Destroy(collision.gameObject);
    }
}
