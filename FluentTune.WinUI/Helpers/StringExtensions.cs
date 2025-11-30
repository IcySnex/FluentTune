using Windows.UI;

namespace FluentTune.WinUI.Helpers;

public static class StringExtensions
{
    extension(string text)
    {
        public Color ToColor()
        {
            int start = (text[0] == '#') ? 1 : 0;
            int len = text.Length - start;

            if (len != 6 && len != 8)
                return Color.FromArgb(0, 0, 0, 0);

            uint value = 0;

            for (int i = start; i < text.Length; i++)
            {
                int c = text[i];

                int v =
                    (c >= '0' && c <= '9') ? (c - '0') :
                    (c >= 'A' && c <= 'F') ? (c - 'A' + 10) :
                    (c >= 'a' && c <= 'f') ? (c - 'a' + 10) :
                    -1;

                if (v < 0)
                    return Color.FromArgb(0, 0, 0, 0);

                value = (value << 4) | (uint)v;
            }

            if (len == 6)
            {
                return Color.FromArgb(
                    255,
                    (byte)((value >> 16) & 0xFF),
                    (byte)((value >> 8) & 0xFF),
                    (byte)(value & 0xFF));
            }

            return Color.FromArgb(
                (byte)((value >> 24) & 0xFF),
                (byte)((value >> 16) & 0xFF),
                (byte)((value >> 8) & 0xFF),
                (byte)(value & 0xFF));
        }

    }
}