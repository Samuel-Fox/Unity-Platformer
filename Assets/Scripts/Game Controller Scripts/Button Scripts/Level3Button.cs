using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level3Button : MonoBehaviour
{
    [SerializeField] private Button level3;
    public PauseMenu pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        //Button level1Click = level1.GetComponent<Button>();
		level3.onClick.AddListener(LoadLevel3);
        pauseMenu = GameObject.FindGameObjectWithTag("Pause").GetComponent<PauseMenu>();
    }

    void LoadLevel3()
    {
        SceneManager.LoadScene("Level 3");
        pauseMenu.buttonClicked();
    }
}

