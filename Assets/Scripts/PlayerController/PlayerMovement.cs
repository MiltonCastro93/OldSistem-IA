using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController _cC;
    private bool _inGrounded;
    private Vector3 _playerVelocity;
    [SerializeField] private float _playerSpeed = 2.0f;
    [SerializeField] private float _jumpHeight = 1f;
    private float gravityValue = -9.81f;

    private float life = 100;

    // Start is called before the first frame update
    void Start() {
        _cC = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update() {

        if(life >= 1) {
            PlayerMove();
        }

    }

    void PlayerMove() {
        _inGrounded = _cC.isGrounded;
        if(_inGrounded && _playerVelocity.y < 0f) {
            _playerVelocity.y = 0f;
        }

        Vector3 direction = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));
        direction = Vector3.ClampMagnitude(direction, 1f);

        if (Input.GetButtonDown("Jump") && _inGrounded) {
            _playerVelocity.y = Mathf.Sqrt(_jumpHeight * -2.0f * gravityValue);
        }

        _playerVelocity.y += gravityValue * Time.deltaTime;

        Vector3 finalMove = (direction * _playerSpeed) + (_playerVelocity.y * Vector3.up);
        _cC.Move(finalMove * Time.deltaTime);
    }

}
