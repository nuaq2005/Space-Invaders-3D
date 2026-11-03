# Space Invaders Project
By: Aquila Nuzhat
## Main Requirements
- [x] Make the remaining aliens speed up as their compatriots are destroyed.
- [x] Detect when the aliens have reached a point on the screen that the game is no longer
possible to win.
- [x] Prevent the spaceship from moving offscreen.
- [x] Find at least three ways in which my code is inefficient, non-idiomatic, or otherwise
poorly written. Fix all three issues.

### Speed up aliens
In our `RemoveAlien` function  which handles aliens which are hit by dart, we update speed and increase it. 
This function is established in `AlienFleet.cs` and called upon in `Alien.cs`
```
public void RemoveAlien(GameObject alien){
        aliens.Remove(alien);
        alienCounter.score = aliens.Count;

        speed *= 1.03f; // P1: increase the speed of the fleet when an alien dies
    }
```

### Detect When Aliens reach point of end game
 In `FixedUpdate` function of `AlienFleet.cs` file, we have a for loop which updates direction fleet is moving in. We set the lower boundary of fleet as a public float, 
 and continuously check if lower boundary approached spaceship. If it reaches the spaceship, we call upon the endgame panel screen.  

 ```
// P2: keep track of lowest alien in fleet if it goes below the spaceship, game over
            if (position.y < lowestPosition) {
                lowestPosition = position.y;
                if (lowestPosition < -6){
                    GameManager.instance.EndGame(false); //end panel pops up
                    Time.timeScale = 0; // stop the game
                }
            } 
```

### Prevent the spaceship from moving offscreen

In `Spaceship.cs` file, we establish boundaries of spaceship as floats `leftBound`and `rightBound`. 
In `Update` function of `Spaceship.cs` file, we have a for loop which updates direction spaceship is moving in. 
We check if its position goes beyond right or left boundaries when key is pressed, and keep it in place

```
//P3: enforce spaceship boundaries
        if (position.x > rightBound) position.x = rightBound;
        if (position.x < leftBound) position.x = leftBound;
```

### Three Issues:
1. `AlienFleet.cs`: Fix the redundant double for loop and combine into a single foreach loop when changing direction of fleet in `FixedUpdate()`
2. `AlientFleet.cs`: Counting aliens in fleet only when alien dies rather than every `Update()`
3. `Spaceship.cs`: Getting rid of multiple redundant Vector3 position assignments in  `Update()`, and simplified the code for moving the spaceship

## Complete four of the following:
- [x] Add a starting and ending screen. (Did this with a panel, will make it opaque and not transparent if I get time)
- [x] Implement lives (with a related graphic or textual display): I used textual display, may do hearts if I get time
- [x] Replace the background: did a canvas background that is galaxy themed
- [x] Add animations when collisions occur: explosion effect added to spaceship and alien, triggered when collision occurs. 
