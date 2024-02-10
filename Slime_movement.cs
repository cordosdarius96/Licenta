using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime_movement : MonoBehaviour
{

	public float movespeed;


	void Update()
	{
		transform.Translate(new Vector3(movespeed, 0, 0) * Time.deltaTime);
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("turn"))
		{
			movespeed *= -1;
		}
		if (collision.gameObject.CompareTag("Player"))
		{
			collision.gameObject.GetComponent<Character_Controller>().Death();
			Destroy(gameObject);
		}
	}

}