using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [HideInInspector]
    public UnityEvent OnScoreChange = new();
    [HideInInspector]
    public UnityEvent OnColorChange = new();

    public Color Color {  get; private set; }
    public int Score { get; private set; }

    public Paddle Paddle;

    public bool isAI;

    float movement;
    bool isCharging;

    public void SetColor(Color color)
    {
        Color = color;
        OnColorChange.Invoke();
    }

    public void AddScore(int amount)
    {
        Score += amount;
        OnScoreChange.Invoke();
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        if (!isAI) MovePaddle(context.ReadValue<float>()); 
    }

    public void OnChargeInput(InputAction.CallbackContext context)
    {
        if (!isAI) ChargePaddle(context.ReadValueAsButton());
    }

    public void MovePaddle(float movement)
    {
        this.movement = movement;
    }

    public void ChargePaddle(bool isCharging)
    {
        this.isCharging = isCharging;
    }

    private void FixedUpdate()
    {
        if(movement != 0) Paddle.Move(movement);
        if (isCharging) Debug.Log("Is Charging..."); //Paddle.Charge(isCharging);
    }
}
