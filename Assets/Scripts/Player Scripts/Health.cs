using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth {get; private set;}
    [SerializeField] private float invincibilityTime;
    private float invincibilityOver;
    private Rigidbody2D player;
    // Start is called before the first frame update
    void Awake()
    {
        player = GetComponent<Rigidbody2D>();
        currentHealth = startingHealth;
        invincibilityOver = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth == 0) 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if(Input.GetKey(KeyCode.H)) {
            currentHealth = 5;
        }
    }

    public void TakeDamage() 
    {
        invincibilityOver = Time.time + invincibilityTime;
        currentHealth -= 1;     
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if(Time.time > invincibilityOver) {
            if (other.gameObject.tag == "Trap" || other.gameObject.tag == "Boss") 
            {
                TakeDamage();
            }
        }
    }

    public float getInvincibilityOver() {
        return invincibilityOver;
    }
}
