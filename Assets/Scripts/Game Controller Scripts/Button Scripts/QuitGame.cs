using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuitGame : MonoBehaviour
{
    [SerializeField] private Button quit;
    public PauseMenu pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        //Button level1Click = level1.GetComponent<Button>();
		quit.onClick.AddListener(LoadLevel2);
        pauseMenu = GameObject.FindGameObjectWithTag("Pause").GetComponent<PauseMenu>();
    }

    void LoadLevel2()
    {
      Application.Quit();
    }
}
