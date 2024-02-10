using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_Attack : MonoBehaviour
{

    private float timeBtwShots;
    public float startTimeBtwShots;
    public GameObject Fire;

    void Start()
    {
        timeBtwShots = startTimeBtwShots;
    }
    void Update()
    {
        if(timeBtwShots <= 0)
        {
            Instantiate(Fire, transform.position,Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
