//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CongVanManager
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class LoaiCongVan
    {
        public LoaiCongVan()
        {
            this.CongVans = new HashSet<CongVan>();
        }

        public string Id { get => _id; set { _id = value.ToUpper(); } }
        // Only in uppercase please

        public virtual ICollection<CongVan> CongVans { get; set; }

        private static ObservableCollection<LoaiCongVan> _db;
        private string _id;

        public static ObservableCollection<LoaiCongVan> DB
        {
            get
            {
                if (_db == null)
                    _db = new ObservableCollection<LoaiCongVan>();
                return _db;
            }
            private set { }
        }
    }
}