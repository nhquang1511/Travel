﻿#pragma checksum "..\..\..\Views\KháchSanView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "CECCC361807EC56288D5FE7564CCA7953DD0F215ECB61DFE01559537DDD0ABFC"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Dulich.Views;
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


namespace Dulich.Views {
    
    
    /// <summary>
    /// KhachSanView
    /// </summary>
    public partial class KhachSanView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\..\Views\KháchSanView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox idTextBox;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\Views\KháchSanView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tenKhachSanTextBox;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\Views\KháchSanView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox diaChiTextBox;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Views\KháchSanView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox loaiKhachSanTextBox;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Views\KháchSanView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imgPreview;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Views\KháchSanView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid myDataGrid;
        
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
            System.Uri resourceLocater = new System.Uri("/Dulich;component/views/kh%c3%a1chsanview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\KháchSanView.xaml"
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
            this.idTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.tenKhachSanTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.diaChiTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.loaiKhachSanTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            
            #line 24 "..\..\..\Views\KháchSanView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ThemButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 25 "..\..\..\Views\KháchSanView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.XoaButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 26 "..\..\..\Views\KháchSanView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SuaButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.imgPreview = ((System.Windows.Controls.Image)(target));
            return;
            case 9:
            
            #line 28 "..\..\..\Views\KháchSanView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SelectImage_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.myDataGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 31 "..\..\..\Views\KháchSanView.xaml"
            this.myDataGrid.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.myDataGrid_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

