﻿#pragma checksum "..\..\..\HomeUsuarios.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "66145EB14E0CEEA799BEF08B25C4D46B7A10F488"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
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
using WpfAppIntermodular;


namespace WpfAppIntermodular {
    
    
    /// <summary>
    /// HomeUsuarios
    /// </summary>
    public partial class HomeUsuarios : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 36 "..\..\..\HomeUsuarios.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Reserva;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\HomeUsuarios.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Habitaciones;
        
        #line default
        #line hidden
        
        
        #line 129 "..\..\..\HomeUsuarios.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button EditarUsuario;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.4.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WpfAppIntermodular;component/homeusuarios.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\HomeUsuarios.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Reserva = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\..\HomeUsuarios.xaml"
            this.Reserva.Click += new System.Windows.RoutedEventHandler(this.Reserva_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Habitaciones = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\..\HomeUsuarios.xaml"
            this.Habitaciones.Click += new System.Windows.RoutedEventHandler(this.Habitaciones_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 49 "..\..\..\HomeUsuarios.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Editar_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 50 "..\..\..\HomeUsuarios.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.CrearUsuario_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 51 "..\..\..\HomeUsuarios.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.CrearEmpleado_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 52 "..\..\..\HomeUsuarios.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Cerrar_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.EditarUsuario = ((System.Windows.Controls.Button)(target));
            
            #line 129 "..\..\..\HomeUsuarios.xaml"
            this.EditarUsuario.Click += new System.Windows.RoutedEventHandler(this.EditarUsuario_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

