using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody fizik;

    [Range(1,40)]
    public int speed = 30;
    private int damage = 25;
    
    void Start()
    {
        Movement();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            other.gameObject.GetComponent<Enemy>().TakeDamage(this.damage);
        }
        Destroy(this.transform.gameObject);
    }

    private void Movement()
    {
        fizik = transform.GetComponent<Rigidbody>();
        this.transform.rotation = Player.lookDir;
        fizik.velocity = transform.forward * speed;
    }
}
