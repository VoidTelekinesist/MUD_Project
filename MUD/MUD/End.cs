﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUD
{
	static class End
	{
		public static void story(string action)
		{
			string input = "";
			switch (action)
			{
				case "deathPit":
					C.t("This room is completely dark.");
					C.t("You stumple through the darkness, perhaps you could find a light switch.");
					C.t("You fall; soon screaming as you realize you keep falling.");
					C.t("A silent \"BUMB\" can be hard from the top of the pit", 4000);
					C.t("\t\t\t\tGAME OVER");
					Console.Write("\n\n\n\n\n\n\n\n\n\n");
					C.t("", 10000);
					C.t("Continue or Quit?");
					while (true)
					{
						input = Console.ReadLine().ToLower();
						if (input.Contains("continue"))
						{
							Save.load();
							break;
						}
						else if (input.Contains("quit"))
						{
							Environment.Exit(0);
						}
						else if (input.Contains("save"))
						{
							C.t("You DIED. Moron");
							C.t("Why would you wan't to save? So you could reload the death screen?!?!");
							C.t("Idiot");
						}
						else
						{
							C.t("You only have those two options. Please choose one");
						}
					}
					
					break;
				default:
					C.d("This room is supposed to have a custom action, but the action specified does not exist");
					break;
			}
		}
	}
}
