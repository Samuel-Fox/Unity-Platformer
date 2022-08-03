using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Canvas pauseMenu;
    private bool paused;
    // Start is called before the first frame update
    void Start()
    {
      pauseMenu.gameObject.SetActive(false);
      paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (paused == false) {
                pauseMenu.gameObject.SetActive(true);
                Time.timeScale = 0f;
                paused = true;
            }
            else {
                pauseMenu.gameObject.SetActive(false);
                Time.timeScale = 1f;
                paused = false;
            }
        }  
    }

    public void buttonClicked() {
        paused = false;
        Time.timeScale = 1f;
    }
}
