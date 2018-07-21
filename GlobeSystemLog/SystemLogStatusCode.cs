using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobeSystemLog
{
	public enum SystemLogStatusCode
	{
		
		Success = 0,

		// Information status, not the error		
		Continue = 1,
		LineMessageIsEmpty = 2,
		WordLengthExceedLimit = 3,
		CharIsNotAvailable = 4,
		
		// General Error
		Error = 100,

		// code parse error
		ParseFileError = 200,
		ParseHeaderError = 201,
		ParseBodyProcedureError = 202,

		// code generate error
		CodeGenerateError = 300, 
		ProcessFileError = 301,

		// others error
		AddGLBSysLogModuleError = 400,
		FolderIsNotCreatedError = 401,
		InitError = 402,
		ReplaceFilesError = 403,
        InvalidSettingPath = 404,
	}
}
