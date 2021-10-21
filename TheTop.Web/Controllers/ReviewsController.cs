using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheTop.Application.Entities;
using TheTop.Application.Services;
using TheTop.Application.Services.DTOs;
using TheTop.ViewModels;

namespace TheTop.Controllers
{
    
    public class ReviewsController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private readonly IReviewService _reviewService;

        public ReviewsController(UserManager<ApplicationUser> userManager, IReviewService service)
        {
            this._userManager = userManager;
            this._reviewService = service;
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Reviews()
        {
            List<ReviewDTO> reviewDtoList = _reviewService.GetAllAllReviews().ToList();

            List<ReviewVM> reviewVMlist = new List<ReviewVM>();
            reviewDtoList.ForEach(review =>
            {
                reviewVMlist.Add(new ReviewVM { 
                 Customer = new CustomerVM
                 {
                     FirstName = review.User.FirstName,
                     LastName = review.User.LastName,
                     Email = review.User.Email,
                     //ImageName = review.User.ImagName
                 },
                 Massage = review.Massage,
                 Subject = review.Subject,
                 ID = review.ID,
                 Approved = review.Approved
                });
            });
            return View(reviewVMlist);
        }

        public ActionResult Details(int id)
        {
            ReviewDTO reviewDTO = _reviewService.GetReviewById(id);
            return View(new ReviewVM {
                Customer = new CustomerVM
                {
                    FirstName = reviewDTO.User.FirstName,
                    LastName = reviewDTO.User.LastName,
                    Email = reviewDTO.User.Email,
                    //ImageName = review.User.ImagName
                },
                ID = reviewDTO.ID,
                Massage = reviewDTO.Massage,
              Subject = reviewDTO.Subject,
              Approved = reviewDTO.Approved,
            });
        }

        [Authorize]
        public ActionResult Create()
        {
            return View(new ReviewVM());
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ReviewVM reviewVM)
        {
            var user = await _userManager.GetUserAsync(User);
            if (! ModelState.IsValid)
            {               
                return RedirectToAction("HomePage", "Home");
            }
            _reviewService.CreateNewReview(new ReviewDTO
            {
                
                Massage = reviewVM.Massage,
                Subject = reviewVM.Subject,
                UserId = user.Id,
            });
            return RedirectToAction("HomePage", "Home");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ApproveReview(int id)
        {
            _reviewService.ApproveReview(id);
            return RedirectToAction("Reviews");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult DeleteReview(int id)
        {
            _reviewService.RemoveReview(id);
            return RedirectToAction("Reviews");
        }

    }
}
