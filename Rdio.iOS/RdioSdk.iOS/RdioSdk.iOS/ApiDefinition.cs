using System;
using System.Drawing;
using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace RdioSdk.iOS
{
	[BaseType (typeof (NSObject), Name = "RDAPIRequestDelegate")]
	[Model]
	[Protocol]
	interface RequestDelegateHandlers {

		[Export ("rdioRequest:didLoadData:")]
		void DidLoadData (Request request, NSObject data);

		[Export ("rdioRequest:didLoadData:")]
		void DidFail (Request request, NSError error);
	}

	[BaseType (typeof (NSObject), Name = "RDAPIRequestDelegate")]
	interface RequestDelegate : RequestDelegateHandlers {

		[Static]
		[Export ("delegateToTarget:loadedAction:failedAction:")]
		NSObject DelegateToTarget (NSObject target, Selector loadedAction, Selector failedAction);

		[Export ("initWithTarget:action:")]
		IntPtr Constructor (NSObject target, Selector action);

		[Export ("initWithTarget:loadedAction:failedAction:")]
		IntPtr Constructor (NSObject target, Selector loadedAction, Selector failedAction);

		[Export ("userInfo", ArgumentSemantic.Retain)] [NullAllowed]
		NSObject UserInfo { get; set; }
	}

	[BaseType (typeof (NSObject), Name = "RDAPIRequest")]
	interface Request {

		[Export ("cancel")]
		void Cancel ();

		[Export ("parameters")]
		NSDictionary Parameters { get; }
	}

	[BaseType (typeof (NSObject))]
	interface Rdio {

		[Export ("initWithConsumerKey:andSecret:delegate:")]
		IntPtr Constructor (string key, string secret, [NullAllowed] RdioDelegate aDelegate);

		[Export ("authorizeFromController:")]
		void AuthorizeFromController (UIViewController currentController);

		[Export ("authorizeUsingAccessToken:")]
		void AuthorizeUsingAccessToken (string accessToken);

		[Export ("authorizeUsingAccessToken:fromController:")] 
		[Obsolete ("You should use 'AuthorizeUsingAccessToken (string accessToken)` in new apps, and explicitly call `AuthorizeFromController` on failure if that's your desired behavior")]
		void AuthorizeUsingAccessToken (string accessToken, [NullAllowed] UIViewController currentController);

		[Export ("logout")]
		void Logout ();

		[Export ("callAPIMethod:withParameters:delegate:")]
		Request CallApiMethod (string method, NSDictionary parameters, RequestDelegateHandlers aDelegate);

		[Wrap ("WeakDelegate")][NullAllowed]
		RdioDelegate Delegate { get; set; }

		[Export ("delegate", ArgumentSemantic.Assign)][NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Export ("user")]
		NSDictionary User { get; }

		[Export ("player")]
		Player RdioPlayer { get; }
	}

	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface RdioDelegate {

		[Export ("rdioDidAuthorizeUser:withAccessToken:")]
		void DidAuthorizeUser (NSDictionary user, string accessToken);

		[Export ("rdioAuthorizationFailed:")]
		void AuthorizationFailed (string error);

		[Export ("rdioAuthorizationCancelled")]
		void AuthorizationCancelled ();

		[Export ("rdioDidLogout")]
		void DidLogout ();
	}

	[BaseType (typeof (NSObject), Name = "RDPlayerDelegate")]
	[Model]
	[Protocol]
	interface PlayerDelegate {

		[Abstract]
		[Export ("rdioIsPlayingElsewhere")]
		bool IsPlayingElsewhere ();

		[Abstract]
		[Export ("rdioPlayerChangedFromState:toState:")]
		void PlayerChanged (PlayerState oldState, PlayerState newState);

		[Export ("rdioPlayerQueueDidChange")]
		void PlayerQueueDidChange ();

		[Export ("rdioPlayerCouldNotStreamTrack:")]
		bool PlayerCouldNotStreamTrack (string trackKey);
	}

	[BaseType (typeof (NSObject), Name = "RDPlayer")]
	interface Player {

		[Export ("playSource:")]
		void PlaySource (string sourceKey);

		[Export ("playSources:")]
		void PlaySources (string [] sourceKeys);

		[Export ("next")]
		void Next ();

		[Export ("previous")]
		void Previous ();

		[Export ("skipToIndex:")]
		bool SkipToIndex (uint index);

		[Export ("play")]
		void Play ();

		[Export ("playAndRestart:")]
		void PlayAndRestart (bool shouldRestart);

		[Export ("togglePause")]
		void TogglePause ();

		[Export ("stop")]
		void Stop ();

		[Export ("seekToPosition:")]
		void SeekToPosition (double positionInSeconds);

		[Export ("queueSource:")]
		void QueueSource (string sourceKey);

		[Export ("queueSources:")]
		void QueueSources (string [] sourceKey);

		[Export ("updateQueue:withCurrentTrackIndex:")]
		bool UpdateQueue (string [] sourceKeys, int index);

		[Export ("resetQueue")]
		void ResetQueue ();

		[Export ("state")]
		PlayerState State { get; }

		[Export ("position")]
		double Position { get; }

		[Export ("duration")]
		double Duration { get; }

		[Export ("currentTrack")]
		string CurrentTrack { get; }

		[Export ("currentTrackIndex")]
		int CurrentTrackIndex { get; }

		[Export ("trackKeys")]
		string [] TrackKeys { get; }

		[Wrap ("WeakDelegate")][NullAllowed]
		PlayerDelegate Delegate { get; set; }

		[Export ("delegate", ArgumentSemantic.Assign)][NullAllowed]
		NSObject WeakDelegate { get; set; }
	}
}