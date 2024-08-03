using Accountant.Data;
using Accountant.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Accountant.Controllers
{
    public class MainUserTemController : Controller
    {
        private readonly DataContextDB dbContext;
        public MainUserTemController(DataContextDB dbContext)

        {
            this.dbContext = dbContext;
        }
        public IActionResult ScreenMainUserTem(string messager = " ", string Error = " ")
        {
            ModelState.AddModelError("Messages", messager);
            ModelState.AddModelError("Error", Error);
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ScreenMainUserTem(MainUserTem model)
        {
            MainUserTem? mainUserTem = await dbContext.mainUserTem.Where(M => M.Name == model.Name).FirstOrDefaultAsync();
      
            MainUser? mainUser = await dbContext.mainUser.Where(M => M.Name == model.Name).FirstOrDefaultAsync();
            GeneralUser? generalUser = await dbContext.generalUser.Where(G => G.Name == model.Name).FirstOrDefaultAsync();
            ProgramUser? programUser = await dbContext.programUser.Where(P => P.Name == model.Name).FirstOrDefaultAsync();

            if (ModelState.IsValid)
            {
                try
                {
                    if (programUser != null)
                    {
                        ModelState.AddModelError("Name", "هذا الاسم او الباسورد موجود بلفعل");
                    }
                    else if (generalUser != null)
                    {
                        ModelState.AddModelError("Name", "هذا الاسم او الباسورد موجود بلفعل");
                    }
                    else if (mainUser != null)
                    {
                        ModelState.AddModelError("Name", "هذا الاسم او الباسورد موجود بلفعل");
                    }
                    else if (mainUserTem != null)
                    {

                        return RedirectToAction("ScreenMainUserTem", new { Error = "لقد تم تقديم طلب من قبل عن طريق هذا المستخدم" });

                    }
                    else
                    {
                        model.CreatedDate = DateTime.Now;
                        dbContext.Add(model);
                        dbContext.SaveChanges();
                        return RedirectToAction("ScreenMainUserTem", new { messager = "شكرا لك لقد تم تقديم طلبك بنجاح سيتم ارد عليك خلال 48 ساعة واذا لم يتم ارد يمكنك مراسلة على هذا المسنجر" });

                    }
                }
                catch 
                {
                    return RedirectToAction("ScreenMainUserTem", new { Error = "هناك مشكلة لم يعرف مصدرها وهذا ارسالة عن طريقة الكود try" });

                }
                
            }

            return View();
        }
        public IActionResult ScreenMainUserTemList()
        { 
            return View(dbContext.mainUserTem.ToList());
        }
        public async Task<IActionResult> MainUser(string Name)
        {
            MainUserTem? manUserTem = await dbContext.mainUserTem.Where(U => U.Name == Name).FirstOrDefaultAsync();
            if (ModelState.IsValid)
            {
                if (manUserTem == null)
                {

                }
                else
                {
                    MainUser mainUser = new MainUser();
                    mainUser.Name = manUserTem.Name;
                    mainUser.Name = manUserTem.Name;
                    mainUser.Confirmed = true;
                    mainUser.Password = manUserTem.Password;
                    mainUser.CreatedDate = manUserTem.CreatedDate;
                    dbContext.Add(mainUser);
                    dbContext.SaveChanges();


                    dbContext.Remove(manUserTem);
                    dbContext.SaveChanges();
                    HttpContext.Session.SetString("CountMainUserTem", dbContext.mainUserTem.Count().ToString());
                    return RedirectToAction("ScreenMainUserTemList");
                }


                return RedirectToAction("ScreenMainUserTemList");
            }
            return RedirectToAction("ScreenMainUserTemList");
        }

    }
}
