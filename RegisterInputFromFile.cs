﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Threading;
using SALT;

namespace SmolTAS
{
    public class RegisterInputFromFile
    {
        public RegisterInputFromFile() { } //Constructor

        VirtualInputs virtualInputs = new VirtualInputs(); //Caliing VirtualInputs class

        // Booleans to check key presses
        private bool isDpressed = false; 
        private bool isWpressed = false;
        private bool isApressed = false;
        private bool isSpressed = false;
        private bool isUpPressed = false;
        private bool isDownPressed = false;

        // Each line of the file is stored as a string

        public static List<string> recordedInputsList { get; set; }

        // Inputs folder in SALT\Mods folder
        private string Inputs => FileSystem.GetMyPath() + "\\Inputs";

        private readonly string[] empty = { string.Empty };

        // Creates a file in SALT\Mods folder
        public void CreateTextFile()
        {
            if (!Directory.Exists(Inputs))
                Directory.CreateDirectory(Inputs);
            File.WriteAllLines(Inputs + "\\AO.txt", empty);
            File.WriteAllLines(Inputs + "\\AO.txt", empty);
            File.WriteAllLines(Inputs + "\\PoR.txt", empty);
            File.WriteAllLines(Inputs + "\\RH.txt", empty);
            File.WriteAllLines(Inputs + "\\PL.txt", empty);
            File.WriteAllLines(Inputs + "\\AOR.txt", empty);
            File.WriteAllLines(Inputs + "\\TTM.txt", empty);
            File.WriteAllLines(Inputs + "\\NO.txt", empty);
            File.WriteAllLines(Inputs + "\\MM.txt", empty);
            File.WriteAllLines(Inputs + "\\IM.txt", empty);
            File.WriteAllLines(Inputs + "\\RU.txt", empty);
            File.WriteAllLines(Inputs + "\\INA.txt", empty);
            File.WriteAllLines(Inputs + "\\HCH.txt", empty);
            File.WriteAllLines(Inputs + "\\REF.txt", empty);
            File.WriteAllLines(Inputs + "\\MAIN.txt", empty);
        }

        // Reads from a file named AO.txt in SALT\Mods folder
        public void ReadFiles(Level level)
        {
            if (!Directory.Exists(Inputs))
                Directory.CreateDirectory(Inputs);

            string[] temp;
            switch (level)
            {
                case Level.MAIN_MENU:
                    temp = File.ReadAllLines(Inputs + "\\MAIN.txt");
                    break;

                case Level.OFFICE:
                    temp = File.ReadAllLines(Inputs + "\\AO.txt");
                    break;

                case Level.POP_ON_ROCKS:
                    temp = File.ReadAllLines(Inputs + "\\PoR.txt");
                    break;

                case Level.RED_HEART:
                    temp = File.ReadAllLines(Inputs + "\\RH.txt");
                    break;

                case Level.PEKO_LAND:
                    temp = File.ReadAllLines(Inputs + "\\PL.txt");
                    break;

                case Level.OFFICE_REVERSED:
                    temp = File.ReadAllLines(Inputs + "\\AOR.txt");
                    break;

                case Level.TO_THE_MOON:
                    temp = File.ReadAllLines(Inputs + "\\TTM.txt");
                    break;

                case Level.NOTHING:
                    temp = File.ReadAllLines(Inputs + "\\NO.txt");
                    break;

                case Level.MOGU_MOGU:
                    temp = File.ReadAllLines(Inputs + "\\MM.txt");
                    break;

                case Level.INUMORE:
                    temp = File.ReadAllLines(Inputs + "\\IM.txt");
                    break;

                case Level.RUSHIA:
                    temp = File.ReadAllLines(Inputs + "\\RU.txt");
                    break;

                case Level.INASCAPABLE_MADNESS:
                    temp = File.ReadAllLines(Inputs + "\\INA.txt");
                    break;

                case Level.HERE_COMES_HOPE:
                    temp = File.ReadAllLines(Inputs + "\\HCH.txt");
                    break;

                case Level.REFLECT:
                    temp = File.ReadAllLines(Inputs + "\\REF.txt");
                    break;

                default:
                    temp = empty;
                    break;
            }
            recordedInputsList = temp.ToList();
        }

        public void ResetInputs()
        {
            isWpressed = false;
            isApressed = false;
            isSpressed = false;
            isDpressed = false;
            isUpPressed = false;
            isDownPressed = false;
        }


        // Method which checks which characters are in the text file and presses corresponding keys
        public void DoInputs(int i)
        {
            if (recordedInputsList != null)
            {
                if (recordedInputsList[i].Contains('D') && !isDpressed)
                {
                    isDpressed = true;
                    virtualInputs.SendDPressed();
                }
                if (!recordedInputsList[i].Contains('D') && isDpressed)
                {
                    isDpressed = false;
                    virtualInputs.SendDPressed();
                    virtualInputs.SendDReleased();
                }
                if (recordedInputsList[i].Contains('W') && !isWpressed)
                {
                    isWpressed = true;
                    virtualInputs.SendWPressed();
                }
                if (!recordedInputsList[i].Contains('W') && isWpressed)
                {
                    isWpressed = false;
                    virtualInputs.SendWPressed();
                    virtualInputs.SendWReleased();
                }
                if (recordedInputsList[i].Contains('A') && !isApressed)
                {
                    isApressed = true;
                    virtualInputs.SendAPressed();
                }
                if (!recordedInputsList[i].Contains('A') && isApressed)
                {
                    isApressed = false;
                    virtualInputs.SendAPressed();
                    virtualInputs.SendAReleased();
                }
                if (recordedInputsList[i].Contains('S') && !isSpressed)
                {
                    isSpressed = true;
                    virtualInputs.SendSPressed();
                }
                if (!recordedInputsList[i].Contains('S') && isSpressed)
                {
                    isSpressed = false;
                    virtualInputs.SendSPressed();
                    virtualInputs.SendSReleased();
                }
                if (recordedInputsList[i].Contains('J') && !isUpPressed)
                {
                    isUpPressed = true;
                    virtualInputs.SendUpPressed();
                }
                if (!recordedInputsList[i].Contains('J') && isUpPressed)
                {
                    isUpPressed = false;
                    virtualInputs.SendUpPressed();
                    virtualInputs.SendUpReleased();
                }
                if (recordedInputsList[i].Contains('G') && !isDownPressed)
                {
                    isDownPressed = true;
                    virtualInputs.SendDownPressed();
                }
                if (!recordedInputsList[i].Contains('G') && isDownPressed)
                {
                    isDownPressed = false;
                    virtualInputs.SendDownPressed();
                    virtualInputs.SendDownReleased();
                }
            }
        }
    }
}
