﻿#pragma checksum "..\..\w_search_shipping.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "54E0898523D3D511CAB35AA67CAB7ECB1460750164A5585FE0BE201D69480EBF"
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
    /// w_search_shipping
    /// </summary>
    public partial class w_search_shipping : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 51 "..\..\w_search_shipping.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox autoTextBox;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\w_search_shipping.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox trailerTextBox;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\w_search_shipping.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox cargoCodeTextBox;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\w_search_shipping.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox cargoClassTextBox;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\w_search_shipping.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox containerTextBox;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\w_search_shipping.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox senderTextBox;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\w_search_shipping.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox receiverTextBox;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\w_search_shipping.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox loadTextBox;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\w_search_shipping.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox unloadTextBox;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\w_search_shipping.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox urgentCheckBox;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\w_search_shipping.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox driverTextBox;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\w_search_shipping.xaml"
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
            System.Uri resourceLocater = new System.Uri("/trucking_app;component/w_search_shipping.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\w_search_shipping.xaml"
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
            this.autoTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 52 "..\..\w_search_shipping.xaml"
            this.autoTextBox.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.autoTextBox_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 2:
            this.trailerTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 54 "..\..\w_search_shipping.xaml"
            this.trailerTextBox.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.trailerTextBox_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 3:
            this.cargoCodeTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.cargoClassTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.containerTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.senderTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.receiverTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.loadTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 66 "..\..\w_search_shipping.xaml"
            this.loadTextBox.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.loadTextBox_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 9:
            this.unloadTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 68 "..\..\w_search_shipping.xaml"
            this.unloadTextBox.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.unloadTextBox_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 10:
            this.urgentCheckBox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 11:
            this.driverTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 72 "..\..\w_search_shipping.xaml"
            this.driverTextBox.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.driverTextBox_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 12:
            this.okButton = ((System.Windows.Controls.Button)(target));
            
            #line 76 "..\..\w_search_shipping.xaml"
            this.okButton.Click += new System.Windows.RoutedEventHandler(this.okButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

