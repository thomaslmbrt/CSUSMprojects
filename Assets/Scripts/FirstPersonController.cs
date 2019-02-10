using UnityEngine;

public class FirstPersonController : MonoBehaviour {

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public LayerMask ground;
    public float jumpHeight;
    public float speed;
    
    private Animator anim;
    private AudioSource audio;
    private Vector3 direction;
    private float minY = -60f;
    private float maxY = 60f;
    private Rigidbody rbody;
    private float rotationSpeed = 10f;
    private float rotationY = 10f;
    private float rotationX = 0f;

    void Start () {
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        direction = Vector3.zero;
        jumpHeight = 1.0f;
        rbody = GetComponent<Rigidbody>();
        speed = 2.0f;        
    }
    
    void Update () {
        
        direction = Vector3.zero;
        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");
        direction = direction.normalized;
        if(direction.x != 0)
            rbody.MovePosition(rbody.position + transform.right * direction.x * speed * Time.deltaTime);
        if(direction.z != 0)
            rbody.MovePosition(rbody.position + transform.forward * direction.z * speed * Time.deltaTime);

        rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * rotationSpeed;
        rotationY += Input.GetAxis("Mouse Y") * rotationSpeed;
        rotationY = Mathf.Clamp(rotationY, minY, maxY);
        transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        
        if (anim)
            Animating(direction.x, direction.z);

        bool isGrounded = Physics.CheckSphere(transform.position, 0.3f, ground, QueryTriggerInteraction.Ignore);
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            audio.Play();
            rbody.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
        }

        if(Input.GetButtonDown("Fire1")) {
            Fire();
        }
    }

    void Animating(float h, float v)
    {
        bool walking = h != 0f || v != 0f;
        anim.SetBool("IsWalking", walking);
    }

    void Fire() {
        var bullet = Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;
        Destroy(bullet, 2.0f);
    }
}
















