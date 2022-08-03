using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrap : MonoBehaviour
{
    [SerializeField] private Rigidbody2D trap;
    [SerializeField] private bool moveXaxis;
    private float changeDirection;
    [SerializeField] private float direction;
    [SerializeField] private float trapSpeed;
    [SerializeField] private float trapLength;
    // Start is called before the first frame update
    void Start()
    {
        changeDirection = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(moveXaxis) {
            trap.transform.position = new Vector2 (trap.transform.position.x + (trapSpeed*Time.deltaTime*direction), trap.transform.position.y);
            if(Time.time > changeDirection) {
                changeDirection = Time.time + trapLength;
                direction *= -1;
            }
        }
        else {
            trap.transform.position = new Vector2 (trap.transform.position.x, trap.transform.position.y+ (trapSpeed*Time.deltaTime*direction));
            if(Time.time > changeDirection) {
                changeDirection = Time.time + trapLength;
                direction *= -1;
            }
        }
    }
}
