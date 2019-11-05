using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour
{

    private Vector3 _StartingPosition;
    public Transform _FollowTarget;
    private Vector3 _TargetPos;
    public float _MoveSpeed;

    void Start()
    {
        _StartingPosition = transform.position;
    }

    void Update()
    {
        if (_FollowTarget != null)
        {
            _TargetPos = new Vector3(_FollowTarget.position.x, _FollowTarget.position.y, transform.position.z);
            Vector3 velocity = (_TargetPos - transform.position) * _MoveSpeed;
            transform.position = Vector3.SmoothDamp(transform.position, _TargetPos, ref velocity, 1.0f, Time.deltaTime);
        }
    }

    void TrackPlayer()
    {
        _FollowTarget = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void TrackTarget(Transform _Target)
    {
        _FollowTarget = (_Target ? _FollowTarget : _Target);
    }
}
