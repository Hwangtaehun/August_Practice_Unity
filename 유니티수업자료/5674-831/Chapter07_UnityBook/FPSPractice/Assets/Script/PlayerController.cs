using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float speed;
	public float mouseSensitivity;

	public float RotationLimit;
	public float currRotationX;

	Camera MainCamera;
	Rigidbody rid;

	void Start()
	{
		rid = GetComponent<Rigidbody>();
		MainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
	}

	void Update()
	{
		PlayerMove();
		PlayerRotation();
		CameraRotation();
	}

	private void PlayerMove()
	{
		float moveX = Input.GetAxisRaw("Horizontal");
		float moveZ = Input.GetAxisRaw("Vertical");

		Vector3 moveHorizontal = transform.right * moveX;
		Vector3 moveVertical = transform.forward * moveZ;

		Vector3 velocity = (moveHorizontal + moveVertical).normalized * speed;

		rid.MovePosition(transform.position + velocity * Time.deltaTime);
	}

	private void PlayerRotation()
	{
		float rotationY = Input.GetAxisRaw("Mouse X");

		Vector3 playerRotaionY = new Vector3(0f, rotationY, 0f) * mouseSensitivity;

		rid.MoveRotation(rid.rotation * Quaternion.Euler(playerRotaionY));
	}

	private void CameraRotation()
	{
		float roateionX = Input.GetAxisRaw("Mouse Y");
		float cameraRotationX = roateionX * mouseSensitivity;
		currRotationX -= cameraRotationX;
		currRotationX = Mathf.Clamp(currRotationX, -RotationLimit, RotationLimit);

		MainCamera.transform.localEulerAngles = new Vector3(currRotationX, 0f, 0f);
	}
}