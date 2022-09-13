using LiveCards.Data;
using LiveCards.Models;
using LiveCards.Web.Models;
using LiveCards.Web.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LiveCards.Web.Areas.Admin.Controllers
{

    [Authorize(Roles = "Admin")]

    [Area("Admin")]

    public class PaymentsController : Controller
    {
        public ApplicationDbContext _db;
        public PaymentsController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var paymenstList = _db.Payments.Where(x => !x.IsDelete)
                 .OrderByDescending(x => DateTime.Now).ToList();
            return View(paymenstList);
        }


        [HttpGet]
        public IActionResult Create()
        {
            ViewData["PaymentsList"] = new SelectList(_db.Agents.Where(x=>x.Active).ToList()
               , "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreatePaymentViewModel input)
        {
            if (ModelState.IsValid)
            {
                var nameExist = _db.Payments.Any(x => x.Id == input.Id && !x.IsDelete);
                if (nameExist)
                {
                    TempData["msg"] = "ID is Exist...";
                    return View(input);
                }
                var payments = new Payment();
                payments.Amount = input.Amount;
                payments.ExhangeRate = input.ExhangeRate;
                payments.Date = DateTime.Now;
                payments.Note = input.Note;
                
                _db.Payments.Add(payments);
                _db.SaveChanges();
                TempData["msg"] = "Paymensts Added Succsfuly...";
                return RedirectToAction("Index");

            }
            return View(input);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var payment = _db.Payments.SingleOrDefault(x => x.Id == id && !x.IsDelete);
            if (payment == null)
                return NotFound();

            var vm = new UpdatePaymentViewModel();
            vm.Amount = payment.Amount;
            vm.ExhangeRate = payment.ExhangeRate;
            vm.Note = payment.Note;
            return View(vm);
        }
        [HttpPost]
        public IActionResult Update(UpdatePaymentViewModel input)
        {
            if (ModelState.IsValid)
            {
                var payment = _db.Payments.SingleOrDefault(x => x.Id == input.Id && !x.IsDelete);
                if (payment == null)
                    return NotFound();

                payment.Amount = input.Amount;
                payment.ExhangeRate = input.ExhangeRate;
                payment.Status = input.Status;
                payment.Note = input.Note;
                _db.Payments.Update(payment);
                _db.SaveChanges();
                TempData["msg"] = "Paymensts Updated Succsfuly...";
                return RedirectToAction("Index");
            }
            return View(input);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var paymenst = _db.Payments.SingleOrDefault(x => x.Id == id && !x.IsDelete);
            if (paymenst == null)
                return NotFound();

            paymenst.IsDelete = true;
            _db.Payments.Update(paymenst);
            _db.SaveChanges();
            TempData["msg"] = "Item Deleted Succsfuly...";
            return RedirectToAction("Index");
        }
    }
}
