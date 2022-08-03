using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D boss;
    [SerializeField] private Transform player;
    [SerializeField] private Transform bossPosition;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float bossHealth;
    [SerializeField] private Image totalHealth;
    [SerializeField] private Image currentHealth;
    public BossUniqueAttack bossUniqueAttack;
    
    private bool bossAwake;
    void Awake()
    {
        totalHealth.enabled = false;
        currentHealth.enabled = false;
        bossAwake = false;
        bossUniqueAttack = GameObject.FindGameObjectWithTag("BossWeapon").GetComponent<BossUniqueAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        if(bossAwake && !bossUniqueAttack.isAttacking())
        {
            if(player.position.x - boss.position.x > 0)
            {
                boss.velocity = new Vector2(1 * moveSpeed, boss.velocity.y);
            } 
            else 
            {
                boss.velocity = new Vector2(-1 * moveSpeed, boss.velocity.y);
            }
        }
        currentHealth.fillAmount = bossHealth / 20;
        if(bossHealth <= 0) {
            Destroy(gameObject);
        }
    }

    public void awakeBoss() 
    {
        totalHealth.enabled = true;
        currentHealth.enabled = true;
        bossAwake = true;
    }

    public void takeDamage()
    {
        bossHealth -= 1;
    }

    public bool isAwake() {
        return bossAwake;
    }

     public Vector3 shotVector() {
        return player.position - bossPosition.position;
    }
}
