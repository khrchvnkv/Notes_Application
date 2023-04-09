using System;
namespace DataLayer
{
	public static class SampleData
	{
		public static void InitData(EFDBContext context)
		{
			if (!context.Directory.Any())
			{
				context.Directory.Add(
					new Entities.Directory()
					{
						Title = "First Directory",
						Html = "<b>First Directory Content</b>"
					});
                context.Directory.Add(
                    new Entities.Directory()
                    {
                        Title = "Second Directory",
                        Html = "<b>Second Directory Content</b>"
                    });
				context.SaveChanges();
            }

			if (!context.Material.Any())
			{
				context.Material.Add(
					new Entities.Material()
					{
						Title = "First Material",
						Html = "<i>Material Content</i>",
						DirectoryId = context.Directory.First().Id
					});
                context.Material.Add(
					new Entities.Material()
					{
						Title = "Second Material",
						Html = "<i>Material Content</i>",
						DirectoryId = context.Directory.First().Id
					});
                context.Material.Add(
                    new Entities.Material()
                    {
                        Title = "Third Material",
                        Html = "<i>Material Content</i>",
                        DirectoryId = context.Directory.OrderBy(d => d.Id).Last().Id
                    });
				context.SaveChanges();
            }
		}
	}
}

