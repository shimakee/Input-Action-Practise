using UnityEngine;
using UnityEngine.InputSystem;


//Using input actions by attaching to Player input invoking uity events
public class Player : MonoBehaviour
{
    Vector2 _direction;
    float speed = 1;

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

    private void Update()
    {
        transform.Translate(_direction * speed * Time.deltaTime);
    }
}
