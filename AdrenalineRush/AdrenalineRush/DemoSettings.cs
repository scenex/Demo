using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace AdrenalineRush
{
    static class DemoSettings
    {
        static bool isFullscreen = false;
        static bool isVSync = false;
        static bool isAntiAlias = false;


        static float demoAspectRatio = 0f;

        static int demoResolutionWidth = 0;
        static int demoResolutionHeight = 0;

        public static void SetFullscreen(bool value)
        {
            isFullscreen = value;
        }

        public static bool GetFullscreen()
        {
            return isFullscreen;
        }




        public static void SetVSync(bool value)
        {
            isVSync = value;
        }

        public static bool GetVSync()
        {
            return isVSync;
        }




        public static void SetAntiAlias(bool value)
        {
            isAntiAlias = value;
        }

        public static bool GetAntiAlias()
        {
            return isAntiAlias;
        }




        public static void SetDemoResolution(DemoResolution demoResolution)
        {
            demoResolutionWidth = demoResolution.GetDemoWidth();
            demoResolutionHeight = demoResolution.GetDemoHeight();
        }

        public static DemoResolution GetDemoResolution()
        {
            return new DemoResolution(demoResolutionWidth, demoResolutionHeight);
        }




        public static void SetDemoAspectRatio(float aspectRatio)
        {
            demoAspectRatio = aspectRatio;
        }

        public static float GetDemoAspectRatio()
        {
            return demoAspectRatio;
        }
    }




    enum AvailableDemoAspectRatios
    { 
        AspectRatio4to3,
        AspectRatio16to9,
        AspectRatio16to10
    }




    class DemoResolution
    {
        int demoWidth = 0;
        int demoHeight = 0;

        public DemoResolution(int Width, int Height)
        {
            this.demoWidth = Width;
            this.demoHeight = Height;
        }

        public int GetDemoWidth()
        {
            return demoWidth;
        }

        public int GetDemoHeight()
        {
            return demoHeight;
        }
    }

    
}
