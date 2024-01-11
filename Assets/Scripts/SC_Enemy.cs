using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Enemy : MonoBehaviour
{

	private void Start()
	{
		

	}

	void Update()
	{

	}
	private void OnCollisionEnter2D(Collision2D collision)
	{

		if (collision.gameObject.tag == "Player")
		{
			if (collision.gameObject.GetComponent<SC_Player>() != null)
				collision.gameObject.GetComponent<SC_Player>().SetHealth(-20f);


		}
	}
}
