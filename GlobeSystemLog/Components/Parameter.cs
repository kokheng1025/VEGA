using System;
using System.Collections.Generic;
using System.Text;

namespace migrationTools.Components
{
	public enum PARAMETER_TYPE
	{
		PARAMETER_BYVALUE = 1,
		PARAMETER_BYREF = 2,
		PARAMETER_DATATYPE = 3
	}

	class Parameter
	{
		private string mName;
		private PARAMETER_TYPE mType;
		private string mDataType;
		private bool bOptional; 

		public string Name
		{
			get { return mName; }
			set { mName = value; }
		}

		public PARAMETER_TYPE Type
		{
			get { return mType; }
			set { mType = value; }
		}

		public string DataType
		{
			get { return mDataType; }
			set { mDataType = value; }
		}

		public bool Optional 
		{
			get { return bOptional; }
			set { bOptional = value; }
		}
	}
}
