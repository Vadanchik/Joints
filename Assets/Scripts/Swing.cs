using UnityEngine;

public class Swing : MonoBehaviour
{
    [SerializeField] private HingeJoint _joint;
    [SerializeField] private float _forceValue;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = _joint.connectedBody;
    }

    private void OnMouseDown()
    {
        Push();
    }

    private void Push()
    {
        _rigidbody.AddForce(_rigidbody.transform.forward * _forceValue);
    }
}
