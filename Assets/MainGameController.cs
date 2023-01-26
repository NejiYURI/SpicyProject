using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainGameController : MonoBehaviour
{
    public static MainGameController mainController;
    public float CountDownSecond;
    public List<Collider2D> PlayerColliderList;

    public float SpawnRadius = 5f;
    public int SpawnNum;
    public GameObject FoodObj;

    public Image SpicyRateBar;
    public float SpicyRate;
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
        for (int cnt = 0; cnt < SpawnNum; cnt++)
        {
            float RandomRange = Random.Range(0, SpawnRadius);
            float angle = 2 * Mathf.PI * Random.Range(0f, 1f);
            float x = RandomRange * Mathf.Cos(angle);
            float y = RandomRange * Mathf.Sin(angle);
            Vector3 Pos = new Vector3(x, y, 0);
            GameObject obj = Instantiate(FoodObj, Pos, Quaternion.Euler(0, 0, Random.Range(0.0f, 360.0f)));
            obj.transform.localScale = new Vector3(Random.Range(0.5f, 1.5f), Random.Range(0.5f, 1.5f), 1f);
        }
        SpicyRate_Val = 0f;
        if (SpicyRateBar != null)
        {
            SpicyRateBar.fillAmount = SpicyRate_Val / SpicyRate;
        }
    }

    public void ChopsticksWin()
    {
        if (GameEventManager.instance != null)
        {
            StopCoroutine(SpicyRateCoroutine);
            Cursor.lockState = CursorLockMode.None;
            GameEventManager.instance.GameOver.Invoke("Chopsticks Win!", Color.black);
        }
    }

    public void ChiliWin()
    {
        if (GameEventManager.instance != null)
        {
            Cursor.lockState = CursorLockMode.None;
            GameEventManager.instance.GameOver.Invoke("ChiliPepper Win!", Color.red);
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator StartCounter()
    {
        yield return new WaitForSeconds(CountDownSecond);
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
            if (SpicyRateBar != null)
            {
                SpicyRateBar.fillAmount = SpicyRate_Val / SpicyRate;
            }
        }
        ChiliWin();
    }
}
