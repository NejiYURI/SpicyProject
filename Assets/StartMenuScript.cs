using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuScript : MonoBehaviour
{
    public static StartMenuScript instance;
    public GameObject chiliObj;
    public Transform SpawnPoint;
    public Image JoystickImg;
    public AudioClip DropSound;
    private bool IsPress;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        if (GameSettingScript.instance != null)
        {
            JoystickImg.color = GameSettingScript.instance.IsJoycon?Color.white:Color.black;
        }
    }
    public void GameStart()
    {
        
        if (chiliObj != null && SpawnPoint != null && !IsPress)
        {
            IsPress = true;
            Instantiate(chiliObj, SpawnPoint.position, Quaternion.identity);
        }
      
    }

    public void ChangeScene()
    {
        StartCoroutine(StartCounter());
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ChangeJoycon()
    {
        if (GameSettingScript.instance != null)
        {
            GameSettingScript.instance.IsJoycon = !GameSettingScript.instance.IsJoycon;
            JoystickImg.color = GameSettingScript.instance.IsJoycon ? Color.white : Color.black;
        }
    }

    IEnumerator StartCounter()
    {
        if (AudioController.instance) AudioController.instance.PlaySound(DropSound);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("PlayScene");
    }
}
