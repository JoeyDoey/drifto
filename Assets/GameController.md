GameController is used for handling things related to the game scene.
Is NOT persistent and only exists in game scenes.

## Accessing GameController
There is no special way to access the game controller (should this change?).
Currently just passing a reference through the inspector

## Scripts
All under GameController namespace

### [GameController.cs](GameController/GameController.cs)
Controls a lot of the movement between game states.
Handles the off track and backwards timers, and the collision game over things.

### [GameStateController.cs](GameController/GameController.cs)
Very crude state machine.

##### GameState (enum)
* pregame: Game menu (play button and title)
* game: The drifting part
* postgame: Game over screen

##### GameStateInfo (class)
Defines what events are called on a state being started and stopped. Also defines what the next legal states are.

### [TimerHelper.cs](GameController/TimerHelper.cs)
Helper classes for the game over timers.
UpdateTimer and UpdateState must be called regularly for it to work.
Give it updates on the state of the game over check and events can be registered for:
* onStart: When the countdown is (re)started: new state and not old state
* onStop: When the countdown is (re)stopped: not new state and old state
* onTimeout: When the countdown reaches zero: state has been false long enough
onStop is not (necessarily) called when onTimeout is.