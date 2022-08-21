using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FireController : MonoBehaviour {

	public Transform Aimtr;
	public AudioSource audio;

	private void Start()
	{
		Aimtr = GameObject.Find("AimSpot").GetComponent<Transform>();
		Cursor.lockState = CursorLockMode.Locked;
		audio = GetComponent<AudioSource>();
		audio.mute = true;
	}

	void Update () {
		if (Input.GetMouseButton(0))
		{
			audio.mute = false;
			RaycastHit hit;

			if (Physics.Raycast(Aimtr.position, Aimtr.transform.forward, out hit))
			{
				if (hit.collider.tag == "enemy") 
				{
					hit.collider.gameObject.GetComponent<Animator>().SetBool("Damaged", true);
					hit.collider.gameObject.GetComponent<NavMeshAgent>().speed = 0f;
					Destroy(hit.collider.gameObject, 3.0f);
				}
			}
		}
		else
		{
			audio.mute = true;
		}
	}
}
