# C# - Bulle's Eye Gamge For Console
 
## The game:
The computer randomly selects a 4-letter sequence from the first 8 letters of the English alphabet (A-H), a letter cannot appear twice.
At each stage the player guesses what the sequence the computer has chosen is, and the computer gives him "feedback" on the guess that the player must improve the next guess until the guesses are over or until he is determined correctly.

## Scoring method:
A letter that appears in the same position in the sequence that the computer selected ("stamp") will receive a "V" and a letter that appears in the sequence of the computer but not in the same position in the sequence ("hit") will receive an "X" Note, the result does not show which of the letters received a "V" "Or" X ".
The result is always aligned to the left and the "V" is always shown followed by the "X".

## Design Choices:
#### Model (M) - Contains the current state of the game and logic for checking win or lose
#### View (V) - Contains the console user interface for interacting with the game
#### Controller (C) - Contains the interface between View and Model

## how it's really works:
![ezgif com-gif-maker](https://user-images.githubusercontent.com/86562519/147337342-503df911-7164-43f6-831e-e39168f9d6d5.gif)
