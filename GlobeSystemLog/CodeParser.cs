using migrationTools.Components;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics;
using System.Windows.Forms;

namespace GlobeSystemLog
{
	public enum VB_FILE_TYPE
	{
		VB_FILE_UNKNOWN = 0,
		VB_FILE_FORM = 1,
		VB_FILE_MODULE = 2,
		VB_FILE_CLASS = 3
	};

	class CodeParser
	{
		private VB_FILE_TYPE mFileType;
		private Module mSourceModule;
		private Module mTargetModule;
		private string mOutSourceCode;

		private const string FORM_FIRST_LINE = "VERSION 5.00";
		private const string MODULE_FIRST_LINE = "ATTRIBUTE";
		private const string CLASS_FIRST_LINE = "1.0 CLASS";

		private const string Indent2 = "  ";
		private const string Indent4 = "    ";
		private const string Indent6 = "      ";
		private int lineNum;
        private List<String> checkedFilesFromForm;

		public CodeParser()
		{
			mSourceModule = new Module();
			lineNum = 0;
		}
		
		public int ParseFile(string fileName, List<String> checkedFiles)
		{
			int status = (int)SystemLogStatusCode.Success;
            checkedFilesFromForm = checkedFiles;
			string line = String.Empty;
			string tempLine = String.Empty;

			// open file
			StreamReader Reader = new StreamReader(fileName, Encoding.ASCII, false, 65536);

			try
			{
				// decode file extension
				mFileType = Utils.FileExtensionDecode(fileName);

				// parse header function 
				status = ParseHeader(Reader);

				// parse remain - variables, functions, procedures
				if (status == (int)SystemLogStatusCode.Success)
					status = ParseBodyProcedure(Reader);
			} 
			catch (Exception e)
			{
				Debug.WriteLine(e.Message);
				return (int)SystemLogStatusCode.ParseFileError;
			}
			
			// close stream before exit
			Reader.Close();

			// generate output File
			if (status == (int)SystemLogStatusCode.Success)
				status = GenerateSourceCode(fileName);

			return status;
		}

		private int GenerateSourceCode(string fileName)
		{
			CodeGenerator codeGenerator = new CodeGenerator(mSourceModule);
			int status = codeGenerator.LogGenerator(fileName);

			return status;
		}

		#region ParseHeader
		private int ParseHeader(StreamReader reader)
		{
			int status = (int)SystemLogStatusCode.Success;

			string line = String.Empty;
			string tempLine = String.Empty;
			int wordNum = 0;

			// Start from begin
			reader.BaseStream.Seek(0, SeekOrigin.Begin);
			line = reader.ReadLine();
			lineNum++;

			// get first word from first line
			status = Utils.GetNextWord(line, ref tempLine, ref wordNum);
			if (status != (int)SystemLogStatusCode.Success)
				return status;

			switch (tempLine.ToUpper())
			{
				// 'Attribute VB_Name = "ModuleName"'
				case MODULE_FIRST_LINE: 
					mFileType = VB_FILE_TYPE.VB_FILE_MODULE;
					break;
				case "VERSION":
					string version = String.Empty;
					if ((status = Utils.GetNextWord(line, ref version, ref wordNum)) != (int)SystemLogStatusCode.Success)
						return status;
					mSourceModule.Version = version;
					break;
			}

			// parse header module base on file extension
			if (mFileType == VB_FILE_TYPE.VB_FILE_CLASS)
			{
				mSourceModule.Type = VB_FILE_TYPE.VB_FILE_CLASS;
				if ((status = ParseClass(reader)) != (int)SystemLogStatusCode.Success)
					return status;
			}
			else if (mFileType == VB_FILE_TYPE.VB_FILE_FORM)
			{
				mSourceModule.Type = VB_FILE_TYPE.VB_FILE_FORM;
			}
			else if (mFileType == VB_FILE_TYPE.VB_FILE_MODULE)
			{
				mSourceModule.Type = VB_FILE_TYPE.VB_FILE_MODULE;
			}
			else
			{
				status = (int)SystemLogStatusCode.ParseHeaderError;
			}

			return status;
		}
		
		private int ParseClass(StreamReader reader)
		{
			int status = (int)SystemLogStatusCode.Success;

			int wordPosition = 0;
			string line = String.Empty;
			string nextWord = String.Empty;

			while ((line = reader.ReadLine()) != null)
			{
				lineNum++;
				wordPosition = 0;

				if ((status = Utils.GetNextWord(line, ref nextWord, ref wordPosition)) != (int)SystemLogStatusCode.Success)
					return status;

				if (nextWord == "Attribute")
				{
					if ((status = Utils.GetNextWord(line, ref nextWord, ref wordPosition)) != (int)SystemLogStatusCode.Success)
						return status;

					if (nextWord == "VB_Name")
					{
						if ((status = Utils.GetSingleExpression(line, ref nextWord)) != (int)SystemLogStatusCode.Success)
							return status;

						mSourceModule.Name = nextWord;
					}
					else
					{
						if (nextWord == "VB_Exposed")
							return (int)SystemLogStatusCode.Success;
					}
				}
			}

			return status;
		}
		#endregion


		#region ParseBody

        private bool isFunctionChecked(string functionName)
        {
            bool functionFound = false;

            foreach (string files in checkedFilesFromForm)
            {
                if (files == functionName)
                {
                    functionFound = true;
                    break;
                }
            }
            
            return functionFound;
        }

		private int ParseBodyProcedure(StreamReader reader)
		{
			int status = (int)SystemLogStatusCode.Success;

			string line = String.Empty;
			string nextWord = String.Empty;
			string endProduceName = String.Empty;
			bool bProcedure = false;

			Procedure oProcedure = null;

			try 
			{
				while ((line = reader.ReadLine()) != null)
				{
					lineNum++;
					int wordPosition = 0;

					if (line == null || line == String.Empty) continue;
					
					// if line not yet finish, added it together
					while (line.Substring(line.Length - 1, 1) == "_")
					{
						line += reader.ReadLine();
						lineNum++;
					}

					if (bProcedure == false)
					{
						string startProduceName = String.Empty;
						string keyWord = String.Empty;
						if (Utils.IsFoundStartProcedureFunction(line, ref startProduceName, ref keyWord) == true)
						{
                            //Check if function is in Checked List
                            if (isFunctionChecked(startProduceName))
                            {
                                oProcedure = new Procedure();
                                oProcedure.Name = startProduceName;

                                if (keyWord == "Sub")
                                {
                                    oProcedure.Type = PROCEDURE_TYPE.PROCEDURE_SUB;
                                    endProduceName = "Sub";
                                }
                                else if (keyWord == "Function")
                                {
                                    oProcedure.Type = PROCEDURE_TYPE.PROCEDURE_FUNCTION;
                                    endProduceName = "Function";
                                }

                                oProcedure.LineMap.Add("START-" + oProcedure.Name, lineNum);
                                bProcedure = true;
                            }
						}

						if (status >= (int)SystemLogStatusCode.Error)
							return (int)SystemLogStatusCode.ParseBodyProcedureError;

						if (bProcedure == true)
							continue;
					}

					if (bProcedure)
					{
						// Search GoTo Error Handler exit function
						wordPosition = 0;


						// Search procedure End function
						if (Utils.IsFoundEndProcedureFunction(line, endProduceName) == true)
						{
							oProcedure.LineMap.Add("END-" + oProcedure.Name, lineNum); // i.e. Sub-END or Function-END
							mSourceModule.ProcedureAdd(oProcedure);
							bProcedure = false;
						}	
					}
				}
			}
			catch (Exception e)
			{
				Debug.WriteLine("error {0}", e.Message);
				return (int)SystemLogStatusCode.ParseBodyProcedureError;
			}
	

			return (int)SystemLogStatusCode.Success;
		}


		#endregion

	}
}
