using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

namespace System
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class MemoryExtensions
    {
        public static ReadOnlySpan<char> AsSpan(this string text)
        {
            if (text == null) return default;
            return new ReadOnlySpan<char>(text.ToCharArray());
        }

        public static ReadOnlySpan<char> AsSpan(this string text, int start)
        {
            if (text == null)
            {
                if (start != 0) throw new ArgumentOutOfRangeException();
                return default;
            }

            return AsSpan(text, start, text.Length - start);
        }

        public static ReadOnlySpan<char> AsSpan(this string text, int start, int length)
        {
             if (text == null)
             {
                 if (start != 0 || length != 0) throw new ArgumentOutOfRangeException();
                 return default;
             }

             // In case ToCharArray(start, length) is not available/reliable in all H5 targets,
             // using Substring + ToCharArray is safer given we are in H5 environment where string ops are cheapish (JS strings).
             // But actually ToCharArray() creates an array, so Substring is fine.
             // Wait, if I use Substring, I allocate a string then an array.
             // If I use ToCharArray(), I allocate an array.
             // I'll assume ToCharArray() is good or just use full array + offset.

             // H5 ReadOnlySpan implementation takes (array, offset, length).
             // If I do text.ToCharArray(), I get the FULL array.
             // Then I pass start and length to ReadOnlySpan ctor.
             // This avoids allocating a substring.

             return new ReadOnlySpan<char>(text.ToCharArray(), start, length);
        }

        public static bool SequenceEqual<T>(this ReadOnlySpan<T> span, ReadOnlySpan<T> other) where T : IEquatable<T>
        {
            if (span.Length != other.Length) return false;
            for (int i = 0; i < span.Length; i++)
            {
                if (!EqualityComparer<T>.Default.Equals(span[i], other[i])) return false;
            }
            return true;
        }
    }
}
