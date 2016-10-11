﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MUD
{
	/**
	 * Handles savedata and stored settigns
	 */
	public static class Save
	{
		//Loads saved data
		//Set reset to 1 to load default values
		public static string[] load(byte reset = 0)
		{
			string[] data = new string[9];
			byte index = 0;
			XmlDocument x = new XmlDocument();
			x.Load(@"..\GameData.xml");
			data[index] = (x.DocumentElement.ChildNodes[reset].ChildNodes[0].Attributes["val"].Value);
			index++;
			data[index] = (x.DocumentElement.ChildNodes[reset].ChildNodes[1].ChildNodes[0].Attributes["val"].Value);
			index++;

			foreach(XmlAttribute cont in x.DocumentElement.ChildNodes[reset].ChildNodes[1].ChildNodes[1].Attributes)
			{
				data[index] = cont.Value;
				index++;
			}
			foreach (XmlAttribute cont in x.DocumentElement.ChildNodes[reset].ChildNodes[1].ChildNodes[2].Attributes)
			{
				data[index] = cont.Value;
				index++;
			}
			return data;
		}

		public static void save()
		{
			string[] data = new string[9];
			XmlDocument x = new XmlDocument();
			x.Load(@"..\GameData.xml");
			x.DocumentElement.ChildNodes[0].ChildNodes[0].Attributes["val"].Value = Player.room.ToString();
			x.DocumentElement.ChildNodes[0].ChildNodes[1].ChildNodes[0].Attributes["val"].Value = Player.HP.ToString();
			x.DocumentElement.ChildNodes[0].ChildNodes[1].ChildNodes[1].Attributes["desc"].Value = Player.armor;
			x.DocumentElement.ChildNodes[0].ChildNodes[1].ChildNodes[1].Attributes["damRes"].Value = Player.damageResistance.ToString();
			x.DocumentElement.ChildNodes[0].ChildNodes[1].ChildNodes[1].Attributes["damRed"].Value = Player.damageReduction.ToString();
			x.DocumentElement.ChildNodes[0].ChildNodes[1].ChildNodes[2].Attributes["desc"].Value = Player.weapon;
			x.DocumentElement.ChildNodes[0].ChildNodes[1].ChildNodes[2].Attributes["wieldAb"].Value = Player.weildability.ToString();
			x.DocumentElement.ChildNodes[0].ChildNodes[1].ChildNodes[2].Attributes["damage"].Value = Player.damage.ToString();
			x.DocumentElement.ChildNodes[0].ChildNodes[1].ChildNodes[2].Attributes["inconsis"].Value = Player.inconsitency.ToString();
			
			x.Save(@"..\GameData.xml");
		}

		public static void printSave(string[] data)
		{
			foreach(string val in data)
			{
				C.d(val);
			}
		}

		public static void setValues(string[] d)
		{
			Player.room = int.Parse(d[0]);
			Player.HP = int.Parse(d[1]);
			Player.armor = d[2];
			Player.damageResistance = int.Parse(d[3]);
			Player.damageReduction = int.Parse(d[4]);
			Player.weapon = d[5];
			Player.weildability = int.Parse(d[6]);
			Player.damage = int.Parse(d[7]);
			Player.inconsitency = float.Parse(d[8]);
		}
	}
}