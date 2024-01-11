using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Coin : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
            if (col.gameObject.GetComponent<SC_Player>() != null)
                col.gameObject.GetComponent<SC_Player>().CoinCollected();
            Destroy(this.gameObject);
        }
    }

}
