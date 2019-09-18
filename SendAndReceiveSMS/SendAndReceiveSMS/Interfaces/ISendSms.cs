namespace SendAndReceiveSMS.Interfaces
{
    public interface ISendSms
    {
        void Send(string address, string message);
    }
}