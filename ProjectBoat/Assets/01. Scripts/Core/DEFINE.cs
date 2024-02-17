using UnityEngine;

public static class DEFINE
{
	public static PlayerHand PlayerHand = null;

	private static GameObject stageBoard = null;
	public static GameObject StageBoard {
		get {
			if(stageBoard == null)
				stageBoard = GameObject.Find("StageBoard");
			return stageBoard;
		}
	}
}
