using migrationTools.Components;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace GlobeSystemLog
{
	sealed class Utils
	{

		public static int GetNextWord(string line, ref string nextWord, ref int wordPosition)
		{
			int status = (int)SystemLogStatusCode.Error;

			// remove all leading and trailing white-space characters
			string lineMessage = line.Trim();

			// split by whitespace, brackets, comma and remove null or empty list
			char[] delimiter = { ' ', '(', ')', ',' };
			List<string> sLine = lineMessage.Split(delimiter).ToList();
			sLine.RemoveAll(String.IsNullOrEmpty);

			// return -1 if wordPosition is more than number of words
			if (wordPosition >= sLine.Count)
			{
				wordPosition = -1;
				return (int)SystemLogStatusCode.WordLengthExceedLimit;
			}

			int count = 0;
			foreach (string word in sLine)
			{
				// ignore white-space
				if (count == wordPosition && word.Length > 0)
				{
					nextWord = word;
					wordPosition++;
					return (int)SystemLogStatusCode.Success;
				}
				count++;
			}

			return status;
		}

		public static int GetNextWord(string line, ref string nextWord, ref int wordPosition, char trimEndChar)
		{
			int status = (int)SystemLogStatusCode.Error;

			// Remove all leading and trailing white-space characters
			string lineMessage = line.Trim();

			// return error if trimEndChar is not available
			if (lineMessage.IndexOf(trimEndChar) == -1)
				return (int)SystemLogStatusCode.CharIsNotAvailable;

			// remove endling trailing by trimEndChar
			lineMessage = lineMessage.Substring(0, lineMessage.IndexOf(trimEndChar));

			// Split by whitespace, brackets, comma and remove null or empty list
			char[] delimiter = { ' ', '(', ')', ',' };
			List<string> sLine = lineMessage.Split(delimiter).ToList();
			sLine.RemoveAll(String.IsNullOrEmpty);
			
			// return -1 if wordPosition is more than number of words
			if (wordPosition >= sLine.Count)
			{
				wordPosition = -1;
				return (int)SystemLogStatusCode.WordLengthExceedLimit;
			}

			int count = 0;
			foreach (string word in sLine)
			{
				// ignore white-space
				if (count == wordPosition && word.Length > 0)
				{
					nextWord = word;
					wordPosition++;
					return (int)SystemLogStatusCode.Success;
				}
				count++;
			}

			return status;
		}

		// variable_name = expression
		public static int GetSingleExpression(string line, ref string expression)
		{
			int statusCode = (int)SystemLogStatusCode.Error;

			if (line.Length == 0)
				return (int)SystemLogStatusCode.LineMessageIsEmpty;

			// Remove all leading and trailing white-space characters
			string lineMessage = line.Trim();

			// Remove leading characters after equal operator
			int startPos = lineMessage.IndexOf('=') + 1;
			int totalLength = 0;
			if (startPos < lineMessage.Length)
				totalLength = lineMessage.Length - startPos;

			lineMessage = lineMessage.Substring(startPos, totalLength);

			// split by whitespace, brackets, comma and remove null or empty list
			char[] delimiter = { ' ', '(', ')', ',' , '"'};
			List<string> sLine = lineMessage.Split(delimiter).ToList();
			sLine.RemoveAll(String.IsNullOrEmpty);

			int count = 0;
			foreach (string word in sLine)
			{
				if (count == 0)
				{
					expression = word;
					return (int)SystemLogStatusCode.Success;
				}
				count++;
			}

			return statusCode;
		}

		public static VB_FILE_TYPE FileExtensionDecode(string fileName)
		{
			VB_FILE_TYPE fileType = VB_FILE_TYPE.VB_FILE_UNKNOWN;

			string fileExt = fileName.Substring(fileName.Length - 3, 3);
			if (fileExt != String.Empty)
			{
				switch (fileExt.ToUpper())
				{
					case "FRM":
						fileType = VB_FILE_TYPE.VB_FILE_FORM;
						break;
					case "BAS":
						fileType = VB_FILE_TYPE.VB_FILE_MODULE;
						break;
					case "CLS":
						fileType = VB_FILE_TYPE.VB_FILE_CLASS;
						break;
					default:
						fileType = VB_FILE_TYPE.VB_FILE_UNKNOWN;
						break;
				}
			}

			return fileType;
		}

		public static int SearchProcedureName(string line, string keyWord, ref int wordPosition)
		{
			int status = (int)SystemLogStatusCode.Error;
			string nextWord = String.Empty;			

			while(true)
			{
				status = GetNextWord(line, ref nextWord, ref wordPosition, '(');

				// Declare keyWord is not belong to Procedure/Function
				if (status == (int)SystemLogStatusCode.Success && nextWord == "Declare")
					return (int)SystemLogStatusCode.Continue;

				if (status == (int)SystemLogStatusCode.Success && nextWord == keyWord)
				{
					if (IsFoundCommentLine(line, keyWord) != true)
						return (int)SystemLogStatusCode.Success;
				}

				// exist if found error
				if (status != (int)SystemLogStatusCode.Success)
					break;
			}

			return status;
		}

		public static int SearchProcedureEnd(string line, string keyWord, ref int wordPosition)
		{
			int status = (int)SystemLogStatusCode.Error;
			string nextWord = String.Empty;			

			while (true)
			{
				status = GetNextWord(line, ref nextWord, ref wordPosition);
				if (status == (int)SystemLogStatusCode.Success && keyWord == nextWord)
				{
					if (IsFoundCommentLine(line, keyWord) != true)
						return (int)SystemLogStatusCode.Success;
				}

				// exist if found error
				if (status != (int)SystemLogStatusCode.Success)
					break;
			}

			return status;
		}

		public static int SearchExitFunction(string line)
		{
			int status = (int)SystemLogStatusCode.Error;			
			string nextWord = String.Empty;
			int wordPosition = 0;

			while (true)
			{
				status = GetNextWord(line, ref nextWord, ref wordPosition);
				if (status == (int)SystemLogStatusCode.Success && "Exit" == nextWord)
				{
					if (IsFoundCommentLine(line, "Exit") != true)
						return(int)SystemLogStatusCode.Success;
				}

				// exist if found error
				if (status != (int)SystemLogStatusCode.Success)
					break;
			}

			return status;
		}

		public static bool IsFoundStartProcedureFunction (string line, ref string startProduceName, ref string word)
		{
			bool bIsFound = false;
			string nextWord = String.Empty;
			int wordPosition = 0;

			string[] sKeyWord = { "Sub", "Function" };
			foreach (string keyWord in sKeyWord)
			{
				wordPosition = 0;
				if ((Utils.SearchProcedureName(line, keyWord, ref wordPosition)) == (int)SystemLogStatusCode.Success)
				{
					if ((Utils.GetNextWord(line, ref nextWord, ref wordPosition)) == (int)SystemLogStatusCode.Success)
					{
						startProduceName = nextWord;
						word = keyWord;
						bIsFound = true;						
						break;
					}
				}
			}

			return bIsFound;
		}

		public static bool IsFoundEndProcedureFunction(string line, string procedureName)
		{
			bool bIsFound = false;
			string nextWord = String.Empty;
			int wordPosition = 0;

			if ((Utils.SearchProcedureEnd(line, "End", ref wordPosition)) == (int)SystemLogStatusCode.Success)
			{
				if ((GetNextWord(line, ref nextWord, ref wordPosition)) != (int)SystemLogStatusCode.Success)
					bIsFound = false;

				if (procedureName == nextWord)
				{
					bIsFound = true;
				}
			}

			return bIsFound;
		}

		public static bool IsFoundCommentLine(string line)
		{
			bool bIsFound = false;

			// Remove all leading and trailing white-space characters
			string lineMessage = line.Trim();

			int IdxOfComment = lineMessage.IndexOf("'");
			if (IdxOfComment  >= 0)
			{
				if (IdxOfComment < line.IndexOf("Sub", StringComparison.CurrentCultureIgnoreCase) ||
					IdxOfComment < line.IndexOf("Function", StringComparison.CurrentCultureIgnoreCase) ||
					IdxOfComment < line.IndexOf("End", StringComparison.CurrentCultureIgnoreCase) ||
					IdxOfComment < line.IndexOf("Exit", StringComparison.CurrentCultureIgnoreCase) ||
					IdxOfComment < line.IndexOf("GoTo", StringComparison.CurrentCultureIgnoreCase)) 
				{
					bIsFound = true;
				}
			}

			return bIsFound;
		}

		public static bool IsFoundCommentLine(string line, string keyWord)
		{
			bool bIsFound = false;

			// Remove all leading and trailing white-space characters
			string lineMessage = line.Trim();

			int IdxOfComment = lineMessage.IndexOf("'");
			if (IdxOfComment >= 0)
			{
				if (IdxOfComment < line.IndexOf(keyWord, StringComparison.CurrentCultureIgnoreCase))
				{
					bIsFound = true;
				}
			}

			return bIsFound;
		}

		public static int AddGLBSysLogModule(string sourceFile, string destFile)
		{
			int status = (int)SystemLogStatusCode.Error;

			string line = String.Empty;
			int lineNumber = 0;

			StreamReader reader = new StreamReader(sourceFile);
			StreamWriter writer = new StreamWriter(destFile, true);

			string moduleStr = "Module=GLBSysLog; " + Path.Combine("Temp", "GLBSysLog.bas");
			try
			{
				while ((line = reader.ReadLine()) != null)
				{
					lineNumber++;

					if (lineNumber == 1 && line != moduleStr)
						writer.WriteLine(moduleStr);

					writer.WriteLine(line);
				}
			}
			catch (Exception e)
			{
				Debug.WriteLine(e.Message);
				return (int)SystemLogStatusCode.AddGLBSysLogModuleError;
			}
			finally
			{
				reader.Close();
				writer.Close();
				status = (int)SystemLogStatusCode.Success;
			}

			return status;
		}


		public static int Initialize(string sourceFolder)
		{
			string tempFolder = Path.Combine(sourceFolder, "temp");
			string GLBSysLogFile = Path.Combine(Directory.GetCurrentDirectory(), "GLBSysLog.bas");

			// create temp folder if not exist, 
			//otherwise delete the previous temp folder
			if (!Directory.Exists(tempFolder))
			{
				Directory.CreateDirectory(tempFolder);
			}
			else
			{
				Directory.Delete(tempFolder, true);
				while (Directory.Exists(tempFolder))
				{
					System.Threading.Thread.Sleep(100);
				}

				Directory.CreateDirectory(tempFolder);
				System.Threading.Thread.Sleep(500);
			}

			// make sure temp folder is exist
			if (!Directory.Exists(tempFolder))
				return (int)SystemLogStatusCode.FolderIsNotCreatedError;

			File.Copy(GLBSysLogFile, Path.Combine(tempFolder, "GLBSysLog.bas"), true);

			// only one *.vbp file in each Target folder
			string[] files = Directory.GetFiles(sourceFolder, "*.vbp");
			if (files.Length == 1)
			{
				string vbpFileName = Path.GetFileName(files[0]);
				File.Copy(files[0], Path.Combine(tempFolder, vbpFileName), true);

				string vbpFile = Path.Combine(tempFolder, vbpFileName + "__");

				if (AddGLBSysLogModule(files[0], vbpFile) != (int)SystemLogStatusCode.Success)
					return (int)SystemLogStatusCode.InitError;
			}
			else
				return (int)SystemLogStatusCode.InitError;

			return (int)SystemLogStatusCode.Success;			
		}

		public static int replaceTargetFiles(string sourceFolder)
		{
			string tempFolder = Path.Combine(sourceFolder, "temp");		
			string[] files = Directory.GetFiles(tempFolder, "*.*__");

			try
			{
				foreach (string f in files)
				{
					if (File.Exists(f))
					{
						// remove trailing __ from dirty file extension
						string fileName = Path.GetFileName(f.Substring(0, f.Length - 2));
						File.Copy(f, Path.Combine(sourceFolder, fileName), true);
					}
				}
			}
			catch (Exception e)
			{
				Debug.WriteLine("Replace files not success with error message - {0}", e.Message);
				return (int)SystemLogStatusCode.ReplaceFilesError;
			}

			return (int)SystemLogStatusCode.Success;
		}
	}
}
