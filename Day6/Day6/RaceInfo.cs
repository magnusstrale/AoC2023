public record RaceInfo(long Time, long Distance)
{
    public int WaysToWinCount =>
        Enumerable.Range(1, (int)Time).Where(c => IsWinningChargeTime(c)).Count();

    public long WaysToWinCalculated()
    {
        // Solve equation x * (Time - x) = Distance
        var halfTime = Time / 2;
        var lowerBound = halfTime - Math.Sqrt(halfTime * halfTime - Distance);
        var upperBound = halfTime + Math.Sqrt(halfTime * halfTime - Distance);

        // Fine-tune values (handle rounding errors)
        var testLower = (long)lowerBound - 1;
        while (!FirstWinningChargeTime(testLower))
            testLower ++;

        var testUpper = (long)upperBound - 1;
        while (!LastWinningChargeTime(testUpper))
            testUpper++;

        return testUpper - testLower + 1;
    }

    bool IsWinningChargeTime(long t) => t * (Time - t) > Distance;

    bool FirstWinningChargeTime(long t) => !IsWinningChargeTime(t - 1) && IsWinningChargeTime(t);

    bool LastWinningChargeTime(long t) => IsWinningChargeTime(t) && !IsWinningChargeTime(t + 1);
}