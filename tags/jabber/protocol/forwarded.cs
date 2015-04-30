﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="forwarded.cs">
//   
// </copyright>
// <summary>
//   The namespace.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

using System.Xml.Linq;
using XMPP.Registries;
using XMPP.Tags.Jabber.Client;
using XMPP.Tags.Xmpp.Delay;

namespace XMPP.Tags.Jabber.Protocol.Forwarded
{
    public class Namespace
    {
        public const string XmlNamespace = "urn:xmpp:forward:0";

        public static readonly XName Forwarded = XName.Get("forwarded", XmlNamespace);
    }

    [XmppTag(typeof(Namespace), typeof(Forwarded))]
    public class Forwarded : Tag
    {
        public Forwarded() : base(Namespace.Forwarded)
        {
        }

        public Forwarded(XElement other) : base(other)
        {
        }

        public Message MessageElement
        {
            get { return Element<Message>(Client.Namespace.Message); }
        }

        public Delay Delay
        {
            get { return Element<Delay>(XMPP.Tags.Xmpp.Delay.Namespace.Delay); }
        }

        public Presence PresenceElement
        {
            get { return Element<Presence>(Client.Namespace.Presence); }
        }

        public Client.Iq IqElement
        {
            get { return Element<Client.Iq>(Client.Namespace.Iq); }
        }
    }
}

/*
<?xml version='1.0' encoding='UTF-8'?>

<xs:schema
    xmlns:xs='http://www.w3.org/2001/XMLSchema'
    targetNamespace='urn:xmpp:forward:0'
    xmlns='urn:xmpp:forward:0'
    elementFormDefault='qualified'>

  <xs:annotation>
    <xs:documentation>
      The protocol documented by this schema is defined in
      XEP-0297: http://www.xmpp.org/extensions/xep-0297.html
    </xs:documentation>
  </xs:annotation>

  <xs:import namespace='jabber:client'
             schemaLocation='http://xmpp.org/schemas/jabber-client.xsd'/>
  <xs:import namespace='jabber:server'
             schemaLocation='http://xmpp.org/schemas/jabber-server.xsd'/>
  <xs:import namespace='urn:xmpp:delay'
             schemaLocation='http://xmpp.org/schemas/delay.xsd'/>

  <xs:element name='forwarded'>
    <xs:complexType>
      <xs:sequence xmlns:delay='urn:xmpp:delay'
                   xmlns:client='jabber:client'
                   xmlns:server='jabber:server'>
        <xs:element ref='delay:delay' minOccurs='0' maxOccurs='1' />
        <xs:choice minOccurs='0' maxOccurs='1'>
          <xs:choice>
            <xs:element ref='client:message'/>
            <xs:element ref='client:presence'/>
            <xs:element ref='client:iq'/>
          </xs:choice>
          <xs:choice>
            <xs:element ref='server:message'/>
            <xs:element ref='server:presence'/>
            <xs:element ref='server:iq'/>
          </xs:choice>
        </xs:choice>
      </xs:sequence>
    </xs:complexType>
  </xs:element>

</xs:schema>
*/