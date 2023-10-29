using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _mainThrust = 1000F;
    [SerializeField] private float _rotationThrust = 100F;

    private Rigidbody _rigidbody;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log($"Hi! I initialize Movement script.");
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    private void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            _rigidbody.AddRelativeForce(Vector3.up * (_mainThrust * Time.deltaTime));
        }
    }

    private void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            ApplyRotation(Vector3.back);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            ApplyRotation(Vector3.forward);
        }
    }

    private void ApplyRotation(Vector3 direction)
    {
        transform.Rotate(direction * (_rotationThrust * Time.deltaTime));
    }
}
