using System;
using System.Collections.Generic;
using System.Text;

namespace migrationTools.Components
{
	class Variable
	{
		private string mName;
		private string mType;
		private string mScope;
		private string mComment;

		public string Name
		{
			get { return mName; }
			set { mName = value; }
		}

		public string Type
		{
			get { return mType; }
			set { mType = value; }
		}

		public string Scope
		{
			get { return mScope; }
			set { mScope = value; }
		}

		public string Comment
		{
			get { return mComment; }
			set { mComment = value; }
		}

		public static implicit operator Variable(Dictionary<string, string> v)
		{
			throw new NotImplementedException();
		}
	}
}
