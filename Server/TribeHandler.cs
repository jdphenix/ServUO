using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server
{
	public class TribeHandler
	{
		private readonly IDictionary<string, string> m_OpposingTribes;

		public TribeHandler()
		{
			var oppositions = Config.Entries
				.Where(x => x.Scope == "Mobile.Tribes")
				.Where(x => x.Key.StartsWith("Opposition"));

			m_OpposingTribes = oppositions
				.Select(x => new KeyValuePair<string, string>(
					x.Key.Split('.')[1],
					x.Value))
				.ToDictionary(x => x.Key, x => x.Value);
		}

		public string MemberOf(Type mobileType)
		{
			return string.Empty;
		}

		public ITribeOpposer Does(string tribe)
		{
			return new TribeOpposer(tribe, m_OpposingTribes);
		}

		public interface ITribeOpposer
		{
			bool Oppose(string otherTribe);
		}

		private class TribeOpposer : ITribeOpposer
		{
			private readonly string m_Tribe;
			private readonly IDictionary<string, string> m_OpposingTribes;

			public TribeOpposer(
				string tribe,
				IDictionary<string, string> opposingTribes)
			{
				m_Tribe = tribe;
				m_OpposingTribes = opposingTribes;
			}

			public bool Oppose(string otherTribe)
			{
				return m_OpposingTribes.ContainsKey(m_Tribe) && m_OpposingTribes[m_Tribe] == otherTribe;
			}
		}
	}
}
