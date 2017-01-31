/*
 * EasyMenuKit Editor v1.003b
 * File Role: Editor for Easy Menu Kit
 * 
 * Author: Goryunov Vyacheslav
 * Mail: microslav@yandex.ru
 * MaxCinema Corp
 */

#pragma warning disable
using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;

[CustomEditor(typeof(EasyMenuKit))]
public class EasyMenuKitEditor : Editor {

	private string newPageName = "";
	
	EasyMenuKit menu;

	void CreatePage(ref string name)
	{
		EasyMenuKit.MenuPage page = new EasyMenuKit.MenuPage(name);
		
		menu.m_AllPages.Insert(0, page);
		
		if(menu.m_AllPages[menu.m_AllPages.Count - 1] == page)
			menu.currentPage = menu.m_AllPages[0];

		name = "";
	}

	public override void OnInspectorGUI()
	{
		menu = target as EasyMenuKit;

		EditorGUILayout.BeginVertical (GUI.skin.box);
		EditorGUILayout.LabelField ("Pages");

		EditorGUILayout.BeginVertical (GUI.skin.box);

		for (int i = (menu.m_AllPages.Count - 1); i >= 0; i--) 
		{
			RenderPageEditor (menu.m_AllPages[i]);
		}

		EditorGUILayout.Space();
		
		EditorGUILayout.BeginVertical (GUI.skin.box);
		EditorGUILayout.LabelField ("New page name");

		newPageName = EditorGUILayout.TextField (newPageName);

		GUI.backgroundColor = Color.green;
		if (GUILayout.Button ("Create Page")) 
		{
			newPageName = newPageName.Trim();
			if(newPageName == "")
				Debug.LogError("You enter a blank page name!");
			else if(menu.m_AllPages.Count == 0)
				CreatePage(ref newPageName);
			else foreach(EasyMenuKit.MenuPage m_Page in menu.m_AllPages)
			{
				if(m_Page.m_Name == newPageName)
				{
					Debug.LogError("This page name already exists!");
					break;
				}
				else
				{
					CreatePage(ref newPageName);
					break;
				}
			}
		}
		GUI.backgroundColor = Color.gray;
		EditorGUILayout.EndVertical ();
		EditorGUILayout.EndVertical ();
		EditorGUILayout.EndVertical ();
	}

	void OnInspectorUpdate()
	{
		this.Repaint ();
	}

	void RenderPageEditor(EasyMenuKit.MenuPage page)
	{
		page.ed_foldout = EditorGUILayout.Foldout (page.ed_foldout, page.m_Name);

		if (page.ed_foldout) {
						EditorGUILayout.BeginVertical (GUI.skin.box);

						EditorGUILayout.BeginVertical (GUI.skin.box);
						page.m_Name = EditorGUILayout.TextField ("Name", page.m_Name);
						page.m_useGlobalSkin = EditorGUILayout.Toggle("Use Global skin", page.m_useGlobalSkin);
						if(page.m_useGlobalSkin)
							page.m_globalSkin = (GUISkin)EditorGUILayout.ObjectField("Global Skin", page.m_globalSkin, typeof(GUISkin));
						EditorGUILayout.EndVertical ();

						EditorGUILayout.Separator ();

						EditorGUILayout.BeginVertical (GUI.skin.box);
						EditorGUILayout.LabelField ("Objects:");
						
			if (page.m_Objects.Count != 0) {
				for (int i = (page.m_Objects.Count - 1); i >= 0; i--) {
					EasyMenuKit.MenuObject obj = page.m_Objects[i];
					obj.ed_foldout = EditorGUILayout.Foldout (obj.ed_foldout, obj.m_Name);
					if (obj.ed_foldout) {
						EditorGUILayout.BeginHorizontal ();
						
						EditorGUILayout.LabelField ("Name:");
						obj.m_Name = EditorGUILayout.TextField (obj.m_Name);
						
						EditorGUILayout.EndHorizontal ();

						EditorGUILayout.Separator ();
						
						EditorGUILayout.LabelField ("Depth");
						EditorGUILayout.BeginVertical (GUI.skin.box);
						obj.m_Z_index = EditorGUILayout.IntField("Z-index", obj.m_Z_index);
						EditorGUILayout.EndVertical ();

						EditorGUILayout.Separator ();
						EditorGUILayout.LabelField ("Position");
						
						EditorGUILayout.BeginVertical (GUI.skin.box);
						obj.m_Tansform.m_PositionOn = (EasyMenuKit.MenuObjectTransform.m_TypePositionOn)EditorGUILayout.EnumPopup ("Align", obj.m_Tansform.m_PositionOn);
						
						obj.m_Tansform.m_X = EditorGUILayout.FloatField ("X", obj.m_Tansform.m_X);
						
						obj.m_Tansform.m_Y = EditorGUILayout.FloatField ("Y", obj.m_Tansform.m_Y);
						EditorGUILayout.EndVertical ();
						
						EditorGUILayout.Separator ();

						EditorGUILayout.LabelField ("Scale");
						
						EditorGUILayout.BeginVertical (GUI.skin.box);
						obj.m_Tansform.m_W = EditorGUILayout.FloatField ("Width", obj.m_Tansform.m_W);
						
						obj.m_Tansform.m_H = EditorGUILayout.FloatField ("Height", obj.m_Tansform.m_H);
						
						if (obj.m_Type == EasyMenuKit.MenuObject.m_ObjType.m_Texture) {
							obj.m_Texture.m_ScaleMode = (ScaleMode)EditorGUILayout.EnumPopup ("Scale Mode", obj.m_Texture.m_ScaleMode);
						}
						EditorGUILayout.EndVertical ();

						EditorGUILayout.Separator ();

						EditorGUILayout.LabelField ("Style");

						EditorGUILayout.BeginVertical (GUI.skin.box);

						obj.m_UseCustomStyle = EditorGUILayout.Toggle("Use Custom Style", obj.m_UseCustomStyle);

						if(obj.m_UseCustomStyle)
						{
							obj.ed_st_foldout = EditorGUILayout.Foldout(obj.ed_st_foldout, "Style");

							if(obj.ed_st_foldout)
							{
								EditorGUILayout.BeginVertical(GUI.skin.box);
						obj.fs_normal = EditorGUILayout.Foldout(obj.fs_normal, "Normal");

						if(obj.fs_normal)
						{
								EditorGUILayout.BeginVertical(GUI.skin.box);
								obj.m_Style.normal.background = (Texture2D)EditorGUILayout.ObjectField("Background", obj.m_Style.normal.background, typeof(Texture2D));
								obj.m_Style.normal.textColor = EditorGUILayout.ColorField("Text Color", obj.m_Style.normal.textColor);
								EditorGUILayout.EndVertical();
						}

						obj.fs_hover = EditorGUILayout.Foldout(obj.fs_hover, "Hover");

						if(obj.fs_hover)
						{
								EditorGUILayout.BeginVertical(GUI.skin.box);
								obj.m_Style.hover.background = (Texture2D)EditorGUILayout.ObjectField("Background", obj.m_Style.hover.background, typeof(Texture2D));
								obj.m_Style.hover.textColor = EditorGUILayout.ColorField("Text Color", obj.m_Style.hover.textColor);
								EditorGUILayout.EndVertical();
						}

							obj.fs_active = EditorGUILayout.Foldout(obj.fs_active, "Active");
						
						if(obj.fs_active)
						{
								EditorGUILayout.BeginVertical(GUI.skin.box);
								obj.m_Style.active.background = (Texture2D)EditorGUILayout.ObjectField("Background", obj.m_Style.active.background, typeof(Texture2D));
								obj.m_Style.active.textColor = EditorGUILayout.ColorField("Text Color", obj.m_Style.active.textColor);
								EditorGUILayout.EndVertical();
						}

							obj.fs_focused = EditorGUILayout.Foldout(obj.fs_focused, "Focused");
						
						if(obj.fs_focused)
						{
								EditorGUILayout.BeginVertical(GUI.skin.box);
								obj.m_Style.focused.background = (Texture2D)EditorGUILayout.ObjectField("Background", obj.m_Style.focused.background, typeof(Texture2D));
								obj.m_Style.focused.textColor = EditorGUILayout.ColorField("Text Color", obj.m_Style.focused.textColor);
								EditorGUILayout.EndVertical();
						}

						obj.fs_onnormal = EditorGUILayout.Foldout(obj.fs_onnormal, "On Normal");

						if(obj.fs_onnormal)
						{
								EditorGUILayout.BeginVertical(GUI.skin.box);
								obj.m_Style.onNormal.background = (Texture2D)EditorGUILayout.ObjectField("Background", obj.m_Style.onNormal.background, typeof(Texture2D));
								obj.m_Style.onNormal.textColor = EditorGUILayout.ColorField("Text Color", obj.m_Style.onNormal.textColor);
								EditorGUILayout.EndVertical();
						}

							obj.fs_onhover = EditorGUILayout.Foldout(obj.fs_onhover, "On Hover");

						if(obj.fs_onhover)
						{
								EditorGUILayout.BeginVertical(GUI.skin.box);
								obj.m_Style.onHover.background = (Texture2D)EditorGUILayout.ObjectField("Background", obj.m_Style.onHover.background, typeof(Texture2D));
								obj.m_Style.onHover.textColor = EditorGUILayout.ColorField("Text Color", obj.m_Style.onHover.textColor);
								EditorGUILayout.EndVertical();
						}

							obj.fs_onactive = EditorGUILayout.Foldout(obj.fs_onactive, "On Active");
						
						if(obj.fs_onactive)
						{
								EditorGUILayout.BeginVertical(GUI.skin.box);
								obj.m_Style.onActive.background = (Texture2D)EditorGUILayout.ObjectField("Background", obj.m_Style.onActive.background, typeof(Texture2D));
								obj.m_Style.onActive.textColor = EditorGUILayout.ColorField("Text Color", obj.m_Style.onActive.textColor);
								EditorGUILayout.EndVertical();
						}

							obj.fs_onfocused = EditorGUILayout.Foldout(obj.fs_onfocused, "On Focused");
						
						if(obj.fs_onfocused)
						{
								EditorGUILayout.BeginVertical(GUI.skin.box);
								obj.m_Style.onFocused.background = (Texture2D)EditorGUILayout.ObjectField("Background", obj.m_Style.onFocused.background, typeof(Texture2D));
								obj.m_Style.onFocused.textColor = EditorGUILayout.ColorField("Text Color", obj.m_Style.onFocused.textColor);
								EditorGUILayout.EndVertical();
						}

						obj.fs_border = EditorGUILayout.Foldout(obj.fs_border, "Border");

						if(obj.fs_border)
						{
								EditorGUILayout.BeginVertical(GUI.skin.box);
								obj.m_Style.border.left = EditorGUILayout.IntField("Left", obj.m_Style.border.left);
								obj.m_Style.border.right = EditorGUILayout.IntField("Right", obj.m_Style.border.right);
								obj.m_Style.border.top = EditorGUILayout.IntField("Top", obj.m_Style.border.top);
								obj.m_Style.border.bottom = EditorGUILayout.IntField("Bottom", obj.m_Style.border.bottom);
								
								EditorGUILayout.EndVertical();
						}

							obj.fs_margin = EditorGUILayout.Foldout(obj.fs_margin, "Margin");
							
						if(obj.fs_margin)
						{
								EditorGUILayout.BeginVertical(GUI.skin.box);
								obj.m_Style.margin.left = EditorGUILayout.IntField("Left", obj.m_Style.margin.left);
								obj.m_Style.margin.right = EditorGUILayout.IntField("Right", obj.m_Style.margin.right);
								obj.m_Style.margin.top = EditorGUILayout.IntField("Top", obj.m_Style.margin.top);
								obj.m_Style.margin.bottom = EditorGUILayout.IntField("Bottom", obj.m_Style.margin.bottom);
								
								EditorGUILayout.EndVertical();
						}

							obj.fs_padding = EditorGUILayout.Foldout(obj.fs_padding, "Padding");
							
							if(obj.fs_padding)
							{
								EditorGUILayout.BeginVertical(GUI.skin.box);
								obj.m_Style.padding.left = EditorGUILayout.IntField("Left", obj.m_Style.padding.left);
								obj.m_Style.padding.right = EditorGUILayout.IntField("Right", obj.m_Style.padding.right);
								obj.m_Style.padding.top = EditorGUILayout.IntField("Top", obj.m_Style.padding.top);
								obj.m_Style.padding.bottom = EditorGUILayout.IntField("Bottom", obj.m_Style.padding.bottom);
								EditorGUILayout.EndVertical();
								
							}

							obj.fs_overflow = EditorGUILayout.Foldout(obj.fs_overflow, "Overflow");
							
							if(obj.fs_overflow)
							{
								EditorGUILayout.BeginVertical(GUI.skin.box);
								obj.m_Style.overflow.left = EditorGUILayout.IntField("Left", obj.m_Style.overflow.left);
								obj.m_Style.overflow.right = EditorGUILayout.IntField("Right", obj.m_Style.overflow.right);
								obj.m_Style.overflow.top = EditorGUILayout.IntField("Top", obj.m_Style.overflow.top);
								obj.m_Style.overflow.bottom = EditorGUILayout.IntField("Bottom", obj.m_Style.overflow.bottom);
								EditorGUILayout.EndVertical();
							}

							obj.m_Style.font = (Font)EditorGUILayout.ObjectField("Font", obj.m_Style.font, typeof(Font));
							obj.m_Style.fontSize = EditorGUILayout.IntField("Font Size", obj.m_Style.fontSize);
							obj.m_Style.fontStyle = (FontStyle)EditorGUILayout.EnumPopup("Font Style", obj.m_Style.fontStyle);
							obj.m_Style.alignment = (TextAnchor)EditorGUILayout.EnumPopup("Alignment", obj.m_Style.alignment);
							obj.m_Style.wordWrap = EditorGUILayout.Toggle("World Wrap", obj.m_Style.wordWrap);
							obj.m_Style.richText = EditorGUILayout.Toggle("Rich Text", obj.m_Style.richText);
							obj.m_Style.clipping = (TextClipping)EditorGUILayout.IntField("Text Clipping", (int)obj.m_Style.clipping);
							obj.m_Style.imagePosition = (ImagePosition)EditorGUILayout.EnumPopup("Image Position", obj.m_Style.imagePosition);

							EditorGUILayout.LabelField("Content Offset");
							EditorGUILayout.BeginVertical(GUI.skin.box);
							obj.fs_oX = EditorGUILayout.FloatField("X", obj.fs_oX);
							obj.fs_oY = EditorGUILayout.FloatField("Y", obj.fs_oY);

							obj.m_Style.contentOffset.Set(obj.fs_oX, obj.fs_oY);
							EditorGUILayout.EndVertical();

							obj.m_Style.fixedWidth = EditorGUILayout.FloatField("Fixed Width", obj.m_Style.fixedWidth);
							obj.m_Style.fixedHeight = EditorGUILayout.FloatField("Fixed Height", obj.m_Style.fixedHeight);
							obj.m_Style.stretchWidth = EditorGUILayout.Toggle("Stretch Width", obj.m_Style.stretchWidth);
							obj.m_Style.stretchHeight = EditorGUILayout.Toggle("Stretch Height", obj.m_Style.stretchHeight);
								EditorGUILayout.EndVertical();
							}
						}

						EditorGUILayout.EndVertical ();

						EditorGUILayout.Separator ();
						
						EditorGUILayout.LabelField ("Role of object");
						EditorGUILayout.BeginVertical (GUI.skin.box);
						obj.m_Type = (EasyMenuKit.MenuObject.m_ObjType)EditorGUILayout.EnumPopup ("Object type", obj.m_Type);
						
						switch (obj.m_Type) {
						case EasyMenuKit.MenuObject.m_ObjType.m_Label:
							obj.m_Label.m_Text = EditorGUILayout.TextField ("Text Label", obj.m_Label.m_Text);
							break;
							
						case EasyMenuKit.MenuObject.m_ObjType.m_Button:
							obj.m_Button.m_Text = EditorGUILayout.TextField ("Button Label", obj.m_Button.m_Text);
							obj.m_Button.m_Action = (EasyMenuKit.MenuButton.m_BtnAction)EditorGUILayout.EnumPopup ("Action", obj.m_Button.m_Action);
							
							switch (obj.m_Button.m_Action) {
							case EasyMenuKit.MenuButton.m_BtnAction.m_LoadLevel:
								obj.m_Button.m_LevelName = EditorGUILayout.TextField ("Level name", obj.m_Button.m_LevelName);
								break;
								
							case EasyMenuKit.MenuButton.m_BtnAction.m_OpenPage:
								obj.m_Button.m_PageName = EditorGUILayout.TextField ("Page name", obj.m_Button.m_PageName);
								break;
								
							case EasyMenuKit.MenuButton.m_BtnAction.m_SendMessage:
								obj.m_Button.m_Target = (GameObject)EditorGUILayout.ObjectField ("Target", obj.m_Button.m_Target, typeof(GameObject));
								obj.m_Button.m_FunctionName = EditorGUILayout.TextField ("Method Name", obj.m_Button.m_FunctionName);
								break;
							}
							
							break;
							
						case EasyMenuKit.MenuObject.m_ObjType.m_Texture:
							obj.m_Texture.m_Texture = (Texture2D)EditorGUILayout.ObjectField ("Texture", obj.m_Texture.m_Texture, typeof(Texture2D));
							break;
						}
						EditorGUILayout.EndVertical ();

						EditorGUILayout.Space();

						GUI.backgroundColor = Color.red;
						if(GUILayout.Button("Delete object"))
						{
							page.m_Objects.Remove(obj);
						}
						GUI.backgroundColor = Color.white;
					}
				}
			}
			EditorGUILayout.EndVertical ();

			EditorGUILayout.Space();
			EditorGUILayout.Space();

			EditorGUILayout.BeginVertical (GUI.skin.box);

			EditorGUILayout.LabelField ("New object name");
			
			page.c_object.m_Name = EditorGUILayout.TextField (page.c_object.m_Name);

			EditorGUILayout.LabelField ("New object type");

			page.c_object.m_Type = (EasyMenuKit.MenuObject.m_ObjType)EditorGUILayout.EnumPopup(page.c_object.m_Type);


			GUI.backgroundColor = Color.green;
			if (GUILayout.Button ("Create Object")) 
			{
				EasyMenuKit.MenuObject c_obj = page.c_object;
				page.m_Objects.Insert(0, c_obj);
				page.c_object = new EasyMenuKit.MenuObject();
			}

			GUI.backgroundColor = Color.gray;
			EditorGUILayout.EndVertical ();

			EditorGUILayout.Space();

			GUI.backgroundColor = Color.red;
			if(GUILayout.Button("Delete page"))
			{
				menu.m_AllPages.Remove(page);
			}
			
			GUI.backgroundColor = Color.white;
			EditorGUILayout.EndVertical ();
			EditorGUILayout.Space();
		} 
	}
}
