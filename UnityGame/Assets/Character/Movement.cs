using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Character;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Camera _camera;
    [SerializeField] private float speed = 5f;
    [SerializeField] private Vector3 gravity = new Vector3(0, -9.81f, 0);
    public bool isGrounded;
    [SerializeField] private List<Transform> groundMarkers;
    [SerializeField] private float distance = 0.1f;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Vector3 fallingForce = Vector3.zero;
    private Task _canJumpAgain = Task.CompletedTask;
    [SerializeField] private Vector3 jumpForce = new(0, 7.4f, 0);
    [SerializeField] private Animator animator;

    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move(new CharacterInput
        {
            movement = new Vector2(
                Mathf.Clamp(Input.GetAxisRaw("Horizontal"), -1, 1),
                Mathf.Clamp(Input.GetAxisRaw("Vertical"), -1, 1)),
            jump = Input.GetKey("space"),
            roll = Input.GetKey("r")
        });
    }

    void Move(CharacterInput characterInput)
    {
        float delta = Time.fixedDeltaTime;
        Vector2 move = characterInput.movement;
        /*this._cameraFollower.camera.transform.rotation.eulerAngles;*/
        Vector3 euler = this._camera.transform.rotation.eulerAngles;
        euler.x = 0;
        euler.z = 0;
        Vector3 moveForce = Quaternion.Euler(euler) * new Vector3(move.x * this.speed, 0, move.y * this.speed);
        this.isGrounded = CheckGround();

        if (this.isGrounded)
        {
            this.animator.SetBool("IsJumping", false);
            this.fallingForce = Vector3.zero;
            if (characterInput.jump)
            {
                if (this._canJumpAgain.IsCompleted)
                {
                    this.rb.AddForce(ApplyJumpForce(), ForceMode.Impulse);
                    this._canJumpAgain = Task.Delay(150);
                }
            }
        }
        else
            this.animator.SetBool("IsJumping", true);


        var vel = this.rb.velocity;
        vel.x = moveForce.x;
        vel.z = moveForce.z;
        this.rb.velocity = vel;
        this.animator.SetFloat("Speed", vel.magnitude);
        if (characterInput.roll)
            roll();
    }

    private void roll()
    {
        this.animator.SetTrigger("Roll");
    }

    private bool CheckGround()
    {
        return this.groundMarkers.Select(groundMarker => new Ray(groundMarker.position, Vector3.down))
            .Select(ray => Physics.Raycast(ray, this.distance, Physics.AllLayers, QueryTriggerInteraction.Ignore))
            .Any(hit => hit);
    }

    private Vector3 ApplyJumpForce()
    {
        return this.jumpForce;
    }
}