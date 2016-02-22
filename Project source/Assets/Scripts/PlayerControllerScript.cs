using UnityEngine;
using System.Collections;

public class PlayerControllerScript : MonoBehaviour {

	public float maxSpeed = 10f;
	public float jumpForce = 700f;

	bool facingRight = true;
	public float velMod =1;
	public bool dblJmpGli=false;
	public bool doubleJump = false;
	public int numJumps = 0;
	public AudioSource audioJump;

	Animator anim;

	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.1f;
	public LayerMask whatIsGround;

	void Start ()
	{
		anim = GetComponent<Animator> ();

	}

	void Update()
	{
		if ((grounded || !doubleJump) && Input.GetButtonDown("Jump"))
		{
			jump ();
		}
	}

	public void jump()
	{	
		audioJump.Play ();
		anim.SetBool("Ground", false);
		
		rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 0);
		
		rigidbody2D.AddForce(new Vector2(0, jumpForce));
		if(!grounded)
		{
			doubleJump = true;
			
		}
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool ("Ground", grounded);

		if(grounded && !dblJmpGli)
			doubleJump = false;

		anim.SetFloat ("vSpeed", rigidbody2D.velocity.y);

		float move = Input.GetAxis ("Horizontal") * velMod;

		anim.SetFloat("Speed", Mathf.Abs(move));

		rigidbody2D.velocity = new Vector2 (maxSpeed * move, rigidbody2D.velocity.y);

		if(move > 0 && !facingRight)
			Flip();
		else if(move < 0 && facingRight)
			Flip();
	}

	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
