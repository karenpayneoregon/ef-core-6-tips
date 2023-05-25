using System.Numerics;

namespace EF_IdentityOptions.Classes;

public static class GenericExtensions
{
    public static bool IsEven<T>(this T sender) where T : INumber<T>
        => T.IsEvenInteger(sender);

}