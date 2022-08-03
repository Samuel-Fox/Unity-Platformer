using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level2Button : MonoBehaviour
{
    [SerializeField] private Button level2;
    public PauseMenu pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        //Button level1Click = level1.GetComponent<Button>();
		level2.onClick.AddListener(LoadLevel2);
        pauseMenu = GameObject.FindGameObjectWithTag("Pause").GetComponent<PauseMenu>();
    }

    void LoadLevel2()
    {
        SceneManager.LoadScene("Level 2");
        pauseMenu.buttonClicked();
    }
}
