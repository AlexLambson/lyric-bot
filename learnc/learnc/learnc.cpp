// learnc.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
#include <string>
#include <stdio.h>      /* printf, scanf, puts, NULL */
#include <stdlib.h>     /* srand, rand */
#include <time.h> 

CWinApp theApp;

using namespace std;
class humanplayer{
	int score = 0;
public:
	bool givePoints(int points){
		score += points;
		return true;
	}
	int getPoints(){
		int scorereturn = score;
		return scorereturn;
	}

};
int switchTurns(int turn){
	if (turn == 1){
		turn = 2;
	}
	else{
		turn = 1;
	}
	return turn;
};
int main(int argc, TCHAR* argv[], TCHAR* envp[])
{
	int win = 20;
	humanplayer player1;
	humanplayer player2;
	int turn = 1;
	int tempPoints = 0;
	int di;
	string option; 
	while (player1.getPoints() <= win && player1.getPoints() <= win){
		for (int i = 0; i < 10; i++){
			int num = handle_battle(3, 2);
			cout << num << endl;
		}
		if (tempPoints >= win){
			if (turn == 1){
				player1.givePoints(tempPoints);
			}
			else{
				player2.givePoints(tempPoints);
			}
		}
		else{
			srand(time(NULL));
			if (tempPoints == 0){
				cout << "Player " << turn << ", would you like to role the di? [y,n]  ";
			}
			else{
				cout << "Player " << turn << " has earned " << tempPoints << " points... Continue? [y,n]  ";
			}
			cin >> option;
			if (option == "y"){
				di = rand() % 6 + 1;
				if (di != 1){
					cout << "Di rolled to " << di << endl;
					tempPoints += di;
				}
				else if (di == 1)
				{
					cout << "Rolled a 1, turn over and " << tempPoints << " potential points were lost" << endl << endl;
					tempPoints = 0;
					turn = switchTurns(turn);
				}
			}
			else if (option == "n"){
				if (turn == 1){
					player1.givePoints(tempPoints);
				}
				else{
					player1.givePoints(tempPoints);
				}
				cout << "Gave Player " << turn << " " << tempPoints << " points" << endl << endl;
				tempPoints = 0;
				turn = switchTurns(turn);
			}
		}
		
	}
	if (player1.getPoints() >= win){
		cout << endl << "Player 1 wins! Press any key to end the game!";
		cin;
	}
	else if (player2.getPoints() >= win){
		cout << endl << "Player 2 wins! Press any key to end the game!";
		cin;
	}
	
	return 0;
}