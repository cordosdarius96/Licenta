using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathFall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Character_Controller>().Death();
            Destroy(gameObject);
        }
    }
}
