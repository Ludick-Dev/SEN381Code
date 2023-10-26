namespace CallCenter.Types
{
    interface IWorkRequest
    {
        Guid requestID { get; set; }
        Guid clientID { get; set; }
        Guid serviceTypeID { get; set; }
        Guid priorityID { get; set; }
        string status { get; set; }

    }
}