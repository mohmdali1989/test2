    //========================================================================================================
    function checkAllCheckboxes(prefix, checked) {
    // Get all the checkboxes with the given prefix.
    const checkboxes = document.querySelectorAll(`input[type="checkbox"][id^="${prefix}"]`);

    // Set the checked property of all the checkboxes.
    for (const checkbox of checkboxes) {checkbox.checked = checked;}}

    // Check all the checkboxes when the MainUserAlii checkbox is checked.
    document.getElementById('MainUserAlii').addEventListener('change', () => {
    checkAllCheckboxes('Briefs', document.getElementById('MainUserAlii').checked);
    checkAllCheckboxes('Car', document.getElementById('MainUserAlii').checked);
    checkAllCheckboxes('CarInsurance', document.getElementById('MainUserAlii').checked);
    checkAllCheckboxes('CarLicense', document.getElementById('MainUserAlii').checked);
    checkAllCheckboxes('CompanyDebts', document.getElementById('MainUserAlii').checked);
    checkAllCheckboxes('CompanyObligations', document.getElementById('MainUserAlii').checked);
    checkAllCheckboxes('Contracts', document.getElementById('MainUserAlii').checked);
    checkAllCheckboxes('CustomerDebts', document.getElementById('MainUserAlii').checked);
    checkAllCheckboxes('Driver', document.getElementById('MainUserAlii').checked);
    checkAllCheckboxes('Expenses', document.getElementById('MainUserAlii').checked);
    checkAllCheckboxes('Fuel', document.getElementById('MainUserAlii').checked);
    checkAllCheckboxes('Memo', document.getElementById('MainUserAlii').checked);
    checkAllCheckboxes('Monthly', document.getElementById('MainUserAlii').checked);
    checkAllCheckboxes('Payments', document.getElementById('MainUserAlii').checked);
    checkAllCheckboxes('RepairWorkshops', document.getElementById('MainUserAlii').checked);
    checkAllCheckboxes('SparePartsCenters', document.getElementById('MainUserAlii').checked);
    checkAllCheckboxes('WorkCompanies', document.getElementById('MainUserAlii').checked);
    checkAllCheckboxes('WorkDiary', document.getElementById('MainUserAlii').checked);
      

    checkAllCheckboxes('DriversDiary', document.getElementById('MainUserAlii').checked);
    checkAllCheckboxes('FuelProvider', document.getElementById('MainUserAlii').checked);
    checkAllCheckboxes('InputCompany', document.getElementById('MainUserAlii').checked);
    checkAllCheckboxes('TrafficViolations', document.getElementById('MainUserAlii').checked);
    checkAllCheckboxes('ReportscCar', document.getElementById('MainUserAlii').checked);
    });

    //========================================================================================================
    //========================================================================================================


    //===================================================================
    var MainUser = document.getElementById("MainUser");
    MainUser.addEventListener("change", function () {
    if (MainUser.checked) {
        document.getElementById("DriversDiary").checked = true;
        document.getElementById("DriversDiaryAdd").checked = true;
        document.getElementById("DriversDiaryEdit").checked = true;
        document.getElementById("DriversDiaryDelete").checked = true;
        //================ 
        document.getElementById("FuelProvider").checked = true;
        document.getElementById("FuelProviderAdd").checked = true;
        document.getElementById("FuelProviderEdit").checked = true;
        document.getElementById("FuelProviderDelete").checked = true;
        //================ 
        document.getElementById("InputCompany").checked = true;
        document.getElementById("InputCompanyAdd").checked = true;
        document.getElementById("InputCompanyEdit").checked = true;
        document.getElementById("InputCompanyDelete").checked = true;
        //================ 
        document.getElementById("TrafficViolations").checked = true;
        document.getElementById("TrafficViolationsAdd").checked = true;
        document.getElementById("TrafficViolationsEdit").checked = true;
        document.getElementById("TrafficViolationsDelete").checked = true;
        //================
        document.getElementById("ReportscCar").checked = true;
        document.getElementById("ReportscCarAdd").checked = true;
        document.getElementById("ReportscCarEdit").checked = true;
        document.getElementById("ReportscCarDelete").checked = true;
        //================




        document.getElementById("Briefs").checked = true;
        document.getElementById("BriefsAdd").checked = true;
        document.getElementById("BriefsEdit").checked = true;
        document.getElementById("BriefsDelete").checked = true;
        //================
        document.getElementById("Car").checked = true;
        document.getElementById("CarAdd").checked = true;
        document.getElementById("CarEdit").checked = true;
        document.getElementById("CarDelete").checked = true;
        //================
        document.getElementById("CarInsurance").checked = true;
        document.getElementById("CarInsuranceAdd").checked = true;
        document.getElementById("CarInsuranceEdit").checked = true;
        document.getElementById("CarInsuranceDelete").checked = true;
        //================
        document.getElementById("CarLicense").checked = true;
        document.getElementById("CarLicenseAdd").checked = true;
        document.getElementById("CarLicenseEdit").checked = true;
        document.getElementById("CarLicenseDelete").checked = true;
        //================

        document.getElementById("CompanyDebts").checked = false;
        document.getElementById("CompanyDebtsAdd").checked = false;
        document.getElementById("CompanyDebtsEdit").checked = false;
        document.getElementById("CompanyDebtsDelete").checked = false;
        //================
        document.getElementById("CompanyObligations").checked = true;
        document.getElementById("CompanyObligationsAdd").checked = true;
        document.getElementById("CompanyObligationsEdit").checked = true;
        document.getElementById("CompanyObligationsDelete").checked = true;
        //================
        document.getElementById("Contracts").checked = false;
        document.getElementById("ContractsAdd").checked = false;
        document.getElementById("ContractsEdit").checked = false;
        document.getElementById("ContractsDelete").checked = false;
        //================
        document.getElementById("CustomerDebts").checked = true;
        document.getElementById("CustomerDebtsAdd").checked = true;
        document.getElementById("CustomerDebtsEdit").checked = true;
        document.getElementById("CustomerDebtsDelete").checked = true;
        //================
        document.getElementById("Driver").checked = true;
        document.getElementById("DriverAdd").checked = true;
        document.getElementById("DriverEdit").checked = true;
        document.getElementById("DriverDelete").checked = true;
        //================
        document.getElementById("Expenses").checked = true;
        document.getElementById("ExpensesAdd").checked = true;
        document.getElementById("ExpensesEdit").checked = true;
        document.getElementById("ExpensesDelete").checked = true;
        //================
        document.getElementById("Fuel").checked = true;
        document.getElementById("FuelAdd").checked = true;
        document.getElementById("FuelEdit").checked = true;
        document.getElementById("FuelDelete").checked = true;
        //================
        document.getElementById("GeneralUsers").checked = false;
        document.getElementById("GeneralUsersAdd").checked = false;
        document.getElementById("GeneralUsersEdit").checked = false;
        document.getElementById("GeneralUsersDelete").checked = false;
        //================
        document.getElementById("Memo").checked = true;
        document.getElementById("MemoAdd").checked = true;
        document.getElementById("MemoEdit").checked = true;
        document.getElementById("MemoDelete").checked = true;
        //================
        document.getElementById("Monthly").checked = true;
        document.getElementById("MonthlyAdd").checked = true;
        document.getElementById("MonthlyEdit").checked = true;
        document.getElementById("MonthlyDelete").checked = true;
        //================
        document.getElementById("Payments").checked = true;
        document.getElementById("PaymentsAdd").checked = true;
        document.getElementById("PaymentsEdit").checked = true;
        document.getElementById("PaymentsDelete").checked = true;
        //================
        document.getElementById("RepairWorkshops").checked = true;
        document.getElementById("RepairWorkshopsAdd").checked = true;
        document.getElementById("RepairWorkshopsEdit").checked = true;
        document.getElementById("RepairWorkshopsDelete").checked = true;
        //================
        document.getElementById("SparePartsCenters").checked = true;
        document.getElementById("SparePartsCentersAdd").checked = true;
        document.getElementById("SparePartsCentersEdit").checked = true;
        document.getElementById("SparePartsCentersDelete").checked = true;
        //================
        document.getElementById("WorkCompanies").checked = true;
        document.getElementById("WorkCompaniesAdd").checked = true;
        document.getElementById("WorkCompaniesEdit").checked = true;
        document.getElementById("WorkCompaniesDelete").checked = true;
        //================
        document.getElementById("WorkDiary").checked = true;
        document.getElementById("WorkDiaryAdd").checked = true;
        document.getElementById("WorkDiaryEdit").checked = true;
        document.getElementById("WorkDiaryDelete").checked = true;
        //================
        }
    else
    {
        document.getElementById("DriversDiary").checked = false;
        document.getElementById("DriversDiaryAdd").checked = false;
        document.getElementById("DriversDiaryEdit").checked = false;
        document.getElementById("DriversDiaryDelete").checked = false;
        //================ 
        document.getElementById("FuelProvider").checked = false;
        document.getElementById("FuelProviderAdd").checked = false;
        document.getElementById("FuelProviderEdit").checked = false;
        document.getElementById("FuelProviderDelete").checked = false;
        //================ 
        document.getElementById("InputCompany").checked = false;
        document.getElementById("InputCompanyAdd").checked = false;
        document.getElementById("InputCompanyEdit").checked = false;
        document.getElementById("InputCompanyDelete").checked = false;
        //================ 
        document.getElementById("TrafficViolations").checked = false;
        document.getElementById("TrafficViolationsAdd").checked = false;
        document.getElementById("TrafficViolationsEdit").checked = false;
        document.getElementById("TrafficViolationsDelete").checked = false;
        //================
        document.getElementById("ReportscCar").checked = false;
        document.getElementById("ReportscCarAdd").checked = false;
        document.getElementById("ReportscCarEdit").checked = false;
        document.getElementById("ReportscCarDelete").checked = false;
        //================


        document.getElementById("Briefs").checked = false;
        document.getElementById("BriefsAdd").checked = false;
        document.getElementById("BriefsEdit").checked = false;
        document.getElementById("BriefsDelete").checked = false;
        //================
        document.getElementById("Car").checked = false;
        document.getElementById("CarAdd").checked = false;
        document.getElementById("CarEdit").checked = false;
        document.getElementById("CarDelete").checked = false;
        //================
        document.getElementById("CarInsurance").checked = false;
        document.getElementById("CarInsuranceAdd").checked = false;
        document.getElementById("CarInsuranceEdit").checked = false;
        document.getElementById("CarInsuranceDelete").checked = false;
        //================
        document.getElementById("CarLicense").checked = false;
        document.getElementById("CarLicenseAdd").checked = false;
        document.getElementById("CarLicenseEdit").checked = false;
        document.getElementById("CarLicenseDelete").checked = false;
        //================
        Company
        document.getElementById("CompanyDebts").checked = false;
        document.getElementById("CompanyDebtsAdd").checked = false;
        document.getElementById("CompanyDebtsEdit").checked = false;
        document.getElementById("CompanyDebtsDelete").checked = false;
        //================
        document.getElementById("CompanyObligations").checked = false;
        document.getElementById("CompanyObligationsAdd").checked = false;
        document.getElementById("CompanyObligationsEdit").checked = false;
        document.getElementById("CompanyObligationsDelete").checked = false;
        //================
        document.getElementById("Contracts").checked = false;
        document.getElementById("ContractsAdd").checked = false;
        document.getElementById("ContractsEdit").checked = false;
        document.getElementById("ContractsDelete").checked = false;
        //================
        document.getElementById("CustomerDebts").checked = false;
        document.getElementById("CustomerDebtsAdd").checked = false;
        document.getElementById("CustomerDebtsEdit").checked = false;
        document.getElementById("CustomerDebtsDelete").checked = false;
        //================
        document.getElementById("Driver").checked = false;
        document.getElementById("DriverAdd").checked = false;
        document.getElementById("DriverEdit").checked = false;
        document.getElementById("DriverDelete").checked = false;
        //================
        document.getElementById("Expenses").checked = false;
        document.getElementById("ExpensesAdd").checked = false;
        document.getElementById("ExpensesEdit").checked = false;
        document.getElementById("ExpensesDelete").checked = false;
        //================
        document.getElementById("Fuel").checked = false;
        document.getElementById("FuelAdd").checked = false;
        document.getElementById("FuelEdit").checked = false;
        document.getElementById("FuelDelete").checked = false;
        //================
        document.getElementById("GeneralUsers").checked = false;
        document.getElementById("GeneralUsersAdd").checked = false;
        document.getElementById("GeneralUsersEdit").checked = false;
        document.getElementById("GeneralUsersDelete").checked = false;
        //================
        document.getElementById("Memo").checked = false;
        document.getElementById("MemoAdd").checked = false;
        document.getElementById("MemoEdit").checked = false;
        document.getElementById("MemoDelete").checked = false;
        //================
        document.getElementById("Monthly").checked = false;
        document.getElementById("MonthlyAdd").checked = false;
        document.getElementById("MonthlyEdit").checked = false;
        document.getElementById("MonthlyDelete").checked = false;
        //================
        document.getElementById("Payments").checked = false;
        document.getElementById("PaymentsAdd").checked = false;
        document.getElementById("PaymentsEdit").checked = false;
        document.getElementById("PaymentsDelete").checked = false;
        //================
        document.getElementById("RepairWorkshops").checked = false;
        document.getElementById("RepairWorkshopsAdd").checked = false;
        document.getElementById("RepairWorkshopsEdit").checked = false;
        document.getElementById("RepairWorkshopsDelete").checked = false;
        //================
        document.getElementById("SparePartsCenters").checked = false;
        document.getElementById("SparePartsCentersAdd").checked = false;
        document.getElementById("SparePartsCentersEdit").checked = false;
        document.getElementById("SparePartsCentersDelete").checked = false;
        //================
        document.getElementById("WorkCompanies").checked = false;
        document.getElementById("WorkCompaniesAdd").checked = false;
        document.getElementById("WorkCompaniesEdit").checked = false;
        document.getElementById("WorkCompaniesDelete").checked = false;
        //================
        document.getElementById("WorkDiary").checked = false;
        document.getElementById("WorkDiaryAdd").checked = false;
        document.getElementById("WorkDiaryEdit").checked = false;
        document.getElementById("WorkDiaryDelete").checked = false;
                //================
        }
    }
    );

    //===================================================================
    var User = document.getElementById("User");
    User.addEventListener("change", function () {
        if (User.checked) {
        document.getElementById("DriversDiary").checked = true;
        document.getElementById("DriversDiaryAdd").checked = false;
        document.getElementById("DriversDiaryEdit").checked = false;
        document.getElementById("DriversDiaryDelete").checked = false;
        //================  
        document.getElementById("FuelProvider").checked = true;
        document.getElementById("FuelProviderAdd").checked = false;
        document.getElementById("FuelProviderEdit").checked = false;
        document.getElementById("FuelProviderDelete").checked = false;
        //================ 
        document.getElementById("InputCompany").checked = true;
        document.getElementById("InputCompanyAdd").checked = false;
        document.getElementById("InputCompanyEdit").checked = false;
        document.getElementById("InputCompanyDelete").checked = false;
        //================ 
        document.getElementById("TrafficViolations").checked = true;
        document.getElementById("TrafficViolationsAdd").checked = false;
        document.getElementById("TrafficViolationsEdit").checked = false;
        document.getElementById("TrafficViolationsDelete").checked = false;
        //================
        document.getElementById("ReportscCar").checked = true;
        document.getElementById("ReportscCarAdd").checked = false;
        document.getElementById("ReportscCarEdit").checked = false;
        document.getElementById("ReportscCarDelete").checked = false;
        //================
        document.getElementById("Briefs").checked = true;
        document.getElementById("BriefsAdd").checked = true;
        document.getElementById("BriefsEdit").checked = true;
        document.getElementById("BriefsDelete").checked = true;
        //================
        document.getElementById("Car").checked = true;
        document.getElementById("CarAdd").checked = false;
        document.getElementById("CarEdit").checked = false;
        document.getElementById("CarDelete").checked = false;
        //================
        document.getElementById("CarInsurance").checked = true;
        document.getElementById("CarInsuranceAdd").checked = false;
        document.getElementById("CarInsuranceEdit").checked = false;
        document.getElementById("CarInsuranceDelete").checked = false;
        //================
        document.getElementById("CarLicense").checked = true;
        document.getElementById("CarLicenseAdd").checked = false;
        document.getElementById("CarLicenseEdit").checked = false;
        document.getElementById("CarLicenseDelete").checked = false;
        //================
        document.getElementById("Companys").checked = false;
        document.getElementById("CompanysAdd").checked = false;
        document.getElementById("CompanysEdit").checked = false;
        document.getElementById("CompanysDelete").checked = false;
        //================
        document.getElementById("CompanyDebts").checked = false;
        document.getElementById("CompanyDebtsAdd").checked = false;
        document.getElementById("CompanyDebtsEdit").checked = false;
        document.getElementById("CompanyDebtsDelete").checked = false;
        //================
        document.getElementById("CompanyObligations").checked = true;
        document.getElementById("CompanyObligationsAdd").checked = false;
        document.getElementById("CompanyObligationsEdit").checked = false;
        document.getElementById("CompanyObligationsDelete").checked = false;
        //================
        document.getElementById("Contracts").checked = false;
        document.getElementById("ContractsAdd").checked = false;
        document.getElementById("ContractsEdit").checked = false;
        document.getElementById("ContractsDelete").checked = false;
        //================
        document.getElementById("CustomerDebts").checked = true;
        document.getElementById("CustomerDebtsAdd").checked = true;
        document.getElementById("CustomerDebtsEdit").checked = true;
        document.getElementById("CustomerDebtsDelete").checked = true;
        //================
        document.getElementById("Driver").checked = true;
        document.getElementById("DriverAdd").checked = true;
        document.getElementById("DriverEdit").checked = true;
        document.getElementById("DriverDelete").checked = true;
        //================
        document.getElementById("Expenses").checked = true;
        document.getElementById("ExpensesAdd").checked = true;
        document.getElementById("ExpensesEdit").checked = true;
        document.getElementById("ExpensesDelete").checked = true;
        //================
        document.getElementById("Fuel").checked = true;
        document.getElementById("FuelAdd").checked = true;
        document.getElementById("FuelEdit").checked = true;
        document.getElementById("FuelDelete").checked = true;
        //================
        document.getElementById("GeneralUsers").checked = false;
        document.getElementById("GeneralUsersAdd").checked = false;
        document.getElementById("GeneralUsersEdit").checked = false;
        document.getElementById("GeneralUsersDelete").checked = false;
        //================
        document.getElementById("Memo").checked = true;
        document.getElementById("MemoAdd").checked = true;
        document.getElementById("MemoEdit").checked = true;
        document.getElementById("MemoDelete").checked = true;
        //================
        document.getElementById("Monthly").checked = true;
        document.getElementById("MonthlyAdd").checked = true;
        document.getElementById("MonthlyEdit").checked = true;
        document.getElementById("MonthlyDelete").checked = true;
        //================
        document.getElementById("Payments").checked = true;
        document.getElementById("PaymentsAdd").checked = true;
        document.getElementById("PaymentsEdit").checked = true;
        document.getElementById("PaymentsDelete").checked = true;
        //================
        document.getElementById("RepairWorkshops").checked = false;
        document.getElementById("RepairWorkshopsAdd").checked = false;
        document.getElementById("RepairWorkshopsEdit").checked = false;
        document.getElementById("RepairWorkshopsDelete").checked = false;
        //================
        document.getElementById("SparePartsCenters").checked = true;
        document.getElementById("SparePartsCentersAdd").checked = true;
        document.getElementById("SparePartsCentersEdit").checked = true;
        document.getElementById("SparePartsCentersDelete").checked = true;
        //================
        document.getElementById("WorkCompanies").checked = false;
        document.getElementById("WorkCompaniesAdd").checked = false;
        document.getElementById("WorkCompaniesEdit").checked = false;
        document.getElementById("WorkCompaniesDelete").checked = false;
        //================
        document.getElementById("WorkDiary").checked = true;
        document.getElementById("WorkDiaryAdd").checked = false;
        document.getElementById("WorkDiaryEdit").checked = false;
        document.getElementById("WorkDiaryDelete").checked = false;
        //================
        }
        else
        {
        document.getElementById("DriversDiary").checked = false;
        document.getElementById("DriversDiaryAdd").checked = false;
        document.getElementById("DriversDiaryEdit").checked = false;
        document.getElementById("DriversDiaryDelete").checked = false;
        //================   
        document.getElementById("FuelProvider").checked = false;
        document.getElementById("FuelProviderAdd").checked = false;
        document.getElementById("FuelProviderEdit").checked = false;
        document.getElementById("FuelProviderDelete").checked = false;
        //================ 
        document.getElementById("InputCompany").checked = false;
        document.getElementById("InputCompanyAdd").checked = false;
        document.getElementById("InputCompanyEdit").checked = false;
        document.getElementById("InputCompanyDelete").checked = false;
        //================ 
        document.getElementById("TrafficViolations").checked = false;
        document.getElementById("TrafficViolationsAdd").checked = false;
        document.getElementById("TrafficViolationsEdit").checked = false;
        document.getElementById("TrafficViolationsDelete").checked = false;
        //================
        document.getElementById("ReportscCar").checked = false;
        document.getElementById("ReportscCarAdd").checked = false;
        document.getElementById("ReportscCarEdit").checked = false;
        document.getElementById("ReportscCarDelete").checked = false;
        //================
        document.getElementById("Briefs").checked = false;
        document.getElementById("BriefsAdd").checked = false;
        document.getElementById("BriefsEdit").checked = false;
        document.getElementById("BriefsDelete").checked = false;
        //================
        document.getElementById("Car").checked = false;
        document.getElementById("CarAdd").checked = false;
        document.getElementById("CarEdit").checked = false;
        document.getElementById("CarDelete").checked = false;
        //================
        document.getElementById("CarInsurance").checked = false;
        document.getElementById("CarInsuranceAdd").checked = false;
        document.getElementById("CarInsuranceEdit").checked = false;
        document.getElementById("CarInsuranceDelete").checked = false;
        //================
        document.getElementById("CarLicense").checked = false;
        document.getElementById("CarLicenseAdd").checked = false;
        document.getElementById("CarLicenseEdit").checked = false;
        document.getElementById("CarLicenseDelete").checked = false;
        //================
        document.getElementById("Companys").checked = false;
        document.getElementById("CompanysAdd").checked = false;
        document.getElementById("CompanysEdit").checked = false;
        document.getElementById("CompanysDelete").checked = false;
        //================
        document.getElementById("CompanyDebts").checked = false;
        document.getElementById("CompanyDebtsAdd").checked = false;
        document.getElementById("CompanyDebtsEdit").checked = false;
        document.getElementById("CompanyDebtsDelete").checked = false;
        //================
        document.getElementById("CompanyObligations").checked = false;
        document.getElementById("CompanyObligationsAdd").checked = false;
        document.getElementById("CompanyObligationsEdit").checked = false;
        document.getElementById("CompanyObligationsDelete").checked = false;
        //================
        document.getElementById("Contracts").checked = false;
        document.getElementById("ContractsAdd").checked = false;
        document.getElementById("ContractsEdit").checked = false;
        document.getElementById("ContractsDelete").checked = false;
        //================
        document.getElementById("CustomerDebts").checked = false;
        document.getElementById("CustomerDebtsAdd").checked = false;
        document.getElementById("CustomerDebtsEdit").checked = false;
        document.getElementById("CustomerDebtsDelete").checked = false;
        //================
        document.getElementById("Driver").checked = false;
        document.getElementById("DriverAdd").checked = false;
        document.getElementById("DriverEdit").checked = false;
        document.getElementById("DriverDelete").checked = false;
        //================
        document.getElementById("Expenses").checked = false;
        document.getElementById("ExpensesAdd").checked = false;
        document.getElementById("ExpensesEdit").checked = false;
        document.getElementById("ExpensesDelete").checked = false;
        //================
        document.getElementById("Fuel").checked = false;
        document.getElementById("FuelAdd").checked = false;
        document.getElementById("FuelEdit").checked = false;
        document.getElementById("FuelDelete").checked = false;
        //================
        document.getElementById("GeneralUsers").checked = false;
        document.getElementById("GeneralUsersAdd").checked = false;
        document.getElementById("GeneralUsersEdit").checked = false;
        document.getElementById("GeneralUsersDelete").checked = false;
        //================
        document.getElementById("Memo").checked = false;
        document.getElementById("MemoAdd").checked = false;
        document.getElementById("MemoEdit").checked = false;
        document.getElementById("MemoDelete").checked = false;
        //================
        document.getElementById("Monthly").checked = false;
        document.getElementById("MonthlyAdd").checked = false;
        document.getElementById("MonthlyEdit").checked = false;
        document.getElementById("MonthlyDelete").checked = false;
        //================
        document.getElementById("Payments").checked = false;
        document.getElementById("PaymentsAdd").checked = false;
        document.getElementById("PaymentsEdit").checked = false;
        document.getElementById("PaymentsDelete").checked = false;
        //================
        document.getElementById("RepairWorkshops").checked = false;
        document.getElementById("RepairWorkshopsAdd").checked = false;
        document.getElementById("RepairWorkshopsEdit").checked = false;
        document.getElementById("RepairWorkshopsDelete").checked = false;
        //================
        document.getElementById("SparePartsCenters").checked = false;
        document.getElementById("SparePartsCentersAdd").checked = false;
        document.getElementById("SparePartsCentersEdit").checked = false;
        document.getElementById("SparePartsCentersDelete").checked = false;
        //================
        document.getElementById("WorkCompanies").checked = false;
        document.getElementById("WorkCompaniesAdd").checked = false;
        document.getElementById("WorkCompaniesEdit").checked = false;
        document.getElementById("WorkCompaniesDelete").checked = false;
        //================
        document.getElementById("WorkDiary").checked = false;
        document.getElementById("WorkDiaryAdd").checked = false;
        document.getElementById("WorkDiaryEdit").checked = false;
        document.getElementById("WorkDiaryDelete").checked = false;
                //================
        }

    }

   
  
 
 
 
 
 );
//==============================================================================================================================
var DriversDiary = document.getElementById("DriversDiary");
DriversDiary.addEventListener("change", function () {
    if (DriversDiary.checked) { } else { document.getElementById("DriversDiaryAdd").checked = false; document.getElementById("DriversDiaryEdit").checked = false; document.getElementById("DriversDiaryDelete").checked = false; }
});
function DriversDiaryCheckboxChange(event) { document.querySelector('#DriversDiary').checked = true; }
document.querySelectorAll('#DriversDiaryAdd, #DriversDiaryEdit, #DriversDiaryDelete').forEach(function (button) {
    button.addEventListener('change', DriversDiaryCheckboxChange);
});
//==============================================================================================================================



var FuelProvider = document.getElementById("FuelProvider");
FuelProvider.addEventListener("change", function () {
    if (FuelProvider.checked) { } else { document.getElementById("FuelProviderAdd").checked = false; document.getElementById("FuelProviderEdit").checked = false; document.getElementById("FuelProviderDelete").checked = false; }
});
function FuelProviderCheckboxChange(event) { document.querySelector('#FuelProvider').checked = true; }
document.querySelectorAll('#FuelProviderAdd, #FuelProviderEdit, #FuelProviderDelete').forEach(function (button) {
    button.addEventListener('change', FuelProviderCheckboxChange);
});
//==============================================================================================================================


var InputCompany = document.getElementById("InputCompany");
InputCompany.addEventListener("change", function () {
    if (InputCompany.checked) { } else { document.getElementById("InputCompanyAdd").checked = false; document.getElementById("InputCompanyEdit").checked = false; document.getElementById("InputCompanyDelete").checked = false; }
});
function InputCompanyCheckboxChange(event) { document.querySelector('#InputCompany').checked = true; }
document.querySelectorAll('#InputCompanyAdd, #InputCompanyEdit, #InputCompanyDelete').forEach(function (button) {
    button.addEventListener('change', InputCompanyCheckboxChange);
});
//==============================================================================================================================
var TrafficViolations = document.getElementById("TrafficViolations");
TrafficViolations.addEventListener("change", function () {
    if (TrafficViolations.checked) { } else { document.getElementById("TrafficViolationsAdd").checked = false; document.getElementById("TrafficViolationsEdit").checked = false; document.getElementById("TrafficViolationsDelete").checked = false; }
});
function TrafficViolationsCheckboxChange(event) { document.querySelector('#TrafficViolations').checked = true; }
document.querySelectorAll('#TrafficViolationsAdd, #TrafficViolationsEdit, #TrafficViolationsDelete').forEach(function (button) {
    button.addEventListener('change', TrafficViolationsCheckboxChange);
});
//==============================================================================================================================
var ReportscCar = document.getElementById("ReportscCar");
ReportscCar.addEventListener("change", function () {
    if (ReportscCar.checked) { } else { document.getElementById("ReportscCarAdd").checked = false; document.getElementById("ReportscCarEdit").checked = false; document.getElementById("ReportscCarDelete").checked = false; }
});
function ReportscCarCheckboxChange(event) { document.querySelector('#ReportscCar').checked = true; }
document.querySelectorAll('#ReportscCarAdd, #ReportscCarEdit, #ReportscCarDelete').forEach(function (button) {
    button.addEventListener('change', ReportscCarCheckboxChange);
});








    //==============================================================================================================================
    var Briefs = document.getElementById("Briefs");
    Briefs.addEventListener("change", function () {if (Briefs.checked) { } else
    {document.getElementById("BriefsAdd").checked = false;document.getElementById("BriefsEdit").checked = false;document.getElementById("BriefsDelete").checked = false;}});
    function briefsCheckboxChange(event) {document.querySelector('#Briefs').checked = true;}
    document.querySelectorAll('#BriefsAdd, #BriefsEdit, #BriefsDelete').forEach(function (button)
    {
        button.addEventListener('change', briefsCheckboxChange);
    });

    //==============================================================================================================================
    var Car = document.getElementById("Car");
Car.addEventListener("change", function () {
    if (Car.checked) { } else { document.getElementById("CarAdd").checked = false; document.getElementById("CarEdit").checked = false; document.getElementById("CarDelete").checked = false; }
});
function CarCheckboxChange(event) { document.querySelector('#Car').checked = true; }
document.querySelectorAll('#CarAdd, #CarEdit, #CarDelete').forEach(function (button) {
    button.addEventListener('change', CarCheckboxChange);
});

    //==============================================================================================================================
 
var CarInsurance = document.getElementById("CarInsurance");
CarInsurance.addEventListener("change", function () {
    if (CarInsurance.checked) { } else { document.getElementById("CarInsuranceAdd").checked = false; document.getElementById("CarInsuranceEdit").checked = false; document.getElementById("CarInsuranceDelete").checked = false; }
});
function CarInsuranceCheckboxChange(event) { document.querySelector('#CarInsurance').checked = true; }
document.querySelectorAll('#CarInsuranceAdd, #CarInsuranceEdit, #CarInsuranceDelete').forEach(function (button) {
    button.addEventListener('change', CarInsuranceCheckboxChange);
});
 //==============================================================================================================================
var CarLicense = document.getElementById("CarLicense");
CarLicense.addEventListener("change", function () {
    if (CarLicense.checked) { } else { document.getElementById("CarLicenseAdd").checked = false; document.getElementById("CarLicenseEdit").checked = false; document.getElementById("CarLicenseDelete").checked = false; }
});
function CarLicenseCheckboxChange(event) { document.querySelector('#CarLicense').checked = true; }
document.querySelectorAll('#CarLicenseAdd, #CarLicenseEdit, #CarLicenseDelete').forEach(function (button) {
    button.addEventListener('change', CarLicenseCheckboxChange);
});
 //==============================================================================================================================
var CompanyDebts = document.getElementById("CompanyDebts");
CompanyDebts.addEventListener("change", function () {
    if (CompanyDebts.checked) { } else { document.getElementById("CompanyDebtsAdd").checked = false; document.getElementById("CompanyDebtsEdit").checked = false; document.getElementById("CompanyDebtsDelete").checked = false; }
});
function CompanyDebtsCheckboxChange(event) { document.querySelector('#CompanyDebts').checked = true; }
document.querySelectorAll('#CompanyDebtsAdd, #CompanyDebtsEdit, #CompanyDebtsDelete').forEach(function (button) {
    button.addEventListener('change', CompanyDebtsCheckboxChange);
});
 //==============================================================================================================================
var CompanyObligations = document.getElementById("CompanyObligations");
CompanyObligations.addEventListener("change", function () {
    if (CompanyObligations.checked) { } else { document.getElementById("CompanyObligationsAdd").checked = false; document.getElementById("CompanyObligationsEdit").checked = false; document.getElementById("CompanyObligationsDelete").checked = false; }
});
function CompanyObligationsCheckboxChange(event) { document.querySelector('#CompanyObligations').checked = true; }
document.querySelectorAll('#CompanyObligationsAdd, #CompanyObligationsEdit, #CompanyObligationsDelete').forEach(function (button) {
    button.addEventListener('change', CompanyObligationsCheckboxChange);
});
 //==============================================================================================================================
var Contracts = document.getElementById("Contracts");
Contracts.addEventListener("change", function () {
    if (Contracts.checked) { } else { document.getElementById("ContractsAdd").checked = false; document.getElementById("ContractsEdit").checked = false; document.getElementById("ContractsDelete").checked = false; }
});
function ContractsCheckboxChange(event) { document.querySelector('#Contracts').checked = true; }
document.querySelectorAll('#ContractsAdd, #ContractsEdit, #ContractsDelete').forEach(function (button) {
    button.addEventListener('change', ContractsCheckboxChange);
});
 //==============================================================================================================================
var CustomerDebts = document.getElementById("CustomerDebts");
CustomerDebts.addEventListener("change", function () {
    if (CustomerDebts.checked) { } else { document.getElementById("CustomerDebtsAdd").checked = false; document.getElementById("CustomerDebtsEdit").checked = false; document.getElementById("CustomerDebtsDelete").checked = false; }
});
function CustomerDebtsCheckboxChange(event) { document.querySelector('#CustomerDebts').checked = true; }
document.querySelectorAll('#CustomerDebtsAdd, #CustomerDebtsEdit, #CustomerDebtsDelete').forEach(function (button) {
    button.addEventListener('change', CustomerDebtsCheckboxChange);
});
 //==============================================================================================================================
var Driver = document.getElementById("Driver");
Driver.addEventListener("change", function () {
    if (Driver.checked) { } else { document.getElementById("DriverAdd").checked = false; document.getElementById("DriverEdit").checked = false; document.getElementById("DriverDelete").checked = false; }
});
function DriverCheckboxChange(event) { document.querySelector('#Driver').checked = true; }
document.querySelectorAll('#DriverAdd, #DriverEdit, #DriverDelete').forEach(function (button) {
    button.addEventListener('change', DriverCheckboxChange);
});
 //==============================================================================================================================
var Expenses = document.getElementById("Expenses");
Expenses.addEventListener("change", function () {
    if (Expenses.checked) { } else { document.getElementById("ExpensesAdd").checked = false; document.getElementById("ExpensesEdit").checked = false; document.getElementById("ExpensesDelete").checked = false; }
});
function ExpensesCheckboxChange(event) { document.querySelector('#Expenses').checked = true; }
document.querySelectorAll('#ExpensesAdd, #ExpensesEdit, #ExpensesDelete').forEach(function (button) {
    button.addEventListener('change', ExpensesCheckboxChange);
});
 //==============================================================================================================================
var Fuel = document.getElementById("Fuel");
Fuel.addEventListener("change", function () {
    if (Fuel.checked) { } else { document.getElementById("FuelAdd").checked = false; document.getElementById("FuelEdit").checked = false; document.getElementById("FuelDelete").checked = false; }
});
function FuelCheckboxChange(event) { document.querySelector('#Fuel').checked = true; }
document.querySelectorAll('#FuelAdd, #FuelEdit, #FuelDelete').forEach(function (button) {
    button.addEventListener('change', FuelCheckboxChange);
});
 //==============================================================================================================================
var Memo = document.getElementById("Memo");
Memo.addEventListener("change", function () {
    if (Memo.checked) { } else { document.getElementById("MemoAdd").checked = false; document.getElementById("MemoEdit").checked = false; document.getElementById("MemoDelete").checked = false; }
});
function MemoCheckboxChange(event) { document.querySelector('#Memo').checked = true; }
document.querySelectorAll('#MemoAdd, #MemoEdit, #MemoDelete').forEach(function (button) {
    button.addEventListener('change', MemoCheckboxChange);
});
 //==============================================================================================================================
var Monthly = document.getElementById("Monthly");
Monthly.addEventListener("change", function () {Monthly
    if (Monthly.checked) { } else { document.getElementById("MonthlyAdd").checked = false; document.getElementById("MonthlyEdit").checked = false; document.getElementById("MonthlyDelete").checked = false; }
});
function MonthlyCheckboxChange(event) { document.querySelector('#Monthly').checked = true; }
document.querySelectorAll('#MonthlyAdd, #MonthlyEdit, #MonthlyDelete').forEach(function (button) {
    button.addEventListener('change', MonthlyCheckboxChange);
});
 //==============================================================================================================================
var Payments = document.getElementById("Payments");
Payments.addEventListener("change", function () {
    if (Payments.checked) { } else { document.getElementById("PaymentsAdd").checked = false; document.getElementById("PaymentsEdit").checked = false; document.getElementById("PaymentsDelete").checked = false; }
});
function PaymentsCheckboxChange(event) { document.querySelector('#Payments').checked = true; }
document.querySelectorAll('#PaymentsAdd, #PaymentsEdit, #PaymentsDelete').forEach(function (button) {
    button.addEventListener('change', PaymentsCheckboxChange);
});
 //==============================================================================================================================
var RepairWorkshops = document.getElementById("RepairWorkshops");
RepairWorkshops.addEventListener("change", function () {
    if (RepairWorkshops.checked) { } else { document.getElementById("RepairWorkshopsAdd").checked = false; document.getElementById("RepairWorkshopsEdit").checked = false; document.getElementById("RepairWorkshopsDelete").checked = false; }
});
function RepairWorkshopsCheckboxChange(event) { document.querySelector('#RepairWorkshops').checked = true; }
document.querySelectorAll('#RepairWorkshopsAdd, #RepairWorkshopsEdit, #RepairWorkshopsDelete').forEach(function (button) {
    button.addEventListener('change', RepairWorkshopsCheckboxChange);
});
 //==============================================================================================================================
var SparePartsCenters = document.getElementById("SparePartsCenters");
SparePartsCenters.addEventListener("change", function () {
    if (SparePartsCenters.checked) { } else { document.getElementById("SparePartsCentersAdd").checked = false; document.getElementById("SparePartsCentersEdit").checked = false; document.getElementById("SparePartsCentersDelete").checked = false; }
});
function SparePartsCentersCheckboxChange(event) { document.querySelector('#SparePartsCenters').checked = true; }
document.querySelectorAll('#SparePartsCentersAdd, #SparePartsCentersEdit, #SparePartsCentersDelete').forEach(function (button) {
    button.addEventListener('change', SparePartsCentersCheckboxChange);
});
 //==============================================================================================================================
var WorkCompanies = document.getElementById("WorkCompanies");
WorkCompanies.addEventListener("change", function () {
    if (WorkCompanies.checked) { } else { document.getElementById("WorkCompaniesAdd").checked = false; document.getElementById("WorkCompaniesEdit").checked = false; document.getElementById("WorkCompaniesDelete").checked = false; }
});
function WorkCompaniesCheckboxChange(event) { document.querySelector('#WorkCompanies').checked = true; }
document.querySelectorAll('#WorkCompaniesAdd, #WorkCompaniesEdit, #WorkCompaniesDelete').forEach(function (button) {
    button.addEventListener('change', WorkCompaniesCheckboxChange);
});
 //==============================================================================================================================
var WorkDiary = document.getElementById("WorkDiary");
WorkDiary.addEventListener("change", function () {
    if (WorkDiary.checked) { } else { document.getElementById("WorkDiaryAdd").checked = false; document.getElementById("WorkDiaryEdit").checked = false; document.getElementById("WorkDiaryDelete").checked = false; }
});
function WorkDiaryCheckboxChange(event) { document.querySelector('#WorkDiary').checked = true; }
document.querySelectorAll('#WorkDiaryAdd, #WorkDiaryEdit, #WorkDiaryDelete').forEach(function (button) {
    button.addEventListener('change', WorkDiaryCheckboxChange);
});
 //==============================================================================================================================
