using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Camera gameCam;
    public bool bossTriggered;
    [SerializeField] private float cutsceneTime;
    private float cutsceneOver;
    private bool awakeBoss;
    public BossController bossController;
    // Start is called before the first frame update
    void Awake()
    {
        bossTriggered = false;
        cutsceneOver = 0;
        awakeBoss = false;
        bossController = GameObject.FindGameObjectWithTag("Boss").GetComponent<BossController>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(!bossTriggered) 
        {
             transform.position = new Vector3(player.position.x, player.position.y + 1, transform.position.z);
        }
        if (cutsceneOver > Time.time) {
           cameraMove();
           awakeBoss = true;      
        }
        else 
        {
            if(awakeBoss) {
                bossController.awakeBoss();
                awakeBoss = false;
            }
        }
    }

    public void bossTriggeredUpdate()
    {
        bossTriggered = true;
        //transform.position = new Vector3(player.position.x + 10, player.position.y + 1, transform.position.z - 10);
        cutsceneOver = Time.time + cutsceneTime;
       // cameraMove();
    }

    
    private void cameraMove()
    {
        transform.Translate(Vector3.right * 5.5f * Time.deltaTime);
        transform.Translate(Vector3.up * 1f * Time.deltaTime);
        gameCam.orthographicSize -= -1 * Time.deltaTime;
    }
}