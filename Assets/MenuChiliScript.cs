using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuChiliScript : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (StartMenuScript.instance != null) StartMenuScript.instance.ChangeScene();
        Destroy(gameObject);
    }
}
