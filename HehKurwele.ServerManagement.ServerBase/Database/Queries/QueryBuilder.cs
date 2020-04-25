using System.Collections.Generic;
using System.Text;

namespace HehKurwele.ServerManagement.ServerBase.Database.Queries
{
	public sealed class QueryBuilder
	{
		private readonly StringBuilder mStringBuilder;

		public abstract class SpecializedQueryBuilder
		{
			protected readonly QueryBuilder Parent;

			internal SpecializedQueryBuilder(QueryBuilder parent)
			{
				Parent = parent;
			}

			protected abstract void BuildInternal();

			public string Build()
			{
				BuildInternal();
				return Parent.ToString();
			}

			protected void Append(string queryPart)
			{
				Parent.mStringBuilder.Append(queryPart);
			}

			public static implicit operator string(SpecializedQueryBuilder specializedQueryBuilder)
			{
				return specializedQueryBuilder.Build();
			}
		}

		public sealed class FromQueryBuilder : SpecializedQueryBuilder
		{
			private readonly string mTableName;

			public FromQueryBuilder(QueryBuilder parent, string tableName) : base(parent)
			{
				mTableName = tableName;
			}

			protected override void BuildInternal()
			{
				Append($" FROM {mTableName} ");
			}
		}

		public sealed class ValuesQueryBuilder : SpecializedQueryBuilder
		{
			private readonly List<string> mValuesList;

			public ValuesQueryBuilder(QueryBuilder parent, params string[] values) : base(parent)
			{
				mValuesList = new List<string>(values);
			}

			public ValuesQueryBuilder Values(params string[] values)
			{
				mValuesList.AddRange(values);
				return this;
			}

			protected override void BuildInternal()
			{
				Append($" VALUES ( {string.Join(", ", mValuesList)} ) ");
			}
		}

		public sealed class SelectQueryBuilder : SpecializedQueryBuilder
		{
			private readonly List<string> mFields;

			internal SelectQueryBuilder(QueryBuilder parent, params string[] fields) : base(parent)
			{
				mFields = new List<string>(fields);
			}

			public SelectQueryBuilder Select(params string[] fields)
			{
				mFields.AddRange(fields);
				return this;
			}

			public FromQueryBuilder From(string tableName)
			{
				BuildInternal();
				return new FromQueryBuilder(Parent, tableName);
			}

			protected override void BuildInternal()
			{
				Append($" {string.Join(", ", mFields)} ");
			}
		}

		public sealed class UpdateQueryBuilder : SpecializedQueryBuilder
		{
			private readonly string mTableName;
			private readonly List<string> mSetList;

			internal UpdateQueryBuilder(QueryBuilder parent, string tableName) : base(parent)
			{
				mTableName = tableName;
				mSetList = new List<string>();
			}

			public UpdateQueryBuilder Set(string field, string value)
			{
				mSetList.Add($"{field}={value}");
				return this;
			}

			protected override void BuildInternal()
			{
				Append($" {mTableName} SET {string.Join(", ", mSetList)} ");
			}

		}

		public sealed class InsertQueryBuilder : SpecializedQueryBuilder
		{
			private readonly string mTableName;
			private readonly List<string> mFields;

			internal InsertQueryBuilder(QueryBuilder parent, string tableName) : base(parent)
			{
				mTableName = tableName;
				mFields = new List<string>();
			}

			public InsertQueryBuilder Column(params string[] columnNames)
			{
				mFields.AddRange(columnNames);
				return this;
			}

			public ValuesQueryBuilder Values(params string[] values)
			{
				BuildInternal();
				return new ValuesQueryBuilder(Parent, values);
			}

			protected override void BuildInternal()
			{
				Append($" {mTableName} ({string.Join(", ", mFields)}) ");
			}
		}

		public QueryBuilder()
		{
			mStringBuilder = new StringBuilder();
		}

		public SelectQueryBuilder Select(params string[] fields)
		{
			mStringBuilder.Append($"SELECT ");
			return new SelectQueryBuilder(this).Select(fields);
		}

		public UpdateQueryBuilder Update(string tableName)
		{
			mStringBuilder.Append($"UPDATE ");
			return new UpdateQueryBuilder(this, tableName);
		}

		public InsertQueryBuilder Insert(string tableName)
		{
			mStringBuilder.Append($"INSERT INTO ");
			return new InsertQueryBuilder(this, tableName);
		}

		public override string ToString()
		{
			return mStringBuilder.ToString();
		}
	}
}
