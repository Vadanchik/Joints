using System.Collections;
using UnityEngine;

public class Catapult : MonoBehaviour
{
    [SerializeField] private Vector3 _torque;
    [SerializeField] private ForceMode _forceMode;
    [SerializeField] private Rigidbody _prefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _reloadTime = 3;

    private Rigidbody _currentBall;
    private SpringJoint _joint;
    private Rigidbody _spoon;
    private bool _isReady = true;

    private void Awake()
    {
        _joint = GetComponent<SpringJoint>();
        _spoon = _joint.connectedBody;
    }

    private void Start()
    {
        SpawnBall();
    }

    private void OnMouseDown()
    {
        if (_isReady)
        {
            StartCoroutine(Launch());
        }
    }

    private IEnumerator Launch()
    {
        _isReady = false;
        _currentBall.isKinematic = false;
        _spoon.AddRelativeTorque(_torque, _forceMode);

        yield return new WaitForSeconds(_reloadTime);

        SpawnBall();
        _isReady = true;
    }

    private void SpawnBall()
    {
        _currentBall = Instantiate(_prefab, _spawnPoint.position, Quaternion.identity);
        _currentBall.isKinematic = true;
    }
}
