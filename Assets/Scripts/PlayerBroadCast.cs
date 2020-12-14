using UnityEngine;
using UnityEngine.InputSystem;

//Using input actions by attaching to Player input invoking broadcast message
//have no way of getting input info, so you still have to attach player input or input class implementation
public class PlayerBroadCast : MonoBehaviour
{
    Vector2 _direction;
    float speed = 1;

    private void Awake()
    {
    }

    public void OnMove()
    {
        
        Debug.Log("Moving");

        //_direction = ctx.ReadValue<Vector2>();
    }

    public void OnLook()
    {
        Debug.Log("Looking");
    }

    public void OnAttack()
    {
        Debug.Log("Attacking");
    }

    private void Update()
    {
    }
}
