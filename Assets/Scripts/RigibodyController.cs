using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RigibodyController : MonoBehaviour
{
    public Text countText;
    public LayerMask ground;
    public Text winText;
    
    private AudioSource audioJump;
    private int count;
    private Vector3 direction;
    private float jumpHeight;
    private const int pickUpNb = 20;
    private Rigidbody rbody;
        
    void Start()
    {
        audioJump = GetComponent<AudioSource>();
        count = 0;
        direction = Vector3.zero;
        jumpHeight = 1.5f;
        rbody = GetComponent<Rigidbody>();
        winText.text = "";
        SetCountText();
    }

    void Update()
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");
        direction = direction.normalized;
        if (direction != Vector3.zero)
        {
            rbody.AddForce(direction * 0.2f, ForceMode.VelocityChange);
        }
        if (Input.GetButtonDown("Jump") &&
            Physics.CheckSphere(transform.position, transform.localScale.z / 2, ground, QueryTriggerInteraction.Ignore))
        {
            audioJump.Play();
            rbody.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);   
        }
    }
    
    void SetCountText ()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= pickUpNb)
        {
            winText.text = "You Win!";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText ();
        }
        else if (other.gameObject.CompareTag("Trap"))
        {
            gameObject.SetActive(false);
            SceneManager.LoadScene(1);
        }
    }
}
