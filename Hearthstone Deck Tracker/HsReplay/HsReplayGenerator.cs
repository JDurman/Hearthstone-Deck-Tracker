#region

using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using static Hearthstone_Deck_Tracker.HsReplay.HsReplayConstants;

#endregion

namespace Hearthstone_Deck_Tracker.HsReplay
{
	public class HsReplayGenerator
	{
		private static XmlMetaData[] MetaData
			=>
				new[]
				{
					new XmlMetaData("x-address", Core.Game.MetaData.ServerAddress),
					new XmlMetaData("x-clientid", Core.Game.MetaData.ClientId),
					new XmlMetaData("x-spectateKey", Core.Game.MetaData.SpectateKey),
					new XmlMetaData("x-gameid", Core.Game.MetaData.GameId)
				};

		public static void Generate(List<string> log)
		{
			Directory.CreateDirectory(HsReplayPath);
			Directory.CreateDirectory(TmpDirPath);

			if(!File.Exists(HsReplayExe) || CheckForUpdate())
				Update();

			using(var sw = new StreamWriter(TmpFilePath))
			{
				foreach(var line in log)
					sw.WriteLine(line);
			}

			RunExe();

			AddMetaData(HsReplayOutput, MetaData);

			//TODO: Cleanup
		}

		private static void RunExe()
		{
			var procInfo = new ProcessStartInfo
			{
				FileName = HsReplayExe,
				Arguments = TmpFilePath,
				CreateNoWindow = true,
				RedirectStandardOutput = true,
				UseShellExecute = false
			};
			var proc = Process.Start(procInfo);
			using(var sw = new StreamWriter(HsReplayOutput))
				sw.Write(proc?.StandardOutput.ReadToEnd());
			proc?.WaitForExit();
		}

		public static void AddMetaData(string xmlFile, XmlMetaData[] metaData)
		{
			var xml = XDocument.Load(xmlFile);
			var game = xml.Elements().FirstOrDefault(x => x.Name == "HSReplay")?.Elements().FirstOrDefault(x => x.Name == "Game");
			foreach(var pair in metaData)
				game?.SetAttributeValue(pair.Key, pair.Value);
			xml.Save(xmlFile);
		}

		private static void Update()
		{
			//TODO
		}

		private static bool CheckForUpdate()
		{
			//TODO
			return false;
		}
	}
}