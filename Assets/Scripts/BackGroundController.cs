using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BackGroundController : MonoBehaviour
{
    public SpriteRenderer SoupBg;

    public AudioSource BGMPlayer;

    [SerializeField]
    private float Ratio;

    private float SpawnCounter;

    public float SpawnRadius;

    public GameObject Bubble;

    public GameObject SpicyParticle;


    public float SpawnDuration;

    private void Start()
    {
        if (GameEventManager.instance != null)
        {
            GameEventManager.instance.SpicyRate.AddListener(GetSpicyRate);
            GameEventManager.instance.GameStart.AddListener(GameStart);
        }
        SpawnCounter = 0;
    }

    private void Update()
    {
        if (Ratio >= 0.7f)
        {
            if (SpicyParticle != null && !SpicyParticle.activeSelf)
                SpicyParticle.SetActive(true);
            SpawnCounter += Time.deltaTime;
            if (SpawnCounter >= SpawnDuration / Ratio)
            {
                SpawnBubble();
                SpawnCounter = 0;
            }
            if (BGMPlayer != null) BGMPlayer.pitch = Mathf.Lerp(1f, 2f, (Ratio-0.7f)/0.55f);
        }
    }

    void GameStart()
    {
        if (BGMPlayer != null) BGMPlayer.Play();
    }

    void GetSpicyRate(float cur_val, float Max_val)
    {
        if (SoupBg != null)
        {
            Ratio = (cur_val / (Max_val * 0.8f));
            SoupBg.color = new Color(SoupBg.color.r, SoupBg.color.g, SoupBg.color.b, Ratio);

        }
    }

    void SpawnBubble()
    {
        float RandomRange = Random.Range(2, SpawnRadius);
        float angle = 2 * Mathf.PI * Random.Range(0f, 1f);
        float x = RandomRange * Mathf.Cos(angle);
        float y = RandomRange * Mathf.Sin(angle);
        Vector3 Pos = new Vector3(x, y, 0);
        GameObject obj = Instantiate(Bubble, Pos, Quaternion.Euler(0, 0, Random.Range(0.0f, 360.0f)));
        Destroy(obj, 3f);
    }
}
