

var userinputs = (ID) => {

    require(['text!' + ComponentsPath + 'user-inputs/user-inputs.html']);
    require(['css!' + ComponentsPath + 'user-inputs/user-inputs.css']);

    proto.Directors = [{ DrectorNo: 0, Name: "", Surname: "", Email: "", Cell: "", IDNumber: "", PhysicalAddress: "", PostalAddress: "" },
    { DrectorNo: 0, Name: "", Surname: "", Cell: "", Email: "", IDNumber: "", PhysicalAddress: "", PostalAddress: "" },
    { DrectorNo: 0, Name: "", Surname: "", Cell: "", Email: "", IDNumber: "", PhysicalAddress: "", PostalAddress: "" },
    { DrectorNo: 0, Name: "", Surname: "", Cell: "", Email: "", IDNumber: "", PhysicalAddress: "", PostalAddress: "" },
    { DrectorNo: 0, Name: "", Surname: "", Cell: "", Email: "", IDNumber: "", PhysicalAddress: "", PostalAddress: "" }
    ];
    proto.CompanyDetails = [{ Name1: "", Name2: "", Name3: "", Name4: "", EmailAddress: "", URL: "", PhysicalAddress: "", PostalAddress: "" }];
    proto.ProductsSelected = [{ CompanyRegistration: true, Taxclearancecertificate: false, logo: false, Letterhead: false, Businesscard: false, Businessprofile: false, website: false }];
    proto.Products = [{ Name: 'CompanyRegistration', Price: 800.00 },
    { Name: 'Taxclearancecertificate', Price: 600.00 },
    { Name: 'logo', Price: 800.00 },
    { Name: 'Letterhead', Price: 800.00 },
    { Name: 'Businesscard', Price: 850.00 },
    { Name: 'Businessprofile', Price: 1800.00 },
    { Name: 'website', Price: 4500.00 }]
    var data = new FormData();

    var ViewModel = function () {
        gproducts.data[ID].object = this;
        this.userinputs = ko.observable();
        //binding visibility of forms 
        this.showDirectorOne = ko.observable(false);
        this.showDirectorTwo = ko.observable(true);
        this.showDirectorThree = ko.observable(true);
        this.showDirectorFour = ko.observable(true);
        this.showDirectorFive = ko.observable(true);
        this.showCompnayDetails = ko.observable(true);
        this.showProductSelection = ko.observable(true);
        this.showApproval = ko.observable(true);
        //binding visibility of forms 

        //First director data
        this.DirectorOneName = ko.observable();
        this.DirectorOneSurname = ko.observable();
        this.DirectorOneCell = ko.observable();
        this.DirectorOneEmail = ko.observable();
        this.DirectorOneIDNumber = ko.observable();
        this.DirectorOnePhysicalAddress = ko.observable();
        this.DirectorOnePostalAddress = ko.observable();
        this.DirectorOneID = ko.observable();
        this.fileuploadOneID = () => {
            var object = gproducts.data[ID].object;
            var files = $("#fileuploadOneID").get(0).files;
            data.append("file1", files[0]);

            object.DirectorOneID(data);
        }
        //First director data

        //2nd director data
        this.DirectorTwoName = ko.observable();
        this.DirectorTwoSurname = ko.observable();
        this.DirectorTwoCell = ko.observable();
        this.DirectorTwoEmail = ko.observable();
        this.DirectorTwoIDNumber = ko.observable();
        this.DirectorTwoPhysicalAddress = ko.observable();
        this.DirectorTwoPostalAddress = ko.observable();
        this.DirectorTwoID = ko.observable();
        this.fileuploadTwoID = () => {
            var object = gproducts.data[ID].object;
            var files = $("#fileuploadOneID").get(0).files;
            data.append("file2", files[0]);

            object.DirectorTwoID(data);
        }
        //2nd director data

        //3rd director data
        this.DirectorThreeName = ko.observable();
        this.DirectorThreeSurname = ko.observable();
        this.DirectorThreeCell = ko.observable();
        this.DirectorThreeEmail = ko.observable();
        this.DirectorThreeIDNumber = ko.observable();
        this.DirectorThreePhysicalAddress = ko.observable();
        this.DirectorThreePostalAddress = ko.observable();
        this.DirectorThreeID = ko.observable();
        this.fileuploadThreeID = () => {
            var object = gproducts.data[ID].object;
            var files = $("#fileuploadOneID").get(0).files;
            data.append("file3", files[0]);

            object.DirectorThreeID(data);
        }
        //3rd director data

        //4th director data
        this.DirectorFourName = ko.observable();
        this.DirectorFourSurname = ko.observable();
        this.DirectorFourCell = ko.observable();
        this.DirectorFourEmail = ko.observable();
        this.DirectorFourIDNumber = ko.observable();
        this.DirectorFourPhysicalAddress = ko.observable();
        this.DirectorFourPostalAddress = ko.observable();
        this.DirectorFourID = ko.observable();
        this.fileuploadFourID = () => {
            var object = gproducts.data[ID].object;
            var files = $("#fileuploadOneID").get(0).files;
            data.append("file4", files[0]);

            object.DirectorFourID(data);
        }
        //4th director data

        //5th director data
        this.DirectorFiveName = ko.observable();
        this.DirectorFiveSurname = ko.observable();
        this.DirectorFiveCell = ko.observable();
        this.DirectorFiveEmail = ko.observable();
        this.DirectorFiveIDNumber = ko.observable();
        this.DirectorFivePhysicalAddress = ko.observable();
        this.DirectorFivePostalAddress = ko.observable();
        this.DirectorFiveID = ko.observable();
        this.fileuploadFiveID = () => {
            var object = gproducts.data[ID].object;
            var files = $("#fileuploadOneID").get(0).files;
            data.append("file5", files[0]);

            object.DirectorFiveID(data);
        }
        //5th director data
        //company details
        this.CompanyNameOne = ko.observable();
        this.CompanyNameTwo = ko.observable();
        this.CompanyNameThree = ko.observable();
        this.CompanyNameFour = ko.observable();
        this.CompanyEmail = ko.observable();
        this.URL = ko.observable('http://');
        this.CompanyPhysicalAddress = ko.observable();
        this.CompanyPostalAddress = ko.observable();
        //company details


        //bind Finals before check out
        this.CompanyRegistrationTotal = ko.observable();
        //bind Finals before check out

        //binding click events 
        this.BackDirector = () => {
            var object = gproducts.data[ID].object;
            if (Directors[4].DrectorNo === 5) {
                object.showCompnayDetails(true);
                object.showDirectorFive(false);
            } else if (Directors[3].DrectorNo === 4) {
                object.showCompnayDetails(true);
                object.showDirectorFour(false);
            } else if (Directors[2].DrectorNo === 3) {
                object.showCompnayDetails(true);
                object.showDirectorThree(false);
            } else if (Directors[1].DrectorNo === 2) {
                object.showCompnayDetails(true);
                object.showDirectorTwo(false);
            } else if (Directors[0].DrectorNo === 1) {
                object.showCompnayDetails(true);
                object.showDirectorOne(false);
            }
        }
        this.Continue = () => {
            var object = gproducts.data[ID].object;
            formValidation();
            if (!object.showDirectorOne()) {

                var form = $('#DirectorOne');
                form.removeAttr('novalidate');
                $.validator.unobtrusive.parse(form);

                if (form.valid()) {
                    Directors[0].DrectorNo = 1;
                    Directors[0].Name = object.DirectorOneName();
                    Directors[0].Surname = object.DirectorOneSurname();
                    Directors[0].Email = object.DirectorOneEmail();
                    Directors[0].Cell = object.DirectorOneCell();
                    Directors[0].IDNumber = object.DirectorOneIDNumber();
                    Directors[0].PhysicalAddress = object.DirectorOnePhysicalAddress();
                    Directors[0].PostalAddress = object.DirectorOnePostalAddress();
                    object.showCompnayDetails(false);
                    object.showDirectorOne(true);
                }
            }
            else if (!object.showDirectorTwo()) {
                var form = $('#DirectorTwo');
                form.removeAttr('novalidate');
                $.validator.unobtrusive.parse(form);

                if (form.valid()) {
                    Directors[1].DrectorNo = 2;
                    Directors[1].Name = object.DirectorTwoName();
                    Directors[1].Surname = object.DirectorTwoSurname();
                    Directors[1].Email = object.DirectorTwoEmail();
                    Directors[1].Cell = object.DirectorTwoCell();
                    Directors[1].IDNumber = object.DirectorTwoIDNumber();
                    Directors[1].PhysicalAddress = object.DirectorTwoPhysicalAddress();
                    Directors[1].PostalAddress = object.DirectorTwoPostalAddress();
                    object.showCompnayDetails(false);
                    object.showDirectorTwo(true);
                }
            }
            else if (!object.showDirectorThree()) {
                var form = $('#DirectorThree');
                form.removeAttr('novalidate');
                $.validator.unobtrusive.parse(form);

                if (form.valid()) {
                    Directors[2].DrectorNo = 3;
                    Directors[2].Name = object.DirectorThreeName();
                    Directors[2].Surname = object.DirectorThreeSurname();
                    Directors[2].Cell = object.DirectorThreeCell();
                    Directors[2].Email = object.DirectorThreeEmail();
                    Directors[2].IDNumber = object.DirectorThreeIDNumber();
                    Directors[2].PhysicalAddress = object.DirectorThreePhysicalAddress();
                    Directors[2].PostalAddress = object.DirectorThreePostalAddress();

                    object.showCompnayDetails(false);
                    object.showDirectorThree(true);
                }
            }
            else if (!object.showDirectorFour()) {
                var form = $('#DirectorFour');
                form.removeAttr('novalidate');
                $.validator.unobtrusive.parse(form);

                if (form.valid()) {
                    Directors[3].DrectorNo = 4;
                    Directors[3].Name = object.DirectorFourName();
                    Directors[3].Surname = object.DirectorFourSurname();
                    Directors[3].Cell = object.DirectorFourCell();
                    Directors[3].Email = object.DirectorFourEmail();
                    Directors[3].IDNumber = object.DirectorFourIDNumber();
                    Directors[3].PhysicalAddress = object.DirectorFourPhysicalAddress();
                    Directors[3].PostalAddress = object.DirectorFourPostalAddress();
                    object.showCompnayDetails(false);
                    object.showDirectorFour(true);
                }
            }
            else if (!object.showDirectorFive()) {
                var form = $('#DirectorFive');
                form.removeAttr('novalidate');
                $.validator.unobtrusive.parse(form);

                if (form.valid()) {
                    Directors[4].DrectorNo = 5;
                    Directors[4].Name = object.DirectorFiveName();
                    Directors[4].Surname = object.DirectorFiveSurname();
                    Directors[4].Cell = object.DirectorFiveCell();
                    Directors[4].Email = object.DirectorFiveEmail();
                    Directors[4].IDNumber = object.DirectorFiveIDNumber();
                    Directors[4].PhysicalAddress = object.DirectorFivePhysicalAddress();
                    Directors[4].PostalAddress = object.DirectorFivePostalAddress();

                    object.showCompnayDetails(false);
                    object.showDirectorFive(true);
                }
            }
            else if (!object.showCompnayDetails()) {
                var form = $('#CompnayDetails');
                form.removeAttr('novalidate');
                $.validator.unobtrusive.parse(form);

                if (form.valid()) {
                    CompanyDetails[0].Name1 = object.CompanyNameOne();
                    CompanyDetails[0].Name2 = object.CompanyNameTwo();
                    CompanyDetails[0].Name3 = object.CompanyNameThree();
                    CompanyDetails[0].Name4 = object.CompanyNameFour();
                    CompanyDetails[0].EmailAddress = object.CompanyEmail();
                    CompanyDetails[0].URL = object.URL();
                    CompanyDetails[0].PhysicalAddress = object.CompanyPhysicalAddress();
                    CompanyDetails[0].PostalAddress = object.CompanyPostalAddress();

                    object.showProductSelection(false);
                    object.showCompnayDetails(true);
                }
            }
            else if (!object.showProductSelection()) {
                object.showApproval(false);
                object.showProductSelection(true);
            }
            else if (!object.showApproval()) {

            }

        }
        this.BackCompanyDetails = () => {
            var object = gproducts.data[ID].object;
            object.showProductSelection(true);
            object.showCompnayDetails(false);
        }
        this.CheckOut = () => {


            $('#gComfirmation').modal({ "show": true, "backdrop": "static", "keyboard": false });
        }
        this.AddAnotherDirector = () => {

            formValidation();
            var object = gproducts.data[ID].object;
            if (!object.showDirectorOne()) {
                var form = $('#DirectorOne');
                form.removeAttr('novalidate');
                $.validator.unobtrusive.parse(form);

                if (form.valid()) {
                    Directors[0].DrectorNo = 1;
                    Directors[0].Name = object.DirectorOneName();
                    Directors[0].Surname = object.DirectorOneSurname();
                    Directors[0].Cell = object.DirectorOneCell();
                    Directors[0].Email = object.DirectorOneEmail();
                    Directors[0].IDNumber = object.DirectorOneIDNumber();
                    Directors[0].PhysicalAddress = object.DirectorOnePhysicalAddress();
                    Directors[0].PostalAddress = object.DirectorOnePostalAddress();
                    object.showDirectorTwo(false);
                    object.showDirectorOne(true);
                }
            }
            else if (!object.showDirectorTwo()) {
                var form = $('#DirectorTwo');
                form.removeAttr('novalidate');
                $.validator.unobtrusive.parse(form);

                if (form.valid()) {
                    Directors[1].DrectorNo = 2;
                    Directors[1].Name = object.DirectorTwoName();
                    Directors[1].Surname = object.DirectorTwoSurname();
                    Directors[1].Cell = object.DirectorTwoCell();
                    Directors[1].Email = object.DirectorTwoEmail();
                    Directors[1].IDNumber = object.DirectorTwoIDNumber();
                    Directors[1].PhysicalAddress = object.DirectorTwoPhysicalAddress();
                    Directors[1].PostalAddress = object.DirectorTwoPostalAddress();
                    object.showDirectorThree(false);
                    object.showDirectorTwo(true);
                }
            }
            else if (!object.showDirectorThree()) {
                var form = $('#DirectorThree');
                form.removeAttr('novalidate');
                $.validator.unobtrusive.parse(form);

                if (form.valid()) {
                    Directors[2].DrectorNo = 3;
                    Directors[2].Name = object.DirectorThreeName();
                    Directors[2].Surname = object.DirectorThreeSurname();
                    Directors[2].Cell = object.DirectorThreeCell();
                    Directors[2].Email = object.DirectorThreeEmail();
                    Directors[2].IDNumber = object.DirectorThreeIDNumber();
                    Directors[2].PhysicalAddress = object.DirectorThreePhysicalAddress();
                    Directors[2].PostalAddress = object.DirectorThreePostalAddress();
                    object.showDirectorFour(false);
                    object.showDirectorThree(true);
                }
            }
            else if (!object.showDirectorFour()) {
                var form = $('#DirectorFour');
                form.removeAttr('novalidate');
                $.validator.unobtrusive.parse(form);

                if (form.valid()) {
                    Directors[3].DrectorNo = 4;
                    Directors[3].Name = object.DirectorFourName();
                    Directors[3].Surname = object.DirectorFourSurname();
                    Directors[3].Cell = object.DirectorFourCell();
                    Directors[3].Email = object.DirectorFourEmail();
                    Directors[3].IDNumber = object.DirectorFourIDNumber();
                    Directors[3].PhysicalAddress = object.DirectorFourPhysicalAddress();
                    Directors[3].PostalAddress = object.DirectorFourPostalAddress();
                    object.showDirectorFive(false);
                    object.showDirectorFour(true);
                }
            }

        }

        this.OK = () => {

            for (var i = 0; i < Directors.length; i++) {
                if (Directors[i].DrectorNo === 0) {
                    Directors.splice(i);
                }
            }
            var Application = {};
            Application.Directors = Directors;
            Application.CompanyDetails = CompanyDetails;
            Application.ProductsSelected = ProductsSelected;
            Application.Products = Products;
            data.append("ApplicantData", JSON.stringify(Application));

            var Url = "/SubmitForm.ashx";
            //var Url = webUrl.concat("SubmitForm.ashx");
            jQuery.ajax({
                type: 'POST',
                url: Url,
                data: data,
                contentType: false,
                processData: false,
                success: (data) => {
                    $('#gComfirmation').modal('hide');
                    $('#gHappy').modal({ "show": true, "backdrop": "static", "keyboard": false });
                 
                }
            });
        };


        this.Done = () => {
            $('#gHappy').modal('hide')
            window.location.reload(true);
        }
        //binding click events 

        //checkboxes
        this.Taxclearancecertificate = ko.observable();
        this.logo = ko.observable();
        this.Letterhead = ko.observable();
        this.Businesscard = ko.observable();
        this.Businessprofile = ko.observable();
        this.website = ko.observable();
        //checkboxes


        //bind computed value
        this.CompanyRegistrationTotal = ko.computed(() => {
            return 800;
        });

        this.information = ko.computed(() => {
            if (!gproducts.data[ID].object.showCompnayDetails()) {
                proto.home.header1('COMPANY DETAILS');
                proto.home.msg1('Please make sure to capture all required information');
            } else if (!gproducts.data[ID].object.showProductSelection()) {
                proto.home.header1('INVOICE/QUOTE');
                proto.home.msg1('You may build your package before checking out...');
                proto.home.TIP('Please note that all work requested will only resume after a deposit has been made into our banking details as displayed.');
            }
            else {
                proto.home.header1('DIRECTOR DETAILS');
                proto.home.msg1('Please make sure to capture all required information');
            }


        })


        this.GrandTotal = ko.computed(() => {
            var object = gproducts.data[ID].object;
            var subTotal = 800;

            if (object.Taxclearancecertificate()) {
                ProductsSelected[0].Taxclearancecertificate = true;
                subTotal = subTotal + 600;
            } else {
                ProductsSelected[0].Taxclearancecertificate = false;
            }

            if (object.logo()) {
                ProductsSelected[0].logo = true;
                subTotal = subTotal + 800;
            } else {
                ProductsSelected[0].logo = false;
            }

            if (object.Letterhead()) {
                ProductsSelected[0].Letterhead = true;
                subTotal = subTotal + 800;
            } else {
                ProductsSelected[0].Letterhead = false;
            }

            if (object.Businesscard()) {
                ProductsSelected[0].Businesscard = true;
                subTotal = subTotal + 850;
            } else {
                ProductsSelected[0].Businesscard = false;
            }
            if (object.Businessprofile()) {
                ProductsSelected[0].Businessprofile = true;
                subTotal = subTotal + 1800;
            } else {
                ProductsSelected[0].Businessprofile = false;
            }
            if (object.website()) {
                ProductsSelected[0].website = true;
                subTotal = subTotal + 4500;
            } else {
                ProductsSelected[0].website = false;
            }

            return subTotal;
        });
        //bind computed value

        populateVariables(this);

    }

    var populateVariables = (object) => {

        formValidation();
    };
    var userinputsViewModel = new ViewModel();
    var populateTemplate = () => {
        ko.cleanNode($('#user-inputs')[0]);
        ko.applyBindings(userinputsViewModel, $('#user-inputs')[0]);
    };


    var init = () => {
        if (ko.components.isRegistered('user-inputs')) {
            ko.components.unregister('user-inputs');
            ko.cleanNode($('user-inputs')[0]);
            // Remove any child elements from node
            while (('user-inputs').firstChild) {
                ('user-inputs').removeChild(element.firstChild);
            }
        }

        ko.components.register('user-inputs', {
            viewModel: { instance: userinputsViewModel },
            template: {
                require: 'text!' + ComponentsPath + 'user-inputs/user-inputs.html'
            }
        });

        populateTemplate();



    };

    return init();


}