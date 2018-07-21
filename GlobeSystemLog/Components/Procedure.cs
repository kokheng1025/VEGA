using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace migrationTools.Components
{
	public enum PROCEDURE_TYPE
	{
		PROCEDURE_EVENT = 1,
		PROCEDURE_SUB = 2,
		PROCEDURE_FUNCTION = 3,
		PROCEDURE_PROPERTY = 4
	}

	class Procedure
	{
		private string mName;
		private string mScope;
		private PROCEDURE_TYPE mType;
		private ArrayList mParameterList;
		private string mReturnType;

		private string mComment;
		private ArrayList mLineList;
		private IDictionary<string, int> mlineMap;

		public Procedure()
		{
			mLineList = new ArrayList();
			mParameterList = new ArrayList();
			mlineMap = new Dictionary<string, int>();
		}

		public string Name
		{
			get { return mName; }
			set { mName = value; }
		}

		public string Comment
		{
			get { return mComment; }
			set { mComment = value; }
		}

		public string Scope
		{
			get { return mScope; }
			set { mScope = value; }
		}

		public PROCEDURE_TYPE Type
		{
			get { return mType; }
			set { mType = value; }
		}

		public ArrayList ParameterList
		{
			get { return mParameterList; }
			set { mParameterList = value; }
		}

		public string ReturnType
		{
			get { return mReturnType; }
			set { mReturnType = value; }
		}

		public ArrayList LineList
		{
			get { return mLineList; }
			set { mLineList = value; }
		}

		public IDictionary<string, int> LineMap 
		{ 
			get { return mlineMap; }
			set { mlineMap = value; }
		}
	}
}
