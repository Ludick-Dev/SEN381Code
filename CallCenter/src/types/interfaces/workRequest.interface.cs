namespace CallCenter.Types
{
    interface IWorkRequest
    {
        int requestID { get; set; }
        int clientID { get; set; }
        int serviceTypeID { get; set; }
        int priorityID { get; set; }
        string status { get; set; }

    }
}