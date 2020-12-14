using UnityEngine;
using UnityEngine.InputSystem;


//Using Player input by getting player input component
public class PlayChar : MonoBehaviour
{
    [SerializeField] PlayerInput playerInput;

    private InputActionMap inputActionMap;
    private InputAction attackInputAction;
    private InputAction movementInputAction;
    private Vector2 direction;
    private float speed = 1;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();

        inputActionMap = playerInput.currentActionMap;

        movementInputAction = inputActionMap.FindAction("Move");
        attackInputAction = inputActionMap.FindAction("Attack");

        movementInputAction.performed += ctx => direction = ctx.ReadValue<Vector2>();
        movementInputAction.canceled += ctx => direction = ctx.ReadValue<Vector2>();
        attackInputAction.performed += _ => OnAttack();
    }

    private void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnAttack()
    {
        Debug.Log("Attack", this);
    }
}
