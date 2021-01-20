using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{

    public bool isSolved = false;
    public GameObject player;
    public AudioClip goalSound;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject collidedWith = other.gameObject;
        if (gameObject.tag == collidedWith.tag)
        {
            isSolved = true;
            AudioSource.PlayClipAtPoint(goalSound, player.transform.position, 2f);
            GetComponent<Light>().enabled = false;
            Destroy(collidedWith);
        }
    }

    public void RestartGoals()
    {
        isSolved = false;
        GetComponent<Light>().enabled = true;
    }
}
