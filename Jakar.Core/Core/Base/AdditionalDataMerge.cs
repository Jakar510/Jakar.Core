// Jakar.Extensions :: Jakar.Core
// 11/16/2026

namespace Jakar.Extensions;


/// <summary> Jakar.Extensions' <c> Json.Merge </c>, for <see cref="BaseClass"/> and <see cref="BaseRecord"/>. </summary>
internal static class AdditionalDataMerge
{
    /// <summary> Copies <paramref name="source"/> into <paramref name="destination"/> (creating it if needed), replacing existing keys; values are cloned. </summary>
    public static JObjectNode? Merge( JObjectNode? destination, JObjectNode? source )
    {
        if ( source is null || source.Count == 0 ) { return destination; }

        destination ??= [];
        foreach ( ( string key, JNode? value ) in source ) { destination[key] = value?.DeepClone(); }

        return destination;
    }
}
