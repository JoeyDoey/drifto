## [ScoreController.cs](GameController/ScoreController.cs)
Handle score logic.
Takes into consideration speed, angle, time in drift, and clipping points.

## Raw Score
The raw score of any frame is the product of the speed and drift angle of the [[Car]].
This assumes the drift angle and speed are above their respective thresholds.

## Multiplier
When the player initiates a drift, a timer is started.

