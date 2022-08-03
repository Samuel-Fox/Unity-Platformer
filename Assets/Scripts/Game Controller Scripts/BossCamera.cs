using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCamera : MonoBehaviour
{
    private Rigidbody2D player;
    public CameraController myCamera;
    [SerializeField] private BoxCollider2D bossTrigger;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        myCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Trigger") 
        {
            bossTrigger.enabled = false;
            myCamera.bossTriggeredUpdate();
        }
    }
}

