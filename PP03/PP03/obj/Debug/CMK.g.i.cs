﻿#pragma checksum "..\..\CMK.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "FB2E489C6A6476EA267543777BB755BE6FD0DD168EA058002684D0E3A688ABF2"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using PP03;
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


namespace PP03 {
    
    
    /// <summary>
    /// CMK
    /// </summary>
    public partial class CMK : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\CMK.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblTitle;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\CMK.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgCMK;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\CMK.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblName_CMK;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\CMK.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbName_CMK;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\CMK.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btCMK_InsertType;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\CMK.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btCMK_UpdateType;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\CMK.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btCMK_DeleteType;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\CMK.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btCMK_Import;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\CMK.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbSearch;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\CMK.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btSearch;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\CMK.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox chbFilter;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\CMK.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btClose;
        
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
            System.Uri resourceLocater = new System.Uri("/PP03;component/cmk.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\CMK.xaml"
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
            
            #line 8 "..\..\CMK.xaml"
            ((PP03.CMK)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.lblTitle = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.dgCMK = ((System.Windows.Controls.DataGrid)(target));
            
            #line 27 "..\..\CMK.xaml"
            this.dgCMK.AutoGeneratingColumn += new System.EventHandler<System.Windows.Controls.DataGridAutoGeneratingColumnEventArgs>(this.DgCMK_AutoGeneratingColumn);
            
            #line default
            #line hidden
            return;
            case 4:
            this.lblName_CMK = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.tbName_CMK = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.btCMK_InsertType = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\CMK.xaml"
            this.btCMK_InsertType.Click += new System.Windows.RoutedEventHandler(this.BtCMK_InsertType_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btCMK_UpdateType = ((System.Windows.Controls.Button)(target));
            return;
            case 8:
            this.btCMK_DeleteType = ((System.Windows.Controls.Button)(target));
            return;
            case 9:
            this.btCMK_Import = ((System.Windows.Controls.Button)(target));
            
            #line 51 "..\..\CMK.xaml"
            this.btCMK_Import.Click += new System.Windows.RoutedEventHandler(this.BtCMK_Import_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.tbSearch = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.btSearch = ((System.Windows.Controls.Button)(target));
            return;
            case 12:
            this.chbFilter = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 13:
            this.btClose = ((System.Windows.Controls.Button)(target));
            
            #line 63 "..\..\CMK.xaml"
            this.btClose.Click += new System.Windows.RoutedEventHandler(this.BtClose_Click_1);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
