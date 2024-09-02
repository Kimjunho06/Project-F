using System;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.InputSystem;
using static Controls;

[CreateAssetMenu(menuName = "SO/InputReader")]
public class InputReader : ScriptableObject, IPlayerActions
{
    #region input event section
    public bool IsDash;
    public event Action InteractionEvent;
    #endregion

    #region input value section
    public float XInput { get; private set; }
    public float YInput { get; private set; }
    public Vector2 AimPosition { get; private set; }
    #endregion

    private Controls _controls;

    private void OnEnable()
    {
        if (_controls == null)
        {
            _controls = new Controls();
            _controls.Player.SetCallbacks(this);

        }
        _controls.Player.Enable();
    }

    public void SetPlayerInputEnable(bool value)
    {
        if (value)
            _controls.Player.Enable();
        else
            _controls.Player.Disable();
    }

    public void OnXMovement(InputAction.CallbackContext context)
    {
        XInput = context.ReadValue<float>();
    }

    public void OnYMovement(InputAction.CallbackContext context)
    {
        YInput = context.ReadValue<float>();
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        IsDash = context.performed; 
    }

    public void OnMousePosition(InputAction.CallbackContext context)
    {
        AimPosition = context.ReadValue<Vector2>();
    }

    public void OnInteraction(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            InteractionEvent?.Invoke();
        }
    }

}