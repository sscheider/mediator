namespace SS.Mediation.Example.Interfaces
{
    public interface IMediatedObject
    {
        /// <summary>
        /// this method handles calls from the Mediator.
        /// </summary>
        /// <param name="initMessage">string:: the passed message</param>
        /// <remarks>In actual practice, any number of methods could be shared.</remarks>
        void ActOnNotify(string initMessage);
    }
}
