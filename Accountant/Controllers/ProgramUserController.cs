using Accountant.Data;
using Accountant.Models;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;
using static System.Collections.Specialized.BitVector32;
using System;

namespace Accountant.Controllers
{
    public class ProgramUserController : Controller
    {
        private readonly DataContextDB dbContext;

       public ProgramUserController(DataContextDB dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult ScreenProgramUser()
        {
            return View();
        }
        public async Task<IActionResult> ScreenTableProgramUser(string Error)
        {
            ViewBag.Error = Error;
            return View(await dbContext.programUser.ToListAsync());
        }

        public IActionResult ScreenAddProgramUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ScreenAddProgramUser(ProgramUser model)
        {
            ProgramUser? programUser = await dbContext.programUser.Where(P => P.Name == model.Name).FirstOrDefaultAsync();
            if (ModelState.IsValid)
            {
                if (programUser == null)
                {
                    dbContext.Add(model);
                    dbContext.SaveChanges();
                    return RedirectToAction("ScreenTableProgramUser", "ProgramUser");
                }
                else
                {
                    ModelState.AddModelError("Name", "هذا الاسم موجود");
                }
            }
            return View();
        }
        public async Task<IActionResult> ScreenEditProgramUser(int id)
        {
            ProgramUser? programUser = await dbContext.programUser.Where(P => P.Id == id).FirstOrDefaultAsync();
             
            return View(programUser);
        }
        [HttpPost]
        public async Task<IActionResult> ScreenEditProgramUser(ProgramUser model)
        {
             
            ProgramUser? programUser = await dbContext.programUser.Where(P => P.Id == model.Id).FirstOrDefaultAsync();
            //
            MainUserTem? mainUserTem = await dbContext.mainUserTem.Where(M => M.Name == model.Name).FirstOrDefaultAsync();
            MainUser? mainUser = await dbContext.mainUser.Where(M => M.Name == model.Name).FirstOrDefaultAsync();
            GeneralUser? generalUser = await dbContext.generalUser.Where(G => G.Name == model.Name).FirstOrDefaultAsync();
            if (ModelState.IsValid)
            {
                if (programUser != null)
                {
                    if (programUser.Name != model.Name || programUser.Password != model.Password)
                    {
                        if (generalUser != null)
                        {
                            ModelState.AddModelError("Name", "هذا الاسم محجوز لا يمكن استخدامه");
                            return View();
                        }
                        else if (mainUserTem != null)
                        {
                            ModelState.AddModelError("Name", "هذا الاسم محجوز لا يمكن استخدامه");
                            return View();
                        }
                        else if (mainUser != null)
                        {
                            ModelState.AddModelError("Name", "هذا الاسم محجوز لا يمكن استخدامه");
                            return View();
                        }
                        else if (programUser != null)
                        {
                            ProgramUser? ProgramUserName = await dbContext.programUser.Where(M => M.Name == model.Name).FirstOrDefaultAsync();

                            if (programUser.Name != model.Name || programUser.Password != model.Password)
                            {
                                if (ProgramUserName != null)
                                {
                                    if (programUser.Name == model.Name)
                                    {
                                        programUser.Name = model.Name;
                                        programUser.Password = model.Password;
                                        dbContext.Update(programUser);
                                        dbContext.SaveChanges();
                                        return RedirectToAction("ScreenTableProgramUser");
                                    }
                                    else
                                    {

                                        ModelState.AddModelError("Name", "هذا الاسم محجوز لا يمكن استخدامه");


                                    }
                                }
                                else
                                {
                                    programUser.Name = model.Name;
                                    programUser.Password = model.Password;
                                    dbContext.Update(programUser);
                                    dbContext.SaveChanges();
                                    return RedirectToAction("ScreenTableProgramUser");
                                }


                            }

                            else
                            {
                                ModelState.AddModelError("Name", "هذا الاسم محجوز لا يمكن استخدامه");
                            }


                        }
                    }
                    else
                    {
                        return RedirectToAction("ScreenTableProgramUser");

                    }
                }




            }
            return View();
        }
        public async Task<IActionResult> DeleteProgramUser(int ID)
        {// يجب عمل شروط من اجل البيانات المرطبته
            ProgramUser? programUser = await dbContext.programUser.Where(G => G.Id == ID).FirstOrDefaultAsync();

            if (programUser != null)
            {
                int programUserCount = await dbContext.programUser.Where(G => G.Id == ID).CountAsync();

                
                    if (programUserCount > 1)
                    {
                        dbContext.Remove(programUser);
                        dbContext.SaveChanges();
                    }
                    else
                    {
                        return RedirectToAction("ScreenTableProgramUser", new { Error = "لا يمكن حذف هذا المستخدم  بسبب ان لا يوجد مستخدم بديل" });


                    }

                
                
              
            }




            return RedirectToAction("ScreenTableProgramUser");
        }

    }

}



