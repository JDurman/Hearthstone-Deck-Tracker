#region

using System.IO;

#endregion

namespace Hearthstone_Deck_Tracker.HsReplay
{
	public class HsReplayConstants
	{
		public const string DownloadUrl = "https://github.com/Epix37/HDT-Test/releases/download/hsreplay/hsreplay-{0}.zip";
		public const string ZipFile = "hsreplay-{0}.zip";
		private const string HsReplayXmlFile = "hslog.xml";
		private const string TmpPowerLogFile = "tmp.log";
		private const string HsReplayDir = "HsReplay";
		private const string HsReplayExeFilename = "convert.exe";
		private const string TmpDir = "temp";
		private const string VersionFile = "version";

		public static string TmpDirPath => Path.Combine(HsReplayPath, TmpDir);
		public static string TmpFilePath => Path.Combine(TmpDirPath, TmpPowerLogFile);
		public static string HsReplayPath => Path.Combine(Config.AppDataPath, HsReplayDir);
		public static string HsReplayExe => Path.Combine(HsReplayPath, HsReplayExeFilename);
		public static string HsReplayOutput => Path.Combine(TmpDirPath, HsReplayXmlFile);
		public static string VersionFilePath => Path.Combine(HsReplayPath, VersionFile);
		public static string ZipFilePath => Path.Combine(HsReplayPath, ZipFile);
	}
}