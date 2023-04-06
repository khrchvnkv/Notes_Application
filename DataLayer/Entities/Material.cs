using System;

namespace DataLayer.Entities
{
	public class Material : Page
	{
		public int DirectoryId { get; set; }
		public Directory Directory { get; set; }
	}
}

