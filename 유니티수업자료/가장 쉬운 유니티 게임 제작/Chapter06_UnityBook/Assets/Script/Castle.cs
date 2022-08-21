using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Castle : MonoBehaviour {
    
    private float MaxHp;
    private float Damge;
    public Image GuageBar;

    // Use this for initialization
    void Start () {
        MaxHp = 10; // 최대 체력
        Damge = 1; // 몬스터에게 입는 데미지
        GuageBar = GameObject.Find("HpGuage").GetComponent<Image>(); // 이미지 컴포넌트를 받아온다
        GuageBar.fillAmount = 1; // 처음 시작 시 게이지바를 최대로 설정한다

    }
	
	// Update is called once per frame
	void Update () {
		if(GuageBar.fillAmount <= 0) //게이지 바가 0 이하가 된다면 == 성 체력이 바닥나면
        {
            SceneManager.LoadScene("GameOver");
        }
	}

    private void OnTriggerEnter2D(Collider2D collision) // 물리충돌이 일어날 때 실행되는 함수
    {
        GuageBar.fillAmount -= Damge / MaxHp; //  게이지를 데미지만큼 감소한다
        Destroy(collision.gameObject); // 성에 부딛힌 적이 죽음
    }
}
