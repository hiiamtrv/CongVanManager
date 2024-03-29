﻿using CongVanManager.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CongVanManager.ViewModel
{
    class UC_OutBoxFilterViewModel : FilterSetting
    {
        #region Filter Setting
        private List<Func<CongVan, bool>> filterList = new List<Func<CongVan, bool>>(5);
        private Func<CongVan, bool> defaultFilter = (item) => false;
        public override bool Filter(CongVan item)
        {
            string filterText = MainWindowViewModel.Ins.FilterText;

            if (!Match(item, filterText))
                return false;

            foreach (var func in filterList)
                if (func?.Invoke(item) == true)
                    return true;
            return false;
        }
        #endregion

        #region Binding
        private bool _choDuyet;
        public bool ChoDuyet
        {
            get => _choDuyet;
            set
            {
                _choDuyet = value;
                if (value == false)
                    filterList[0] = defaultFilter;
                else
                    filterList[0] = (item) =>
                        item.StatusCode == CongVan.StatusCodeEnum.ChoDuyet;
                OnPropertyChanged();
            }
        }
        private bool _daDuyet;
        public bool DaDuyet
        {
            get => _daDuyet;
            set
            {
                _daDuyet = value;
                if (value == false)
                    filterList[1] = defaultFilter;
                else
                    filterList[1] = (item) =>
                        item.StatusCode == CongVan.StatusCodeEnum.DaDuyet_Di;
                OnPropertyChanged();
            }
        }
        private bool _daLuuTru;
        public bool DaLuuTru
        {
            get => _daLuuTru;
            set
            {
                _daLuuTru = value;
                if (value == false)
                    filterList[2] = defaultFilter;
                else
                    filterList[2] = (item) =>
                        item.StatusCode == CongVan.StatusCodeEnum.DaLuuTru;
                OnPropertyChanged();
            }
        }
        private bool _daGui;
        public bool DaGui
        {
            get => _daGui;
            set
            {
                _daGui = value;
                if (value == false)
                    filterList[3] = defaultFilter;
                else
                    filterList[3] = (item) =>
                        item.StatusCode == CongVan.StatusCodeEnum.DaGui;
                OnPropertyChanged();
            }
        }

        private bool moiDoi;
        public bool MoiDoi
        {
            get => moiDoi;
            set
            {
                moiDoi = value;
                if (value == false)
                    filterList[4] = defaultFilter;
                else
                    filterList[4] = (item) =>
                        item.NgayXuLi > (MainWindowViewModel.Ins.User?.LastSeen??DateTime.MinValue);
                OnPropertyChanged();
            }
        }
        #endregion

        #region Singleton
        private UC_OutBoxFilterViewModel()
        {
            while (filterList.Count < filterList.Capacity)
                filterList.Add(defaultFilter);

            DaLuuTru = true;
            DaDuyet = true;
            DaGui = true;
            ChoDuyet = true;
        }

        private static UC_OutBoxFilterViewModel ins = null;
        public static UC_OutBoxFilterViewModel Ins
        {
            get
            {
                if (ins == null)
                    ins = new UC_OutBoxFilterViewModel();
                return ins;
            }
            private set => ins = value;
        }
        #endregion

        #region ButtonFilter
        private ICommand _buttonFilterCongVan;
        public ICommand ButtonFilterCongVan
        {
            get
            {
                if (_buttonFilterCongVan == null)
                    _buttonFilterCongVan = new RelayCommand(param =>
                    {
                        MainWindowViewModel.Ins.ButtonFilterCongVan.Execute(null);
                    });
                return _buttonFilterCongVan;
            }
        }
        #endregion
    }
}
