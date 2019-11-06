using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Weapon : MonoBehaviour
{
    public CurrentPrimary _CurrentPrimary;
    public CurrentSpecial _CurrentSpecial;
    public CurrentMelee _CurrentMelee;
    public DebugMode _DebugMode;

    private Animator _Animator;

    private Vector3 _MousePos; //position of mouse relative to world cordinates 
    public GameObject _CenterPointOfPlayer;
    private float _SafeZoneRadius = 1;

    public GameObject _StunProjectile;
    public GameObject _DamageProjectile;

    private Vector3 _FirePoint;

    //See PlayerScript.cs for animator---------------------------------------------------------------------------------------------------

    void Start()
    {
        _Animator = gameObject.GetComponent<Animator>();
    }

    
    void Update()
    {
        _MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _MousePos.x -= _CenterPointOfPlayer.transform.position.x;
        _MousePos.y -= _CenterPointOfPlayer.transform.position.y;
        _Animator.SetFloat("AimingAngle", GetAngle()); 

        switch (_DebugMode)
        {
            case DebugMode.Origin:
                {
                    Debug.DrawRay(_CenterPointOfPlayer.transform.position, _MousePos, Color.blue);
                    //Debug.Log(Mathf.Atan(_MousePos.y / _MousePos.x) * 180 / Mathf.PI);
                    break; 
                }
            case DebugMode.Ranged:
                {
                    float _Angle = Mathf.Atan(_MousePos.y / _MousePos.x);
                    Debug.Log("X:" + _MousePos.x + " Y:" + _MousePos.y);
                    if (_MousePos.x > _CenterPointOfPlayer.transform.position.x)
                    {
                        _FirePoint.x = Mathf.Cos(_Angle) * _SafeZoneRadius + _CenterPointOfPlayer.transform.position.x;
                        _FirePoint.y = Mathf.Sin(_Angle) * _SafeZoneRadius + _CenterPointOfPlayer.transform.position.x;

                    }
                    else if(_MousePos.x < _CenterPointOfPlayer.transform.position.x)
                    {
                        _FirePoint.x = Mathf.Cos(_Angle) * -_SafeZoneRadius + _CenterPointOfPlayer.transform.position.x;
                        _FirePoint.y = Mathf.Sin(_Angle) * -_SafeZoneRadius + _CenterPointOfPlayer.transform.position.x;
                    }
                    else
                    {
                        _FirePoint.x = _CenterPointOfPlayer.transform.position.x;
                        _FirePoint.y = (_MousePos.y > _CenterPointOfPlayer.transform.position.y) ? (_SafeZoneRadius) : (-1 * _SafeZoneRadius) + _CenterPointOfPlayer.transform.position.y;
                    }
                    Debug.DrawRay(_FirePoint, _MousePos, Color.blue);
                    break;
                }
            case DebugMode.Off:
                break;
        }
    }

    private float GetAngle() //gets the angle that the character is aiming
    {
        if (_MousePos.y > _CenterPointOfPlayer.transform.position.y)
        {
            //return (Mathf.Atan(_MousePos.y - _CenterPointOfPlayer.transform.position.y  / _MousePos.x - _CenterPointOfPlayer.transform.position.x) * 180 / Mathf.PI) + ((_MousePos.x > _CenterPointOfPlayer.transform.position.x) ? 0f : 0f);
            if (_MousePos.x > _CenterPointOfPlayer.transform.position.x)
            {
                return (Mathf.Atan(_MousePos.y - _CenterPointOfPlayer.transform.position.y / _MousePos.x - _CenterPointOfPlayer.transform.position.x) * 180 / Mathf.PI);
            }
            else
            {
                return 180 - (Mathf.Atan(_MousePos.y - _CenterPointOfPlayer.transform.position.y / _MousePos.x - _CenterPointOfPlayer.transform.position.x) * 180 / Mathf.PI);
            }
        }
        else
        {
            //return (Mathf.Atan(_MousePos.y - _CenterPointOfPlayer.transform.position.x / _MousePos.x - _CenterPointOfPlayer.transform.position.x) * 180 / Mathf.PI) + ((_MousePos.x > _CenterPointOfPlayer.transform.position.x) ? 360f : 270f);
            if (_MousePos.x > _CenterPointOfPlayer.transform.position.x)
            {
                return 360 + (Mathf.Atan(_MousePos.y - _CenterPointOfPlayer.transform.position.x / _MousePos.x - _CenterPointOfPlayer.transform.position.x) * 180 / Mathf.PI);
            }
            else
            {
                return 180 - (Mathf.Atan(_MousePos.y - _CenterPointOfPlayer.transform.position.x / _MousePos.x - _CenterPointOfPlayer.transform.position.x) * 180 / Mathf.PI);
            }
        }
    }

    public void PrimaryFire() //Primary weapon slot
    {
        _Animator.SetTrigger("FiredPrimary");
        switch (_CurrentPrimary)
        {
            case CurrentPrimary.Unarmed: //no weapon
                {
                    break;
                }
            case CurrentPrimary.StunGunRay: //shotos a stun ray
                {
                    ShootStunGunRay();
                    break;
                }
            case CurrentPrimary.StunGunProjectile: //shots a stun projectile
                {
                    Debug.Log(GetAngle());
                    ShootStunProjectile();
                    break;
                }
            case CurrentPrimary.DamageRay:
                {
                    ShootDamageRay();
                    break;
                }
            case CurrentPrimary.DamageProjectile:
                {
                    ShootDamageProjectile();
                    break;
                }
        }
    }

    public void SpecialFire()
    {
        switch (_CurrentSpecial)
        {
            case CurrentSpecial.Unarmed:
                {
                    break;
                }
        }
    }

    public void MeleeAttack()
    {
        _Animator.SetTrigger("Attack");
        switch (_CurrentMelee)
        {
            case CurrentMelee.Damage:
                {
                    PreformDamageMelee();
                    break;
                }
        }
    }

    private void ShootStunGunRay()
    {
        float _StunDuration = 4;
        RaycastHit2D _Hit = Physics2D.Raycast(_CenterPointOfPlayer.transform.position, _MousePos, Mathf.Infinity, ~LayerMask.NameToLayer("Player"));
        if (_Hit)
        {
            _Hit.transform.BroadcastMessage("ApplyStun", _StunDuration);
        }
    }

    private void ShootDamageRay()
    {
        float _Damage = 20;
        RaycastHit2D _Hit = Physics2D.Raycast(_CenterPointOfPlayer.transform.position, _MousePos, Mathf.Infinity, ~LayerMask.NameToLayer("Player"));
        if (_Hit)
        {
            _Hit.transform.BroadcastMessage("ApplyDamage", _Damage);
        }
    }

    private void ShootStunProjectile()
    {
        if (_StunProjectile != null)
        {
            Instantiate(_StunProjectile, transform.position, Quaternion.identity);
        }
    }

    private void ShootDamageProjectile()
    {
        if(_DamageProjectile != null)
        {
            Instantiate(_DamageProjectile, transform.position, Quaternion.identity);
        }
    }

    private void PreformDamageMelee()
    {
        float _Damage = 50;
        float _MeleeRange = 2.0f;
        RaycastHit2D _Hit = Physics2D.Raycast(_CenterPointOfPlayer.transform.position, _MousePos, _MeleeRange, ~LayerMask.NameToLayer("Player"));
        if (_Hit)
        {
            _Hit.transform.BroadcastMessage("ApplyDamage", _Damage);
        }
    }
}

public enum CurrentPrimary
{
    Unarmed,
    StunGunRay,
    StunGunProjectile,
    DamageRay,
    DamageProjectile
}

public enum CurrentSpecial
{
    Unarmed
}

public enum CurrentMelee
{
    Unarmed,
    Damage
}


public enum DebugMode
{
    Origin,
    Ranged,
    Off
}
