using Accountant.Data;
using Accountant.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Accountant.Controllers
{
    public class MainUserController : Controller
    {
        private readonly DataContextDB dbContext;

        public MainUserController(DataContextDB dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IActionResult> ScreenMainUser( string Error)
        {
            ViewBag.Error = Error;
            return View(await dbContext.mainUser.ToListAsync());
        }
        public IActionResult ScreenAddMainUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ScreenAddMainUser(MainUser model)
        {
            MainUserTem? mainUserTem = await dbContext.mainUserTem.Where(M => M.Name == model.Name).FirstOrDefaultAsync();
            MainUser? mainUser = await dbContext.mainUser.Where(M => M.Name == model.Name).FirstOrDefaultAsync();
            ProgramUser? programUser = await dbContext.programUser.Where(P => P.Name == model.Name).FirstOrDefaultAsync();
            GeneralUser? generalUser = await dbContext.generalUser.Where(G => G.Name == model.Name).FirstOrDefaultAsync();
            if (ModelState.IsValid)
            {
                if (mainUserTem != null)
                {
                    ModelState.AddModelError("Name", "هذا الاسم موجود في انتضارك في المواقه عليها في صفحه الموافقة");
                }
                else if (mainUser != null)
                {
                    ModelState.AddModelError("Name", "هذا الاسم او الباسورد موجود بلفعل");
                }

                else if (programUser != null)
                {
                    ModelState.AddModelError("Name", "هذا الاسم او الباسورد موجود بلفعل");
                }
                else if (generalUser != null)
                {
                    ModelState.AddModelError("Name", "هذا الاسم او الباسورد موجود بلفعل");
                }
                else
                {
                    model.CreatedDate = DateTime.Now;
                     
                    model.Confirmed = true;
                    dbContext.Add(model);
                    dbContext.SaveChanges();
                    return RedirectToAction("ScreenMainUser");
                }
            }
                    return View();
        }
        public async Task<IActionResult> ScreenEditMainUser(int Id)
        {
            MainUser? mainUser = await dbContext.mainUser.Where(G => G.Id == Id).FirstOrDefaultAsync();
            return View(mainUser);
        }
        [HttpPost]
        public async Task<IActionResult> ScreenEditMainUser(MainUser model)
        {
            MainUser? mainUser = await dbContext.mainUser.Where(M => M.Id == model.Id).FirstOrDefaultAsync();
            //
            MainUserTem? mainUserTem = await dbContext.mainUserTem.Where(M => M.Name == model.Name).FirstOrDefaultAsync(); 
            ProgramUser? programUser = await dbContext.programUser.Where(P => P.Name == model.Name).FirstOrDefaultAsync();
            GeneralUser? generalUser = await dbContext.generalUser.Where(G => G.Name == model.Name).FirstOrDefaultAsync();
            if (ModelState.IsValid)
            {
                if (mainUser != null)
                {
                    if (mainUser.Name != model.Name || mainUser.Password != model.Password)
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
                        else if (programUser != null)
                        {
                            ModelState.AddModelError("Name", "هذا الاسم محجوز لا يمكن استخدامه");
                            return View();
                        }
                        else if (mainUser != null)
                        {
                            MainUser? mainUserName = await dbContext.mainUser.Where(M => M.Name == model.Name).FirstOrDefaultAsync();
                             
                            if (mainUser.Name != model.Name || mainUser.Password != model.Password)
                            {
                                if (mainUserName != null)
                                {
                                    if(mainUser.Name == model.Name)
                                    {
                                        mainUser.Name = model.Name;
                                        mainUser.Password = model.Password;
                                        dbContext.Update(mainUser);
                                        dbContext.SaveChanges();
                                        return RedirectToAction("ScreenMainUser");
                                    }
                                    else
                                    {
                                        
                                            ModelState.AddModelError("Name", "هذا الاسم محجوز لا يمكن استخدامه");
                                        

                                    }
                                }
                                else
                                {
                                    mainUser.Name = model.Name;
                                    mainUser.Password = model.Password;
                                    dbContext.Update(mainUser);
                                    dbContext.SaveChanges();
                                    return RedirectToAction("ScreenMainUser");
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
                        return RedirectToAction("ScreenMainUser");

                    }
                }
                 
                 
                
                 
            }
            return View();
        }
        public async Task<IActionResult> EditConfirmedMainUser(int ID)
        {
            MainUser? mainUser = await dbContext.mainUser.Where(G => G.Id == ID).FirstOrDefaultAsync();

            if (mainUser != null)
            {
                if (mainUser?.Confirmed == true)
                {
                    mainUser.Confirmed = false;
                    dbContext.Update(mainUser);
                    dbContext.SaveChanges();
                }
                else if (mainUser?.Confirmed == false)
                {
                    mainUser.Confirmed = true;
                    dbContext.Update(mainUser);
                    dbContext.SaveChanges();
                }
            }


            return RedirectToAction("ScreenMainUser");
        }
        public async Task<IActionResult> DeleteMainUser(int ID)
        {// يجب عمل شروط من اجل البيانات المرطبته
            MainUser? mainUser = await dbContext.mainUser.Where(G => G.Id == ID).FirstOrDefaultAsync();

            if (mainUser != null)
            {
                GeneralUser? generalUser = await dbContext.generalUser.Where(G => G.IDMainUser == mainUser.Id).FirstOrDefaultAsync();
                Car? car  = await dbContext.car.Where(G => G.IDMainUser == mainUser.Id).FirstOrDefaultAsync();
                int count = await dbContext.generalUser.Where(G => G.IDMainUser == mainUser.Id).CountAsync();
                int countCar = await dbContext.car.Where(G => G.IDMainUser == mainUser.Id).CountAsync();

                if (generalUser == null)
                    {
                    if (car == null)
                    {
                        dbContext.Remove(mainUser);
                        dbContext.SaveChanges();
                    }
                    else
                    {
                        return RedirectToAction("ScreenMainUser", new { Error = "لا يمكن خذف هذا المستخدم بسبب ان هناك بيانات في ملف المركبات ويوجد "+ countCar + " من البيانات مرتبطة في هذا المستخدم يرجى اول خذف البيانات في مجلد المركبات" });


                    }

                }
                    else
                    { 
                        return RedirectToAction("ScreenMainUser", new { Error = "لا يمكن حذف هذا المستخدم بسبب ان هناك "+ count +" من مستخدمين مرتبطين مع هذا المستخدم" });

                    }
                }
            



            return RedirectToAction("ScreenMainUser");
        }

    }
}
