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


    private Rigidbody2D rg;
    private PlayerInput playerInput;


    [SerializeField]
    private Vector2 MouseDeltaPos;

    [SerializeField]
    private bool CanMove;
    private void Awake()
    {
        playerInput = new PlayerInput();
    }
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        this.rg = GetComponent<Rigidbody2D>();
        playerInput.ChopStick.Click.performed += _ => ChopStickGet();
        if (IgnoreCollider != null && SettingCollider != null)
        {
            Physics2D.IgnoreCollision(SettingCollider, IgnoreCollider);
        }

        if (GameEventManager.instance != null)
        {
            GameEventManager.instance.GameStart.AddListener(GameStart);
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
        if (!this.CanMove) return;
        this.rg.AddForce(MouseDeltaPos * MoveSpeed);
        this.rg.velocity = new Vector2(Mathf.Clamp(this.rg.velocity.x, -1 * MoveSpeedLimit, MoveSpeedLimit), Mathf.Clamp(this.rg.velocity.y, -1 * MoveSpeedLimit, MoveSpeedLimit));

        if (followCameraControl != null)
        {
            followCameraControl.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, followCameraControl.transform.position.z);
        }
    }

    void GameStart()
    {
        this.CanMove = true;
    }

    void ChopStickGet()
    {
        Collider2D[] hitObj = Physics2D.OverlapCircleAll(this.transform.position, ClickRange, CollisionDetect);
        if (hitObj.Count() == 1)
        {
            if (hitObj[0].transform.tag.Equals("Chili"))
            {
                Debug.Log("Got it!");
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, ClickRange);
    }
}
