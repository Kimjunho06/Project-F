using System;
using System.Collections;
using UnityEngine;

public abstract class PlayerController : MonoBehaviour
{
    #region components region
    public Animator AnimatorCompo { get; private set; }
    public Rigidbody2D RigidbodyCompo { get; private set; }
    public SpriteRenderer SpriteRendererCompo { get; private set; }
    public CapsuleCollider2D Collder2DCompo { get; private set; }
    #endregion

    public bool CanStateChangeable { get; set; } = true;
    public int FacingDirection { get; protected set; } = 1; //오른쪽을 향하고 있을때 1
    public Action<int> OnFlip;

    public bool isDead;

    protected virtual void Awake()
    {
        Transform visualTrm = transform.Find("Visual");
        AnimatorCompo = visualTrm.GetComponent<Animator>();
        SpriteRendererCompo = visualTrm.GetComponent<SpriteRenderer>();
        RigidbodyCompo = GetComponent<Rigidbody2D>();
        Collder2DCompo = GetComponent<CapsuleCollider2D>();
    }

    protected virtual void OnDestroy(){}
    
    #region Delay Callback Coroutine

    public Coroutine StartDelayCallback(float delayTime, Action Callback)
    {
        return StartCoroutine(DelayCoroutine(delayTime, Callback));
    }

    protected IEnumerator DelayCoroutine(float delayTime, Action Callback)
    {
        yield return new WaitForSeconds(delayTime);
        Callback?.Invoke();
    }

    #endregion


    #region Flip controlling

    public virtual void Flip()
    {
        FacingDirection = FacingDirection * -1;
        transform.Rotate(0, 180, 0); //180도 회전. 
        OnFlip?.Invoke(FacingDirection);
    }


    public virtual void FlipController(float x)
    {
        //반대방향으로 눌렀다면
        x = x > 0.05f ? 1 : x < -0.05f ? -1 : 0;
        if (Mathf.Abs(FacingDirection + x) < 0.5f)
        {
            Flip();
        }
    }

    #endregion

    #region velocity control

    public void SetVelocity(float x, float y, bool doNotFlip = false)
    {
        RigidbodyCompo.velocity = new Vector2(x, y);
        if (!doNotFlip)
            FlipController(x);
    }

    public void StopImmediately(bool withYAxis)
    {
        if (withYAxis)
            RigidbodyCompo.velocity = Vector2.zero;
        else
            RigidbodyCompo.velocity = new Vector2(0, RigidbodyCompo.velocity.y);
    }
    #endregion
}