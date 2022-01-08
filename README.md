# Dialogue-System
 
## What is this?

This is a WIP implementation of a basic 2D Dialogue System for Unity, made with version 2020.3.4f1. You can see an example on the "Example" scene.

## How can I use it?


### GameObjects


Your scene must have an S_DialogueManager Script and a S_DialogueUiManager Script. You can use the prefab P_DialogueManager.


### Text files


For the dialogues, you can create a txt file with the following format:


(0 if left character, 1 if right character)|(character name)|(character emotion)|(speed mode)|(dialogue)


Example:
0|Character1|HAPPY|NORMAL|Hello!
0|Character1|NEUTRAL|NORMAL|How did you sleep last night?
1|Character2|SAD|SLOW|...
1|Character2|SAD|SLOW|I didn't sleep

If you want to change the sprite of the character that not speaks first, write the following line at the begining of the file:


(0 if left character, 1 if right character)|(character name)|(character emotion)||OTHERSPRITE

### Scriptable Objects


Also, you have to create two types of ScriptableObjects: S_DialogueCharacters and a S_DialogueOptions.

#### S_DialogueCharacters 


You can change the name, sprites(one for each emotion) and sound of the character.

#### S_DialogueOptions


You can change the seconds between characters ( speed of the dialogue ), the default sound, and if the character that is not speaking is visible or not.




