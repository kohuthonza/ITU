﻿#pragma checksum "..\..\MainUserControl.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "29AB679DF33D75588DA839D8B0DECDEC"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ITU;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace ITU {
    
    
    /// <summary>
    /// MainUserControl
    /// </summary>
    public partial class MainUserControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 45 "..\..\MainUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid main_grid;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\MainUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button adminBtn;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\MainUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button startBtn;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\MainUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button accBtn;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\MainUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button endBtn;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ITU;component/mainusercontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainUserControl.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.main_grid = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.adminBtn = ((System.Windows.Controls.Button)(target));
            
            #line 54 "..\..\MainUserControl.xaml"
            this.adminBtn.Click += new System.Windows.RoutedEventHandler(this.adminBtn_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.startBtn = ((System.Windows.Controls.Button)(target));
            
            #line 70 "..\..\MainUserControl.xaml"
            this.startBtn.Click += new System.Windows.RoutedEventHandler(this.startBtn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.accBtn = ((System.Windows.Controls.Button)(target));
            
            #line 71 "..\..\MainUserControl.xaml"
            this.accBtn.Click += new System.Windows.RoutedEventHandler(this.accBtn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.endBtn = ((System.Windows.Controls.Button)(target));
            
            #line 72 "..\..\MainUserControl.xaml"
            this.endBtn.Click += new System.Windows.RoutedEventHandler(this.endBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

