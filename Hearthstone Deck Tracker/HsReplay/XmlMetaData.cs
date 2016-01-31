namespace Hearthstone_Deck_Tracker.HsReplay
{
	public class XmlMetaData
	{
		public XmlMetaData(string key, string value)
		{
			Key = key;
			Value = value;
		}

		public string Key { get; set; }
		public string Value { get; set; }
	}
}