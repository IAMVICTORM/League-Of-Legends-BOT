﻿using InputManager;
using LeagueBot.Game.Enums;
using LeagueBot.Img;
using LeagueBot.IO;
using LeagueBot.Windows;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using static LeagueBot.Windows.Interop;

namespace LeagueBot.Api
{
    public class ImgApi
    {
        private WinApi WinApi
        {
            get;
            set;
        }

        public ImgApi(WinApi winApi)
        {
            this.WinApi = winApi;
        }

        public void waitForImage(string image)
        {
            bool exists = ImageRecognition.ImageExists(image);
            while (!exists)
            {
                exists = ImageRecognition.ImageExists(image);
                Thread.Sleep(1000);
            }

        }
        public void leftClickImage(string image)
        {
            if (ImageRecognition.ImageExists(image))
            {
                Point coords = ImageRecognition.ImageCoords(image);

                Mouse.Move(coords.X, coords.Y);
                Mouse.PressButton(Mouse.MouseKeys.Left, 150);
            }

        }


        public void waitForText(string text)
        {
            bool exists = TextRecognition.TextExists(text);
            while (!exists)
            {
                exists = TextRecognition.TextExists(text);
                Thread.Sleep(1000);
            }

        }
        public void waitForText2(string processName, string text)
        {
            bool exists = TextRecognition.TextExists2(processName, text);
            while (!exists)
            {
                Thread.Sleep(1000);
                exists = TextRecognition.TextExists2(processName, text);
            }

        }
        public bool textExists(string processName, string text)
        {
            return TextRecognition.TextExists2(processName, text); 
        }
        public void leftClickText(string text)
        {
            if (TextRecognition.TextExists(text))
            {
                Point coords = TextRecognition.TextCoords(text);

                Mouse.Move(coords.X, coords.Y);
                Mouse.PressButton(Mouse.MouseKeys.Left, 150);
            }

        }


    }
}
