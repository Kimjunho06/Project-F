using System;
using UnityEngine;
using UnityEngine.Playables;

public class Player : PlayerController
{
    [Header("Setting values")]
    public float moveSpeed = 12f;
    public float jumpForce = 12f;
    public float dashDuration = 0.4f;
    public float dashSpeed = 20f;

    public PlayerStateMachine StateMachine { get; private set; }
    [SerializeField] private InputReader _inputReader;
    public InputReader PlayerInput => _inputReader;

    protected override void Awake()
    {
        base.Awake();
        StateMachine = new PlayerStateMachine();

        foreach (PlayerStateEnum state in Enum.GetValues(typeof(PlayerStateEnum)))
        {

            string typeName = state.ToString();
            try
            {
                Type t = Type.GetType($"Player{typeName}State");
                var playerState = Activator.CreateInstance(t, this, StateMachine, typeName) as PlayerState;

                StateMachine.AddState(state, playerState);
            }
            catch (Exception ex)
            {
                Debug.LogError($"{typeName} is loading error, Message :");
                Debug.Log(ex);
            }
        }
    }

    private void OnEnable()
    {
        PlayerInput.DashEvent += HandleDashEvent;
    }

    private void OnDisable()
    {
        PlayerInput.DashEvent -= HandleDashEvent;
    }

   
    protected void Start()
    {
        StateMachine.Initialize(PlayerStateEnum.Idle, this);
    }

    protected void Update()
    {
        StateMachine.CurrentState.UpdateState();
    }

    public void AnimationEndTrigger() => StateMachine.CurrentState.AnimationEndTrigger();

    private void HandleDashEvent()
    {
        // Dash
    }
}