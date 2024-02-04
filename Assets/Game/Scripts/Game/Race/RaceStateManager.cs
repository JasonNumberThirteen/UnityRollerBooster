using UnityEngine;

public class RaceStateManager : MonoBehaviour
{
	private RaceState state = RaceState.COUNTDOWN;

	private enum RaceState
	{
		COUNTDOWN, ACTIVE, PAUSED, WON, OVER
	}

	public void SwitchPauseState()
	{
		if(IsActive())
		{
			SetAsPaused();
		}
		else
		{
			SetAsActive();
		}
	}

	public bool IsCountdown() => state == RaceState.COUNTDOWN;
	public bool IsActive() => state == RaceState.ACTIVE;
	public bool IsPaused() => state == RaceState.PAUSED;
	public bool IsWon() => state == RaceState.WON;
	public bool IsOver() => state == RaceState.OVER;
	public void SetAsActive() => state = RaceState.ACTIVE;
	public void SetAsPaused() => state = RaceState.PAUSED;
	public void SetAsWon() => state = RaceState.WON;
	public void SetAsOver() => state = RaceState.OVER;
}