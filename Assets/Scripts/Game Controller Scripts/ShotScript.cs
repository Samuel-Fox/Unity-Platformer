using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour
{
    [SerializeField] private float shotSpeed;
    private int groundLayer;
    private int trapLayer;
    private int bossLayer;
    private int hitLayer;
    public BossController bossController;
    private BoxCollider2D boxCollider;

    void Awake()
    {
        groundLayer = 1 << 8;
        trapLayer = 1 << 9;
        bossLayer = 1 << 7;
        hitLayer = groundLayer | trapLayer | bossLayer;
        bossController = GameObject.FindGameObjectWithTag("Boss").GetComponent<BossController>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, transform.right, 0.1f, hitLayer);
        if (raycastHit.collider != null) {
            if (raycastHit.collider.CompareTag("Boss")) {
                bossController.takeDamage();
                Destroy(gameObject);
            }
            else if (raycastHit.collider.CompareTag("Ground") || raycastHit.collider.CompareTag("Trap")) { 
                Destroy(gameObject);
            }
        }
        transform.Translate(Vector2.right * shotSpeed * Time.deltaTime);
    }
}
