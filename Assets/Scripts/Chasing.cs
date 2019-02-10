using UnityEngine;
using UnityEngine.UI;

public class Chasing : MonoBehaviour {

    public GameObject explosion;
    public float speed;
    public Transform target;
    
    private float health;
    private Image healBar;
    private Text healText;
    private float maxHealth;
    
    void Start () {
        health = 100.0f;
        healBar = transform.Find("EnemyCanvas").Find("MaxHealthBar").Find("HealthBar").GetComponent<Image>();
        healText = transform.Find("EnemyCanvas").Find("HealthBarText").GetComponent<Text>();        
        maxHealth = 100.0f;
        speed = 0.5f;
    }
	
    void Update () {
        transform.LookAt(target, Vector3.up);
        transform.position += transform.forward * speed * Time.deltaTime;
        healText.text = health.ToString();
        healBar.fillAmount = health / maxHealth;
    }

    void OnCollisionEnter(Collision col) {
        if(col.gameObject.tag.Equals("Bullet")) {
            health -= 10;
            if(health < 1) {
                Destroy(this);
                Instantiate(explosion, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }
}





