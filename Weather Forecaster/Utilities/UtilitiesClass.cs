namespace Utilities;

/// <summary>
/// Provides utility methods for mathematical calculations.
/// </summary>
public class UtilitiesClass
{
    /// <summary>
    /// Calculates the factorial of a non-negative integer.
    /// Throws ArgumentException if the number is negative.
    /// </summary>
    /// <param name="number">The non-negative integer to calculate the factorial for.</param>
    /// <returns>The factorial of the specified number.</returns>
    public long Factorial(int number)
    {
        if (number < 0)
            throw new ArgumentException("Number must be non-negative.");
        if (number == 0 || number == 1)
            return 1;
        long result = 1;
        for (int i = 2; i <= number; i++)
        {
            result *= i;
        }
        return result;
    }
}
