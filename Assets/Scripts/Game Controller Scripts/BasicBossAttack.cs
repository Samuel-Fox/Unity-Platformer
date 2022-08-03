using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBossAttack : MonoBehaviour
{
    [SerializeField] private GameObject bossShot;
    [SerializeField] private Transform shootFrom;
    [SerializeField] private float basicAttackCooldown;
    [SerializeField] private Transform player;
    [SerializeField] private Transform bossPosition;
    private float basicAttackCooldownOver;
    public BossController bossController;
    public BossUniqueAttack bossUniqueAttack;

    void Awake()
    {
        basicAttackCooldownOver = 0;
        bossController = GameObject.FindGameObjectWithTag("Boss").GetComponent<BossController>();
        bossUniqueAttack = GameObject.FindGameObjectWithTag("BossWeapon").GetComponent<BossUniqueAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 difference = transform.position - player.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ);

        if (bossController.isAwake() && Time.time > basicAttackCooldownOver && !bossUniqueAttack.isAttacking()) {
            basicAttackCooldownOver = Time.time + basicAttackCooldown;
            Instantiate(bossShot, shootFrom.position, transform.rotation);
        }
        if( bossController.isAwake() && bossUniqueAttack.getBossAttack() == 1 && bossUniqueAttack.isAttacking()) {
            if(Time.time > basicAttackCooldownOver) {
                UniqueAttack1();
            }
        }
        if( bossController.isAwake() && bossUniqueAttack.getBossAttack() == 2 && bossUniqueAttack.isAttacking()) {
            if(Time.time > basicAttackCooldownOver) {
                UniqueAttack2();
            }
        }
        if( bossController.isAwake() && bossUniqueAttack.getBossAttack() == 3 && bossUniqueAttack.isAttacking()) {
            if(Time.time > basicAttackCooldownOver) {
                UniqueAttack3();
            }
        }
    }

    private void UniqueAttack1() {
        Instantiate(bossShot, shootFrom.position + new Vector3(5, 0, 0), transform.rotation);
        Instantiate(bossShot, shootFrom.position, transform.rotation);
        Instantiate(bossShot, shootFrom.position + new Vector3(-5, 0, 0), transform.rotation);
        basicAttackCooldownOver = Time.time + .5f;
    }

    private void UniqueAttack2() {
        Instantiate(bossShot, shootFrom.position, transform.rotation);
        basicAttackCooldownOver = Time.time + .2f;
    }

    private void UniqueAttack3() {
        Instantiate(bossShot, shootFrom.position, transform.rotation);
        basicAttackCooldownOver = Time.time + .1f;
    }

    public void setCooldown(float input) {
        basicAttackCooldownOver = Time.time + input;
    }
}
