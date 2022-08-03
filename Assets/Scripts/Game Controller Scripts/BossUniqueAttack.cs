using System.Security.Permissions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossUniqueAttack : MonoBehaviour
{
    [SerializeField] private Rigidbody2D boss;
    [SerializeField] private Transform bossPosition;
    [SerializeField] private Transform player;
    [SerializeField] private float attackCooldown;
    [SerializeField] private float attackLength1;
    private float attackCooldownOver;
    [SerializeField] private int bossNum;
    private bool attacking;
    private int whichAttack;
    public BossController bossController;
    public BasicBossAttack basicBossAttack;
    void Start() {
        //Random.InitState(15678);
        Random.InitState(System.DateTime.Now.Millisecond);
    }
    void Awake()
    {
        attackCooldownOver = Time.time + attackCooldown;
        attacking = false;
        whichAttack = 0;
        basicBossAttack = GameObject.FindGameObjectWithTag("BossWeapon").GetComponent<BasicBossAttack>();
        bossController = GameObject.FindGameObjectWithTag("Boss").GetComponent<BossController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > attackCooldownOver && attacking == false && boss.IsAwake()) {
            whichAttack = Random.Range(1, bossNum+1);
            if (whichAttack == 1) {
                attacking = true;
                StartCoroutine(UniqueAttack1());
            }
            else if (whichAttack == 2) {
                attacking = true;
                StartCoroutine(UniqueAttack2());
            }
            else if (whichAttack == 3) {
                StartCoroutine(UniqueAttack3());
                attacking = true;
            }
        }
    }

    private IEnumerator UniqueAttack1() 
    {
            attackCooldownOver = Time.time + attackCooldown + attackLength1;
            float gravity = boss.gravityScale;
            boss.gravityScale = 0;
            //Vector2 lastPosition = boss.position;
            boss.position = new Vector2 (101, boss.position.y + 10);
            basicBossAttack.setCooldown(.1f);
            boss.velocity = new Vector2(-10, 0f);
            yield return new WaitForSeconds(attackLength1);
            boss.gravityScale = gravity; 
            attacking = false;
    }
    private IEnumerator UniqueAttack2() 
    {
        basicBossAttack.setCooldown(.1f);
        attackCooldownOver = Time.time + attackCooldown + 2f;
            if(boss.position.x < 85 ) {
                boss.velocity = new Vector2(10f, 15f);
            }
            else {
                boss.velocity = new Vector2(-10f, 15f);
            }
            yield return new WaitForSeconds(2f);
            attacking = false;
    }
    private IEnumerator UniqueAttack3() 
    {
        attackCooldownOver = Time.time + attackCooldown + 6f;
        float gravity = boss.gravityScale;
        boss.gravityScale = 0;
        boss.velocity = new Vector2 (0,0);
        basicBossAttack.setCooldown(0f);
        for(int i = 0; i < 6; i++) {
            float bossX = Random.Range(70f, 100f);
            float bossY = Random.Range(50f, 55f);
            boss.transform.position = new Vector2(bossX, bossY);
            yield return new WaitForSeconds(1f);
        }
        //yield return new WaitForSeconds(3f);
        boss.gravityScale = gravity; 
        attacking = false;
    }

    public bool isAttacking() {
        return attacking;
    }

    public int getBossAttack() {
        return whichAttack;
    }
}
