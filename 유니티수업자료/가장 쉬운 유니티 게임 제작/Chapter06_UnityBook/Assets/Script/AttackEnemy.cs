using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemy : MonoBehaviour {

	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
        
            Vector2 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition); //터치한 곳을 월드좌표로 받아온다
            Ray2D ray = new Ray2D(wp, Vector2.zero); // 레이 기준설정
            
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction); //발사한 레이에 대한 반환값 받아옴

            if (hit.collider != null) //콜라이더가 맞았다면
            {
                if (hit.collider.tag == "enemy") // 레이 맞은 객체의 태그가 enemy라면
                {
                    Destroy(hit.collider.gameObject); // 그 객체 오브젝트를 파괴한다
                }
            }
        }
    }
}
