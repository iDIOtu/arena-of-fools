using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MainCharacterController : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private Health—ontrol _healthControl;
    [SerializeField] private float _speedMove;
    [SerializeField] private float _gravity;
    [SerializeField] private float _jumpForse;
    [SerializeField] private float _speedRotate;

    private Animator _animator;
    private CharacterController _controller;
    private Vector3 _moveDirection;
    private float _yDirection = 0.0f;
    private float _xRotation = 0.0f;
    private float _healthPoints = 100.0f;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        SetMoveDirection();

        if (_controller.isGrounded)
        {
            _yDirection = 0.0f;

            _animator.SetBool("Jump", false);
            if (Input.GetButton("Jump"))
            {
                Jump();
            }
        }

        Rotate();

        _yDirection -= _gravity * Time.deltaTime;
        _controller.Move(_moveDirection);
    }

    private void SetMoveDirection()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 inputDirection = new Vector3(horizontalInput, _yDirection, verticalInput);
        inputDirection = transform.TransformDirection(inputDirection);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            inputDirection *= 1.5f;
        }

        _moveDirection = inputDirection * _speedMove * Time.deltaTime;

        _animator.SetBool("Run", inputDirection.magnitude > 0.1f);
    }

    private void Jump()
    {
        _yDirection = _jumpForse;

        _animator.SetBool("Jump", true);
    }

    private void Rotate()
    {
        _xRotation -= Input.GetAxis("Mouse Y") * _speedRotate * Time.deltaTime;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        _camera.localRotation = Quaternion.Euler(_xRotation, 0.0f, 0.0f);

        transform.Rotate(Input.GetAxis("Mouse X") * _speedRotate * Time.deltaTime * Vector3.up);
    }

    public void GetDamage(float damage)
    {
        _healthPoints -= damage * Time.deltaTime;

        _healthControl.SetHealth(damage);

        if (_healthPoints <= 0)
        {
            Debug.Log("you DIED MUHAHAHAHAHA");
        }
    }
}
