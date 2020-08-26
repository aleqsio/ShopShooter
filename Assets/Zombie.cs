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
    public GameObject player;
    private Animator _animator;
    private bool _isGrounded;
    private Vector3 _lastPosition;
    public float gravityDelay;
    public bool dead;
    private
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        _controller = GetComponent<CharacterController>();
        _animator = rig.GetComponent<Animator>();
    }
 //Detect collisions between the GameObjects with Colliders attached
    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "Bomb")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            _animator.SetBool("Dead", true);
            Speed= 0;
            dead=true;
            GetComponent<CapsuleCollider>().enabled = false;
            StartCoroutine(Disappear());
        }
    }
    IEnumerator Disappear()
    {
        //Print the time of when the function is first called.

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(3);

        //After we have waited 5 seconds print the time again.
        this.gameObject.SetActive(false);
    }
    void FixedUpdate()
    {
        if(dead) return;
        Vector3 move = (player.transform.position - this.transform.position).normalized;
        _controller.Move(move * Time.deltaTime * Speed);
        _animator.SetFloat("MoveSpeed", move.magnitude);
        if (move != Vector3.zero)
            transform.forward = move;
        // if (_lastPosition.y <= this.transform.position.y)
        // {
        //     _animator.SetBool("Grounded", true);
        //     _velocity.y = 0f;
        // }
        // else
        // {
        //     Debug.Log('x' + Mathf.Abs(_velocity.y) + 'y' + (Gravity * Time.deltaTime * 1000));
        //     _animator.SetBool("Grounded", Mathf.Abs(_velocity.y) < Mathf.Abs(Gravity * Time.deltaTime * gravityDelay));
        // }

        _velocity.y += Gravity * Time.deltaTime;
        _lastPosition = this.transform.position;
        _controller.Move(_velocity * Time.deltaTime);

    }

}
