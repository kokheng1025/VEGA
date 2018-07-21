Option Explicit

Public Function ESysLogger(targetName As String, fileName As String, status As String, funcName As String)
    Dim log_path As String, content As String
    Dim lngFileHandle As Long: lngFileHandle = FreeFile
    
    log_path = CStr(Environ("USERPROFILE") & "\Documents\GLBSysLog_" + Format(Now, "dd-MMM-yyyy") + ".log")
    
    content = content + Format(Now, "dd-MMM-yyyy HH:nn:ss") & "." & Right(Format(Timer, "#0.00"), 2)
    content = content + " " + targetName + " " + fileName + " " + status + " " + funcName
    
    lngFileHandle = FreeFile
    Open log_path For Append As lngFileHandle
    Print #lngFileHandle, content
    Close lngFileHandle
End Function

