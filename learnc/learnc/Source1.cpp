
#include "stdafx.h"
#include <iostream>
#include <string>
#include <stdio.h>      /* printf, scanf, puts, NULL */
#include <stdlib.h>     /* srand, rand */
#include <time.h> 

using namespace std;

int roll_die(const int sides){
	int di = rand() % sides + 1;
	return di;
}
void sort_int_dsc(int a[], const int size){
	for (int i = 0; i < size; i++){
		for (int j = i + 1; j < size; j++){
			if (a[i] < a[j]){
				int store = a[i];
				a[i] = a[j];
				a[j] = store;
			}
		}
	}
}
void roll_player(int rolls[], const int ndice){
	for (int i = 0; i < ndice; i++){
		rolls[i] = roll_die(6);
	}
	sort_int_dsc(rolls, 10);
}
int handle_battle(const int nattack, const int ndefend){
	if (nattack > 3 || ndefend > 2){
		return -1;
	}
	int attackDice[10] = { 0 };
	int defendDice[10] = { 0 };
	roll_player(attackDice, nattack);
	roll_player(defendDice, ndefend);

	int i = 0;
	int defenderLosses = 0;

	while (i < ndefend){
		if (attackDice[i] > defendDice[i]){
			defenderLosses += 1;
		}
		i += 1;
	}

	return defenderLosses;
}