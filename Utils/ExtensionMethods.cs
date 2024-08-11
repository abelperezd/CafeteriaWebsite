namespace CafeteriaWebsite.Utils
{
	public static class ExtensionMethods
	{
		public static string GetExtension(this string original)
		{
			return Path.GetExtension(original);
		}
	}
}
