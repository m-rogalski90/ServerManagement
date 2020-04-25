using System.Data;

namespace HehKurwele.ServerManagement.ServerBase.Database.Queries
{
	public sealed class QueryParameter
	{
		public readonly string Name;
		public readonly object Value;
		public SqlDbType? SqlDbType { get; set; }

		public QueryParameter(string name, object value)
		{
			Name = name;
			Value = value;
		}
	}
}
