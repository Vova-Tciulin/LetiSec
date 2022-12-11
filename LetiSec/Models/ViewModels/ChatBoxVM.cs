using LetiSec.Models.DbModel;

namespace LetiSec.Models.ViewModels
{
	public class ChatBoxVM
	{
		public SuppMessage SuppMessage { get; set; }
		public List<AllMessage> Msg { get; set; } = new List<AllMessage>();
		public bool IsUser { get; set; }
		public string? Message { get; set; }
	}

	public class AllMessage
	{
		public string Msg { get; set; }
		public string Name { get; set; }
		public DateTime Date { get; set; }
	}
}
