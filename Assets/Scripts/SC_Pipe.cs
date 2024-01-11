using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Pipe : MonoBehaviour

{
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			if (collision.gameObject.GetComponent<SC_Player>() != null)
				collision.gameObject.GetComponent<SC_Player>().ResetJump();
		}
	}
}

