using System;
using System.Collections.Generic;
using System.Drawing;

namespace Lazaro.Pres.DisplayStyles
{
        public class Template
        {
                public static Template Current = new Template();

                public IDisplayStyle Default = new OldStyle();
                public IDisplayStyle EditForm = new OldStyle();

                public IDisplayStyle Generica = new Brown();
                public IDisplayStyle Articulos = new Articulos();
                public IDisplayStyle Comprobantes = new Comprobantes();
                public IDisplayStyle Personas = new Personas();
                public IDisplayStyle Cajas = new DarkColors();

                public IDisplayStyle White = new White();

                // Microsoft Sans Serif, Segoe UI, Bitstream Vera Sans
                public string DefaultFontName { get; set; }
                public string DefaultCaptionFontName { get; set; }
                public string DefaultPrintFontName { get; set; }
                public string DefaultMonoFontName { get; set; }
                public System.Drawing.Font DefaultFont { get; set; }
                public System.Drawing.Font MenuFont { get; set; }
                public System.Drawing.Font SmallFont { get; set; }
                public System.Drawing.Font SmallerFont { get; set; }
                public System.Drawing.Font DataEntryFont { get; set; }
                public System.Drawing.Font BigFont { get; set; }
                public System.Drawing.Font BiggerFont { get; set; }
                public System.Drawing.Font MainHeaderFont { get; set; }
                public System.Drawing.Font GroupHeaderFont { get; set; }
                public System.Drawing.Font GroupHeader2Font { get; set; }
                public System.Drawing.Font MonospacedFont { get; set; }

                public Color RedColor = Color.Firebrick;
                public Color BlueColor = Color.SteelBlue;
                public Color GreenColor = Color.SeaGreen;
                public Color OrangeColor = Color.DarkOrange;

                public Template()
                {
                        bool TengoSegoe = false, TengoTrebuchet = false;
                        try {
                                if (System.Drawing.SystemFonts.MessageBoxFont.Name == "Segoe UI" || System.IO.File.Exists(Environment.ExpandEnvironmentVariables(@"%windir%\Fonts\segoeui.ttf")))
                                        TengoSegoe = true;
                                else
                                        TengoSegoe = false;
                        } catch {
                                TengoSegoe = false;
                        }

                        if (TengoSegoe == false) {
                                try {
                                        if (System.IO.File.Exists(Environment.ExpandEnvironmentVariables(@"%windir%\Fonts\trebuc.ttf")))
                                                TengoTrebuchet = true;
                                        else
                                                TengoTrebuchet = false;
                                } catch {
                                        TengoTrebuchet = false;
                                }
                        }

                        // Microsoft Sans Serif, Segoe UI, Bitstream Vera Sans
                        if (TengoSegoe) {
                                DefaultFontName = "Segoe UI";
                                DefaultCaptionFontName = "Segoe UI";
                        } else if (TengoTrebuchet) {
                                DefaultFontName = "Trebuchet MS";
                                DefaultCaptionFontName = "Trebuchet MS";
                        } else {
                                DefaultFontName = "Segoe UI";
                                DefaultCaptionFontName = DefaultFontName;
                        }
                        DefaultPrintFontName = "Segoe UI";
                        DefaultMonoFontName = "Bitstream Vera Sans Mono";
                        
                        DefaultFont = new System.Drawing.Font(DefaultFontName, 9.75F);
                        DataEntryFont = new System.Drawing.Font(DefaultFontName, 9.75F);
                        MenuFont = new System.Drawing.Font(DefaultFontName, 9.75F);
                        SmallFont = new System.Drawing.Font(DefaultFontName, 8F);
                        SmallerFont = new System.Drawing.Font(DefaultFontName, 6.75F);
                        BigFont = new System.Drawing.Font(DefaultFontName, 12F);
                        BiggerFont = new System.Drawing.Font(DefaultFontName, 14F);
                        MainHeaderFont = new System.Drawing.Font(DefaultCaptionFontName, 16F);
                        GroupHeaderFont = new System.Drawing.Font(DefaultCaptionFontName, 13F);
                        GroupHeader2Font = new System.Drawing.Font(DefaultCaptionFontName, 11F);
                        MonospacedFont = new System.Drawing.Font(DefaultMonoFontName, 10F);
                }
        }
}
