/// <reference path="jquery-2.2.0.js" />
/// <reference path="knockout-3.4.0.js" />

var CustViewModel = {
    //Declaring variables and feeding default information

    Title: ko.observable("Dr"),
    IdNumber: ko.observable("123"),
    FirstName: ko.observable("Harish"),
    LastName: ko.observable("Chowdary"),
    PreferredName: ko.observable(),
    PreferredLanguage: ko.observable(),
    Gender: ko.observable(),
    NoOfDependents: ko.observable(),
    MaritalStatus: ko.observable(),
    Citizenship: ko.observable(),
    DateOfBirth: ko.observable(),
    WorkPermitExpiry: ko.observable(),
    PhoneDetails: ko.observableArray(),
    BankingDetails: ko.observableArray(),
    AddressDetails: ko.observableArray(),
    //Employment details
    EmploymentDetails: ko.observableArray(),
    SelectedEmployeeDetails: ko.observableArray(),
    //vehicle details
    VehicleDetails: ko.observableArray(),
    SelectedVehicleDetails: ko.observableArray(),

    //income and expenses
    CustomerIncomeAndExpenses: ko.observableArray(),

    //Rollovers
    CustomerRollovers: ko.observableArray(),

    //product selection
    ProductsForCustomer: ko.observableArray(),

    filterEmpDetails: null,
    filterVehicleDetails: null
};
GetCustomer();
function GetCustomer() {
    var deploymentUrlPrefix = "http://41.185.29.146/KeConcepts/Dispatcher/";
    var developmentUrlPrefix = "http://localhost/Ke.CreditEase.Dispatcher/";
    $.ajax({
        type: "GET",
        url: developmentUrlPrefix.concat("Basicinformation?id=1"),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (maindata) {
            BindData(maindata);
            //DeleteMode
            $("input[name='isProductChecked[]']").change(function () {
                $('#divContractsToRollover').attr('hidden', 'hidden');
                $("input[name='isProductChecked[]']:checked").each(function () {
                    $('#divContractsToRollover').removeAttr('hidden');
                })

            });
            $('.editMode').click(function () {
                if ($(this).attr('class') == 'saveMode') {
                    console.log($(this).attr('class'));
                    console.log('save mdoe');
                    OnSaveFunctionality(this);
                }
                else if ($(this).attr('class') == 'editMode') {
                    console.log($(this).attr('class'));
                    console.log('edit mode');
                    OnEditFunctionality(this);
                }
            })

            $('.deleteMode').click(function () {
                if ($(this).attr('class') == 'deleteMode') {
                    console.log($(this).attr('class'));
                    console.log('normal delete mode');
                    //OnSaveFunctionality(this);
                }
                else if ($(this).attr('class') == 'cancelMode') {
                    console.log($(this).attr('class'));
                    console.log('cancel mode');
                    OnCancelFunctionality(this);
                }
            })
        },
        error: function (error) {
            alert(error.status + "<--and--> " + error.statusText);
        }
    });
}
var xyz = null;
function BindData(maindata) {
    ActualDataBinding(maindata)
    console.log('998');

}


var ActualDataBinding = function (maindata) {
    var self = this;
    //temp variables
    self.EmpDetails_temp;
    self.VehDetails_temp;

    //Getting default customer details - Id = 1
    var jsonobj = JSON.parse(maindata.data)
    console.log("json data");
    console.log(jsonobj);
    //var jsonobj = eval("(" + maindata + ")");

    CustViewModel.FirstName(jsonobj["FirstName"]);
    CustViewModel.LastName(jsonobj["LastName"]);
    CustViewModel.IdNumber(jsonobj["IdNumber"]);
    CustViewModel.Title(jsonobj["Title"]);
    CustViewModel.PreferredName(jsonobj["PreferredName"]);
    CustViewModel.PreferredLanguage(jsonobj["PreferredLanguage"]);
    CustViewModel.Gender(jsonobj["Gender"]);
    CustViewModel.NoOfDependents(jsonobj["NoOfDependents"]);
    CustViewModel.MaritalStatus(jsonobj["MaritalStatus"]);
    CustViewModel.Citizenship(jsonobj["Citizenship"]);
    CustViewModel.DateOfBirth(jsonobj["DateOfBirth"]);
    CustViewModel.WorkPermitExpiry(jsonobj["WorkPermitExpiry"]);
    CustViewModel.PhoneDetails(jsonobj["PhoneDetails"]);
    CustViewModel.BankingDetails(jsonobj["BankingDetails"]);
    CustViewModel.AddressDetails(jsonobj["AddressDetails"]);
    CustViewModel.EmploymentDetails(jsonobj["CustomerEmploymentDetails"]);
    self.EmpDetails_temp = jsonobj["CustomerEmploymentDetails"];
    CustViewModel.VehicleDetails(jsonobj["CustomerVehicleInformation"]);
    self.VehDetails_temp = jsonobj["CustomerVehicleInformation"];
    CustViewModel.CustomerIncomeAndExpenses = jsonobj["CustomerIncomeAndExpenses"];
    CustViewModel.ProductsForCustomer = jsonobj["ProductsForCustomer"];
    CustViewModel.CustomerRollovers = jsonobj["CustomerRollovers"];

    var firstEmpLoad = true;
    var firstVehLoad = true;
    CustViewModel.filterEmpDetails = function (employerName) {
        if (self.EmpDetails_temp) {
            for (var i = 0; i < self.EmpDetails_temp.length; i++) {
                var tempNmamame = self.EmpDetails_temp[i].EmployerName;
                if (self.EmpDetails_temp[i].EmployerName == employerName) {
                    CustViewModel.SelectedEmployeeDetails(self.EmpDetails_temp[i]);
                }
            }
            if (firstEmpLoad == true) {
                CustViewModel.SelectedEmployeeDetails(self.EmpDetails_temp[0]);
                firstEmpLoad = false
            }
        }
    }

    CustViewModel.filterVehicleDetails = function (invoiceNumber) {
        if (self.VehDetails_temp) {
            for (var i = 0; i < self.VehDetails_temp.length; i++) {
                var tempNmamame = self.VehDetails_temp[i].VehicleInvoiceNumber;
                if (self.VehDetails_temp[i].VehicleInvoiceNumber == invoiceNumber) {
                    CustViewModel.SelectedVehicleDetails(self.VehDetails_temp[i]);
                }
            }
            if (firstVehLoad == true) {
                CustViewModel.SelectedVehicleDetails(self.VehDetails_temp[0]);
                firstVehLoad = false
            }
        }
    }
    //for the very first time load assigning default values
    //if (self.VehDetails_temp) {
    //    self.filterVehicleDetails(self.VehDetails_temp[0].VehicleInvoiceNumber);
    //}
    //self.filterEmpDetails(self.EmpDetails_temp[0].EmployerName);
    ko.applyBindings(CustViewModel);
}

$('#btnSaveAndClose').click(function () {
    var finalCustomerDetails = ko.toJS(CustViewModel);
    var test = "test";
    console.log(JSON.stringify(finalCustomerDetails));

    var deploymentUrlPrefix = "http://41.185.29.146/KeConcepts/Dispatcher/";
    var developmentUrlPrefix = "http://localhost/Ke.CreditEase.Dispatcher/";
    $.ajax({
        type: "Post",
        url: developmentUrlPrefix.concat("Basicinformation?id=1&customerdetails=" + JSON.stringify(finalCustomerDetails)),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: { content: "abc" },
        success: function (maindata) {
            console.log(maindata)
        },
        error: function (error) {
            console.log("------------From error --------------");
            console.log(error);
        }
    });
})

function OnEditFunctionality(currentControl) {
    $(currentControl).addClass('saveMode');
    $(currentControl).removeClass('editMode');
    var currentRow = $(currentControl).parents("tr:first");
    var columns = $(currentRow).find('td');
    $(columns).each(function (index, item) {
        if ($(item).find('a').length == 1) {
            var currentButton = $(item).find('a');
            var currentSpan = $(item).find('span');
            var currentLabelText = $(currentSpan[0]).text();
            if (currentLabelText == "Edit") {
                $(currentSpan[0]).text('Save')
            }
            else if (currentLabelText == "Delete") {
                $(currentSpan[0]).text('Cancel')
                $(currentButton).removeClass('deleteMode');
                $(currentButton).addClass('cancelMode');
            }
        }
        if ($(item).find('a').length == 0) {
            $(item).attr('contenteditable', 'true');
            $(item).addClass('border-cell');
        }
    })
}
function OnSaveFunctionality(currentControl) {
    $(currentControl).addClass('editMode');
    $(currentControl).removeClass('saveMode');
    var currentRow = $(currentControl).parents("tr:first");
    var columns = $(currentRow).find('td');
    $(columns).each(function (index, item) {
        if ($(item).find('a').length == 1) {
            var currentButton = $(item).find('a');
            var currentSpan = $(item).find('span');
            var currentLabelText = $(currentSpan[0]).text();
            if (currentLabelText == "Save") {
                $(currentSpan[0]).text('Edit')
            }
            else if (currentLabelText == "Cancel") {
                $(currentSpan[0]).text('Delete')
                $(currentButton).removeClass('cancelMode');
                $(currentButton).addClass('deleteMode');
            }
        }
        if ($(item).find('a').length == 0) {
            $(item).attr('contenteditable', 'false');
            $(item).removeClass('border-cell');
        }
    })
}

function OnCancelFunctionality(currentControl) {
    $(currentControl).removeClass('cancelMode');
    $(currentControl).addClass('deleteMode');
    var currentRow = $(currentControl).parents("tr:first");
    var columns = $(currentRow).find('td');
    $(columns).each(function (index, item) {
        if ($(item).find('a').length == 1) {
            var currentButton = $(item).find('a');
            var currentSpan = $(item).find('span');
            var currentLabelText = $(currentSpan[0]).text();
            if (currentLabelText == "Save") {
                $(currentSpan[0]).text('Edit')
                $(currentButton).addClass('editMode');
                $(currentButton).removeClass('saveMode');
            }
            else if (currentLabelText == "Cancel") {
                $(currentSpan[0]).text('Delete')
                $(currentButton).removeClass('cancelMode');
                $(currentButton).addClass('deleteMode');
            }
        }
        if ($(item).find('a').length == 0) {
            $(item).attr('contenteditable', 'false');
            $(item).removeClass('border-cell');
        }
    })
}