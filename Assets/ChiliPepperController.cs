using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ChiliPepperController : MonoBehaviour
{
    public float MoveSpeed = 5f;

    public float MoveSpeedLimit = 50f;

    public Collider2D IgnoreCollider;

    public Collider2D SettingCollider;

    private PlayerInput playerInput;
    [SerializeField]
    private Vector2 Movement;
    [SerializeField]
    private bool CanMove;
    private Rigidbody2D rg;

    private void Awake()
    {
        playerInput = new PlayerInput();
    }

    // Start is called before the first frame update
    void Start()
    {
        this.rg = GetComponent<Rigidbody2D>();
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
        Movement = playerInput.ChiliPepper.KeyboardInput.ReadValue<Vector2>();
    }
    private void FixedUpdate()
    {
        if (!CanMove) return;
        this.rg.AddForce(Movement * MoveSpeed);
        this.rg.velocity = new Vector2(Mathf.Clamp(this.rg.velocity.x, -1 * MoveSpeedLimit, MoveSpeedLimit), Mathf.Clamp(this.rg.velocity.y, -1 * MoveSpeedLimit, MoveSpeedLimit));
    }

    void GameStart()
    {
        this.CanMove = true;
    }

    public void GameOverFunction(string i_showTxt, Color i_color)
    {
        this.CanMove = false;
    }
}
