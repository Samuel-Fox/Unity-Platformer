using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    [SerializeField] private GameObject shot;
    [SerializeField] private Transform shootFrom;
    [SerializeField] private float shotCooldown;
    private float cooldownOver;
    void Awake()
    {
        cooldownOver = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ);

        if (Input.GetMouseButtonDown(0) && Time.time > cooldownOver) 
        {
            cooldown();
            Instantiate(shot, shootFrom.position, transform.rotation);
        }
    }

    private void cooldown() {
        cooldownOver = Time.time + shotCooldown;
    }
}
