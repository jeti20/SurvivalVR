# SurvivalVR

04.09.2023
- Added Island
- Added Player
- Added needs indicator on hand to check hp, hunger, thirst and sleep. Been wondering how to show these needs and try some solutions but decided to show it on hand as some kind of tablet/watch

05.09.2023
 - Added player needs which are decreasing with time
 - Added Interfaces to deal damage to player 
 - Removed CharacterControl from XROrigin. I wasn't able to detect collisions with this component. Turned out movement is working just fine without it. Added Rigidbody and CopsuleColider instead. Player take damage from object with IDamagable interface


Struggle during project:
 - wasn't sure how to present hp, hunger etc ->decided to build some kind of tablet on wirst with Canvas. Interesting struggle.
 - cannot do collisions (needed because player receive dmg based od collision) with CharacterController -> removed CharacterController and replace it with Capsulecolider and Rigidbody. Time consuming struggle.
