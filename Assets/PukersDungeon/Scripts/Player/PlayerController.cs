using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private PlayerAnimator _animator;
    [SerializeField] private PlayerAudioManager _audioManager;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _gravity;
    [SerializeField] private float _jumpForse;
    [SerializeField] private float _speedRotate;

    private CharacterController _controller;
    private Collider _collider;
    private Vector3 _moveDirection;

    private float _verticalVelocity = 0.0f;
    private float _xRotation = 0.0f;

    private bool _isAttacking = true;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        SetMoveDirection();
        Rotate();

        if (_controller.isGrounded)
        {
            _verticalVelocity = 0.0f;
            Jump();
        }
        else
        {
            _verticalVelocity -= _gravity * Time.deltaTime;
        }

        Attack();
    }

    public void Disable()
    {
        _collider.enabled = false;
        enabled = false;
    }

    private void SetMoveDirection()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 inputDirection = new Vector3(horizontalInput, _verticalVelocity, verticalInput);
        inputDirection = transform.TransformDirection(inputDirection);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            inputDirection *= 1.5f;
        }

        _moveDirection = inputDirection * _moveSpeed * Time.deltaTime;
        _controller.Move(_moveDirection);

        _animator.SetRun(inputDirection.magnitude > 0.1f);
    }

    private void Jump()
    {
        if (Input.GetButton("Jump"))
        {
            _verticalVelocity = _jumpForse;

            _animator.SetJump();
            _audioManager.PLayJumpSound();
        }
    }

    private void Rotate()
    {
        _xRotation -= Input.GetAxis("Mouse Y") * _speedRotate * Time.deltaTime;
        _xRotation = Mathf.Clamp(_xRotation, -90.0f, 90.0f);

        _camera.localRotation = Quaternion.Euler(_xRotation, 0.0f, 0.0f);

        transform.Rotate(Input.GetAxis("Mouse X") * _speedRotate * Time.deltaTime * Vector3.up);
    }

    private void Attack()
    {
        if (Input.GetMouseButton(0) && _isAttacking)
        {
            _animator.SetAttack();
            _audioManager.PLayAttackSound();
            StartCoroutine(AttackWithDelay());
        }
    }

    IEnumerator AttackWithDelay()
    {
        _isAttacking = false;
        yield return new WaitForSeconds(1.0f);
        _isAttacking = true;
    }
}
