using System;

namespace SS.Mediation.Example.Interfaces
{
    // mediator only involves communication between two colleagues
    public interface IMediator
    {
        /// <summary>
        /// sets the first colleague.
        /// </summary>
        /// <param name="initColleague">IMediatedObject:: the first Colleague</param>
        /// <exception cref="ArgumentNullException" >thrown when initColleague is null</exception>
        void SetColleague1(IMediatedObject initColleague);

        /// <summary>
        /// sets the second colleague.
        /// </summary>
        /// <param name="initColleague">IMediatedObject:: the second Colleague</param>
        /// <exception cref="ArgumentNullException" >thrown when initColleague is null</exception>
        void SetColleague2(IMediatedObject initColleague);

        /// <summary>
        /// send a message to the colleague
        /// </summary>
        /// <param name="sender">IColleague:: the sender's object</param>
        /// <param name="initMessage">string:: the message</param>
        /// <exception cref="ArgumentNullException">thrown when sender is null.</exception>
        /// <exception cref="ArgumentException">thrown when sender is not one of the two mediated object</exception>
        void Notify(IMediatedObject sender, string initMessage);
    }
}
