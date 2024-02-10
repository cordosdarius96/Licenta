using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_fire : MonoBehaviour
{
    Rigidbody2D Rb;
    [SerializeField]
    float speed;
    [SerializeField]
    LayerMask HeroLayer;

    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 11.10f);
    }

    void Update()
    {
        if (Physics2D.Raycast(Rb.position, Vector2.left, 200f, HeroLayer))
        {
            Rb.velocity = Vector2.left * speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Character_Controller>().Death();
            Destroy(gameObject);
        }
    }
    
}
