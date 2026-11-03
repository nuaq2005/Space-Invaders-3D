using UnityEngine;

public class AlienBullet : MonoBehaviour
{
    [Header("Inscribed")]

    static float speed = .1f;
    // speed at which the bullet moves downward

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //at fixed intervals, the bullet moves downward by a certain speed .1f
    // destroys the bullet if it goes below a certain y-coordinate (e.g., -10)
    // oncollisionenter, destroys both the bullet and the object it collides with
    void FixedUpdate()
    {
        Vector3 position = transform.position;
        position.y -= speed;
        transform.position = position;
        if(position.y < -10)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.GetComponent<Spaceship>() != null)
        {
            GameManager.instance.LoseLife();
        }
        Destroy(gameObject);   // the bullet is always used up on impact
    }
}
