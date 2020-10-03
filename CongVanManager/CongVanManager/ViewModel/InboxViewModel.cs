﻿using QuanLyChamThi.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CongVanManager.ViewModel
{
    class InboxViewModel : ObservableObject
    {
        #region DanhSachCongVan
        public ICollection<CongVan> DSCongVan
        {
            get { return CongVan.DB.Where(Filter).ToList(); }
            set
            // Call to refresh data, 
            // Does not set value
            { OnPropertyChanged("AmountOfLetters"); }
        }

        public int AmountOfLetters
        {
            get { return CongVan.DB.Count; }
        }
        #endregion

        #region SelectedCongVan

        private CongVan _selectedCongVan;
        public CongVan SelectedCongVan
        {
            get { return _selectedCongVan; }
            set
            {
                _selectedCongVan = value;
                OnPropertyChanged("SelectedCongVanKeyNumber");
                OnPropertyChanged("SelectedCongVanNumber");
                OnPropertyChanged("SelectedLoaiCongVan");
                OnPropertyChanged("SelectedCongVanSender");
                OnPropertyChanged("SelectedCongVanTrichYeu");
                OnPropertyChanged("SelectedCongVanSentDate");
                OnPropertyChanged("SelectedCongVanNote");
                OnPropertyChanged("SelectedCongVanKeyNumber");
                OnPropertyChanged("SelectedCongVanNumber");
                OnPropertyChanged("SelectedCongVanDestination");
            }
        }
        #endregion

        #region SelectedCongVanDetail
        public string SelectedLoaiCongVan
        {
            get { return _selectedCongVan?.LoaiCongVan?.Id; }
            set
            {
                OnPropertyChanged();
                if (_selectedCongVan == null)
                    return;
                if (_selectedCongVan.LoaiCongVan.Id != value.ToUpper())
                {
                    LoaiCongVan correctLoaiCongVan = LoaiCongVan.DB.First(
                        (LoaiCongVan item) => { return item.Id == value.ToUpper(); });
                    _selectedCongVan.LoaiCongVan = correctLoaiCongVan;
                    ValueChanged(_selectedCongVan);
                }
            }
        }
        public string SelectedCongVanTrichYeu
        {
            get { return _selectedCongVan?.TrichYeu; }
            set
            {
                OnPropertyChanged();
                if (_selectedCongVan == null)
                    return;
                if (_selectedCongVan.TrichYeu != value)
                {
                    _selectedCongVan.TrichYeu = value;
                    ValueChanged(_selectedCongVan);
                }
            }
        }
        public string SelectedCongVanKeyNumber
        {
            get
            {
                return _selectedCongVan?.SoKyHieu;
            }
            set
            {
                OnPropertyChanged();
                if (_selectedCongVan == null)
                    return;
                if (_selectedCongVan.SoKyHieu != value)
                {
                    _selectedCongVan.SoKyHieu = value;
                    ValueChanged(_selectedCongVan);
                }
            }
        }
        public int? SelectedCongVanNumber
        {
            get { return _selectedCongVan?.SoCongVan; }
            set
            {
                OnPropertyChanged();
                if (_selectedCongVan == null)
                    return;
                if (SelectedCongVanNumber != value)
                {
                    _selectedCongVan.SoCongVan = value;
                    ValueChanged(_selectedCongVan);
                }
            }
        }
        public string SelectedCongVanSender
        {
            get { return _selectedCongVan?.NoiGui?.Name; }
            set
            {
                OnPropertyChanged();
                if (_selectedCongVan == null)
                    return;
                if (SelectedCongVanSender != value)
                {
                    LienHe correctSender = LienHe.DB.First(
                        (LienHe item) => { return item.Name == value || item.Email == value; });
                    _selectedCongVan.NoiGui = correctSender;
                    ValueChanged(_selectedCongVan);
                }
            }
        }
        public DateTime SelectedCongVanSentDate
        {
            get
            {
                return (_selectedCongVan?.NgayCongVan).
                  GetValueOrDefault(DateTime.MinValue);
            }
            set
            {
                OnPropertyChanged();
                if (_selectedCongVan == null)
                    return;
                if (SelectedCongVanSentDate != value)
                {
                    _selectedCongVan.NgayCongVan = value;
                    ValueChanged(_selectedCongVan);
                }
            }
        }
        public string SelectedCongVanNote
        {
            get { return _selectedCongVan?.GhiChu; }
            set
            {
                OnPropertyChanged();
                if (_selectedCongVan == null)
                    return;
                if (SelectedCongVanNote != value)
                {
                    _selectedCongVan.GhiChu = value;
                    ValueChanged(_selectedCongVan);
                }
            }
        }
        public ICollection<NoiNhan> SelectedCongVanDestination
        {
            get { return _selectedCongVan?.DanhSachNoiNhan; }
            set
            {
                OnPropertyChanged();
                if (_selectedCongVan == null)
                    return;
                if (SelectedCongVanDestination != value)
                {
                    _selectedCongVan.DanhSachNoiNhan = new ObservableCollection<NoiNhan>(value);
                    ValueChanged(_selectedCongVan);
                }
            }
        }
        #endregion

        #region FilterSetting
        private List<Func<CongVan, bool>> filterList = new List<Func<CongVan, bool>>(4);
        private Func<CongVan, bool> defaultFilter = (item) => true;
        private bool Filter(CongVan item)
        {
            foreach(var func in filterList)
                if (func?.Invoke(item) == false)
                    return false;
            return true;
        }
        private bool? _chuaDoc;
        public bool? ChuaDoc
        {
            get => _chuaDoc;
            set
            {
                _chuaDoc = value;
                if (value == null)
                    filterList[0] = defaultFilter;
                else
                    filterList[0] = (item) => 
                        !item.StatusCode.HasFlag(CongVan.StatusCodeEnum.DaDoc)
                        ^ value.Value;
            }
        }
        private bool? _daDuyet;
        public bool? DaDuyet
        {
            get => _daDuyet;
            set
            {
                _daDuyet = value;
                if (value == null)
                    filterList[1] = defaultFilter;
                else
                    filterList[1] = (item) =>
                        !item.StatusCode.HasFlag(CongVan.StatusCodeEnum.DaDuyet)
                        ^ value.Value;
            }
        }
        private bool? _daTiepNhan;
        public bool? DaTiepNhan
        {
            get => _daTiepNhan;
            set
            {
                _daTiepNhan = value;
                if (value == null)
                    filterList[2] = defaultFilter;
                else
                    filterList[2] = (item) =>
                        !item.StatusCode.HasFlag(CongVan.StatusCodeEnum.DaTiepNhan)
                        ^ value.Value;
            }
        }
        private bool? _daChuyen;
        public bool? DaChuyen
        {
            get => _daChuyen;
            set
            {
                _daChuyen = value;
                if (value == null)
                    filterList[3] = defaultFilter;
                else
                    filterList[3] = (item) =>
                        !(item.StatusCode.HasFlag(CongVan.StatusCodeEnum.DangChuyen)
                        && item.StatusCode.HasFlag(CongVan.StatusCodeEnum.DaDuyet))
                        ^ value.Value;
            }
        }
        #endregion

        #region ButtonFilter
        private ICommand _buttonFilterCongVan;
        public ICommand ButtonFilterCongVan
        {
            get {
                if (_buttonFilterCongVan == null)
                    _buttonFilterCongVan = new RelayCommand(param => UpdateData(this, null));
                return _buttonFilterCongVan;
            }
        }
        #endregion

        public void ValueChanged(object sender, string[] args = null)
        {
            if (sender is CongVan)
            {
                CongVan target = sender as CongVan;
                target.NgayXuLi = System.DateTime.Now;
                // TODO: Update database
            }
        }
        public void UpdateData(object target, string[] args)
        {
            // Update this ViewModel
            OnPropertyChanged("DSCongVan");
            if (args == null)
                return;
        }


        private InboxViewModel()
        {
            while (filterList.Count < 4) filterList.Add(defaultFilter);

            LienHe contact = new LienHe
            {
                Name = "Phòng Đào tạo",
                Email = "phongdaotao@gmail.com"
            };
            NoiNhan noiNhan1 = new NoiNhan
            {
                LienHe = contact
            };
            NoiNhan noiNhan2 = new NoiNhan
            {
                LienHe = contact
            };
            LoaiCongVan loaiCongVan = new LoaiCongVan { Id = "Kế hoạch" };
            CongVan congVan = new CongVan
            {
                LoaiCongVan = loaiCongVan,
                TrichYeu = "Ngày hội qua môn cho sinh viên năm 6",
                SoKyHieu = "01/ĐH-CNTT",
                NoiGui = contact,
                DanhSachNoiNhan = new ObservableCollection<NoiNhan> {
                    noiNhan1, noiNhan2 },
                SoCongVan = 1,
                NgayCongVan = System.DateTime.Now,
                GhiChu = "Đme ngày hội xàm vài lòn",
                StatusCode = CongVan.StatusCodeEnum.DaDuyet |
                             CongVan.StatusCodeEnum.DangChuyen,

            };
            CongVan congVan2 = new CongVan
            {
                LoaiCongVan = loaiCongVan,
                TrichYeu = "Ngày hội chia sẻ cách để viết một xâu vô cùng dài trong tựa đề chỉ vì lý do kiểm thử phần mềm cho sinh viên năm 6, 7, 8, 9, thực ra ai cũng vô được",
                SoKyHieu = "02/ĐH-CNTT",
                NoiGui = contact,
                DanhSachNoiNhan = new ObservableCollection<NoiNhan> {
                    noiNhan1},
                SoCongVan = 2,
                NgayCongVan = System.DateTime.Now,
                GhiChu = "Chỉ là để chia sẻ cách để viết một xâu vô cùng dài trong tựa đề chỉ vì lý do kiểm thử phần mềm cho sinh viên năm 6, 7, 8, 9, thực ra ai cũng vô được mời mọi người cùng vô cho nó vui",
                StatusCode = CongVan.StatusCodeEnum.DaDuyet |
                             CongVan.StatusCodeEnum.DaTiepNhan,

            };
            noiNhan1.CongVan = noiNhan2.CongVan = congVan;

            CongVan.DB.Add(congVan);
            CongVan.DB.Add(congVan2);
            LoaiCongVan.DB.Add(loaiCongVan);
            NoiNhan.DB.Add(noiNhan2);
            NoiNhan.DB.Add(noiNhan1);
            LienHe.DB.Add(contact);

            CongVan.DB.CollectionChanged +=
                (object sender, NotifyCollectionChangedEventArgs e)
                =>
                { OnPropertyChanged("DSCongVan"); };
        }
        private static InboxViewModel _instance = null;

        public static InboxViewModel Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new InboxViewModel();
                return _instance;
            }
        }
    }
}