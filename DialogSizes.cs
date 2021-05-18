﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HarmonyLib;
using Game.UI.Session.MoveIns;
using Game.Util;
using UnityEngine;

namespace BetterPlacement
{
	[HarmonyPatch(typeof(MoveInServicesDialog), nameof(MoveInServicesDialog.InitializeGameObject))]
	public static class LargerMoveInServicesDialog
	{
		//This seems to be a static value inside Unity resource files so I'm going to statically increase it.
		public static void Postfix(GameObject ____go)
		{
			//____go is actually a window-sized black cover, within is a panel:
			var windowGO = UIUtil.GetChild(____go, "Panel");
			var tr = windowGO.GetComponent<RectTransform>();
			 UIUtil.ForceRectSizeHack(windowGO, tr.rect.width, 950);
		}
	}
}