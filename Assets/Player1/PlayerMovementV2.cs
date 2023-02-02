using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
using UnityEngine.SceneManagement;

public class PlayerMovementV2 : MonoBehaviour
{
	[SerializeField] private float speed;
	[SerializeField] private float turnSpeed;
	[SerializeField] private float jumpForce;
	[SerializeField] private LayerMask groundLayer;
	private Animator anim;
	private Rigidbody rb;
	private bool isGrounded;
	private float facing;
	public Rewired.Player player;
	private Transform cameraReference;

    public float Health { get; internal set; }

    private void Start()
    {
		player = ReInput.players.GetPlayer(0);
		anim = gameObject.GetComponentInChildren<Animator>();
		rb = GetComponent<Rigidbody>();
		cameraReference = Camera.main.transform.GetChild(0).transform;
	}

    private void Update()
    {
		Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal") * speed, 0, Input.GetAxis("Vertical") * speed);
		moveDirection = cameraReference.TransformDirection(moveDirection);
		rb.velocity = new Vector3(moveDirection.x, rb.velocity.y, moveDirection.z);

		isGrounded = Physics.CheckSphere(transform.position, 0.5f, groundLayer);
		if (isGrounded == true)
        {
			anim.SetBool("isGrounded", true);

			if (player.GetButtonDown("Jump"))
			{
				Debug.Log("Hello");
				Jump();
			}
		}
		else
			anim.SetBool("isGrounded", false);

		if (moveDirection.z != 0 || moveDirection.x != 0)
		{
			facing = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;
			anim.SetBool("isMoving", true);
		}
		else
			anim.SetBool("isMoving", false);

		rb.rotation = Quaternion.Euler(0, facing, 0);
		cameraReference.eulerAngles = new Vector3(0, cameraReference.eulerAngles.y, 0);
	}
	private void Jump()
	{
		SoundManagerAAA1 sm = GameObject.Find("SoundManeger").GetComponent<SoundManagerAAA1>();
		sm.PlayJump();
		isGrounded = false;
		anim.SetTrigger("jumped");
		rb.AddForce(Vector3.up * jumpForce);
	}

    private void OnCollisionStay(Collision collision)
    {
		if (collision.gameObject.CompareTag("MovingPlatform") && isGrounded == true)
			transform.parent = collision.transform;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("MovingPlatform"))
            transform.parent = null;
    }
}