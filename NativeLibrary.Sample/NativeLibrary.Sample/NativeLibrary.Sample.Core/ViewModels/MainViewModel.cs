using MvvmCross.Core.ViewModels;
using NativeLibrary.Sample.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace NativeLibrary.Sample.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private readonly INativeOperationsService nativeOperationsService;

        private string nativeText;

        public string NativeText
        {
            get
            {
                return nativeText;
            }
            set
            {
                nativeText = value;
                RaisePropertyChanged("NativeText");
            }
        }

        private ICommand getNativeStringCommand;
        public ICommand GetNativeStringCommand
        {
            get
            {
                if (getNativeStringCommand == null)
                    getNativeStringCommand = new MvxCommand(GetNativeString);

                return getNativeStringCommand;
            }
        }

        public MainViewModel(INativeOperationsService nativeOperationsService)
        {
            this.nativeOperationsService = nativeOperationsService;
        }

        private void GetNativeString()
        {
            NativeText = nativeOperationsService.GetStringFromNative();
        }
    }
}
