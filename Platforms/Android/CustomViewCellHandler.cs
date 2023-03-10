﻿using Android.Content;
using Android.Graphics.Drawables;
using Android.Views;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using Microsoft.Maui.Controls.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AContext = Android.Content.Context;
using AView = Android.Views.View;
using AViewGroup = Android.Views.ViewGroup;

namespace Maui_Workaround13812.Platforms.Android {

    public class CustomViewCellHandler : Microsoft.Maui.Controls.Handlers.Compatibility.ViewCellRenderer 
    {
        private AView pCellCore;
        private bool pSelected;
        private Drawable pUnselectedBackground;

        protected override AView GetCellCore(Cell item, AView convertView, AViewGroup parent, AContext context) 
        {
            pCellCore = base.GetCellCore(item, convertView, parent, context);

            this.pSelected = false;
            this.pUnselectedBackground = pCellCore.Background;

            return pCellCore;
        }

        protected override void OnCellPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e) 
        {
            base.OnCellPropertyChanged(sender, e);

            if (e.PropertyName == "IsSelected") {
                pSelected = !(pSelected);
                if (pSelected) {
                    pCellCore.SetBackgroundColor(((CustomViewCell)sender).SelectedBackgroundColor.ToAndroid());
                }
                else {
                    pCellCore.SetBackground(this.pUnselectedBackground);
                }
            }
        }
    }
}
