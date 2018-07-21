using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace migrationTools.Components
{
	class ControlProperty
	{
		private string mName;
		private string mValue;
		private string mComment;
		private ArrayList mPropertyList;
		private bool mValid;

		public string Name
		{
			get { return mName; }
			set { mName = value; }
		}

		public string Value
		{
			get { return mValue; }
			set { mValue = value; }
		}

		public string Comment
		{
			get { return mComment; }
			set { mComment = value; }
		}

		public bool Valid
		{
			get { return mValid; }
			set { mValid = value; }
		}

		public ControlProperty()
		{
			mPropertyList = new ArrayList();
			mValid = false;
		}

		public ArrayList PropertyList
		{
			get { return mPropertyList; }
			set { mPropertyList = value; }
		}

	}
}
