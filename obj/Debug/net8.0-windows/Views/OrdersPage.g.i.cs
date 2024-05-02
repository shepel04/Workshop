﻿#pragma checksum "..\..\..\..\Views\OrdersPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0C17BC693143E78D5CDA61D693355812D25263AB"
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
using System.Windows.Controls.Ribbon;
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
using Workshop.Views;


namespace Workshop.Views {
    
    
    /// <summary>
    /// OrdersPage
    /// </summary>
    public partial class OrdersPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\..\..\Views\OrdersPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RefreshTableButton;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\Views\OrdersPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid OrdersDataGrid;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\Views\OrdersPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DateFilterPicker;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\Views\OrdersPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PriceFilterLowerTextBox;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\..\Views\OrdersPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PriceFilterHigherTextBox;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\Views\OrdersPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox OrderIdTextBox;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\Views\OrdersPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CustomerNameFilterTextBox;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\..\Views\OrdersPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CompleteOrderButton;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\..\Views\OrdersPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeleteOrderButton;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\..\Views\OrdersPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ResetFiltersButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.2.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Workshop;component/views/orderspage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\OrdersPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.2.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.RefreshTableButton = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\..\Views\OrdersPage.xaml"
            this.RefreshTableButton.Click += new System.Windows.RoutedEventHandler(this.RefreshTableButton_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.OrdersDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 3:
            
            #line 35 "..\..\..\..\Views\OrdersPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ApplyFilterButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.DateFilterPicker = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 5:
            this.PriceFilterLowerTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.PriceFilterHigherTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.OrderIdTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.CustomerNameFilterTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            
            #line 56 "..\..\..\..\Views\OrdersPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.CompleteOrderButton = ((System.Windows.Controls.Button)(target));
            
            #line 57 "..\..\..\..\Views\OrdersPage.xaml"
            this.CompleteOrderButton.Click += new System.Windows.RoutedEventHandler(this.CompleteOrderButton_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.DeleteOrderButton = ((System.Windows.Controls.Button)(target));
            
            #line 58 "..\..\..\..\Views\OrdersPage.xaml"
            this.DeleteOrderButton.Click += new System.Windows.RoutedEventHandler(this.DeleteOrderButton_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.ResetFiltersButton = ((System.Windows.Controls.Button)(target));
            
            #line 59 "..\..\..\..\Views\OrdersPage.xaml"
            this.ResetFiltersButton.Click += new System.Windows.RoutedEventHandler(this.ResetFilterButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

