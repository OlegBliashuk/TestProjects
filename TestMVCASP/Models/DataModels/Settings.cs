//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestMVCASP.Models.DataModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class Settings
    {
        public short SettingID { get; set; }
        public string Setting { get; set; }
        public string Value { get; set; }
        public Nullable<short> ParentID { get; set; }
    }
}
