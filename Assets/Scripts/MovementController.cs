using Scripts;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private AnimationsController _animationsController;
    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _runSpeed;
    [SerializeField] private float _rotationSpeed;

    private float _moveSpeed;
    private Vector3 _lastPlayerPosition;
    
    private void Awake()
    {
        _moveSpeed = _walkSpeed;
    }

    void Update()
    {
        _lastPlayerPosition = transform.position;

        var currentAnimatorClipInfo = _animationsController.GetCurrentAnimationClip();
        if (currentAnimatorClipInfo.name != GlobalConstants.ANIMATION_CLIP_HOOK_NAME)
        {
            Move();
            Rotate();
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _animationsController.SwitchHookAnimationOn();
        }

        if (IsPlayerMoving())
        {
            _animationsController.SwitchWalkAnimationOn();
            _moveSpeed = _walkSpeed;
        }

        if (!IsPlayerMoving())
        {
            _animationsController.SwitchIdleAnimationOn();
        }

        if (IsPlayerMoving() && Input.GetKey(KeyCode.LeftShift))
        {
            _animationsController.SwitchRunAnimationOn();
            _moveSpeed = _runSpeed;
        }
        
    }

    private void Move()
    {
        var verticalInput = Input.GetAxis("Vertical");
            
        Vector3 movement = new Vector3(0f, 0f, verticalInput).normalized;

        transform.Translate(movement * (_moveSpeed * Time.deltaTime));
    }

    private void Rotate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            var rotation = transform.rotation.eulerAngles.y + _rotationSpeed * Time.deltaTime;

            transform.rotation = Quaternion.Euler(0f, rotation % 360f, 0f);
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            var rotation = transform.rotation.eulerAngles.y - _rotationSpeed * Time.deltaTime;

            transform.rotation = Quaternion.Euler(0f, rotation % 360f, 0f);
        }
    }

    private bool IsPlayerMoving()
    {
        if (_lastPlayerPosition != transform.position)
        {
            return true;
        }

        return false;
    }
}
