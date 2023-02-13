namespace Analyzer
{
	public static class Extensions
	{
		public static bool IsNumber(this char ch)
		{
			if (ch >= '0' && ch <= '9')
				return true;

			return false;
		}

		public static bool IsIdStartingSign(this char ch)
		{
			if ((ch >= 'a' && ch <= 'z') || ch == '_')
				return true;

			return false;
		}

		public static bool IsIdSign(this char ch)
		{
			return ch.IsIdStartingSign() || ch.IsNumber();
		}

		public static bool IsNumberSign(this char ch)
		{
			if (ch == '+' || ch == '-')
				return true;

			return false;
		}

		public static bool IsCompareSign(this char ch)
		{
			if (ch == '<' || ch == '>')
				return true;

			return false;
		}

		public static bool IsSpace(this char ch)
		{
			if (ch == ' ')
				return true;

			return false;
		}
	}
}
