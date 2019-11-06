namespace SS.Mediation.Example.Interfaces
{
    public interface IExternalSendMethod
    {
        /// <summary>
        /// Sends a message to the colleague via the Mediator.
        /// </summary>
        /// <param name="initMessage">string:: the message to send.</param>
        void Send(string initMessage);
    }
}
