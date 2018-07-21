using migrationTools.Components;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace GlobeSystemLog
{
	class CodeGenerator
	{
		private Module mSourceCodeModule;
		private Procedure mProcedure;

		public static string mTargetDll;
		private static string mFileName;
		private static string mDestFolder;
		private static string mSourceFolder;
		
		private int mProcedureIndex; 
		
		public CodeGenerator (Module module)
		{
			mSourceCodeModule = module;
			mDestFolder = String.Empty;
			mSourceFolder = String.Empty;
			mTargetDll = String.Empty;
			mFileName = String.Empty;	
			mProcedureIndex = 0;
		}
		
		public int LogGenerator(string sourceFile)
		{
			int status = (int)SystemLogStatusCode.Success;

			mSourceFolder = Path.GetDirectoryName(sourceFile);
			mDestFolder = Path.Combine(mSourceFolder, "temp");
			mFileName = Path.GetFileName(sourceFile);
			mTargetDll = new DirectoryInfo(sourceFile).Parent.Name;

			// copy GLBSysLog.bas and selected target file into temp folder
			string destFile = Path.Combine(mDestFolder, mFileName + "__");	
			File.Copy(sourceFile, Path.Combine(mDestFolder, mFileName), true);
			
			// add debug message selected target file
			if ((status = processTargetFile(sourceFile, destFile)) != (int)SystemLogStatusCode.Success)
				return (int)SystemLogStatusCode.CodeGenerateError;

			return status;
		}
		
		private int processTargetFile(string sourceFile, string destFile)
		{
			int status = (int)SystemLogStatusCode.Success;

			string line = String.Empty;
			bool bWriteLine = false;
			int lineNum = 0;

			StreamReader reader = new StreamReader(sourceFile);
			StreamWriter writer = new StreamWriter(destFile, true, Encoding.GetEncoding(1252));
			
			try
			{
				while ((line = reader.ReadLine()) != null)
				{
					lineNum++;

					if (line == null || line == String.Empty)
					{
						writer.WriteLine(line);
						continue;
					}

					if (mProcedureIndex < mSourceCodeModule.ProcedureList.Count)
					{
						if (lineNum == GetNextLineNum(mProcedureIndex, "START"))
						{
							writer.WriteLine(line);
							writer.WriteLine(GenerateDebugMessage("START", mProcedure.Name));
							bWriteLine = true;
						}

						if (lineNum == GetNextLineNum(mProcedureIndex, "END"))
						{
							writer.WriteLine(GenerateDebugMessage("END", mProcedure.Name));
							writer.WriteLine(line);
							mProcedureIndex++;
							bWriteLine = true;
						}
					}

					if (bWriteLine != true)
					{
						writer.WriteLine(line);
					}

					bWriteLine = false;
				}

			}
			catch (Exception e)
			{
				Debug.WriteLine(e.Message);
				return (int)SystemLogStatusCode.ProcessFileError;
			}
			finally
			{
				reader.Close();
				writer.Close();
			}

			return status;
		}

		private string GenerateDebugMessage(string state, string functionName)
		{
			string displayMsg = String.Format("    ESysLogger \"{0}\", \"{1}\", \"{2}\", \"{3}\" ", mTargetDll, 
				mFileName, state, functionName);

			return displayMsg;
		}

		private int GetNextLineNum(int Index, string keyValue)
		{
			int nextLineNum = 0;

			mProcedure = (Procedure)mSourceCodeModule.ProcedureList[Index];

			if (keyValue == "START")
			{
				
				if (mProcedure.LineMap.ContainsKey("START-" + mProcedure.Name))
				{
					//Console.WriteLine("LineMap: {0}, {1}", mProcedure.LineMap.Keys, mProcedure.LineMap.Values);
					nextLineNum = mProcedure.LineMap["START-" + mProcedure.Name];
				}
			}
			
			if (keyValue == "END")
			{
				if (mProcedure.LineMap.ContainsKey("END-" + mProcedure.Name))
				{
					//Console.WriteLine("LineMap: {0}, {1}", mProcedure.LineMap.Keys, mProcedure.LineMap.Values);
					nextLineNum = mProcedure.LineMap["END-" + mProcedure.Name];
				}
			}

			return nextLineNum;
		}
	}
}
