using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls;
using System;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Input;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.WindowsAPICodePack.Dialogs;


namespace WatermarkManager.ViewModel
{
    public class WatermarkManagerViewModel : ViewModelBase
    {
        #region UI Variable
        private string _fileDirPath = "";
        public string FileDirePath
        {
            get { return _fileDirPath; }
            set { _fileDirPath = value; RaisePropertyChanged("FileDirePath"); }
        }
        #endregion

        #region Command
        public RelayCommand<object> ButtonClickCommand { get; private set; }

        private void InitRelayCommand()
        {
            ButtonClickCommand = new RelayCommand<object>(OnButtonClick);
        }

        private void OnButtonClick(object param)
        {
            switch (param.ToString())
            {
                case "Load":
                    OpenDialog();
                    break;
                case "Run":
                    RunProcess();
                    break;
            }
        }

        private void OpenDialog()
        {
            using(CommonOpenFileDialog dialog = new CommonOpenFileDialog())
            {
                dialog.InitialDirectory = _InitPath;
                dialog.IsFolderPicker = true;
                
                if(dialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    _InitPath = Path.GetDirectoryName(dialog.FileName);
                    FileDirePath = dialog.FileName;
                }
            }  
        }
        #endregion

        #region Field
        private string _InitPath = @"C:\Users\Desktop";
        #endregion

        public WatermarkManagerViewModel()
        {
            InitRelayCommand();
        }

        private void RunProcess()
        {
            var imageFilePathList = Directory.GetFiles(FileDirePath, "*.*", SearchOption.AllDirectories).ToList();

            foreach(var imageFilePath in imageFilePathList)
            {
                // 이미지 처리
                // 이미지 정보
                // 히스토그램
            }
        }

        private void 

    }
}
