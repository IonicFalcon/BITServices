﻿#pragma checksum "..\..\..\..\UI\Windows\CreateJobRequestWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B89C3576111F01E83A8BB81DF8D542B006EE5A8583808EB781ADA061A41B4EC4"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using BITServices.UI.Windows;
using Microsoft.Xaml.Behaviors;
using Microsoft.Xaml.Behaviors.Core;
using Microsoft.Xaml.Behaviors.Input;
using Microsoft.Xaml.Behaviors.Layout;
using Microsoft.Xaml.Behaviors.Media;
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
using Xceed.Wpf.Toolkit;
using Xceed.Wpf.Toolkit.Chromes;
using Xceed.Wpf.Toolkit.Core.Converters;
using Xceed.Wpf.Toolkit.Core.Input;
using Xceed.Wpf.Toolkit.Core.Media;
using Xceed.Wpf.Toolkit.Core.Utilities;
using Xceed.Wpf.Toolkit.Panels;
using Xceed.Wpf.Toolkit.Primitives;
using Xceed.Wpf.Toolkit.PropertyGrid;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;
using Xceed.Wpf.Toolkit.PropertyGrid.Commands;
using Xceed.Wpf.Toolkit.PropertyGrid.Converters;
using Xceed.Wpf.Toolkit.PropertyGrid.Editors;
using Xceed.Wpf.Toolkit.Zoombox;


namespace BITServices.UI.Windows {
    
    
    /// <summary>
    /// CreateJobRequestWindow
    /// </summary>
    public partial class CreateJobRequestWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 39 "..\..\..\..\UI\Windows\CreateJobRequestWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtClientNo;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\UI\Windows\CreateJobRequestWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpcDate;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\UI\Windows\CreateJobRequestWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.Toolkit.TimePicker tmpStartTime;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\UI\Windows\CreateJobRequestWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbJobSkill;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\UI\Windows\CreateJobRequestWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbUrgency;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\..\UI\Windows\CreateJobRequestWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtStreet;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\..\UI\Windows\CreateJobRequestWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSuburb;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\..\UI\Windows\CreateJobRequestWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbState;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\..\UI\Windows\CreateJobRequestWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPostCode;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\..\UI\Windows\CreateJobRequestWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtJobProblem;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\..\UI\Windows\CreateJobRequestWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgrAvaliableContractors;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\..\UI\Windows\CreateJobRequestWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCreate;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\..\UI\Windows\CreateJobRequestWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCancel;
        
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
            System.Uri resourceLocater = new System.Uri("/BITServices;component/ui/windows/createjobrequestwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UI\Windows\CreateJobRequestWindow.xaml"
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
            
            #line 10 "..\..\..\..\UI\Windows\CreateJobRequestWindow.xaml"
            ((BITServices.UI.Windows.CreateJobRequestWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 12 "..\..\..\..\UI\Windows\CreateJobRequestWindow.xaml"
            ((System.Windows.Data.CollectionViewSource)(target)).Filter += new System.Windows.Data.FilterEventHandler(this.CollectionViewSource_Filter);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtClientNo = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.dpcDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 5:
            this.tmpStartTime = ((Xceed.Wpf.Toolkit.TimePicker)(target));
            return;
            case 6:
            this.cmbJobSkill = ((System.Windows.Controls.ComboBox)(target));
            
            #line 45 "..\..\..\..\UI\Windows\CreateJobRequestWindow.xaml"
            this.cmbJobSkill.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cmbJobSkill_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.cmbUrgency = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.txtStreet = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.txtSuburb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.cmbState = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 11:
            this.txtPostCode = ((System.Windows.Controls.TextBox)(target));
            return;
            case 12:
            this.txtJobProblem = ((System.Windows.Controls.TextBox)(target));
            return;
            case 13:
            this.dgrAvaliableContractors = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 14:
            this.btnCreate = ((System.Windows.Controls.Button)(target));
            return;
            case 15:
            this.btnCancel = ((System.Windows.Controls.Button)(target));
            
            #line 79 "..\..\..\..\UI\Windows\CreateJobRequestWindow.xaml"
            this.btnCancel.Click += new System.Windows.RoutedEventHandler(this.btnCancel_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

