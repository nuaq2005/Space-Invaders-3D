using UnityEngine;

public class Dart : MonoBehaviour
{
    [Header("Inscribed")]
    static float speed = .3f;
    // speed at which the dart moves upward
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // at fixed intervals, the dart moves upward by a certain speed .3f
    // destroys the dart if it goes above a certain y-coordinate (e.g., 10)
    void FixedUpdate()
    {
        Vector3 position = transform.position;
        position.y += speed;
        transform.position = position;
        if(position.y > 10)
        {
            Destroy(gameObject);
        }
    }

}
