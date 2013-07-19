using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.Dialog;

using RdioSdk.iOS;

namespace RdioiOSSample
{
	public partial class DVCMenu : DialogViewController
	{
		public DVCMenu () : base (UITableViewStyle.Grouped, null)
		{
			Root = new RootElement ("Rdio Sample") {
				new Section (){
					new StringElement ("Play!!", Play) { Alignment = UITextAlignment.Center }
				}
			};
		}

		// In order to run this short sample you will need an Rdio Key and Shared Secret from
		// http://developer.rdio.com

		Rdio rdio;
		void Play ()
		{
			if (rdio == null) 
				rdio = new Rdio ("Your_Key", "Your_Shared_Secret", null);

			rdio.RdioPlayer.PlaySource ("t2742133");
		}
	}
}
