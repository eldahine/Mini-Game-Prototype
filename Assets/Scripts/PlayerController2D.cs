using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController2D : MonoBehaviour, InputSystem_Actions.IPlayerActions
{
    public Rigidbody2D rigidbody2d;
    public float movementSpeed = 1.0f;
    Vector2 movementDirection = Vector2.zero;

    // Source code representation of asset.
    public InputSystem_Actions m_Actions;
    // Source code representation of action map.
    private InputSystem_Actions.PlayerActions m_Player;

    void Awake()
    {
        // Create asset object.
        m_Actions = new InputSystem_Actions();
        // Extract action map object.
        m_Player = m_Actions.Player;
        // Register callback interface IPlayerActions.
        m_Player.AddCallbacks(this);
    }

    void OnDestroy()
    {
        // Destroy asset object.
        m_Actions.Dispose();
    }

    void OnEnable()
    {
        // Enable all actions within map.
        m_Player.Enable();
    }

    void OnDisable()
    {
        // Disable all actions within map.
        m_Player.Disable();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    void FixedUpdate() { 
        rigidbody2d.linearVelocity = new Vector2(movementDirection.x * movementSpeed, movementDirection.y * movementSpeed);
    }

    // Invoked when "Move" action is either started, performed or canceled.
    public void OnMove(InputAction.CallbackContext context)
    {
        movementDirection = context.ReadValue<Vector2>();
        //Debug.Log($"OnMove: {context.ReadValue<Vector2>()}");
    }

    // Invoked when "Attack" action is either started, performed or canceled.
    public void OnAttack(InputAction.CallbackContext context)
    {
        Debug.Log($"OnAttack: {context.ReadValue<float>()}");
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnCrouch(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnJump(InputAction.CallbackContext context)
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

    public void OnSprint(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }
}
