﻿#pragma checksum "..\..\w_price_report.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "36176BECD241AB6B3DABAF643FF68DD501AE21C90F3CEDA8884B17DEC07A4AEB"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

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
using trucking_app;


namespace trucking_app {
    
    
    /// <summary>
    /// w_price_report
    /// </summary>
    public partial class w_price_report : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 43 "..\..\w_price_report.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox serviceTextBox;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\w_price_report.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox loadunloadTextBox;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\w_price_report.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox overtloadTextBox;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\w_price_report.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox overtunloadTextBox;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\w_price_report.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox urgeTextBox;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\w_price_report.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox specTranTextBox;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\w_price_report.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox otherTextBox;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\w_price_report.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button okButton;
        
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
            System.Uri resourceLocater = new System.Uri("/trucking_app;component/w_price_report.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\w_price_report.xaml"
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
            this.serviceTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.loadunloadTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.overtloadTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.overtunloadTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.urgeTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.specTranTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.otherTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.okButton = ((System.Windows.Controls.Button)(target));
            
            #line 59 "..\..\w_price_report.xaml"
            this.okButton.Click += new System.Windows.RoutedEventHandler(this.okButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

