namespace Tetriz
{
    public static class Const
    {
        public const int DefaultScreenWidth = 20;
        public const int DefaultScreenHeight = 30;
        public const int FrameDelay = 600; // 1000 millisecond
        public static string X = "██";
        public static string _ = "  ";
        public static string Dot = "··";
        public const string TextGameOver = @"

  ________                        ________
 /  _____/_____    _____   ____   \_____  \___  __ ___________
/   \  ___\__  \  /     \_/ __ \   /   |   \  \/ // __ \_  __ \
\    \_\  \/ __ \|  Y Y  \  ___/  /    |    \   /\  ___/|  | \/
 \______  (____  /__|_|  /\___  > \_______  /\_/  \___  >__|
        \/     \/      \/     \/          \/          \/

        ";

        public const string TextTetriz = @"

  __          __         .__
_/  |_  _____/  |________|__|_______
\   __\/ __ \   __\_  __ \  \___   /
 |  | \  ___/|  |  |  | \/  |/    /
 |__|  \___  >__|  |__|  |__/_____ \
           \/                     \/

        ";
    }
}