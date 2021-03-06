using System;
using System.Net;
using Raven.Client.Connection;

namespace Raven.Client.Document.OAuth
{
	public abstract class AbstractAuthenticator
	{
		protected string CurrentOauthToken;

		public virtual void ConfigureRequest(object sender, WebRequestEventArgs e)
		{
			if (string.IsNullOrEmpty(CurrentOauthToken))
				return;

			SetHeader(e.Request.Headers, "Authorization", CurrentOauthToken);
		}

		protected static void SetHeader(WebHeaderCollection headers, string key, string value)
		{
			try
			{
				headers[key] = value;
			}
			catch (Exception e)
			{
				throw new InvalidOperationException("Could not set '" + key + "' = '" + value + "'", e);
			}
		}
	}
}