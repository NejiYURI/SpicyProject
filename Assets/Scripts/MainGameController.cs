using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static UnityEditor.Progress;

[System.Serializable]
public class SpawnData
{
    public int Rate;
    public List<FoodData> foodDatas;
}
public class MainGameController : MonoBehaviour
{
    public static MainGameController mainController;
    public float CountDownSecond;
    public List<Collider2D> PlayerColliderList;

    public float SpawnRadius = 5f;
    public int SpawnNum;
    public GameObject FoodObj;

    //public Image SpicyRateBar;
    public SpriteRenderer SpicyRateBar;
    public float SpicyRate;

    public ChiliPepperController ChiliPepper;
    public ChopSticksController ChopSticks;

    public List<SpawnData> spawnDatas;

    public CounterScript counterControl;

    [SerializeField]
    private float SpicyRate_Val;

    private Coroutine SpicyRateCoroutine;


    private void Awake()
    {
        mainController = this;
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        StartCoroutine(StartCounter());
        Dictionary<int, List<Collider2D>> LayerCollider = new Dictionary<int, List<Collider2D>>();
        for (int layercnt = 0; layercnt < 2; layercnt++)
        {
            for (int cnt = 0; cnt < SpawnNum; cnt++)
            {
                float RandomRange = Random.Range(2, SpawnRadius);
                float angle = 2 * Mathf.PI * Random.Range(0f, 1f);
                float x = RandomRange * Mathf.Cos(angle);
                float y = RandomRange * Mathf.Sin(angle);
                Vector3 Pos = new Vector3(x, y, 0);
                GameObject obj = Instantiate(FoodObj, Pos, Quaternion.Euler(0, 0, Random.Range(0.0f, 360.0f)));
                //obj.transform.localScale = new Vector3(Random.Range(0.5f, 1.5f), Random.Range(0.5f, 1.5f), 1f);
                if (!LayerCollider.ContainsKey(layercnt)) LayerCollider.Add(layercnt, new List<Collider2D>());
                if (obj.GetComponent<FoodScript>() != null)
                {
                    obj.GetComponent<FoodScript>().FoodSetup(GetRandFood());
                    LayerCollider[layercnt].Add(obj.GetComponent<FoodScript>().ColliderObj);
                }
            }
        }
        foreach (var item in LayerCollider[0])
        {
            foreach (var item2 in LayerCollider[1])
            {
                Physics2D.IgnoreCollision(item, item2);
            }
        }

        SpicyRate_Val = 0f;
        if (SpicyRateBar != null)
        {
            //SpicyRateBar.fillAmount = SpicyRate_Val / SpicyRate;
            SpicyRateBar.color = new Color(SpicyRateBar.color.r, SpicyRateBar.color.g, SpicyRateBar.color.b, SpicyRate_Val / SpicyRate);
        }
        if (ChiliPepper != null && ChopSticks != null)
        {
            float ChiliAngle = Random.Range(0, 360);
            float ChopsticksAngle = Random.Range(0, 360);
            while (ChopsticksAngle == ChiliAngle) ChopsticksAngle = Random.Range(0, 360);
            ChiliPepper.SetCharacterAngle(ChiliAngle);
            ChopSticks.SetCharacterAngle(ChopsticksAngle);
        }
    }

    FoodData GetRandFood()
    {
        int num = Random.Range(1, 101);
        int index = 0;
        foreach (var item in spawnDatas)
        {
            index += item.Rate;
            if (num <= index)
                return item.foodDatas[Random.Range(0, item.foodDatas.Count)];
        }

        return null;
    }

    public void ChopsticksWin()
    {
        if (GameEventManager.instance != null)
        {
            StopCoroutine(SpicyRateCoroutine);
            Cursor.lockState = CursorLockMode.None;
            GameEventManager.instance.GameOver.Invoke(true);
        }
    }

    public void ChiliWin()
    {
        if (GameEventManager.instance != null)
        {
            Cursor.lockState = CursorLockMode.None;
            GameEventManager.instance.GameOver.Invoke(false);
        }
    }

    public void RestartLevel()
    {
        if (JoyconManager.Instance != null) JoyconManager.Instance.DetachJoy();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator StartCounter()
    {
        int TmpCnt = (int)CountDownSecond;
        for (int i = TmpCnt; i > 0; i--)
        {
            if (counterControl != null) counterControl.CounterSet(i.ToString("#"));
            yield return new WaitForSeconds(1);
        }

        if (GameEventManager.instance != null)
        {
            GameEventManager.instance.GameStart.Invoke();
            SpicyRateCoroutine = StartCoroutine(SpicyRateCounter());
        }
    }

    IEnumerator SpicyRateCounter()
    {
        while (SpicyRate_Val < SpicyRate)
        {
            yield return new WaitForFixedUpdate();
            SpicyRate_Val += Time.fixedDeltaTime;

            if (GameEventManager.instance != null) GameEventManager.instance.SpicyRate.Invoke(SpicyRate_Val, SpicyRate);
        }
        ChiliWin();
    }
}
