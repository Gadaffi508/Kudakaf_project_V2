using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public int player_�d;

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

    //<-----Input Actions------>
#if UNITY_EDITOR
    Vector2 �nputMove;
    Vector2 �nputCursorRotate;
    private bool �nputJumpButton;
    private bool �nputDashButton;
    private bool �nputRunButton;
    private bool �nputFireButton;
    private bool �nputLeftButton;
    private bool �nputRightButton;
    private bool �nputUpButton;
    private bool �nputDownButton;
    private bool �nputPunchButton;
    private bool �nputExplodeButton;
#endif

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        playerInput = GetComponent<PlayerInput>();
        player_�d = playerInput.playerIndex;
    }

    private void Update()
    {
        bool GroundCol = Physics2D.OverlapCircle(GroundCheck.position, GroundRadius, GroundLayer);
        if (GroundCol) isJump = true;

        if (isJump == true && �nputJumpButton)
        {
            rb.AddForce(Vector2.up * jumpHeight);
            isJump = false;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = PlayerMoveVelocity();
    }


    private Vector2 PlayerMoveVelocity()
    {
        if (isFlyCharecter == true) return new Vector2(�nputMove.x * speed * Time.deltaTime, �nputMove.y * speed * Time.deltaTime);

        else return new Vector2(�nputMove.x * speed * Time.deltaTime, rb.velocity.y);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(GroundCheck.position, GroundRadius);
    }

    public void OnMove(InputAction.CallbackContext ctx) => �nputMove = ctx.ReadValue<Vector2>();
    public void OnCursor(InputAction.CallbackContext ctx) => �nputCursorRotate = ctx.ReadValue<Vector2>();
    public void OnJump(InputAction.CallbackContext ctx) => �nputJumpButton = ctx.ReadValueAsButton();
    public void OnDash(InputAction.CallbackContext ctx) => �nputDashButton = ctx.ReadValueAsButton();
    public void OnRun(InputAction.CallbackContext ctx) => �nputRunButton = ctx.ReadValueAsButton();
    public void OnFire(InputAction.CallbackContext ctx) => �nputFireButton = ctx.ReadValueAsButton();
    public void OnLeft(InputAction.CallbackContext ctx) => �nputLeftButton = ctx.ReadValueAsButton();
    public void OnRight(InputAction.CallbackContext ctx) => �nputRightButton = ctx.ReadValueAsButton();
    public void OnUp(InputAction.CallbackContext ctx) => �nputUpButton = ctx.ReadValueAsButton();
    public void OnDown(InputAction.CallbackContext ctx) => �nputDownButton = ctx.ReadValueAsButton();
    public void OnPunch(InputAction.CallbackContext ctx) => �nputPunchButton = ctx.ReadValueAsButton();
    public void OnExplode(InputAction.CallbackContext ctx) => �nputExplodeButton = ctx.ReadValueAsButton();
}
