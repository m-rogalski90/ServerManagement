using HehKurwele.ServerManagement.ServerBase.Database.Queries;
using System.Data.SqlClient;

namespace HehKurwele.ServerManagement.ServerBase.Database
{
	public sealed class MSSQLClient
	{
		private readonly SqlConnection mConnection;

		public MSSQLClient(SqlConnectionStringBuilder connectionStringBuilder)
		{
			string connectionString = connectionStringBuilder.ToString();
			mConnection = new SqlConnection(connectionString);
		}

		public TTable ExecuteQuery<TTable>(QueryBuilder queryBuilder, params QueryParameter[] queryParameters)
		{
			string queryString = queryBuilder.ToString();
			using (SqlCommand command = mConnection.CreateCommand())
			{
				command.CommandText = queryString;
				foreach (QueryParameter parameter in queryParameters)
				{
					SqlParameter sqlParameter = new SqlParameter
					{
						ParameterName = parameter.Name,
						Value = parameter.Value
					};

					if (parameter.SqlDbType.HasValue)
					{
						sqlParameter.SqlDbType = parameter.SqlDbType.Value;
					}
					command.Parameters.Add(sqlParameter);
				}
				mConnection.Open();
				using (SqlDataReader reader = command.ExecuteReader())
				{
					// .. read values and map them to requested table fields
				}
				mConnection.Close();
			}
			return default;
		}
	}
}
