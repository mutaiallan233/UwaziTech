namespace UwaziTech.Core.Models;


public class ApiResponse 
{
    public string StatusCode { get; set; }
    public string StatusMessage { get; set; }
    public bool Successful => StatusCode == ResponseCode.OK;
}

public class ApiResponse<T> : ApiResponse
{
    public T? ResponseObject { get; set; }
}

public static class ResponseCode
{
    public const string OK = "00";
    public const string FAILED = "99";
    public const string INVALIDREQUEST = "INVALID REQUEST";
}

public static class StatusMessage
{
    public const string DB_ADD_SUCCESSFUL = "Details added to DB successfully";
    public const string DB_ADD_UNSUCCESSFUL = "An error occured adding Details to DB";

    public const string RECORD_FOUND = "Record retrieved successfully";
    public const string RECORD_MISSING = "Referenced record Not Found";

    public const string PENDING_IMPLEMENTATION = "Api implementation in progress";

    public const string ERROR = "An error occured";

    public const string UPDATE_NOT_NEEDED = "No changes detected. Nothing to update here";
}
