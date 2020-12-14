using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static Multipleschemes;


//Using input asset as a class and setting the callback
public class Character : MonoBehaviour, ICharacterActions
{
    Multipleschemes playerControls;
    Vector2 _direction;
    float speed = 1;

    #region Unity Methods

    private void Awake()
    {
        if (playerControls == null)
            playerControls = new Multipleschemes();

        playerControls.Character.SetCallbacks(this);
    }

    private void Update()
    {
        transform.Translate(_direction * speed * Time.deltaTime);
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void OnEnable()
    {
        if(playerControls == null)
        {
            playerControls = new Multipleschemes();
            playerControls.Character.SetCallbacks(this);
        }
        playerControls.Enable();
    }

    #endregion
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


}
