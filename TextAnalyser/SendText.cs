using System;
using System.Collections.Generic;

namespace TextAnalyser
{
	public class Document
	{
		public string language { get; set; }
		public string id { get; set; }
		public string text { get; set; }
	}

	public class SendText
	{
		public List<Document> documents { get; set; }
	}
}
