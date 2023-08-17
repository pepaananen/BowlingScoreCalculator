# Bowling Score Calculator

This program is a console app that was designed to be used while playing a game of bowling. 
It can track the scores of mulitple players and returns list of the final rankings after the game.

The program will walk the user through setting up a game with all the players and then
proceed to ask the pins knocked down for each player in each following the natural flow
of a game of bowling. Once all the throws have been input the program will calculate total 
scores for each player and display the final standings and scores.

The following inputs will be accepted:

	- For number of players
		- Positive integer only.
	- For player name
		- Any string.
		- Null or empty string will result in "PlayerX" where "X" is the player number.
	- For throw input
		- Integer only.
		- Between 0-10 inclusive.
		- Throw 1 and throw 2 must sum to 10 or less.

Any invalid input will lead to a prompt for valid input.
