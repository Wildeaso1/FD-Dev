using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _arrivalThreshold;

    private Path _path;
    private Waypoint _currentwaypoint;

    private void Start()
    {
        SetupPath();

    }

    private void SetupPath()
    {
        _path = FindObjectOfType<Path>();
        _currentwaypoint = _path.GetPathStart();
    }

    private void Update()
    {
        //transform.LookAt(_currentwaypoint.getPosition());
        transform.Translate(Vector3.forward * _speed * Time.deltaTime,Space.Self);

        Vector3 waypointPosition =_currentwaypoint.getPosition();
        float distanceToWaypoint = Vector3.Distance(transform.position, new Vector3(waypointPosition.x, transform.position.y, waypointPosition.z));
        print(distanceToWaypoint);
        if (distanceToWaypoint <= _arrivalThreshold)
        {
            if (_currentwaypoint == _path.GetPathEnd())
            {
                PathComplete();
            }
            else
            {
                _currentwaypoint = _path.GetNextWayPoint(_currentwaypoint);
                transform.LookAt(_currentwaypoint.getPosition());
            }
        }
    }

    private void PathComplete()
    {
        print("Ending");
        Destroy(this.gameObject);
    }
}
