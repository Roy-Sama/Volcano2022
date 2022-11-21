using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    public bool _waterOn;


    [Header("Mesh")]
    [SerializeField] Transform _mesh;
    [Header("Physics")]
    public Vector3 PlayerMovementInput;
    public Rigidbody _rb;
    [SerializeField] float _moveSpeed, _groundDistance, _rotSpeed;
    [SerializeField] Transform _cam;
    [SerializeField] Ladder _currentLadder;
    [Header("Animation")]
    public bool _isPlanting;
    public Animator _animator;

    public static PlayerBehaviour instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Il y a plus d'une instance de PlayerBehaviour dans la scène");
            return;
        }

        instance = this;
    }

    void Start()
    {
        _isPlanting = false;
        _waterOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isPlanting)
        {
            PlayerMovementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")); 
        }

        if (PlayerMovementInput != Vector3.zero )
        {
            _animator.SetBool("isWalking", true);
        }
        else
        {
            _animator.SetBool("isWalking", false);
        }

        //Jump();
        MovePlayer();
        ladder();
    }

    //bool IsGrounded()
    //{
    //    return Physics.Raycast(transform.position, Vector3.down, _groundDistance);
    //}

    //void Jump()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
    //    {
    //        print("Jump");
    //        _rb.velocity = Vector3.up * _jumpForce;
    //    }
    //}

    void MovePlayer()
    {

        Vector3 camF = _cam.forward;
        Vector3 camR = _cam.right;

        camF.y = 0;
        camR.y = 0;

        camF = camF.normalized;
        camR = camR.normalized;

        Vector3 MoveVector = transform.TransformDirection(PlayerMovementInput.z * camF + PlayerMovementInput.x * camR) * _moveSpeed * Time.deltaTime;
        _rb.velocity = new Vector3(MoveVector.x, _rb.velocity.y, MoveVector.z);

        if (PlayerMovementInput.z >= 0.01f)
        {
            Quaternion toRot = Quaternion.LookRotation(camF, Vector3.up);

            _mesh.rotation = Quaternion.RotateTowards(transform.rotation, toRot, _rotSpeed);
        }
        else if (PlayerMovementInput.z <= -0.01f)
        {
            Quaternion toRot = Quaternion.LookRotation(-camF, Vector3.up);

            _mesh.rotation = Quaternion.RotateTowards(transform.rotation, toRot, _rotSpeed);
        }

        if (PlayerMovementInput.x > 0.01f)
        {
            Quaternion toRot = Quaternion.LookRotation(camR, Vector3.up);

            _mesh.rotation = Quaternion.RotateTowards(transform.rotation, toRot, _rotSpeed);
        }
        else if (PlayerMovementInput.x <= -0.01f)
        {
            Quaternion toRot = Quaternion.LookRotation(-camR, Vector3.up);

            _mesh.rotation = Quaternion.RotateTowards(transform.rotation, toRot, _rotSpeed);
        }
    }

    void ladder()
    {
        if (Input.GetKey(KeyCode.Space) && _currentLadder != null)
        {
            _rb.useGravity = false;
            transform.position = Vector3.MoveTowards(transform.position, _currentLadder._top.position, 10f * Time.deltaTime);

        }
        else
        {
            _rb.useGravity = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ladder")
        {
            _currentLadder = other.GetComponent<Ladder>();

        }

        if (other.tag == "Feu" && _waterOn)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                print("player près feu avec eau");
                _waterOn = false;
                other.GetComponent<Feu>().Activate();
            }
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Water" && !_waterOn)
        {
            _waterOn = true;
        }

        if (other.tag == "Feu" && _waterOn)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                print("player près feu avec eau" );
                _waterOn = false;
                other.GetComponent<Feu>().Activate();
            }
        }

        if (other.tag == "Dom" && GameManager.instance._seed > 0)
        {
            Dom thisDom = other.GetComponent<Dom>();
            print("Dom reached");
            if (true)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    print("Plante");
                    GameManager.instance._seed--;
                    _animator.SetBool("Plant", true);
                } 
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ladder")
        {
            _currentLadder = null;

        }
    }

    

    void Interact()
    {

    }
}
