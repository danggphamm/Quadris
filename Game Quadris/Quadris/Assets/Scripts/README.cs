using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class README : MonoBehaviour
{
    /*  - Make and object dragable:             
                
            + Add the "BOX" script to the object and then add "Box collider" to that object.
      
        - Make a new level jumping button on main scene:     
            + Make a new GUI Button.

            + The button's sprite: the locked level sprite.

            + On click event of the button: Choose "Runtime only". Drag the main camera into the on click event. Then choose changeLevel -> changeScene(scene name). 
              Then enter the scene name into the parameter. Example: if the button is for jumping to scene "Tutorial 2", then enter "Tutorial 2" (Must be eaxtly the same.)

            + Drag the "changeLockedSprite" script into the button.
              In the "Change Locked Sprite" field:
              "Sprite to change to": the sprite that will replace the locked sprite.
                                     Example: drag the level 2 sprite into that box, then after unlocked level 2, the button's sprite will change from the locked sprite
                                     to the level 2 sprite.
              Level number: enter the number of that level. Example: enter "2" for button of scene tutorial 2.
              High score: the high score text object. Create it as below, then drag it into this box.

            + High score text object: Create a child object (Type Text) of the level button object, name it "High score"

            + Drag the "levelHighScoreDisplayer" script into the High Score object. 
              In the "Level High Score Displayer" field:
              Level: the level number of its parent. For example, if "High score" of tutorial 2, enter 2 into the "level" box.
              This text: Drag the High Score object itself into the "This text" box.

            + Go back to the parent button object, look for the "Change locked sprite" field, then drag its "High score" text object into the "High Score" box.
      
     
      
     
      
     */
}
