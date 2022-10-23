using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	#region Player Variables
	[SerializeField] public float moveSpeed = 5;

	private Rigidbody2D rb2D;
	private SpriteRenderer sprite;
	private Animator anim;

	private Vector2 moveDirection;
	#endregion

	private void Start()
	{
		rb2D = GetComponent<Rigidbody2D>();
		sprite = GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator>();
	}

	private void Update()
    {
		moveDirection.x = Input.GetAxisRaw("Horizontal");
		moveDirection.y = Input.GetAxisRaw("Vertical");

		anim.SetFloat("Horizontal", moveDirection.x);
		anim.SetFloat("Vertical", moveDirection.y);
		anim.SetFloat("Speed", moveDirection.sqrMagnitude);

		if (moveDirection.x < 0)
			sprite.flipX = true;
		else
			sprite.flipX = false;
    }

	private void FixedUpdate()
	{
		moveDirection.Normalize();
		rb2D.MovePosition(rb2D.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
	}
}
