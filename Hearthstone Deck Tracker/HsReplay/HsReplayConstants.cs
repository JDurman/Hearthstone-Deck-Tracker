#region

using System.IO;

#endregion

namespace Hearthstone_Deck_Tracker.HsReplay
{
	public class HsReplayConstants
	{
		public const string HsReplayXmlFile = "hslog.xml";
		public const string TmpPowerLogFile = "tmp.log";
		private const string HsReplayDir = "HsReplay";
		private const string HsReplayExeFilename = "HSReplay.exe";
		private const string TmpDir = "temp";

		public static string TmpDirPath => Path.Combine(HsReplayPath, TmpDir);
		public static string TmpFilePath => Path.Combine(TmpDir, TmpPowerLogFile);
		public static string HsReplayPath => Path.Combine(Config.AppDataPath, HsReplayDir);
		public static string HsReplayExe => Path.Combine(HsReplayPath, HsReplayExeFilename);
		public static string HsReplayOutput => Path.Combine(TmpDirPath, HsReplayXmlFile);
	}
}