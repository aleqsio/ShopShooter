using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Zombie : MonoBehaviour
{
    // Start is called before the first frame update
    public float Speed;
    public float Gravity;
    private CharacterController _controller;
    private Vector3 _velocity;
    public GameObject rig;
    private Animator _animator;
    private bool _isGrounded;
    private Vector3 _lastPosition;
    public float gravityDelay;
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _animator = rig.GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Vector3 move = new Vector3(-1, 0, Input.GetAxis("Vertical"));
        _controller.Move(move * Time.deltaTime * Speed);
        _animator.SetFloat("MoveSpeed", move.magnitude);
        if (move != Vector3.zero)
            transform.forward = move;
        if (_lastPosition.y <= this.transform.position.y)
        {
            _animator.SetBool("Grounded", true);
            _velocity.y = 0f;
        }
        else
        {
            Debug.Log('x' + Mathf.Abs(_velocity.y) + 'y' + (Gravity * Time.deltaTime * 1000));
            _animator.SetBool("Grounded", Mathf.Abs(_velocity.y) < Mathf.Abs(Gravity * Time.deltaTime * gravityDelay));
        }

        _velocity.y += Gravity * Time.deltaTime;
        _lastPosition = this.transform.position;
        _controller.Move(_velocity * Time.deltaTime);

    }

}
