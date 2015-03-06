//
// WSFederationHttpSecurityElement.cs
//
// Author:
//	Atsushi Enomoto <atsushi@ximian.com>
//
// Copyright (C) 2006 Novell, Inc.  http://www.novell.com
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Net;
using System.Net.Security;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.IdentityModel.Claims;
using System.IdentityModel.Policy;
using System.IdentityModel.Tokens;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Diagnostics;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.MsmqIntegration;
using System.ServiceModel.PeerResolvers;
using System.ServiceModel.Security;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;

namespace System.ServiceModel.Configuration
{
	public sealed partial class WSFederationHttpSecurityElement
		 : ConfigurationElement
	{
		// Static Fields
		static ConfigurationPropertyCollection properties;
		static ConfigurationProperty message;
		static ConfigurationProperty mode;

		static WSFederationHttpSecurityElement ()
		{
			properties = new ConfigurationPropertyCollection ();
			message = new ConfigurationProperty ("message",
				typeof (FederatedMessageSecurityOverHttpElement), null, null/* FIXME: get converter for FederatedMessageSecurityOverHttpElement*/, null,
				ConfigurationPropertyOptions.None);

			mode = new ConfigurationProperty ("mode",
				typeof (WSFederationHttpSecurityMode), "Message", null/* FIXME: get converter for WSFederationHttpSecurityMode*/, null,
				ConfigurationPropertyOptions.None);

			properties.Add (message);
			properties.Add (mode);
		}

		public WSFederationHttpSecurityElement ()
		{
		}


		// Properties

		[ConfigurationProperty ("message",
			 Options = ConfigurationPropertyOptions.None)]
		public FederatedMessageSecurityOverHttpElement Message {
			get { return (FederatedMessageSecurityOverHttpElement) base [message]; }
		}

		[ConfigurationProperty ("mode",
			 DefaultValue = "Message",
			 Options = ConfigurationPropertyOptions.None)]
		public WSFederationHttpSecurityMode Mode {
			get { return (WSFederationHttpSecurityMode) base [mode]; }
			set { base [mode] = value; }
		}

		protected override ConfigurationPropertyCollection Properties {
			get { return properties; }
		}

		internal void ApplyConfiguration (WSFederationHttpSecurity security)
		{
			security.Mode = Mode;
			Message.ApplyConfiguration (security.Message);
		}
	}

}