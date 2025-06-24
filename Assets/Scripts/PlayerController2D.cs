using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController2D : MonoBehaviour, InputSystem_Actions.IPlayerActions
{
    [SerializeField] private Rigidbody2D rigidbody2d;
    
    [Header("Movement Variables")]
    [SerializeField] private float movementVelocity = 8.0f;
    private Vector2 movementDirection = Vector2.zero;

    [Header("Dashing Variables")]
    [SerializeField] private float dashingVelocity = 16.0f;
    [SerializeField] private float dashingTime = 0.2f;
    private Vector2 dashingDirection = Vector2.zero;
    private bool isDashing = false;
    private bool canDash = true;

    [Header("Melee Variables")]
    [SerializeField] private float attackForce = 16.0f;
    [SerializeField] private int dashAttackDamage = 10;

    // Source code representation of asset.
    private InputSystem_Actions actions;
    // Source code representation of action map.
    private InputSystem_Actions.PlayerActions playerActions;

    void Awake()
    {
        // Create asset object.
        actions = new InputSystem_Actions();
        // Extract action map object.
        playerActions = actions.Player;
        // Register callback interface IPlayerActions.
        playerActions.AddCallbacks(this);
    }

    void OnDestroy()
    {
        // Destroy asset object.
        actions.Dispose();
    }

    void OnEnable()
    {
        // Enable all actions within map.
        playerActions.Enable();
    }

    void OnDisable()
    {
        // Disable all actions within map.
        playerActions.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        if(movementDirection.normalized.x > 0)
        {
            // character is facing right
            transform.localScale = new Vector2(1, 1);
        }
        else if (movementDirection.normalized.x < 0)
        {
            // character is facing left
            transform.localScale = new Vector2(-1, 1);
        }

        // NOTE(Ahmed) set animation state in here
        // animator.setBool("IsWalking", movementDirection.magnitude != 0);
        // animator.setBool("IsDashing", isDashing);
    }

    void FixedUpdate() 
    { 
        if (isDashing) {
            rigidbody2d.linearVelocity = dashingDirection.normalized * dashingVelocity;
        }
        else
        {
            rigidbody2d.linearVelocity = movementDirection.normalized * movementVelocity;
        }
    }

    private IEnumerator StopDashing()
    {
        yield return new WaitForSeconds(dashingTime);
        isDashing = false;
        canDash = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (isDashing)
            {
                //Debug.Log($"name: {collision.gameObject.name}");
                collision.rigidbody.AddForce(dashingDirection * attackForce);

                if (collision.transform.TryGetComponent<Health>(out Health health)) {
                    health.Damage(dashAttackDamage);
                }
            }
        }
    }

    // Invoked when "Move" action is either started, performed or canceled.
    public void OnMove(InputAction.CallbackContext context)
    {
        movementDirection = context.ReadValue<Vector2>();
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if (canDash) {
            canDash = false;
            isDashing = true;
            dashingDirection = movementDirection;

            if (dashingDirection == Vector2.zero) {
                // NOTE(Ahmed) our character is simple and it only has a single sprite facing right
                // we can use the x scale to determine the current direction the character faces.
                // currently we only "Animate" 2 directions, if we had a 4 directional animation this has to change.
                dashingDirection = new Vector2(transform.localScale.x, 0);
            }

            StartCoroutine(StopDashing()); 
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        // Debug.Log($"OnAttack: {context.ReadValue<float>()}");
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnPrevious(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnNext(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

}
