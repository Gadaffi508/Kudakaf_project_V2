using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public int player_id;

    [Header("Controller Value")]
    public float speed;
    public bool isFlyCharecter = false;

    [Header("Dash Controller")]
    public float dashForce;
    [Range(0, 1)]
    public float dashTime;

    [Header("Jump Controller")]
    public float jumpHeight;
    public Transform GroundCheck;
    public float GroundRadius;
    public LayerMask GroundLayer;
    public bool isJump = true;

    //<-----Controlls----------->
    private bool dashPressed = false;

    //<-----Get Components------>
    Rigidbody2D rb;
    Animator anim;
    PlayerInput playerInput;
    string[] joystickNames;

    //<-----Input Actions------>
#if UNITY_EDITOR
    Vector2 inputMove;
    Vector2 inputCursorRotate;
    private bool inputJumpButton;
    private bool inputDashButton;
    private bool inputRunButton;
    private bool inputFireButton;
    private bool inputLeftButton;
    private bool inputRightButton;
    private bool inputUpButton;
    private bool inputDownButton;
    private bool inputPunchButton;
    private bool inputExplodeButton;
    private float Horizontal, Vertical;
#endif

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        playerInput = GetComponent<PlayerInput>();
        player_id = playerInput.playerIndex;

        joystickNames = Input.GetJoystickNames();
    }

    private void Update()
    {
        bool GroundCol = Physics2D.OverlapCircle(GroundCheck.position, GroundRadius, GroundLayer);

        if (isJump is true && inputJumpButton || Input.GetKeyDown(KeyCode.Space) && isJump is true)
        {
            rb.AddForce(Vector2.up * jumpHeight);
            isJump = false;
        }
        else if (GroundCol) isJump = true;

        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        rb.velocity = PlayerMoveVelocity();
    }

    float moveValueX, moveValueY;

    private Vector2 PlayerMoveVelocity()
    {

        if (joystickNames  != null)
        {
            moveValueX = inputMove.x;
            moveValueY = inputMove.y;
        }
        else
        {
            moveValueX = Horizontal;
            moveValueY = Vertical;
        }

        if(isFlyCharecter  == true) return new Vector2(Horizontal * speed * Time.deltaTime, Vertical * speed * Time.deltaTime);
        else return new Vector2(Horizontal * speed * Time.deltaTime, rb.velocity.y);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(GroundCheck.position, GroundRadius);
    }

    public void OnMove(InputAction.CallbackContext ctx) => inputMove = ctx.ReadValue<Vector2>();
    public void OnCursor(InputAction.CallbackContext ctx) => inputCursorRotate = ctx.ReadValue<Vector2>();
    public void OnJump(InputAction.CallbackContext ctx) => inputJumpButton = ctx.ReadValueAsButton();
    public void OnDash(InputAction.CallbackContext ctx) => inputDashButton = ctx.ReadValueAsButton();
    public void OnRun(InputAction.CallbackContext ctx) => inputRunButton = ctx.ReadValueAsButton();
    public void OnFire(InputAction.CallbackContext ctx) => inputFireButton = ctx.ReadValueAsButton();
    public void OnLeft(InputAction.CallbackContext ctx) => inputLeftButton = ctx.ReadValueAsButton();
    public void OnRight(InputAction.CallbackContext ctx) => inputRightButton = ctx.ReadValueAsButton();
    public void OnUp(InputAction.CallbackContext ctx) => inputUpButton = ctx.ReadValueAsButton();
    public void OnDown(InputAction.CallbackContext ctx) => inputDownButton = ctx.ReadValueAsButton();
    public void OnPunch(InputAction.CallbackContext ctx) => inputPunchButton = ctx.ReadValueAsButton();
    public void OnExplode(InputAction.CallbackContext ctx) => inputExplodeButton = ctx.ReadValueAsButton();
}
