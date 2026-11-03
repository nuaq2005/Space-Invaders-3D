using UnityEngine; 
//import Unity toolbox to use script like Vector3 and GameObject

public class Alien : MonoBehaviour
// Alien class represents an individual alien in the game
//it inherits MonoBehaviour, which provides the ability to be attached to GameObjects and to have lifecycle methods like Start, Update, and FixedUpdate
{
    [Header("Inscribed")]

    public GameObject bulletPrefab;
    public AlienFleet fleet;
    // bullet template
    // link back to alienfleet that owns this alien
    
    static float bulletSpawnRate = .002f;
    public float lastShot = 0;
    public static float shotCooldown = .1f;
    // chance of shooting on each physics tick
    //shot cooldown and last shot put a gap between shots

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // FixedUpdate is called at a fixed interval, independent of frame rate
    // each tick, alien rolls a random number
    // if < spawnrate and enough time has passed, spawns bullet from its position
    //records time of shot

    void FixedUpdate()
    {
        Vector3 position = transform.position;
        // where it sits, stored as Vector3 (x,y,z)
        
        if(UnityEngine.Random.value < bulletSpawnRate && Time.time - lastShot > shotCooldown){
            GameObject bullet = Instantiate<GameObject>(bulletPrefab); 
            //prefab is a saved template of GameObject 
            //Instantiate creates a new GameObject from the prefab
            bullet.transform.position = position;
            lastShot = Time.time;
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        fleet.RemoveAlien(gameObject); //P4.2 simplify statement get rid of redundant fleet.GetComponent<AlienFleet>()
        Destroy(gameObject);
        Destroy(coll.gameObject);

        if(fleet.aliens.Count == 0)
        {
            GameManager.instance.EndGame(true);
        }
    }
}
