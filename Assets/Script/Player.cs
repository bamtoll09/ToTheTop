using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	Rigidbody2D rigidbody;
	bool isJumping;
	public float moveSpeed;
	public float jumpPower;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody2D>();
		isJumping = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Jump"))
			isJumping = true;

		Jump();
		Move();
	}

	void Move()
	{
		Vector3 movement = new Vector3(
			Input.GetAxis("Horizontal"),
			0.0f,
			0.0f
		);

		transform.Translate(movement * moveSpeed * Time.deltaTime);
	}

	void Jump()
	{
		if (!isJumping)
			return;

		rigidbody.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);

		isJumping = false;
	}
}
