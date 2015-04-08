// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="SessionState.cs">
//   
// </copyright>
// <summary>
//   The session state.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

using XMPP.Common;
using XMPP.Extensions;
using XMPP.Tags;
using XMPP.Tags.Jabber.Client;
using XMPP.Tags.XmppSession;
using XMPP.�ommon;

namespace XMPP.States
{
    public class SessionState : IState
    {
        public SessionState(Manager manager)
            : base(manager)
        {
        }

        public override void Execute(Tag data = null)
        {
            if (data == null)
            {
                var iq = new Iq
                {
                    IdAttr = Tag.NextId(),
                    FromAttr = Manager.Settings.Id,
                    ToAttr = Manager.Settings.Id.Server,
                    TypeAttr = Iq.TypeEnum.set
                };

                iq.Add(new Session());

                Manager.Connection.Send(iq);
            }
            else
            {
                if (Manager.Transport == Transport.Bosh)
                {
                    (Manager.Connection as Bosh).StartPolling();
                }

                Manager.State = new RunningState(Manager);
            }
        }
    }
}