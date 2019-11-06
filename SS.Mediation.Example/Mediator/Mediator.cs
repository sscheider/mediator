using System;
using SS.Mediation.Example.Interfaces;

namespace SS.Mediation.Example.Mediator
{
    /*
        after creating the mediator with a constructor signature of 
        Mediator(IMediatedObject, IMediatedObject), I prefer the Mediator() constructor, using
        SetColleague1() and SetColleague2() methods. The reason is because I see a more general 
        case that you would create the Mediator at a higher level when instantiating objects,
        then pass that object down to the lower level objects that need a bridge of 
        intercommunication.
    */
    public sealed class Mediator : IMediator
    {
        // private props
        private IMediatedObject Colleague1 { get; set; }
        private IMediatedObject Colleague2 { get; set; }

        /// <summary>
        /// sets the first colleague.
        /// </summary>
        /// <param name="initColleague">IMediatedObject:: the first Colleague</param>
        /// <exception cref="ArgumentNullException" >thrown when initColleague is null</exception>
        /// <exception cref="InvalidOperationException" >thrown when Colleague1 is already assigned</exception>
        public void SetColleague1(IMediatedObject initColleague)
        {
            if (Colleague1 != null) throw new InvalidOperationException($"{nameof(Colleague1)} is already assigned.");
            Colleague1 = initColleague ?? throw new ArgumentNullException(nameof(initColleague));
        }

        /// <summary>
        /// sets the second colleague.
        /// </summary>
        /// <param name="initColleague">IMediatedObject:: the second Colleague</param>
        /// <exception cref="ArgumentNullException" >thrown when initColleague is null</exception>
        /// <exception cref="InvalidOperationException" >thrown when Colleague2 is already assigned</exception>
        public void SetColleague2(IMediatedObject initColleague)
        {
            if (Colleague2 != null) throw new InvalidOperationException($"{nameof(Colleague2)} is already assigned.");
            Colleague2 = initColleague ?? throw new ArgumentNullException(nameof(initColleague));
        }

        /// <summary>
        /// send a message to the colleague
        /// </summary>
        /// <param name="sender">IColleague:: the sender's object</param>
        /// <param name="initMessage">string:: the message</param>
        /// <exception cref="ArgumentNullException">thrown when sender is null.</exception>
        /// <exception cref="ArgumentException">thrown when sender is not one of the two mediated object</exception>
        public void Notify(IMediatedObject sender, string initMessage)
        {
            if (sender == null) throw new ArgumentNullException(nameof(sender));

            if(sender == Colleague1)
            {
                Colleague2.ActOnNotify(initMessage);
            }
            else if (sender == Colleague2)
            {
                Colleague1.ActOnNotify(initMessage);
            }
            else
            {
                throw new ArgumentException("sender is not a mediated object. ");
            }
        }
    }
}
