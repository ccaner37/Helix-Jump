using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody rigidbody;
    public int combo;
    public bool gamerunning = true;

    public Transform electricEffect;
    public Transform deathEffect;
    public Transform comboEffect;
    public Transform goalEffect;

    private void Start()
    {
        rigidbody = transform.GetComponent<Rigidbody>();
    }


    // Avoid to jump too much.
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Death")
        {
            GameManager.Instance.Death();
        }
        if (collision.gameObject.tag == "Goal")
        {
            Instantiate(goalEffect, transform.position, Quaternion.identity, transform);
            StartCoroutine("RestartScene");
        }
        if (combo >= 3)
        {
            Destroy(collision.transform.parent.gameObject);
            Instantiate(comboEffect, transform.position, Quaternion.identity, transform);
        }

        if (gamerunning)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, 0); // set y velocity to zero
            rigidbody.AddForce(new Vector2(0, 200)); // some constant force here
            combo = 0;
        }


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "AddScore")
        {
            GameManager.Instance.UpdateScore();
            combo++;
            if (combo >= 3)
            {
                Instantiate(electricEffect, transform.position, Quaternion.identity, transform);
            }
        }
    }

}
