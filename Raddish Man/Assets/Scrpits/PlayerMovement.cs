
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerControls _playerControls;
    private Rigidbody _rigidbody;

    private float _speedZ;
    private float _speedX;

    private void Awake()
    {
        _playerControls = new PlayerControls();
        
        _playerControls.Gameplay.Forward.performed += ctx => MoveForward();
        _playerControls.Gameplay.Forward.canceled +=  ctx => StandStillZ();
        
        _playerControls.Gameplay.Backwards.performed += ctx => MoveBackward();
        _playerControls.Gameplay.Backwards.canceled +=  ctx => StandStillZ();
        
        _playerControls.Gameplay.Forward.performed += ctx => MoveRight();
        _playerControls.Gameplay.Forward.canceled +=  ctx => StandStillX();
        
        _playerControls.Gameplay.Backwards.performed += ctx => MoveLeft();
        _playerControls.Gameplay.Backwards.canceled +=  ctx => StandStillX();
    }
    
    // Start is called before the first frame update
    private void Start()
    {
        print("AA");
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void MoveForward()
    {
        _speedZ = 1;
    }

    private void MoveBackward()
    {
        _speedZ = -1;
    }

    private void StandStillZ()
    {
        _speedZ = 0;
    }
    
    private void MoveRight()
    {
        _speedX = 1;
    }

    private void MoveLeft()
    {
        _speedX = -1;
    }

    private void StandStillX()
    {
        _speedX = 0;
    }
    
    private void OnEnable()
    {
        _playerControls.Gameplay.Enable();
    }

    private void OnDisable()
    {
        _playerControls.Gameplay.Disable();
    }
    

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(_speedX, 0, _speedZ);
    }
}
