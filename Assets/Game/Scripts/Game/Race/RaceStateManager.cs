using UnityEngine;

public class RaceStateManager : MonoBehaviour
{
	private RaceState state = RaceState.COUNTDOWN;
	private RaceState previousState;

	private enum RaceState
	{
		COUNTDOWN, STARTED, PAUSED, WON, OVER
	}

	public void SwitchPauseState()
	{
		if(IsActive())
		{
			SetPreviousState(IsCountdown() ? RaceState.COUNTDOWN : RaceState.STARTED);
			SetAsPaused();
		}
		else if(IsPaused())
		{
			RestorePreviousState();
		}
	}

	public bool IsActive() => IsCountdown() || IsStarted();
	public bool IsCountdown() => state == RaceState.COUNTDOWN;
	public bool IsStarted() => state == RaceState.STARTED;
	public bool IsPaused() => state == RaceState.PAUSED;
	public bool IsWon() => state == RaceState.WON;
	public bool IsOver() => state == RaceState.OVER;
	public void SetAsActive() => state = RaceState.STARTED;
	public void SetAsPaused() => state = RaceState.PAUSED;
	public void SetAsWon() => state = RaceState.WON;
	public void SetAsOver() => state = RaceState.OVER;

	private void SetPreviousState(RaceState newState) => previousState = newState;
	private void RestorePreviousState() => state = previousState;
}