# Test Driven Development kata with Bowling Game ![Build Status](https://travis-ci.org/tavisca-bootcamp/tdd-basics.svg?branch=master)

The idea of this repository is to contain a minimal setup for executing the [Uncle Bob][1] famous [Bowling kata][2] in C# using [xunit][3] framework.

## The Bowling Score

![Example Score](bowling_scoresheet_example.png)

The Game consists of 10 frames as shown above.  In each frame the player has
two opportunities to knock down 10 pins.  The score for the frame is the total
number of pins knocked down, plus bonuses for strikes and spares.

A spare is when the player knocks down all 10 pins in two tries.  The bonus for
that frame is the number of pins knocked down by the next roll.  So in frame 3
above, the score is 10 (the total number knocked down) plus a bonus of 5 (the
number of pins knocked down on the next roll.)

A strike is when the player knocks down all 10 pins on his first try.  The bonus
for that frame is the value of the next two balls rolled.

In the tenth frame a player who rolls a spare or strike is allowed to roll the extra
balls to complete the frame.  However no more than three balls can be rolled in
tenth frame.

# Three laws of TDD

When doing the exercise, it is important to stick to the three rules of TDD. For more information click [here][4].

1. You may not write production code until you have written a failing unit test.

2. You may not write more of a unit test than is sufficient to fail, and not compiling is failing.

3. You may not write more production code than is sufficient to pass the currently failing test.

# Have fun!

[1]: https://twitter.com/unclebobmartin
[2]: http://butunclebob.com/ArticleS.UncleBob.TheBowlingGameKata
[3]: https://xunit.net/
[4]: http://butunclebob.com/ArticleS.UncleBob.TheThreeRulesOfTdd