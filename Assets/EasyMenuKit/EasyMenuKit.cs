/*
 * EasyMenuKit v0.1b
 * File Role: Common system file
 * 
 * Author: Goryunov Vyacheslav
 * Mail: microslav@yandex.ru
 * MaxCinema Corp
 */

using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

//[ExecuteInEditMode]
public class EasyMenuKit : MonoBehaviour {

	[System.Serializable]
	public class MenuObjectTransform
	{
		public enum m_TypePositionOn
		{
			m_TopLeft,
			m_TopRight,
			m_Center,
			m_BottomLeft,
			m_BottomRight
		};

		public m_TypePositionOn  m_PositionOn;

		public float m_X;
		public float m_Y;

		public float m_W;
		public float m_H;
	}

	[System.Serializable]
	public class MenuTexture
	{
		public Texture2D m_Texture;
		public ScaleMode m_ScaleMode;
	}

	[System.Serializable]
	public class MenuLabel
	{
		public string m_Text;
	}

	[System.Serializable]
	public class MenuButton
	{
		public string m_Text;

		public enum m_BtnAction 
		{
			m_LoadLevel,
			m_OpenPage,
			m_SendMessage
		};

		public m_BtnAction m_Action;

		public string m_LevelName = "";

		public MenuPage m_Page;
		public string m_PageName;

		public GameObject m_Target;
		public string m_FunctionName = "";
	}

	[System.Serializable]
	public class MenuObject
	{
		public enum m_ObjType
		{
			m_Button,
			m_Label,
			m_Texture
		};

		public string m_Name = "";

		public MenuObjectTransform m_Tansform = new MenuObjectTransform();

		public int m_Z_index = 0;

		public m_ObjType m_Type;

		public bool m_UseCustomStyle;
		public GUIStyle m_Style;

		public MenuButton m_Button;
		public MenuLabel m_Label;
		public MenuTexture m_Texture;

		// --- Editor Variable ---
		#if UNITY_EDITOR
		public bool ed_foldout = false;
		public bool ed_st_foldout = true;

		// --- Style foldout ---
		public bool fs_normal = false;
		public bool fs_hover = false;
		public bool fs_active = false;
		public bool fs_focused = false;
		public bool fs_onnormal = false;
		public bool fs_onhover = false;
		public bool fs_onactive = false;
		public bool fs_onfocused = false;

		public bool fs_border = false;
		public bool fs_margin = false;
		public bool fs_padding = false;
		public bool fs_overflow = false;

		public float fs_oX = 0.0f;
		public float fs_oY = 0.0f;

		// --- Style foldout ---
		#endif
		// --- Editor Variable ---
	}

	[System.Serializable]
	public class MenuPage
	{
		public string m_Name = "Page";

		public bool m_useGlobalSkin = false;
		public GUISkin m_globalSkin;

		public List<MenuObject> m_Objects = new List<MenuObject>();

		// --- Editor Variable ---
		#if UNITY_EDITOR
		public bool ed_foldout = false;
		public MenuObject c_object = new EasyMenuKit.MenuObject();
		#endif
		// --- Editor Variable ---

		public MenuPage()
		{
			
		}

		public MenuPage(string name)
		{
			m_Name = name;
		}
	}
	
	public bool EditMode = false;

	public List<MenuPage> m_AllPages = new List<MenuPage>();

	public MenuPage currentPage;


	void OpenPage(string name)
	{
		foreach (MenuPage page in m_AllPages) 
		{
			if(page.m_Name == name)
				currentPage = page;
		}
	}

	void RenderPage(MenuPage m_Page)
	{
		if (m_Page.m_useGlobalSkin)
						GUI.skin = m_Page.m_globalSkin;

		for (int i = (m_Page.m_Objects.Count - 1); i >= 0; i--) 
		{
			MenuObject obj = m_Page.m_Objects[i];

			GUI.depth = obj.m_Z_index;

			Rect trans = new Rect();
			
			trans.width = obj.m_Tansform.m_W;
			trans.height = obj.m_Tansform.m_H;
			
			switch(obj.m_Tansform.m_PositionOn)
			{
			case MenuObjectTransform.m_TypePositionOn.m_TopLeft:
				trans.x = trans.y = 0;
				
				trans.x += obj.m_Tansform.m_X;
				trans.y += obj.m_Tansform.m_Y;
				
				break;
				
			case MenuObjectTransform.m_TypePositionOn.m_TopRight:
				trans.x = Screen.width - trans.width;
				trans.y = 0;
				
				trans.x -= obj.m_Tansform.m_X;
				trans.y += obj.m_Tansform.m_Y;
				
				break;
				
			case MenuObjectTransform.m_TypePositionOn.m_BottomLeft:
				trans.x = 0;
				trans.y = Screen.height - trans.height;
				
				trans.x += obj.m_Tansform.m_X;
				trans.y -= obj.m_Tansform.m_Y;
				
				break;
				
			case MenuObjectTransform.m_TypePositionOn.m_BottomRight:
				trans.x = Screen.width - trans.width;
				trans.y = Screen.height - trans.height;
				
				trans.x -= obj.m_Tansform.m_X;
				trans.y -= obj.m_Tansform.m_Y;
				
				break;
				
			case MenuObjectTransform.m_TypePositionOn.m_Center:
				trans.x = (Screen.width / 2) - (obj.m_Tansform.m_W / 2);
				trans.y = (Screen.height / 2) - (obj.m_Tansform.m_H / 2);
				
				trans.x += obj.m_Tansform.m_X;
				trans.y -= obj.m_Tansform.m_Y;
				
				break;
			}
			
			
			
			switch(obj.m_Type)
			{
			case MenuObject.m_ObjType.m_Label:
				GUI.Label(trans, obj.m_Label.m_Text, obj.m_UseCustomStyle ? obj.m_Style : GUI.skin.label);
				break;
				
			case MenuObject.m_ObjType.m_Texture:
				GUI.DrawTexture(trans, obj.m_Texture.m_Texture, obj.m_Texture.m_ScaleMode);
				break;
				
			case MenuObject.m_ObjType.m_Button:
				if(GUI.Button(trans, obj.m_Button.m_Text, obj.m_UseCustomStyle ? obj.m_Style : GUI.skin.button))
				{
					switch(obj.m_Button.m_Action)
					{
					case MenuButton.m_BtnAction.m_LoadLevel:
						Application.LoadLevel(obj.m_Button.m_LevelName);
						break;
						
					case MenuButton.m_BtnAction.m_SendMessage:
						obj.m_Button.m_Target.SendMessage(obj.m_Button.m_FunctionName);
						break;
						
					case MenuButton.m_BtnAction.m_OpenPage:
						OpenPage(obj.m_Button.m_PageName);
						break;
					}
				}
				break;
			}
		}
	}

	void Awake()
	{
		if (m_AllPages [m_AllPages.Count - 1] != null)
			currentPage = m_AllPages [m_AllPages.Count - 1];
		else
			currentPage = new MenuPage ();
	}

	void OnGUI()
	{
		if (currentPage == null)
			if (m_AllPages [m_AllPages.Count - 1] != null) 
				currentPage = m_AllPages [m_AllPages.Count - 1];
			else
				currentPage = new MenuPage ();

		//if(Application.isEditor && EditMode)
			RenderPage (currentPage);
	}

	void OnApplicationQuit()
	{
		if(m_AllPages[m_AllPages.Count - 1] != null) currentPage = m_AllPages[m_AllPages.Count - 1];
	}
}
