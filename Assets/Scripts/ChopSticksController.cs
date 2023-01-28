using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;
using static UnityEditor.Progress;

[RequireComponent(typeof(Rigidbody2D))]
public class ChopSticksController : MonoBehaviour
{
    public Camera followCameraControl;
    public float MoveSpeed = 5f;

    public Collider2D IgnoreCollider;

    public Collider2D SettingCollider;

    public float MoveSpeedLimit = 50f;

    public float ClickRange = 1f;

    public LayerMask CollisionDetect;

    public Camera FollowCam;

    public Animator ChopsticksAnimator;


    private Rigidbody2D rg;
    private PlayerInput playerInput;


    [SerializeField]
    private Vector2 MouseDeltaPos;

    [SerializeField]
    private bool GameStarted;

    [SerializeField]
    private bool CanMove;
    private void Awake()
    {
        playerInput = new PlayerInput();
    }
    // Start is called before the first frame update
    void Start()
    {
       
        this.rg = GetComponent<Rigidbody2D>();
        playerInput.ChopStick.Click.performed += _ => ChopStickGet();
        if (IgnoreCollider != null && SettingCollider != null)
        {
            Physics2D.IgnoreCollision(SettingCollider, IgnoreCollider);
        }

        if (GameEventManager.instance != null)
        {
            GameEventManager.instance.GameStart.AddListener(GameStart);
            GameEventManager.instance.GameOver.AddListener(GameOverFunction);
        }
    }
    private void OnEnable()
    {
        playerInput.Enable();
    }
    private void OnDisable()
    {
        playerInput.Disable();
    }


    // Update is called once per frame
    void Update()
    {
        MouseDeltaPos = playerInput.ChopStick.MouseInput.ReadValue<Vector2>();
    }
    private void FixedUpdate()
    {
        if (!this.GameStarted || !this.CanMove) return;
        this.rg.AddForce(ForceConverter(MouseDeltaPos * MoveSpeed, FollowCam.transform.eulerAngles.z));
        this.rg.velocity = new Vector2(Mathf.Clamp(this.rg.velocity.x, -1 * MoveSpeedLimit, MoveSpeedLimit), Mathf.Clamp(this.rg.velocity.y, -1 * MoveSpeedLimit, MoveSpeedLimit));

        if (followCameraControl != null)
        {
            followCameraControl.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, followCameraControl.transform.position.z);
        }
    }

    void GameStart()
    {
        this.GameStarted = true;
        this.CanMove = true;
    }

    void ChopStickGet()
    {
        if (!this.GameStarted || !this.CanMove) return;
        Collider2D[] hitObj = Physics2D.OverlapCircleAll(this.transform.position, ClickRange, CollisionDetect);
        if (hitObj.Count() == 1)
        {
            if (hitObj[0].transform.tag.Equals("Chili"))
            {
                Debug.Log("Got it!");
                if (MainGameController.mainController != null)
                {
                    MainGameController.mainController.ChopsticksWin();
                }
            }
        }
        else if (hitObj.Count() > 0)
        {
            foreach (var obj in hitObj)
            {
                if (!obj.transform.tag.Equals("Chili") && obj.GetComponent<FoodScript>()!=null)
                {
                    obj.GetComponent<FoodScript>().FoodPickUp();
                    break;
                }
            }
        }
        if (this.rg!=null) this.rg.velocity = Vector2.zero;
        StartCoroutine(StopCounter());
        
    }

    public void GameOverFunction(string i_showTxt, Color i_color)
    {
        this.GameStarted = false;
    }

    Vector2 ForceConverter(Vector2 i_target, float i_angle)
    {
        float sin = Mathf.Sin(i_angle * Mathf.Deg2Rad);
        float cos = Mathf.Cos(i_angle * Mathf.Deg2Rad);

        float tx = i_target.x;
        float ty = i_target.y;
        i_target.x = (cos * tx) - (sin * ty);
        i_target.y = (sin * tx) + (cos * ty);
        return i_target;
    }

    public void SetCharacterAngle(float i_angle)
    {
        this.transform.rotation = Quaternion.Euler(0, 0, i_angle);
        FollowCam.transform.rotation = Quaternion.Euler(0, 0, i_angle);
    }

    IEnumerator StopCounter()
    {
        this.CanMove = false;
        if (ChopsticksAnimator != null)
        {
            ChopsticksAnimator.SetTrigger("ChopsticksGrab");
        }
        yield return new WaitForSeconds(0.5f);
        this.CanMove = true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, ClickRange);
    }
}
