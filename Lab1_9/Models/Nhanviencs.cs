using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab1_9.Models
{
    public class Nhanviencs
    {
        [Key]
        public int Manv { get; set; }
        [Required,MinLength(8,ErrorMessage ="Nhập họ tên gồm 8 kí tự ")]
        [Display(Name ="Họ Tên")]
        public string Hoten { get; set; }
        [Display(Name = "Giới Tính")]
        public bool Gioitinh { get; set; }
        [Display(Name = "Ngày sinh")]
        [DataType(DataType.Date , ErrorMessage ="Ngày sinh bắt buộc đúng định dạng ")]
        public DateTime ngasinh { get; set; }
        [Required(ErrorMessage = "Số điện thoại là bắt buộc")]
        [Display(Name = "Số Điện Thoại")]
        public int Phone { get; set; }
        [Display(Name = "Lương")]
        public float Luong { get { return hSL * 1800000; } }
        [Required(ErrorMessage = "Hệ số lương là bắt buộc")]
        [Display(Name = "Hệ số lương")]
        public float hSL { get; set; }
        [Display(Name = "Phòng")]
        public Phong phong { get; set; }
    }
    public enum Phong
    {
        HA8,
        HA9,
        HA10,
        
    }
}