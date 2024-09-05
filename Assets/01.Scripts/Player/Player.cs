using System;
using UnityEngine;

public class Player : PlayerController
{
    [Header("Setting values")]
    public float moveSpeed = 5f;
    public float dashSpeed = 10f;

    public ItemType currentItem;
    public GameObject currentItemObj;

    public PlayerStateMachine StateMachine { get; private set; }
    [SerializeField] private InputReader _inputReader;
    public InputReader PlayerInput => _inputReader;

    public float xInput;
    public float yInput;

    public Vector3 prevInput { get; private set; }


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
    
    protected void Start()
    {
        currentItem = ItemType.None;
        PickItem(currentItem);

        StateMachine.Initialize(PlayerStateEnum.Idle, this);
    }

    protected void Update()
    {
        StateMachine.CurrentState.UpdateState();


        xInput = PlayerInput.XInput;
        yInput = PlayerInput.YInput;

        if (Mathf.Abs(xInput) > 0.05f || Mathf.Abs(yInput) > 0.05f)
            SetPrevInput(xInput, yInput);



        if (Input.GetKeyDown(KeyCode.T))
            PickItem(ItemType.None);
        if (Input.GetKeyDown(KeyCode.Y))
            PickItem(ItemType.Seed);
        if (Input.GetKeyDown(KeyCode.U))
            PickItem(ItemType.WateringCan);
        if (Input.GetKeyDown(KeyCode.I))
            PickItem(ItemType.Fertilizer);
        if (Input.GetKeyDown(KeyCode.O))
            PickItem(ItemType.Sickle);
    }

    public void AnimationEndTrigger() => StateMachine.CurrentState.AnimationEndTrigger();

    public void PickItem(ItemType itemType)
    {
        Transform visual = transform.Find("Visual");
        Transform rHand = visual.Find("RightHand");

        GameObject prevObj = rHand.Find(currentItem.ToString()).gameObject;
        prevObj.SetActive(false);

        currentItem = itemType;

        currentItemObj = rHand.Find(itemType.ToString()).gameObject;
        currentItemObj.SetActive(true); 
    }

    // 이전 보는 방향을 구하기 위함. // 8방향
    private void SetPrevInput(float xinput, float yinput)
    {
        if (xinput != 0)
            xinput = Mathf.Sign(xinput);
        if (yinput != 0)
            yinput = Mathf.Sign(yinput);

        prevInput = transform.right * FacingDirection * xinput + transform.up * yinput;
    }
}