using HehKurwele.ServerManagement.ServerBase.Database.Queries;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HehKurwele.ServerManagement.Tests
{
	[TestClass]
	public class QueryBuilderTests
	{
		[TestMethod]
		public void BuildUserSelectQuery()
		{
			string query = new QueryBuilder().Select("username", "password").From("dt_user");
			Assert.IsTrue(!string.IsNullOrEmpty(query));
		}

		[TestMethod]
		public void BuildUpdateQuery()
		{
			string query = new QueryBuilder().Update("dt_user").Set("username", "nosiema").Set("password", "nosiema");
			Assert.IsTrue(!string.IsNullOrEmpty(query));
		}

		[TestMethod]
		public void BuildInsertQuery()
		{
			string query = new QueryBuilder().Insert("dt_user").Column("username", "password", "address", "active").Values("dajbuzi", "nosiema", "m.rogalski90@gmail.com", "1");
			Assert.IsTrue(!string.IsNullOrEmpty(query));
		}
	}
}
