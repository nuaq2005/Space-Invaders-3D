using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class AlienFleet : MonoBehaviour
{
    [Header("Inscribed")]

    public GameObject alienPrefab; // prefab for the alien that the fleet consists of
    public AlienCounter alienCounter; // reference to the alien counter that tracks the number of aliens

    public List<GameObject> aliens = new List<GameObject> { };
    // list of all aliens in the fleet

    float speed = .1f; // speed at which the fleet moves left and right
    float leftBound = -16; // left boundary for the fleet
    float rightBound = 16; // right boundary for the fleet
    float lowestPosition = 4.8f;
    float downTime = .1f; // time it takes for the fleet to move down
    bool movingDown = false; // flag indicating if the fleet is currently moving down

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //nested for loops to create the grid of aliens with reference to fleet
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                GameObject alien = Instantiate<GameObject>(alienPrefab);
                alien.transform.position = new Vector3(2 * i - 12, 10 - 2 * j, 0);
                aliens.Add(alien);
                alien.GetComponent<Alien>().fleet = this;
            }
        }

    }

    // Update is called once per frame
    // updates the alien counter with the current number of aliens
    void Update()
    {

    }


    void FixedUpdate()
    {
        //Move all aliens in the fleet: 
        // 1. if not moving down, move sideways
        // 2. Finds leftmost and rightmost aliens to determine if the fleet should change direction
        // 3. reverses at walls; flips speed sign, set movingdown to true, then startsideways 
        // 4. startsidewaysmotion sets movingdown back to false, back to step one

        // P4.1: fix the redundant double for loop, combine into a single foreach loop

        foreach (GameObject alien in aliens) {   
            float left = 0, right = 0;
            Vector3 position = alien.transform.position;
            // P2: keep track of lowest alien in fleet if it goes below the spaceship, game over
            if (position.y < lowestPosition) {
                lowestPosition = position.y;
                if (lowestPosition < -6){
                    GameManager.instance.EndGame(false); //end panel pops up
                    Time.timeScale = 0; // stop the game
                }
            } 
            
            if (!movingDown) {
                position.x += speed;
            } else {
                position.y += -Mathf.Abs(speed);
            }
            alien.transform.position = position;

            // Update leftmost and rightmost positions of the aliens
            if (position.x > right) {
                right = position.x;
            }
            if (position.x < left) {
                left = position.x;
            }

            // Check if the fleet should change direction based on the leftmost and rightmost aliens
            if (speed > 0 && right >= rightBound || speed < 0 && left <= leftBound) {
                speed = -speed;
                movingDown = true;
                Invoke("startSidewaysMotion", downTime);
            }

        }
    }

    void startSidewaysMotion()
    {
        movingDown = false;
    }

    // P4.2: counting aliens in fleet only when alien dies rather than at all times
    public void RemoveAlien(GameObject alien){
        aliens.Remove(alien);
        alienCounter.score = aliens.Count;

        speed *= 1.03f; // P1: increase the speed of the fleet when an alien dies
    }
}
