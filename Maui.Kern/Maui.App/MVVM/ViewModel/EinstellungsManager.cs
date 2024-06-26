﻿using CommunityToolkit.Mvvm.ComponentModel;
using Maui.App.Infrastuktur;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maui.Kern.Manager.Logging;

namespace Maui.App.MVVM.ViewModel
{
    /// <summary>
    /// Stellt die Verwaltung von Einstellungen
    /// </summary>
    public partial class EinstellungsManager : MauiAppObjekt
    {
        public EinstellungsManager()
        {

            LogManager.Info($"{this.GetType().Name} was initialized successfully");
        }

    }
}