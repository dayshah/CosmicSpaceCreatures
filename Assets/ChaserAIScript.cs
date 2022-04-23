using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserAIScript : MonoBehaviour
{

	Animation anim;
	Rigidbody rb;
	public GameObject player;
	Rigidbody player_rb;
	private float velX;
	private float velZ;
	private float speed;
	private AudioSource jumpSound;
	private AudioSource wackSound;
	private AudioSource missSound;
	private bool touchingWall;

	void Start()
	{
		anim = GetComponent<Animation>();
		rb = GetComponent<Rigidbody>();
		player_rb = player.GetComponent<Rigidbody>();
		speed = 750.0f;
		AudioSource[] sounds = GetComponents<AudioSource>();
		jumpSound = sounds[0];
		wackSound = sounds[1];
		missSound = sounds[2];
	}

	// Update is called once per frame
	void Update()
	{
		Vector3 playerDisplacement = this.transform.position - player.transform.position;
		float playerDistance = Vector3.Magnitude(playerDisplacement);
		//Debug.Log(playerDistance);

		if (playerDistance < 15)
		{
			// Attack Animation
			AttackAni();

		} else if (playerDistance < 50)
        {
			speed = 1000.0f;
			// Run Animation
			if (!touchingWall)
			{
				RunAni();
				// Mushroom runs at player
				Vector3 rb_vel = this.transform.forward * speed * Time.deltaTime;
				rb_vel.y = 0;
				rb.velocity = rb_vel;
			} else
            {
				IdleAni();
            }
			
			// Mushroom turns to look at player
			this.transform.LookAt(player.transform);
			Vector3 eulerAngles = this.transform.rotation.eulerAngles;
			eulerAngles = new Vector3(0, eulerAngles.y, 0);
			this.transform.rotation = Quaternion.Euler(eulerAngles);

			

		} else
        {
			IdleAni();
			speed = 0;
			rb.velocity = new Vector3(0, 0, 0);
		}
	}

    private void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.layer == 10)
        {
			touchingWall = true;
        }
    }

	private void OnCollisionExit(Collision c)
	{
		if (c.gameObject.layer == 10)
		{
			touchingWall = false;
		}
	}

	private void JumpNoise()
	{
		jumpSound.Play();
	}

	public void IdleAni()
	{
		anim.CrossFade("Idle");
	}

	public void RunAni()
	{
		anim.CrossFade("Run");
	}

	public void AttackAni()
	{
		anim.CrossFade("Attack");
	}

	public void DamageAni()
	{
		anim.CrossFade("Damage");
	}

	public void DeathAni()
	{
		anim.CrossFade("Death");
	}

	public void Yeet()
    {
		if (Vector3.Magnitude(this.transform.position - player.transform.position) < 15)
        {
			wackSound.Play();
			Vector3 forceDir = (player.transform.position - this.transform.position).normalized;
			player_rb.AddForce(new Vector3(forceDir.x * 5000, 0, forceDir.z * 5000), ForceMode.VelocityChange);
			//player.transform.Translate(forceDir * 100);
			//player_rb.AddForce(forceVec, ForceMode.Impulse);
        } else
        {
			missSound.Play();
        }
    }
   
}
