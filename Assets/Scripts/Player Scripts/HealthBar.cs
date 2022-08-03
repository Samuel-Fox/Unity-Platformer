using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalHealth;
    [SerializeField] private Image CurrentHealth;
    

    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth.fillAmount = playerHealth.currentHealth / 5;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentHealth.fillAmount = playerHealth.currentHealth / 5;
    }
}
