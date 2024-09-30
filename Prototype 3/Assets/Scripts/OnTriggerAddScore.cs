/*
* Kayden Miller
* Assignment 4
* Increments the score whenever a player collides with attached object
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerAddScore : MonoBehaviour
{

    private UIManager uIManager;

    private bool triggered = false;
    // Start is called before the first frame update
    void Start()
    {
        uIManager = GameObject.FindObjectOfType<UIManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !triggered )
        {
            triggered = true;
            uIManager.score++;
        }
    }
}
