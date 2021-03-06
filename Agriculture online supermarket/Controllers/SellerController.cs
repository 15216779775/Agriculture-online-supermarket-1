﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Agriculture_online_supermarket.Controllers
{
    public class SellerController : Controller
    {
        // GET: Seller

        public ActionResult SellerIndex()
        {
            //检查登入状态
            //取的卖家所有售卖商品信息填充模型
            return View();//View(models) 正在售卖商品列表
        }

        public ActionResult ProductInfo(/*string ProductId*/)
        {
            //检查登入状态
            //获取指定商品的信息，填充模型
            return View();//View(model)商品信息(此model应该在提交SaveProductInfo()时作为参数）
        }
        public ActionResult SellerOrder()
        {
            //检查登入状态
            //获取所有订单并填充模型
            return View();//View(models) 订单列表
        } 
        public ActionResult Delivery(/*string OrderId*/)
        {
            //检查登入状态
            //获取订单信息并填充模型
            return View();//View(model) 订单发货和修改发货信息都用此Action，model中的物流信息等可能为空。
        }
        public ActionResult SellerOrderDetail(/*string OrderId*/)
        {
            //检查登入状态
            //获取订单信息并填充模型
            return View();//View(model) 订单信息
        }
        public ActionResult AddProduct()
        {
            //检查登入状态
            //准备空模型
            return View("ProductInfo");//View(model) 待填充的空模型
        }
        public ActionResult DeleteProduct(/*string ProductId*/)
        {
            //检查登入状态
            //删除商品
            return RedirectToAction("SellerIndex");
        }
        public ActionResult SaveProductInfo(/*Model model*/)
        {
            //将模型中数据保存
            return RedirectToAction("SellerIndex");
        }
        public ActionResult Deliver(/*Model model*/)
        {
            //检查登入状态
            //更改相应订单的状态和信息
            return RedirectToAction("SellerOrder");
        }
        public ActionResult Refuse(/*string OrderId*/)
        {
            //检查登入状态
            //更改相应订单的状态
            return RedirectToAction("SellerOrder");
        }
        public ActionResult AgreeRefund(/*string OrderId*/)
        {
            //检查登入状态
            //更改相应订单的状态
            return RedirectToAction("SellerOrder");
        }
        public ActionResult DisagreeRefund(/*string OrderId*/)
        {
            //检查登入状态
            //更改相应订单的状态 
            return RedirectToAction("SellerOrder");
        }

        private bool needRedirect()
        {
            if (Session["state"] == null)
                return true;
            return !((int)Session["state"] == 2 );
        }
        /// <summary>
        /// 获得跳转返回
        /// </summary>
        private ActionResult redirectAction
        {
            get
            {
                if ((int)Session["state"] == 1|| (int)Session["state"] == 0)
                {
                    return RedirectToAction("Index", "Customer");
                }
                else if ((int)Session["state"] == 3)
                {
                    return RedirectToAction("AdminIndex", "Admin");
                }
                
                else
                {
                    return null;
                }
            }
        }
    }
}