using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShotScript : MonoBehaviour
{
   [SerializeField] private float shotSpeed;
    private int groundLayer;
    private int trapLayer;
    private int playerLayer;
    private int hitLayer;
    public BossController bossController;
    public Health playerHealth;

    void Awake()
    {
        groundLayer = 1 << 8;
        trapLayer = 1 << 9;
        playerLayer = 1 << 6;
        hitLayer = groundLayer | trapLayer | playerLayer;
        bossController = GameObject.FindGameObjectWithTag("Boss").GetComponent<BossController>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, transform.forward, 0.1f, hitLayer);
        if (raycastHit.collider != null) {
            if (raycastHit.collider.CompareTag("Player")) {
                if (Time.time > playerHealth.getInvincibilityOver()) {
                    playerHealth.TakeDamage();
                }
                Destroy(gameObject);
            }
            else if (raycastHit.collider.CompareTag("Ground") || raycastHit.collider.CompareTag("Trap")) { 
                Destroy(gameObject);
            }
        }
        transform.Translate(Vector2.left * shotSpeed * Time.deltaTime);
    }
}
