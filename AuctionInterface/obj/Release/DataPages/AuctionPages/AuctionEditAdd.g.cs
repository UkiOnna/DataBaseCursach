﻿#pragma checksum "..\..\..\..\DataPages\AuctionPages\AuctionEditAdd.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "3A8F2B432BB2B9238C086EBDF520E9E99EE7DAA1C5BDE3B01E57308452ACA096"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using AuctionInterface.DataPages.AuctionPages;
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


namespace AuctionInterface.DataPages.AuctionPages {
    
    
    /// <summary>
    /// AuctionEditAdd
    /// </summary>
    public partial class AuctionEditAdd : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\..\DataPages\AuctionPages\AuctionEditAdd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox name;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\DataPages\AuctionPages\AuctionEditAdd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox adress;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\DataPages\AuctionPages\AuctionEditAdd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button create;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\DataPages\AuctionPages\AuctionEditAdd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button edit;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\DataPages\AuctionPages\AuctionEditAdd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox date;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\DataPages\AuctionPages\AuctionEditAdd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox specify;
        
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
            System.Uri resourceLocater = new System.Uri("/AuctionInterface;component/datapages/auctionpages/auctioneditadd.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\DataPages\AuctionPages\AuctionEditAdd.xaml"
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
            this.name = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.adress = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.create = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\..\DataPages\AuctionPages\AuctionEditAdd.xaml"
            this.create.Click += new System.Windows.RoutedEventHandler(this.CreatePerson);
            
            #line default
            #line hidden
            return;
            case 4:
            this.edit = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\..\..\DataPages\AuctionPages\AuctionEditAdd.xaml"
            this.edit.Click += new System.Windows.RoutedEventHandler(this.EditPerson);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 19 "..\..\..\..\DataPages\AuctionPages\AuctionEditAdd.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BackToMainMenu);
            
            #line default
            #line hidden
            return;
            case 6:
            this.date = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.specify = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

