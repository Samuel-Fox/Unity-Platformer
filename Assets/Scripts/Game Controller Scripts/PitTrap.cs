using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PitTrap : MonoBehaviour
{
    [SerializeField]private Rigidbody2D player;
    public PlayerMovement playerMovement;
    public Health health;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
      //  playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
      //  health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Pit") 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
