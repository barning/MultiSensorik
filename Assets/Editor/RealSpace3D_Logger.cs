// *******************************************************************************
// * Copyright (c) 2012,2013,2014 VisiSonics, Inc.
// * This software is the proprietary information of VisiSonics, Inc.
// * All Rights Reserved.
// *
// * © VisiSonics Corporation, 2013-2014
// * VisiSonics Confidential Information
// * Source code provided under the terms of the Software License Agreement 
// * between VisiSonics Corporation and Oculus VR, LLC dated 09/10/2014
// ********************************************************************************
// 
// Original Author: R E Haxton
// $Author$
// $Date$
// $LastChangedDate$
// $Revision$
//
// Purpose:
//
// Comments: 
// 

using UnityEngine;
using UnityEditor;
using RealSpace3D;

public class RealSpace3D_Logger : MonoBehaviour
{
	[MenuItem("Help/RealSpace3D/Development Log")]
	/// <summary>
	/// Init this instance. Display the logging dialog and handle on/off.
	/// </summary>
	private static void Init()
	{
		bool bNotify = false;
		string sNotice = "Turn on RealSpace3D internal logging?";

		RealSpace3D_AudioListener theObject = GameObject.FindObjectOfType(typeof(RealSpace3D_AudioListener)) as RealSpace3D_AudioListener;

		if(EditorUtility.DisplayDialog("RealSpace3D Copyright 2011 - 2014", sNotice, "Yes", "No")) 
		{
			theObject.SetLoggingOn(1);
			bNotify = true;
		} 

		else
		{
			theObject.SetLoggingOn (0);
		}

		if(bNotify) 
		{
			sNotice = "The logfile can be located at: "; 

#if UNITY_IPHONE

			Debug.Log("Mobile build - iOS");
			sNotice += "/vsRealSpace3d/DontTouch/rs.log";

#elif UNITY_ANDROID

			Debug.Log("Mobile build - Android");


			sNotice += "/vsRealSpace3d/DontTouch/rs.log";
#else
			Debug.Log("Platform build");
			sNotice += Application.streamingAssetsPath + "/vsRealSpace3d/DontTouch/rs.log";

#endif
			EditorUtility.DisplayDialog("RealSpace3D Copyright 2011 - 2014", sNotice, "Ok");

		}
	}	
}

