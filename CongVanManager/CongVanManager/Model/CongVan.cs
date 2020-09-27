﻿namespace CongVanManager
{
    using CongVanManager.ViewModel;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;

    public partial class CongVan : ObservableObject
    {
        public CongVan()
        {
            this.DanhSachNoiNhan = new ObservableCollection<NoiNhan>();
            this.PhanHois = new ObservableCollection<PhanHoi>();
        }
        private int _id;
        public int Id
        {
            get => _id;
            set { _id = value; OnPropertyChanged(); }
        }
        private string _soKyHieu;
        public string SoKyHieu
        {
            get => _soKyHieu;
            set { _soKyHieu = value; OnPropertyChanged(); }
        }
        private int? _soCongVan;
        public int? SoCongVan
        {
            get => _soCongVan;
            set { _soCongVan = value; OnPropertyChanged(); }
        }
        private DateTime? _ngayCongVan;
        public DateTime? NgayCongVan
        {
            get => _ngayCongVan;
            set { _ngayCongVan = value; OnPropertyChanged(); }
        }
        private string _trichYeu;
        public string TrichYeu
        {
            get => _trichYeu;
            set { _trichYeu = value; OnPropertyChanged(); }
        }
        private string _ghiChu;
        public string GhiChu
        {
            get => _ghiChu;
            set { _ghiChu = value; OnPropertyChanged(); }
        }
        private string _pDFScanLocation;
        public string PDFScanLocation
        {
            get => _pDFScanLocation;
            set { _pDFScanLocation = value; OnPropertyChanged(); }
        }
        private DateTime _ngayXuLi;
        public DateTime NgayXuLi
        {
            get => _ngayXuLi;
            set { _ngayXuLi = value; OnPropertyChanged(); }
        }
        private int _statusCode;
        public int StatusCode
        {
            get => _statusCode;
            set { _statusCode = value; OnPropertyChanged(); }
        }
        // Status: 
        // 1: Đã tiếp nhận
        // 2: Đã duyệt
        // 4: Đang chuyển
        public string Status
        {
            get
            {
                if (StatusCode >= 6) return "Đã chuyển";
                if (StatusCode >= 2) return "Đã duyệt";
                if (StatusCode == 1) return "Đã tiếp nhận";
                else return "Chưa đọc";
            }
        }
        private LoaiCongVan _loaiCongVan;
        public virtual LoaiCongVan LoaiCongVan
        {
            get => _loaiCongVan;
            set { _loaiCongVan = value; OnPropertyChanged(); }
        }
        private LienHe _noiGui;
        public virtual LienHe NoiGui
        {
            get => _noiGui;
            set { _noiGui = value; OnPropertyChanged(); }
        }
        private ObservableCollection<NoiNhan> _danhSachNoiNhan;
        public virtual ObservableCollection<NoiNhan> DanhSachNoiNhan { get => _danhSachNoiNhan;
            set {
                value.CollectionChanged +=
                (object sender, NotifyCollectionChangedEventArgs e)
                => { this.OnPropertyChanged(); };
                _danhSachNoiNhan = value;
                OnPropertyChanged(); }
        }
        public virtual ObservableCollection<PhanHoi> PhanHois { get; set; }

        public CongVan Clone
        {
            get { return MemberwiseClone() as CongVan; }
        }

        private static ObservableCollection<CongVan> _db;
 
        public static ObservableCollection<CongVan> DB
        {
            get
            {
                if (_db == null)
                {
                    _db = new ObservableCollection<CongVan>();
                    // TODO: syncronize mechanic
                }
                return _db;
            }
            private set { }
        }
        // TODO: syncronize mechanic
    }
}
