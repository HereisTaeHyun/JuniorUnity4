using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    private GameObject player;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDir = (player.transform.position - transform.position).normalized;
        rb.AddForce(lookDir * speed);

        if(transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
