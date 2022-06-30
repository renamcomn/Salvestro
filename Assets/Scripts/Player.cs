using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float runSpeed;
    
    private Rigidbody2D rig;

    private Vector2 _direction;
    private float initialSpeed;
    private bool _isRunning;
    private bool _isRolling;
    private bool _isCutting;
    private bool _isDigging;

    private int handleObj;
    
    
    public Vector2 direction {
        get { return _direction; }
        set { _direction = value; }
    }

    public bool isRunning {
        get { return _isRunning; }
        set { _isRunning = value; }
    }

    public bool isRolling {
        get { return _isRolling; }
        set { _isRolling = value; }
    }

    public bool isCutting {
        get { return _isCutting; }
        set { _isCutting = value; }
    }

    public bool isDigging {
        get { return _isDigging; }
        set { _isDigging = value; }
    }

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        initialSpeed = speed;
    }

    // Update is called once per frame
    private void Update()
    {

        if(Input.GetKeyDown(KeyCode.Alpha1)) {
            handleObj = 0;
        }

        if(Input.GetKeyDown(KeyCode.Alpha2)) {
            handleObj = 1;
        }

        OnInput();
        OnRun();
        OnRolling();
        OnCutting();
        OnDigging();
    }

    private void FixedUpdate() {
        OnMove();
    }

    #region Movement

    void OnInput() {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    void OnMove() {
        rig.MovePosition(rig.position + _direction * speed * Time.fixedDeltaTime);
    }

    void OnRun() {
        if(Input.GetKeyDown(KeyCode.LeftShift)) {
            speed = runSpeed;
            _isRunning = true;
        }

        if(Input.GetKeyUp(KeyCode.LeftShift)) {
            speed = initialSpeed;
             _isRunning = false;
        }
    }

    void OnRolling() {
        if(Input.GetMouseButtonDown(1)) {
            _isRolling = true;
        }

        if(Input.GetMouseButtonUp(1)) {
             _isRolling = false;
        }
    }

    void OnCutting() {
        if(handleObj == 0) {
            if(Input.GetMouseButtonDown(0)) {
                _isCutting = true;
                speed = 0;
            }

            if(Input.GetMouseButtonUp(0)) {
                _isCutting = false;
                speed = initialSpeed;
            }
        }
    }

    void OnDigging() {
        if(handleObj == 1) {
            if(Input.GetMouseButtonDown(0)) {
                _isDigging = true;
                speed = 0;
            }

            if(Input.GetMouseButtonUp(0)) {
                _isDigging = false;
                speed = initialSpeed;
            }
        }
    }

    #endregion
}
