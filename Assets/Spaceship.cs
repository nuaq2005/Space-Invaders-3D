using UnityEngine;
using UnityEngine.InputSystem;

public class Spaceship : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject dartPrefab;
    // prefab for the dart that the spaceship shoots
    public static float shotCooldown = .05f;
    // minimum time between shots
    public float lastShot = 0;
    // records the time of the last shot
    public float speed = 10f;
    // speed at which the spaceship moves left and right
    float leftBound = -16;
    float rightBound = 16; //P3: establish spaceship boundaries

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    // left or right pressed - moves the spaceship in that direction
    // space pressed - shoots a dart from the spaceship's position
    // respects the shot cooldown to prevent rapid firing

    //4.3: getting rid of multiple redundant Vector3 position assignments, and simplified the code for moving the spaceship
    void Update()
    {
        Vector3 position = transform.position;
        float direction = 0;

        //simplified conditional blocks for determining direction
        if (Keyboard.current.rightArrowKey.isPressed) direction = 1;
        if (Keyboard.current.leftArrowKey.isPressed) direction = -1;
       
        position.x += direction * speed * Time.deltaTime;
        //P3: enforce spaceship boundaries
        if (position.x > rightBound) position.x = rightBound;
        if (position.x < leftBound) position.x = leftBound;
        transform.position = position;

        if (Keyboard.current.spaceKey.wasPressedThisFrame && Time.time - lastShot > shotCooldown)
        {
            GameObject bullet = Instantiate<GameObject>(dartPrefab);
            bullet.transform.position = position;
            lastShot = Time.time;
        }

    }

}


