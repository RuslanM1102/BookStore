﻿#pragma checksum "..\..\..\..\Pages\Auth\PasswordPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "7524F2232C313C771AE689FFFE10BE1B9CEAEE5D5B669BB09D7DFDBE203999B3"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using BookStore;
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


namespace BookStore.Pages.Auth {
    
    
    /// <summary>
    /// PasswordPage
    /// </summary>
    public partial class PasswordPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\..\..\Pages\Auth\PasswordPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Login;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\Pages\Auth\PasswordPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LoginPlaceholder;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\Pages\Auth\PasswordPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox OldPassword;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\Pages\Auth\PasswordPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label OldPasswordPlaceholder;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\Pages\Auth\PasswordPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox Password;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\Pages\Auth\PasswordPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label PasswordPlaceholder;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\Pages\Auth\PasswordPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CancelButton;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\..\Pages\Auth\PasswordPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ChangePasswordButton;
        
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
            System.Uri resourceLocater = new System.Uri("/BookStore;component/pages/auth/passwordpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\Auth\PasswordPage.xaml"
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
            this.Login = ((System.Windows.Controls.TextBox)(target));
            
            #line 26 "..\..\..\..\Pages\Auth\PasswordPage.xaml"
            this.Login.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Login_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.LoginPlaceholder = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.OldPassword = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 30 "..\..\..\..\Pages\Auth\PasswordPage.xaml"
            this.OldPassword.PasswordChanged += new System.Windows.RoutedEventHandler(this.OldPassword_PasswordChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.OldPasswordPlaceholder = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.Password = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 35 "..\..\..\..\Pages\Auth\PasswordPage.xaml"
            this.Password.PasswordChanged += new System.Windows.RoutedEventHandler(this.Password_PasswordChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.PasswordPlaceholder = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.CancelButton = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\..\..\Pages\Auth\PasswordPage.xaml"
            this.CancelButton.Click += new System.Windows.RoutedEventHandler(this.CancelButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.ChangePasswordButton = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\..\..\Pages\Auth\PasswordPage.xaml"
            this.ChangePasswordButton.Click += new System.Windows.RoutedEventHandler(this.ChangePasswordButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

