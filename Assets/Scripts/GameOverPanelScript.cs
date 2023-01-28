using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverPanelScript : MonoBehaviour
{
    public TextMeshProUGUI ShowLabel;
    public Image BannerImage;
    public Animator noodleAnimator;
    public Color ChiliWinColor;
    void Start()
    {
        this.transform.LeanScale(Vector3.zero, 0f);
        if (GameEventManager.instance != null)
        {
            GameEventManager.instance.GameOver.AddListener(GameOverFunction);
        }
    }

    public void GameOverFunction(bool IsChopsticks)
    {
        this.transform.LeanScale(Vector3.one, 0.2f);
        if (BannerImage != null && !IsChopsticks) BannerImage.color = ChiliWinColor;
        if (ShowLabel != null) ShowLabel.text = IsChopsticks ? "The noodle soup is saved!" : "The noodle from hell!";
        if (noodleAnimator != null)
        {
            noodleAnimator.enabled = true;
            noodleAnimator.Play(IsChopsticks ? "Noodle_ChopsticksWin" : "Noodle_ChiliPepperWin");
        }

    }
}
