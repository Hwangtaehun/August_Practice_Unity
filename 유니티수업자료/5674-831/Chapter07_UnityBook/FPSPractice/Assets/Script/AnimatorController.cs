using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour {

	public Animator animator;
	public AnimationClip FireAnim;
	//public AnimatorStateInfo 

	void Start () {
		animator = GetComponent<Animator>();
		//animInfo = animator.GetCurrentAnimatorStateInfo(0);
	}

void Update() {

	if (Input.GetMouseButton(1))
	{
		animator.SetBool("Aim", true);

	}
	else
	{
		animator.SetBool("Aim", false);
	}

	if (Input.GetMouseButton(0))
	{
		animator.SetBool("Fire", true);
	}
	else
	{
		animator.SetBool("Fire", false);
	}
}
}
