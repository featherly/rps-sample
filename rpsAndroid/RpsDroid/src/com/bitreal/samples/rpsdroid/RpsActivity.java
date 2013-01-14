package com.bitreal.samples.rpsdroid;

import android.os.Bundle;
import android.app.Activity;
import android.view.Menu;
import android.view.View;
import android.widget.TextView;

public class RpsActivity extends Activity {

	RpsModel RpsGame;
	TextView displayOpponent;	// = (TextView) findViewById(R.id.opponent);
	TextView displayUser;		// = (TextView) findViewById(R.id.user);
	TextView displayResult;
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		RpsGame = new RpsModel();
		setContentView(R.layout.activity_rps);
		displayOpponent = (TextView) findViewById(R.id.opponent);
		displayUser = (TextView) findViewById(R.id.user);
		displayResult = (TextView) findViewById(R.id.result);
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.activity_rps, menu);
		return true;
	}

	private void runGame() {
		displayUser.setText(RpsGame.playerUser.getPick().toString());
		displayOpponent.setText(RpsGame.opponentPlay().toString()); // find and display opponent's decision
		displayResult.setText(RpsGame.playRound().toString());
		RpsGame.userClear();
		RpsGame.opponentClear();
	}

	public void pickedRock(View view) {
		RpsGame.userPick(RpsPicks.Rock);
		runGame();
	}

	public void pickedPaper(View view) {
		RpsGame.userPick(RpsPicks.Paper);
		runGame();
	}

	public void pickedScissors(View view) {
		RpsGame.userPick(RpsPicks.Scissors);
		runGame();
	}
}
