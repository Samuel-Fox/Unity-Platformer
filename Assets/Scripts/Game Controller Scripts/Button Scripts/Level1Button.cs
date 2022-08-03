using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level1Button : MonoBehaviour
{
    [SerializeField] private Button level1;
    public PauseMenu pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        //Button level1Click = level1.GetComponent<Button>();
		level1.onClick.AddListener(LoadLevel1);
        pauseMenu = GameObject.FindGameObjectWithTag("Pause").GetComponent<PauseMenu>();
    }

    void LoadLevel1()
    {
        SceneManager.LoadScene("Level 1");
        pauseMenu.buttonClicked();
    }
}
