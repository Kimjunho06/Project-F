using System;
using UnityEngine;

public class Player : PlayerController
{
    [Header("Setting values")]
    public float moveSpeed = 5f;
    public float dashSpeed = 10f;

    public Item currentItem;
    public GameObject itemObj;

    public LayerMask getObjLayer;

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
        StateMachine.Initialize(PlayerStateEnum.Idle, this);

        if (Inventory.instance.ItemList.Count > 0)
            currentItem = Inventory.instance.ItemList[0];
        else
            currentItem = Inventory.instance.NoneItem;
    }

    protected void Update()
    {
        StateMachine.CurrentState.UpdateState();


        xInput = PlayerInput.XInput;
        yInput = PlayerInput.YInput;

        if (Mathf.Abs(xInput) > 0.05f || Mathf.Abs(yInput) > 0.05f)
            SetPrevInput(xInput, yInput);
    }

    public void AnimationEndTrigger() => StateMachine.CurrentState.AnimationEndTrigger();

    // 이전 보는 방향을 구하기 위함. // 8방향
    private void SetPrevInput(float xinput, float yinput)
    {
        if (xinput != 0)
            xinput = Mathf.Sign(xinput);
        if (yinput != 0)
            yinput = Mathf.Sign(yinput);

        prevInput = transform.right * FacingDirection * xinput + transform.up * yinput;
    }

    public void SetCurrentItem(int idx)
    {
        currentItem = Inventory.instance.ItemList[idx];

        SpriteRenderer sprite = itemObj.GetComponent<SpriteRenderer>();
        sprite.sprite = currentItem.ItemData.ItemImage;

        sprite.sortingOrder = -1;
    }
}