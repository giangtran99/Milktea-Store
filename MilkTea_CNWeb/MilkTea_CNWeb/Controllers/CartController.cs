using MilkTea_CNWeb.DAO;
using MilkTea_CNWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MilkTea_CNWeb.Controllers
{
    public class CartController : Controller
    {
        TraSuaModel db = new TraSuaModel();
        loginDao lg = new loginDao();
        cartDao ct = new cartDao();
        public const string strCart = "CartSession";
        // GET: Cart
        /*
        public ActionResult GioHang()
        {
            var cart = (Cart)Session[strCart];
            var list = new List<CartItem>();
            if(cart != null)
            {
                list = cart.DanhSachSP().ToList();
                ViewBag.TongTien = cart.TongTien();
                ViewBag.QuanityCart = cart.QuanityCart();
            }
            
            return View(list);
        }
        public ActionResult ThemSanPham(int id,int soluong,string topping,string tenSize)
        {
            var cart = (Cart)Session[strCart];
            var entity = db.Sizes.Where(x => x.TenSize == tenSize).FirstOrDefault();
            int? giaSize = entity.GiaSize;

            if(cart!=null)
            {
                cart.ThemSanPham(id, soluong,topping,giaSize,tenSize);
                Session[strCart] = cart;
            }
            else
            {
                cart = new Cart();
                cart.ThemSanPham(id, soluong, topping, giaSize,tenSize);
                Session[strCart] = cart;
            }
           

            return RedirectToAction("ShopDetail","Home");
        }
        public ActionResult XoaSanPham(int id)
        {
            var cart = (Cart)Session[strCart];
            var sp = db.SanPhams.Find(id);
            cart.XoaSanPham(sp);

            Session[strCart] = cart;

            return RedirectToAction("GioHang");
        }
        */

        public ActionResult GioHang()
        {
            var cart = (Cart)Session[strCart];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = cart.DanhSachSP().ToList();
                ViewBag.TongTien = cart.TongTien();
                ViewBag.QuanityCart = cart.QuanityCart();
            }
            return View();
        }

        [HttpGet]
        public JsonResult GetListGioHang()
        {
            var cart = (Cart)Session[strCart];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = cart.DanhSachSP().ToList();
                ViewBag.TongTien = cart.TongTien();
                ViewBag.QuanityCart = cart.QuanityCart();
            }
            return Json(new { status = true ,data = list }, JsonRequestBehavior.AllowGet) ;
        }
       
        public ActionResult ThemSanPham(int id, int soluong, string topping, string tenSize)
        {
            var cart = (Cart)Session[strCart];
            var entity = db.Sizes.Where(x => x.TenSize == tenSize).FirstOrDefault();
            int? giaSize = entity.GiaSize;

            if (cart != null)
            {
                if (!cart.isExistinCart(id))
                {

                    cart.ThemSanPham(id, soluong, topping, giaSize, tenSize);
                    Session[strCart] = cart;

                }
                else
                {
                    cart.UpdateCart(id, soluong);
                    Session[strCart] = cart;
                }
                return RedirectToAction("ShopDetail", "Home");
            }
            else
            {
                cart = new Cart();
                cart.ThemSanPham(id, soluong, topping, giaSize, tenSize);
                Session[strCart] = cart;
                return RedirectToAction("ShopDetail", "Home");
            }
           

        }
        [HttpPost]
        public JsonResult XoaSanPham(int id)
        {
            var cart = (Cart)Session[strCart];
            var sp = db.SanPhams.Find(id);
           
            int quanity = cart.QuanityCart();
            cart.XoaSanPham(sp);
            double? money = cart.TongTien();
            Session[strCart] = cart;

            if(cart.DanhSachSP().Count() == 0)
            {       
                cart = null;
                Session[strCart] = cart;
            }
            


            return Json(new { status = true,data = quanity,tien = money}, JsonRequestBehavior.AllowGet);

        }
       
        public ActionResult ThongTinKH()
        {
            var sess = (LoginModel)Session[LoginController.strLogin];
            if(sess!=null)
            {
                var entity = db.KhachHangs.Where(x => x.TenDangNhap == sess.userName).FirstOrDefault();
                return View(entity);
            }
            return View();
        }
        
        public JsonResult ThanhToan(string ten,string diachi,int sdt,string email,string tk,string mk)
        {
            var acc = (LoginModel)Session[LoginController.strLogin];
            var cart = (Cart)Session[strCart];
            if(cart!=null)
            {
                
                    //neu trang thai khong dang nhap
                    if (acc == null)
                    {

                    //Truong hop dang ky trung email
                       
                        if (ct.isOnlyEmail(email)&&ct.isOnlyTaiKhoan(tk))
                        {
                        ct.ThemKhachHang(new KhachHang
                        {
                            TenDangNhap = tk,
                            MatKhau = mk,
                            HoTen = ten,
                            Diachi = diachi,
                            SDT = sdt,
                            Email = email,
                            LoaiKH = "NULL"
                        }) ;
                        ct.ThemHoaDon(new DonHang
                            {
                                MaKhachHang = ct.GetKhbyEmail(email).MaKhachHang,
                                NgayDatHang = DateTime.Now,
                                TongTien = cart.TongTien(),
                            });


                            foreach (var item in cart.DanhSachSP().ToList())
                            {
                                ct.ThemChiTietHoaDon(new ChitietDonHang
                                {
                                    MaDonHang = ct.GetMaDH(),
                                    MaSanPham = item.product.MaSanPham,
                                    TenSize = item.TenSize,
                                    MaTopping = ct.GetMaTopbyTen(item.Topping).MaTopping,
                                    SoLuong = item.Quanity,
                                    Thanhtien = item.Quanity * item.product.Gia
                                });
                            }
                        return Json(new { data = "Đặt hàng thành công !!! " ,status = true}, JsonRequestBehavior.AllowGet);
                    }
                    return Json(new { status = true,data = "Tài khoản hoặc email đã tồn tại !!! " }, JsonRequestBehavior.AllowGet);
                }
                    else
                    {
                        ct.ThemHoaDon(new DonHang
                        {
                            MaKhachHang = ct.GetKhbyEmail(email).MaKhachHang,
                            NgayDatHang = DateTime.Now,
                            TongTien = cart.TongTien(),
                        });


                        foreach (var item in cart.DanhSachSP().ToList())
                        {
                            ct.ThemChiTietHoaDon(new ChitietDonHang
                            {
                                MaDonHang = ct.GetMaDH(),
                                MaSanPham = item.product.MaSanPham,
                                TenSize = item.TenSize,
                                MaTopping = ct.GetMaTopbyTen(item.Topping).MaTopping,
                                SoLuong = item.Quanity,
                                Thanhtien = item.Quanity * item.product.Gia
                            });
                        }
                    }
                    //Clear session cart va gio hang sau khi thanh toan
                    cart.DanhSachSP().ToList().Clear();
                    Session[strCart] = null;
                    return Json(new {data = "Đặt hàng thành công !!! ", status = true },JsonRequestBehavior.AllowGet);
                
             
            }
            return Json(new { data = "Giỏ hàng rỗng", status = true }, JsonRequestBehavior.AllowGet);

        }

         [ChildActionOnly]
        public ActionResult TestChildView()
        {
            var cart = (Cart)Session[strCart];
          
          
            return PartialView(cart);
        }

    }


}