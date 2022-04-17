using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    GameObject targetGoal;

    Rigidbody enemyRB;
    Vector3 whereLooks;
    float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
        targetGoal = GameObject.Find("Enviromant/Goals/Player Goal");
    }

    void FixedUpdate()
    {
        whereLooks = (targetGoal.transform.position - transform.position).normalized;
        enemyRB.AddForce(whereLooks * speed);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Enemy Goal")
        {
            Destroy(gameObject);
            PlayerController.score++;
            speed++;
        }
        else if (collision.gameObject.name == "Player Goal")
        {
            Destroy(gameObject);
            PlayerController.score--;
        }

    }
}
