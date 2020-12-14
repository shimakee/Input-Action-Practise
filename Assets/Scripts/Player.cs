using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using UnityEngine.InputSystem.Interactions;


//Using input actions by attaching to Player input invoking uity events
public class Player : MonoBehaviour
{
    [SerializeField] GameObject UiParent;
    [SerializeField] GameObject UiMenu;
    [SerializeField] PlayerInput playerInput;

    GameObject UiInstance;
    public static GameObject UiParentInstance;
    Vector2 _direction;
    float speed = 1;

    InputActionMap gameActionMap;
    InputActionMap menuActionMap;

    private void Awake()
    {
        gameActionMap = playerInput.actions.FindActionMap("Character");
        menuActionMap = playerInput.actions.FindActionMap("Menu");

        if (UiParentInstance == null)
            UiParentInstance = Instantiate(UiParent);
    }

    private void Start()
    {
        playerInput.currentActionMap = gameActionMap;
        menuActionMap.Disable();

        if (UiMenu != null)
        {
            if (UiInstance == null)
            {
                UiInstance = Instantiate(UiMenu, UiParentInstance.transform);
                //need to assign the input system UI input module with the correct action asset - because there is a bug that clears the assignment in inspector after every play.
                var inputModule = UiInstance.GetComponent<InputSystemUIInputModule>();
                inputModule.actionsAsset = playerInput.actions;
                //need to hook up all the actions because it is not automatically assigned.
                inputModule.move = InputActionReference.Create(playerInput.actions["Menu/Navigate"]);

                //playerInput.uiInputModule = inputModule;
                UiInstance.SetActive(false);
            }
        }
    }


    public void OnMove(InputAction.CallbackContext ctx)
    {
        Debug.Log("Moving");

        _direction = ctx.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext ctx)
    {
        Debug.Log("Looking");
    }

    public void OnAttack(InputAction.CallbackContext ctx)
    {
        Debug.Log("Attacking");
    }

    public void OnPause(InputAction.CallbackContext ctx)
    {

        if (ctx.performed)
        {
            if(UiInstance != null)
            {
                UiInstance.SetActive(!UiInstance.activeSelf);
                if (UiInstance.activeSelf)
                {
                    menuActionMap.Enable();
                    gameActionMap.Disable();
                }
                else
                {
                    menuActionMap.Disable();
                    gameActionMap.Enable();
                }
            }
        }
    }

    private void Update()
    {
        transform.Translate(_direction * speed * Time.deltaTime);
    }
}
