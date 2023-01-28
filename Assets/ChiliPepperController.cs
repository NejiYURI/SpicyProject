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
    private Vector2 LastMovement;

    [SerializeField]
    private bool CanMove;
    private Rigidbody2D rg;

    public Camera FollowCam;

    public ParticleSystem ChiliParticle;

    private float ParticleSize;

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
        ParticleSize = 0;
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
        if (!CanMove) return;
        Movement = playerInput.ChiliPepper.KeyboardInput.ReadValue<Vector2>();
        float DeltaValue = Mathf.Abs(Vector2.Distance(LastMovement, Movement));
        if (DeltaValue > 0.5f)
        {
            ParticleSize = 0;
        }
        ParticleSize += (Time.deltaTime * 2);
        if (ChiliParticle != null)
        {
            var pmain = ChiliParticle.main;
            pmain.startSize = Mathf.Clamp(ParticleSize, 0, 10);
        }
    }
    private void FixedUpdate()
    {
        if (!CanMove) return;
        this.rg.AddForce(ForceConverter(Movement * MoveSpeed, FollowCam.transform.eulerAngles.z));
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
}
