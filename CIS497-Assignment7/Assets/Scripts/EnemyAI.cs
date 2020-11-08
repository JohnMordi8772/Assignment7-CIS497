/*
John Mordi
Assignment #7
Makes the enemies constantly try to run into the player and push them off
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Rigidbody enemyRb;
    public GameObject player;
    public float speed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //vector for direction from enemy to player
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        //add force in direction of player
        enemyRb.AddForce(lookDirection * speed);

        if(transform.position.y <= -10)
        {
            Destroy(gameObject);
        }
    }
}
