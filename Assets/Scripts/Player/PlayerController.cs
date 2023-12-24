using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public int player_Ýd;

    [Header("Controller Value")]
    public float speed;
    public float jumpHeight;
    public float dashForce;
    [Range(0,1)]
    public float dashTime;

    //<-----Get Components------>
    Rigidbody2D rb;
    Animator anim;
    PlayerInput playerInput;

    //<-----Input Actions------>
#if UNITY_EDITOR
    Vector2 ýnputMove;
    Vector2 ýnputCursorRotate;
    private bool ýnputJumpButton;
    private bool ýnputDashButton;
    private bool ýnputRunButton;
    private bool ýnputFireButton;
    private bool ýnputLeftButton;
    private bool ýnputRightButton;
    private bool ýnputUpButton;
    private bool ýnputDownButton;
    private bool ýnputPunchButton;
    private bool ýnputExplodeButton;
#endif

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        playerInput = GetComponent<PlayerInput>();
        player_Ýd = playerInput.playerIndex;
    }


    public void OnMove(InputAction.CallbackContext ctx) => ýnputMove = ctx.ReadValue<Vector2>();
    public void OnCursor(InputAction.CallbackContext ctx) => ýnputCursorRotate = ctx.ReadValue<Vector2>();
    public void OnJump(InputAction.CallbackContext ctx) => ýnputJumpButton = ctx.ReadValueAsButton();
    public void OnDash(InputAction.CallbackContext ctx) => ýnputDashButton = ctx.ReadValueAsButton();
    public void OnRun(InputAction.CallbackContext ctx) => ýnputRunButton = ctx.ReadValueAsButton();
    public void OnFire(InputAction.CallbackContext ctx) => ýnputFireButton = ctx.ReadValueAsButton();
    public void OnLeft(InputAction.CallbackContext ctx) => ýnputLeftButton = ctx.ReadValueAsButton();
    public void OnRight(InputAction.CallbackContext ctx) => ýnputRightButton = ctx.ReadValueAsButton();
    public void OnUp(InputAction.CallbackContext ctx) => ýnputUpButton = ctx.ReadValueAsButton();
    public void OnDown(InputAction.CallbackContext ctx) => ýnputDownButton = ctx.ReadValueAsButton();
    public void OnPunch(InputAction.CallbackContext ctx) => ýnputPunchButton = ctx.ReadValueAsButton();
    public void OnExplode(InputAction.CallbackContext ctx) => ýnputExplodeButton = ctx.ReadValueAsButton();
}
