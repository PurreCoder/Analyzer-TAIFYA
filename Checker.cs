using System;
using System.Collections.Generic;

namespace Analyzer
{
	public static class Checker
	{
		// variable, its description
		public static SortedDictionary<String, String> variables = new SortedDictionary<string, string>();
		public static SortedDictionary<String, String> constants = new SortedDictionary<string, string>();

		public static bool IsDigit(char c)
		{
			return ('0' <= c && c <= '9');
		}

		public static bool IsLetter(char c)
		{
			return ('a' <= c && c <= 'z');
		}
	}
}