using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TheTop.Application.Entities;
using TheTop.Application.Services;
using TheTop.Application.Services.DTOs;
using TheTop.ViewModels;

namespace TheTop.Controllers
{
    // [Authorize] // -> authenticated 
    /*[Authorize(Roles="Admin")]*/ // -> authenticated 
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAdvertisementService _advertisementService;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IReviewService _reviewService;
        private readonly ICouponService _couponService;
        private readonly ICategoryService _categoryService;
        private readonly ICompanyInformationService _companyInformationService;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public HomeController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IAdvertisementService advertisementService,
            IReviewService reviewService,
            IShoppingCartService shoppingCartService,
            ICouponService couponService,
            ICategoryService categoryService,
            ICompanyInformationService companyInformationService
        )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _advertisementService = advertisementService;
            _reviewService = reviewService;
            _shoppingCartService = shoppingCartService;
            _couponService = couponService;
            _categoryService = categoryService;
            _companyInformationService = companyInformationService;
        }


        public async Task<IActionResult> HomePage()
        {
           
            var user = await _userManager.GetUserAsync(User);

            // Get number items in ShoppingCart
            if (user != null)
            {
                ViewBag.numItemCart = _shoppingCartService.GetNumItemShoppingCart(user.Id);
            }

            //Get coupon if found 
            CouponDTO couponDTO = _couponService.GetValidCoupon();
            CouponVM couponVM = new CouponVM
            {
                Code = couponDTO.Code,
                Ratio = couponDTO.Ratio,
                ValidityDate = couponDTO.ValidityDate,
                CreatedAT = couponDTO.CreatedAt,
            };
            ViewBag.Coupon = couponVM;

            // List  Categorys
           
            List<CategoryDTO> categoryDtoList = _categoryService.GetAllCategories().ToList();
            List<CategoryVM> categoryVMList = categoryDtoList.Select(nameCateg => new CategoryVM
            {
                Name = nameCateg.Name
            }).ToList();
            ViewBag.categorysList = categoryVMList;


            // List Advertisements
            List<AdvertisementDTO> advertisementsDtoList = _advertisementService.GetAllAdvertisemensts().ToList();
            List<AdvertisementVM> advertisementsVMList = advertisementsDtoList
                .Select(advertisement => new AdvertisementVM
                {
                    ID = advertisement.ID,
                    Name = advertisement.Name,
                    Price = advertisement.Price,
                    Category = advertisement.CategoryName,
                    CreatedAT = advertisement.CreatedAt,
                    PhotosNames = advertisement.ImagesNames.Select(img => img).ToList(),
                }).ToList();

            // List Reviews
            List<ReviewDTO> reviewDtoList = _reviewService.GetApprovedReviews().ToList();

            var reviewVMlist = new List<ReviewVM>();
            reviewDtoList.ForEach(review =>
            {
                reviewVMlist.Add(new ReviewVM
                {
                    Customer = new CustomerVM
                    {
                        FirstName = review.User.FirstName,
                        LastName = review.User.LastName,
                        Email = review.User.Email,
                        //ImageName = review.User.ImagName
                    },
                    Massage = review.Massage,
                    Subject = review.Subject,
                    ID = review.ID
                });
            });

            // Object CompanyInformationVM

            CompanyInformationVM companyInformation = new CompanyInformationVM
            {
                Title = _companyInformationService.get("TITLE"),
                Address = _companyInformationService.get("ADDRESS"),
                Email = _companyInformationService.get("EMAIL"),
                PhoneNumber = _companyInformationService.get("PHONE NUMBER")
            };


            // Object Home
            HomeDTO model = new HomeDTO
            {
                AdvertisementsList = advertisementsVMList,
                ReviewsList = reviewVMlist,
                Review = new ReviewVM(),
                CompanyInformation = companyInformation,
            };

            return View(model);
        }



        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            var user = HttpContext.User;
            if (user?.Identity.IsAuthenticated == true)
            {
                await _signInManager.SignOutAsync();
            }

            return RedirectToAction("HomePage");
        }
    }
}