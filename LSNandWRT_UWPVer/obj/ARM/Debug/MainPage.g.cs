﻿#pragma checksum "C:\Users\OneUser\OneDrive - okitobu\Application\LSNandWRT_UWPVer\LSNandWRT_UWPVer\MainPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "FC58DD092651B780EC31144606FFCF7958E94D9A6A078A73792C18A5A8914FC8"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LSNandWRT_UWPVer
{
    partial class MainPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private static class XamlBindingSetters
        {
            public static void Set_Windows_UI_Xaml_Controls_TextBlock_Text(global::Windows.UI.Xaml.Controls.TextBlock obj, global::System.String value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = targetNullValue;
                }
                obj.Text = value ?? global::System.String.Empty;
            }
        };

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class MainPage_obj16_Bindings :
            global::Windows.UI.Xaml.IDataTemplateExtension,
            global::Windows.UI.Xaml.Markup.IDataTemplateComponent,
            global::Windows.UI.Xaml.Markup.IXamlBindScopeDiagnostics,
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IMainPage_Bindings
        {
            private global::LaW.Word dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);
            private bool removedDataContextHandler = false;

            // Fields for each control that has bindings.
            private global::System.WeakReference obj16;
            private global::Windows.UI.Xaml.Controls.TextBlock obj17;
            private global::Windows.UI.Xaml.Controls.TextBlock obj18;

            // Static fields for each binding's enabled/disabled state
            private static bool isobj17TextDisabled = false;
            private static bool isobj18TextDisabled = false;

            public MainPage_obj16_Bindings()
            {
            }

            public void Disable(int lineNumber, int columnNumber)
            {
                if (lineNumber == 79 && columnNumber == 93)
                {
                    isobj17TextDisabled = true;
                }
                else if (lineNumber == 80 && columnNumber == 95)
                {
                    isobj18TextDisabled = true;
                }
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 16: // MainPage.xaml line 78
                        this.obj16 = new global::System.WeakReference((global::Windows.UI.Xaml.Controls.Grid)target);
                        break;
                    case 17: // MainPage.xaml line 79
                        this.obj17 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 18: // MainPage.xaml line 80
                        this.obj18 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    default:
                        break;
                }
            }

            public void DataContextChangedHandler(global::Windows.UI.Xaml.FrameworkElement sender, global::Windows.UI.Xaml.DataContextChangedEventArgs args)
            {
                 if (this.SetDataRoot(args.NewValue))
                 {
                    this.Update();
                 }
            }

            // IDataTemplateExtension

            public bool ProcessBinding(uint phase)
            {
                throw new global::System.NotImplementedException();
            }

            public int ProcessBindings(global::Windows.UI.Xaml.Controls.ContainerContentChangingEventArgs args)
            {
                int nextPhase = -1;
                ProcessBindings(args.Item, args.ItemIndex, (int)args.Phase, out nextPhase);
                return nextPhase;
            }

            public void ResetTemplate()
            {
                Recycle();
            }

            // IDataTemplateComponent

            public void ProcessBindings(global::System.Object item, int itemIndex, int phase, out int nextPhase)
            {
                nextPhase = -1;
                switch(phase)
                {
                    case 0:
                        nextPhase = -1;
                        this.SetDataRoot(item);
                        if (!removedDataContextHandler)
                        {
                            removedDataContextHandler = true;
                            (this.obj16.Target as global::Windows.UI.Xaml.Controls.Grid).DataContextChanged -= this.DataContextChangedHandler;
                        }
                        this.initialized = true;
                        break;
                }
                this.Update_((global::LaW.Word) item, 1 << phase);
            }

            public void Recycle()
            {
            }

            // IMainPage_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
            }

            public void DisconnectUnloadedObject(int connectionId)
            {
                throw new global::System.ArgumentException("No unloadable elements to disconnect.");
            }

            public bool SetDataRoot(global::System.Object newDataRoot)
            {
                if (newDataRoot != null)
                {
                    this.dataRoot = (global::LaW.Word)newDataRoot;
                    return true;
                }
                return false;
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::LaW.Word obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_WordText(obj.WordText, phase);
                        this.Update_Translation(obj.Translation, phase);
                    }
                }
            }
            private void Update_WordText(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // MainPage.xaml line 79
                    if (!isobj17TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj17, obj, null);
                    }
                }
            }
            private void Update_Translation(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // MainPage.xaml line 80
                    if (!isobj18TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj18, obj, null);
                    }
                }
            }
        }
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1: // MainPage.xaml line 1
                {
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)(target);
                    ((global::Windows.UI.Xaml.Controls.Page)element1).SizeChanged += this.Page_SizeChanged;
                }
                break;
            case 2: // MainPage.xaml line 23
                {
                    this.MainGrid = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 3: // MainPage.xaml line 90
                {
                    this.grid1 = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 4: // MainPage.xaml line 105
                {
                    this.CurrentWordBorder = (global::Windows.UI.Xaml.Controls.Border)(target);
                }
                break;
            case 5: // MainPage.xaml line 110
                {
                    this.grid = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 6: // MainPage.xaml line 131
                {
                    this.AdditionInfo = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBlock)this.AdditionInfo).PointerPressed += this.ReadAdditionalInfo;
                }
                break;
            case 7: // MainPage.xaml line 128
                {
                    this.SwitchBut = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.SwitchBut).Click += this.Switch;
                }
                break;
            case 8: // MainPage.xaml line 123
                {
                    this.PrevBut = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.PrevBut).Click += this.PreviousBut;
                }
                break;
            case 9: // MainPage.xaml line 124
                {
                    this.NexBut = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.NexBut).Click += this.NextBut;
                }
                break;
            case 10: // MainPage.xaml line 125
                {
                    this.ReBut = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.ReBut).Click += this.Replay;
                }
                break;
            case 11: // MainPage.xaml line 107
                {
                    this.CurrentWord = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBlock)this.CurrentWord).PointerPressed += this.ShowCurrentWord;
                }
                break;
            case 12: // MainPage.xaml line 54
                {
                    this.grid2 = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 13: // MainPage.xaml line 75
                {
                    this.WordList = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    ((global::Windows.UI.Xaml.Controls.ListView)this.WordList).SelectionChanged += this.Select;
                }
                break;
            case 14: // MainPage.xaml line 86
                {
                    this.AwnserBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.AwnserBox).TextChanged += this.CheckAwnser;
                }
                break;
            case 19: // MainPage.xaml line 66
                {
                    this.SearchBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 20: // MainPage.xaml line 67
                {
                    this.SearchBut = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.SearchBut).Click += this.Search;
                }
                break;
            case 21: // MainPage.xaml line 38
                {
                    this.MediaElement = (global::Windows.UI.Xaml.Controls.MediaElement)(target);
                }
                break;
            case 22: // MainPage.xaml line 39
                {
                    this.FileLocationText = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 23: // MainPage.xaml line 40
                {
                    this.ChooseBut = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.ChooseBut).Click += this.Choose;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            switch(connectionId)
            {
            case 16: // MainPage.xaml line 78
                {                    
                    global::Windows.UI.Xaml.Controls.Grid element16 = (global::Windows.UI.Xaml.Controls.Grid)target;
                    MainPage_obj16_Bindings bindings = new MainPage_obj16_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(element16.DataContext);
                    element16.DataContextChanged += bindings.DataContextChangedHandler;
                    global::Windows.UI.Xaml.DataTemplate.SetExtensionInstance(element16, bindings);
                    global::Windows.UI.Xaml.Markup.XamlBindingHelper.SetDataTemplateComponent(element16, bindings);
                }
                break;
            }
            return returnValue;
        }
    }
}

