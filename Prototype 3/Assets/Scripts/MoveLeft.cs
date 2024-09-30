/*
* Kayden Miller
* Assignment 4
* Move the object this is attached with to the left at a set speed
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 30f;
    private float leftBound = -15f;

    private PlayerController pC;

    void Start()
    {
        pC = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
    // Update is called once per frame
    void Update()
    {
        if ((!pC.gameOver))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (transform.position.x <leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
