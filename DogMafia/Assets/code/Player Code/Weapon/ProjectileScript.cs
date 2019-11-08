using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public Type _Type;
    public float _ProjectileSpeed;
    public float _Damage;
    public float _StunDuration;
    private Vector2 _MousePos;

    private void OnCollisionEnter2D(Collision2D _Collision)
    {
        switch(_Type)
        {
            case Type.Damage:
            {
                if(!_Collision.gameObject.CompareTag("Player"))
                    {
                        _Collision.transform.BroadcastMessage("ApplyDamage", _Damage);
                        Die();
                    }
                break;
            }
            case Type.Stun:
            {
                if (!_Collision.gameObject.CompareTag("Player"))
                {
                    _Collision.transform.BroadcastMessage("ApplyStun", _StunDuration);
                    Die();
                }
                break;
            }
        }
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _MousePos, _ProjectileSpeed * Time.deltaTime);
        if(Vector2.Distance(transform.position, _MousePos) <= .1)
        {
            Die();
        }
    }

    private void Start()
    {
        
        //_CenterPointOfPlayer = GameObject.FindGameObjectWithTag("Player");
        _MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //_MousePos.x -= _CenterPointOfPlayer.transform.position.x;
        //_MousePos.y -= _CenterPointOfPlayer.transform.position.y;
        
    }
    private void Die()
    {
        Destroy(gameObject);
    }
}

public enum Type
{
    Damage,
    Stun
}