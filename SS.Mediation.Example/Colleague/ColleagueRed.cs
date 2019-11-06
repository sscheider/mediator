using System;
using SS.Mediation.Example.Interfaces;

namespace SS.Mediation.Example.Colleague
{
    /* note:
        even though ColleagueRed and ColleagueBlue look identical, they do not need to be
        parented by an abstract class. In practice, ColleagueRed and ColleagueBlue could be
        disparate classes from differring domains that need to share information or share the 
        notifications of events from their domains. All that is needed is to handle the
        IMediatedObject implementation, which will require maintaining the common Mediator object
        as a property. The interface IExternalSendMethod is provided to separate what the
        Mediator pattern needs and what this example requires.
    */
    public sealed class ColleagueRed : IMediatedObject, IExternalSendMethod
    {
        // private prop
        // need to maintain the mediator object so we can call it to send information
        // to the colleague
        private IMediator Mediator { get; set; }

        /// <summary>
        /// default constructor
        /// </summary>
        /// <param name="initMediator">IMediator:: the go-between</param>
        public ColleagueRed(IMediator initMediator)
        {
            Mediator = initMediator;
            // setting the colleague at this point requires a bit of agreement with the
            // instantiation of the other colleague. 
            initMediator.SetColleague2(this);
        }

        #region IMediatedObject
        /// <summary>
        /// this method handles calls from the Mediator.
        /// </summary>
        /// <param name="initMessage">string:: the passed message</param>
        /// <remarks>In actual practice, any number of methods could be shared.</remarks>
        public void ActOnNotify(string initMessage)
        {
            Console.WriteLine($"{this.GetType().Name} received: {initMessage}");
        }

        #endregion

        #region IExternalSendMethod
        /// <summary>
        /// Sends a message to the colleague via the Mediator.
        /// </summary>
        /// <param name="initMessage">string:: the message to send.</param>
        /// <exception cref="InvalidOperationException">thrown when Mediator is null.</exception>
        public void Send(string initMessage)
        {
            if (Mediator == null) throw new InvalidOperationException("the value of Mediator was never set.");
            Mediator.Notify(this, initMessage);
        }
        #endregion
    }
}
