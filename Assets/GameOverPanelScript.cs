using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverPanelScript : MonoBehaviour
{
    public TextMeshProUGUI ShowLabel;
    public Image BannerImage;
    void Start()
    {
        this.transform.LeanScale(Vector3.zero,0f);
        if (GameEventManager.instance != null)
        {
            GameEventManager.instance.GameOver.AddListener(GameOverFunction);
        }
    }

    public void GameOverFunction(string i_showTxt, Color i_color)
    {
        this.transform.LeanScale(Vector3.one, 0.2f);
        if (BannerImage != null) BannerImage.color = i_color;
        if (ShowLabel != null) ShowLabel.text = i_showTxt;

    }
}
