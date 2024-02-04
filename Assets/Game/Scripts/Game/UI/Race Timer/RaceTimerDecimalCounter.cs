public class RaceTimerDecimalCounter : RaceTimerCounter
{
	protected override string CounterText()
	{
		string text = string.Format("{0:F1}", timer.CurrentTime);

		return text[^2..];
	}
}