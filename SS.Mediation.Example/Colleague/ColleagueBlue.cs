using System;
using SS.Mediation.Example.Interfaces;

namespace SS.Mediation.Example.Colleague
{
    /* note:
        even though ColleagueRed and ColleagueBlue look identical, they do not need to be
        parented by an abstract class. In practice, ColleagueRed and ColleagueBlue could be
        disparent classes from differring domains that need to share information or share the 
        notifications of events from their domains. All that is needed is to handle the
        IMediatedObject implementation, which will require maintaining the common Mediator object
        as a property. The interface IExternalSendMethod is provided to separate what the
        Mediator pattern needs and what this example requires.
    */
    public sealed class ColleagueBlue : IMediatedObject, IExternalSendMethod
    {
        // private prop
        // need to maintain the mediator object so we can call it to send information
        // to the colleague
        private IMediator Mediator { get; set; }

        /// <summary>
        /// default constructor
        /// </summary>
        /// <param name="initMediator">IMediator:: the go-between</param>
        public ColleagueBlue(IMediator initMediator)
        {
            Mediator = initMediator;
            // setting the colleague at this point requires a bit of agreement with the
            // instantiation of the other colleague. 
            initMediator.SetColleague1(this);
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

        /// <summary>
        /// this sets the Mediator property.
        /// </summary>
        /// <param name="initMediator">IMediator:: the mediator object</param>
        /// <exception cref="ArgumentNullException" >thrown when the Mediator is null.</exception>
        /// <remarks>the Mediator object calls this method upon instantiation.</remarks>
        public void SetMediator(IMediator initMediator)
        {
            Mediator = initMediator ?? throw new ArgumentNullException(nameof(initMediator));
        }
        #endregion

        #region IExternalSendMethod
        /// <summary>
        /// Sends a message to the colleague via the Mediator.
        /// </summary>
        /// <param name="initMessage">string:: the message to send.</param>
        public void Send(string initMessage)
        {
            if (Mediator == null) throw new InvalidOperationException("the value of Mediator was never set.");
            Mediator.Notify(this, initMessage);
        }
        #endregion
    }
}
