using System.Collections; 
using UnityEngine;

public abstract class PlayerPickState : PlayerState
{
    protected Vector3 getObjoffset;
    protected Vector3 getObjSize;
    protected LayerMask getObjLayer;

    protected float sizeMultiply = 1;

    private Coroutine rotateCoroutine;
    private Vector3 objRot;
 
    public PlayerPickState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
 

        objRot = _player.currentItemObj.transform.eulerAngles;

        RotatePickItem(-25f);
        _player.StopImmediately();
    }

    public override void Exit()
    {
        base.Exit();

        PickCancel(objRot);
    }

    public override void UpdateState()
    {
        base.UpdateState();
        
        // 상호작용 중 움직이면 취소.
        if (Mathf.Abs(_player.xInput) > 0.05f || Mathf.Abs(_player.yInput) > 0.05f)
            _player.StateMachine.ChangeState(PlayerStateEnum.Idle);

        // 애니메이션 끝나면 돌아가기.
        if (_endtriggerCalled)
            _player.StateMachine.ChangeState(PlayerStateEnum.Idle);
    }

    // Update에서 해주면 모든 각도 오브젝트 가져옴.
    public Collider2D[] GetObjects()
    {
        Vector3 pos = _player.transform.position + _player.prevInput.normalized - new Vector3(0, 0.1f, 0);
        Vector3 size = Vector3.one * 0.8f * sizeMultiply;
        float angle = GetAngle();

        Collider2D[] objects = Physics2D.OverlapBoxAll(pos, size, angle, getObjLayer);
        return objects;
    }

    public Collider2D GetObject()
    {
        Vector3 pos = _player.transform.position + _player.prevInput.normalized;
        Vector3 size = Vector3.one * 0.8f * sizeMultiply;
        float angle = GetAngle();

        Collider2D objects = Physics2D.OverlapBox(pos, size, angle, getObjLayer);
        return objects;
    }

    private float GetAngle()
    {
        Vector3 dir = _player.prevInput.normalized;
        float dot = Vector3.Dot(_player.transform.right * _player.FacingDirection, dir);

        float minAngle = (_player.prevInput.y < 0) ? -1 : 1;

        return Mathf.Acos(dot) * Mathf.Rad2Deg * minAngle;
    }

    protected void RotatePickItem(float zAngle)
    {
        if (rotateCoroutine != null)
        {
            return;
        }

        objRot = _player.currentItemObj.transform.eulerAngles;
        Quaternion targetRot = Quaternion.Euler(objRot + new Vector3(0, 0, zAngle));

        rotateCoroutine = _player.StartCoroutine(RotateItem(targetRot, objRot));
    }

    protected void PickCancel(Vector3 objRot)
    {
        if (rotateCoroutine == null)
        {
            return;
        }

        _player.StopCoroutine(rotateCoroutine);
        rotateCoroutine = null;

        _player.currentItemObj.transform.rotation = Quaternion.Euler(objRot);
    }

    protected abstract void InteractEndItem();

    private IEnumerator RotateItem(Quaternion targetRot, Vector3 objRot)
    {
        float rotSpeed = 100;
        while (Quaternion.Angle(_player.currentItemObj.transform.rotation, targetRot) > 0.1f)
        {
            _player.currentItemObj.transform.rotation = Quaternion.RotateTowards(_player.currentItemObj.transform.rotation, targetRot, rotSpeed * Time.deltaTime);
            yield return null;

        }

        while (Quaternion.Angle(_player.currentItemObj.transform.rotation, Quaternion.identity) > 0.1f)
        {
            _player.currentItemObj.transform.rotation = Quaternion.RotateTowards(_player.currentItemObj.transform.rotation, Quaternion.Euler(objRot), rotSpeed * Time.deltaTime);
            yield return null;

        }
        _player.currentItemObj.transform.rotation = Quaternion.identity;

        InteractEndItem();
    }
}