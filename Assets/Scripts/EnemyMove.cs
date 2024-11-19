using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private Rigidbody RB;
    private GameObject player;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -20){ Destroy(gameObject);}
        RB.AddForce((player.transform.position - transform.position).normalized * speed);
    }
}
