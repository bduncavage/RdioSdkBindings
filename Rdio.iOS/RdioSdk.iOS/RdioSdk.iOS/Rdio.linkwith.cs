using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("Rdio.a", LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Simulator, Frameworks = "CoreGraphics CFNetwork SystemConfiguration AudioToolbox Security", ForceLoad = true)]
