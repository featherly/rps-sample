package com.bitreal.samples.rpsdroid;

import java.util.Random;

//import com.bitreal.samples.rpsdroid.RpsPicks;
//import com.bitreal.samples.rpsdroid.RpsResult;
//import com.bitreal.samples.rpsdroid.RpsModel.Player;

public class RpsModel {
	private Random r;

	public class Player {
		private RpsPicks Pick;
		private Boolean Decided;

		// Constructor
		private Player() {
			Pick = RpsPicks.Undetermined;
			Decided = false;
		}

		// getters and setters - for better or worse
		public void setPick (RpsPicks pickValue) {
			Pick = pickValue;
		}
		
		public RpsPicks getPick() {
			return Pick;
		}
		
		public void setDecided (Boolean done) {
			Decided = done;
		}
		
		public Boolean getDecided() {
			return Decided;
		}
	}

	public Player playerUser, playerOpponent;

	// Constructor - when instantiating the model create two player objects
	public RpsModel() {
		playerUser = new Player();
		playerOpponent = new Player();
		r = new Random();
	}

	public void userPick(RpsPicks pickValue) {
		playerUser.Pick = pickValue;			// notice not using getters and setters -
		playerUser.Decided = true;				//  class design discussion needed to answer why
	}

	public void opponentPick(RpsPicks pickValue) {
		playerOpponent.Pick = pickValue;
		playerOpponent.Decided = true;
	}

	public void userClear() {
		playerUser.Pick = RpsPicks.Undetermined;
		playerUser.Decided = false;
	}

	public void opponentClear() {
		playerOpponent.Pick = RpsPicks.Undetermined;
		playerOpponent.Decided = false;
	}

	// Play a round
	public RpsResult playRound() {
		if (playerUser.Decided & playerOpponent.Decided) {
			// both players have made a pick
			
			switch (playerUser.Pick) {
			case Rock:							// rock breaks scissors and is covered by paper
				switch (playerOpponent.Pick) {
				case Rock:
					return RpsResult.draw;
				case Paper:
					return RpsResult.lose;
				case Scissors:
					return RpsResult.win;
				}
				break;
			case Paper:							// paper covers rock and is cut by scissors
				switch (playerOpponent.Pick) {
				case Rock:
					return RpsResult.win;
				case Paper:
					return RpsResult.draw;
				case Scissors:
					return RpsResult.lose;
				}
				break;
			case Scissors:						// scissors cuts paper and is broken by rock
				switch (playerOpponent.Pick) {
				case Rock:
					return RpsResult.lose;
				case Paper:
					return RpsResult.win;
				case Scissors:
					return RpsResult.draw;
				}
				break;
			case Undetermined:
				return RpsResult.failure; // userPlayer has not made a pick
			default:
				return RpsResult.failure; // userPlayer's pick is something we don't recognize
			}	// I left the 'draw' entries in the switch yard for easy access to changes
		}
		else {
			// game failure because either or both players have not picked
			return RpsResult.failure;
		}
		return RpsResult.failure;  // code path should never get here, but just in case ...
	}
	
	public RpsPicks opponentPlay() {	// opponent weighs in, network player, machine player ...
		switch (r.nextInt(3)) {
		case 0:
			this.opponentPick(RpsPicks.Rock);
			return RpsPicks.Rock;
		case 1:
			this.opponentPick(RpsPicks.Paper);
			return RpsPicks.Paper;
		case 2:
			this.opponentPick(RpsPicks.Scissors);
			return RpsPicks.Scissors;
			}
		return RpsPicks.Undetermined;	// only get here if Random doesn't give 0 to 2
	}
}
